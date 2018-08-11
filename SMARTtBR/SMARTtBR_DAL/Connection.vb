Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.OracleClient
Imports System.Xml
Imports System.Configuration
Imports System.Configuration.ConfigurationManager
Imports System.Reflection
Imports SMARTtBR_CO.CommonClass

Public Class Connection
    Inherits ConnectionType

    Private _mConnection As IDbConnection
    Private _mCommand As IDbCommand
    Private _mAdapter As IDbDataAdapter
    Private _mTransaction As IDbTransaction
    Private _mParameter As IDataParameter
    Private _mRetParameter As IDataParameter
    Private mSQLSource As SQLSource

    Private _mExceptionMsg As String

    Private mSQLResfile As Resources.ResourceManager
    Private mSQLResQuery As String

    Public Enum SQLSource
        RESOURCEFILE
        STOREDPROCEDURE
    End Enum

#Region "SQLConnection"

    Private Function Get_ConnectionString(ByRef sSettingString As String) As String

        Dim M_Result As String = ""
        M_Result = Replace(Replace(sSettingString, "@dmin", "sa"), "A!s@D#f$G%", "Aroma2Aroma")
        Return M_Result

    End Function

    Private Function OpenConnection() As Boolean
        Try
            If ServerType = "P" Then
                If _mConnection Is Nothing Then
                    _mConnection = New SqlConnection(Get_ConnectionString(AppSettings("SQL_CONNSTR_P")))
                End If
                _mCommand = New SqlCommand
                _mParameter = New SqlParameter
                _mRetParameter = New SqlParameter
            Else
                If _mConnection Is Nothing Then
                    _mConnection = New SqlConnection(Get_ConnectionString(AppSettings("SQL_CONNSTR")))
                End If
                _mCommand = New SqlCommand
                _mParameter = New SqlParameter
                _mRetParameter = New SqlParameter
            End If

            _mConnection.Open()
            Return True
        Catch ex As Exception
            _mExceptionMsg = ex.Message()
            Return False
        End Try
    End Function

    Private Sub CloseConnection()
        Try
            If _mConnection.State = ConnectionState.Open Then
                _mConnection.Dispose()
                _mConnection = Nothing
            End If
        Catch ex As Exception
            _mConnection.Dispose()
            _mConnection = Nothing
        End Try
    End Sub

    Public Function GetConnectionString() As String
        Return _mConnection.ConnectionString
    End Function

    Private Sub CreateCommandText(ByVal CommandText As String)
        _mCommand = New SqlCommand(CommandText, _mConnection)
        _mCommand.CommandTimeout = 0
    End Sub

    Private Sub GetCommandType()
        If mSQLSource = SQLSource.STOREDPROCEDURE Then
            _mCommand.CommandType = CommandType.StoredProcedure
        End If
    End Sub

    Private Sub CreateAdapter(ByVal Query As String)
        Dim cn = New SqlConnection()
        Dim cmd = New SqlCommand()
        
        If ServerType = "P" Then
            cn.ConnectionString = Get_ConnectionString(AppSettings("SQL_CONNSTR_P"))
            cn.Open()
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.Text
            cmd.CommandText = Query
            cmd.Connection = cn
            _mAdapter = New SqlDataAdapter(cmd)
            cn.Close()
        Else
            cn.ConnectionString = Get_ConnectionString(AppSettings("SQL_CONNSTR"))
            cn.Open()
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.Text
            cmd.CommandText = Query
            cmd.Connection = cn
            _mAdapter = New SqlDataAdapter(cmd)
            cn.Close()
        End If

    End Sub

    Public Sub BeginTransaction()
        _mTransaction = _mConnection.BeginTransaction
    End Sub

    Private Sub GetCommandTransaction()
        _mCommand.Transaction = _mTransaction
    End Sub

    Public Sub CommitTransaction()
        _mTransaction.Commit()
    End Sub

    Public Sub RollBackTransaction()
        _mTransaction.Rollback()
    End Sub

#End Region

#Region "SQLParameter"
    Public Property GetSQLParameter(ByVal ParamField As String) As Object
        Get
            Return _mCommand.Parameters.Item(ParamField).Value
        End Get
        Set(ByVal value As Object)
            CreateParameter(ParamField, value)
        End Set
    End Property

    Public Property GetSQLReturnParameter(ByVal ParamField As String) As Object
        Get
            Return _mCommand.Parameters.Item(ParamField).Value
        End Get
        Set(ByVal value As Object)
            CreateRetParameter(ParamField, value)

        End Set
    End Property

    Public Sub CreateParameter(ByVal paramField As String, ByVal paramValue As Object)
        _mParameter = New SqlParameter(paramField, paramValue)
        _mCommand.Parameters.Add(_mParameter)
    End Sub

    Public Sub CreateRetParameter(ByVal paramField As String, ByVal paramValue As Object)
        _mRetParameter = New SqlParameter(paramField, paramValue)
        _mCommand.Parameters.Add(_mRetParameter)
        _mRetParameter.Direction = ParameterDirection.ReturnValue
    End Sub
