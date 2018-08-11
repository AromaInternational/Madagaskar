Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class ParaCodeDA
    Private M_DBConn As Connection
    Private M_PCID As Integer
    Public Function Save_Data(ByVal M_ParaCode As ParaCodeBO, ByVal M_EntryMode As String, ByVal M_MenuID As Integer, ByVal UserTime As String) As Integer
        Try
            Dim M_Sql As String

            With M_ParaCode
                M_Sql = "Exec IUM_ParaCode_Sp "
                M_Sql = M_Sql & "'" & M_EntryMode & "',"
                M_Sql = M_Sql & M_MenuID & ","
                M_Sql = M_Sql & .PCID & ","
                M_Sql = M_Sql & "'" & .PCDescription & "',"
                M_Sql = M_Sql & .PCType & ","
                M_Sql = M_Sql & .PCOrder & ","
                M_Sql = M_Sql & "'" & .PCLocked & "',"
                M_Sql = M_Sql & "'" & .ActiveStatus & "',"
                M_Sql = M_Sql & .MakerID & ","
                M_Sql = M_Sql & "'" & UserTime & "',"
                M_Sql = M_Sql & .UpdaterId & ","
                M_Sql = M_Sql & "'" & IIf(M_EntryMode = "NEW", "01/01/1900", UserTime) & "'"
            End With

            M_PCID = M_DBConn.ExecuteScalar(M_Sql)

            Return M_PCID

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function


    Public Function Locate_Data(ByVal M_PCID As Integer) As ParaCodeBO
        Try
            Dim M_Dt As New DataTable
            Dim M_ParaCode As New ParaCodeBO
            Dim Qry As String
            Qry = "Select * from ParaCode_P_Tbl where PC_ID = " & M_PCID
            M_DBConn.ExecuteDataTable(M_Dt, Qry)
            If M_Dt.Rows.Count > 0 Then
                With M_ParaCode
                    .PCID = M_Dt.Rows(0).Item("PC_ID")
                    .PCType = M_Dt.Rows(0).Item("PC_Type")
                    .PCOrder = M_Dt.Rows(0).Item("PC_Order")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .UpdaterId = M_Dt.Rows(0).Item("Updater_Id")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                    .PCDescription = M_Dt.Rows(0).Item("PC_Description")
                    .PCLocked = M_Dt.Rows(0).Item("PC_Locked")
                    .ActiveStatus = M_Dt.Rows(0).Item("Active_Status")
                End With
            End If
            Return M_ParaCode
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_ParamCodeDetails(Optional ByVal M_PCType As Integer = 0, Optional ByVal ActiveStatus As String = "") As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "select  *  from  ParaCode_P_Tbl Where 1=1 "
            If M_PCType <> 0 Then M_Sql = M_Sql & " AND PC_Type =" & M_PCType
            If ActiveStatus <> "" Then M_Sql = M_Sql & " AND Active_Status ='" & ActiveStatus & "' "
            M_Sql = M_Sql & " order by PC_Description "
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_ParamTypeDetails(Optional ByVal ActiveStatus As String = "") As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "select  *  from  ParaType_P_Tbl Where 1=1 "
            If ActiveStatus <> "" Then M_Sql = M_Sql & " AND Active_Status ='" & ActiveStatus & "' "
            M_Sql = M_Sql & " order by PT_Description "
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Check_ParameterNameExists(ByVal ParameterName As String, ByVal ParaType As Integer) As Boolean
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT PC_Description FROM ParaCode_P_Tbl WHERE PC_Description = '" & ParameterName & "'"
            M_Sql = M_Sql & " AND PC_Type=" & ParaType
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            If M_DataTable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function Check_ParameterLocked(ByVal ParamCode As Integer) As Boolean
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT 1 FROM ParaCode_P_Tbl WHERE PC_Locked ='Y' And PC_Id = " & ParamCode
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            If M_DataTable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Sub New()
        M_DBConn = New Connection
    End Sub

End Class