#End Region

#Region "SQLDataExecution"
    Public Function ExecuteDataTable(ByRef DT As DataTable, ByVal QueryName As String) As Integer
        Dim ds As New DataSet
        Dim M_Result As Integer
        Try
            CreateAdapter(QueryName)
            _mAdapter.Fill(ds)
            _mAdapter = Nothing
            If ds.Tables.Count > 0 Then
                DT = ds.Tables(0)
                M_Result = ds.Tables(0).Rows.Count
            Else
                M_Result = 0
            End If

            Return M_Result

        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function ExecuteDataSet(ByRef ds As DataSet, ByVal QueryName As String) As DataSet
        Try
            Dim mds As New DataSet
            CreateAdapter(QueryName)
            _mAdapter.Fill(mds)
            _mAdapter = Nothing
            ds = mds
            Return ds
        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function ExecuteScalar(ByVal QueryName As String) As Object
        Dim M_Result As Object
        Try
            If OpenConnection() Then
                CreateCommandText(QueryName)
                GetCommandType()
                M_Result = _mCommand.ExecuteScalar()
                _mCommand.Dispose()
                _mCommand = Nothing

                CloseConnection()
            Else
                M_Result = Nothing
            End If

            Return M_Result
        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Save_AttachmentsMaster(ByVal M_EntryMode As String, ByVal M_MenuID As Integer, ByVal M_HMID As Long, ByVal M_HMSubject As String, ByVal M_HMParrentType As Integer, _
                                           ByVal M_HMParrentID As Integer, ByVal M_HMPriorityID As Integer, ByVal M_HMImage As Byte(), ByVal M_HMDescription As String, ByVal M_HMOwnerID As Integer, ByVal M_HMStatusID As Integer, _
                                           ByVal M_ActiveStatus As String, ByVal M_MakerID As Integer, ByVal M_MakingTime As String, ByVal M_UpdaterID As Integer, ByVal M_UpdatingTime As String) As Integer
        Dim M_Result As Integer = 0
        Try
            If OpenConnection() Then
                Dim cmd As New SqlCommand()

                cmd.Connection = _mConnection
                cmd.CommandType = CommandType.StoredProcedure

                cmd.CommandText = "IUM_AttachmentsMaster_Sp"
                cmd.Parameters.AddWithValue("@Entry_Mode", M_EntryMode)
                cmd.Parameters.AddWithValue("@MM_ID", M_MenuID)
                cmd.Parameters.AddWithValue("@HM_ID", M_HMID)
                cmd.Parameters.AddWithValue("@HM_Subject", M_HMSubject)
                cmd.Parameters.AddWithValue("@HM_ParrentType", M_HMParrentType)
                cmd.Parameters.AddWithValue("@HM_ParrentID", M_HMParrentID)
                cmd.Parameters.AddWithValue("@HM_PriorityID", M_HMPriorityID)

                Dim M_Param As New SqlParameter("@HM_Image", SqlDbType.Image)
                M_Param.Value = M_HMImage
                cmd.Parameters.Add(M_Param)

                cmd.Parameters.AddWithValue("@HM_Description", M_HMDescription)
                cmd.Parameters.AddWithValue("@HM_OwnerID", M_HMOwnerID)
                cmd.Parameters.AddWithValue("@HM_StatusID", M_HMStatusID)
                cmd.Parameters.AddWithValue("@Active_Status", M_ActiveStatus)
                cmd.Parameters.AddWithValue("@Maker_ID", M_MakerID)
                cmd.Parameters.AddWithValue("@Making_Time", M_MakingTime)
                cmd.Parameters.AddWithValue("@Updater_ID", M_UpdaterID)
                cmd.Parameters.AddWithValue("@Updating_Time", M_UpdatingTime)
                cmd.ExecuteNonQuery()

                M_Result = 1
                cmd.Dispose()
                cmd = Nothing
                CloseConnection()
            Else
                M_Result = 0
            End If

            Return M_Result
        Catch ex As Exception
            Return M_Result
            Throw New ApplicationException(ex.Message)
        End Try

    End Function

#End Region

    Protected Overrides Sub Finalize()
        GC.SuppressFinalize(Me)
        MyBase.Finalize()
    End Sub
End Class
