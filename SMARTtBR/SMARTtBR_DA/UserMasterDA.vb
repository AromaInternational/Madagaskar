Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class UserMasterDA
    Private M_DBConn As Connection
    Private M_UserID As Integer
    Public Function Save_Data(ByVal M_User As UserMasterBO, ByVal M_AllotedUnitSw As String, ByVal M_EntryMode As String, ByVal M_MenuID As Integer, ByVal UserTime As String) As Integer
        Try
            Dim M_Sql As String

            With M_User
                M_Sql = "Exec IUM_UserMaster_Sp "
                M_Sql = M_Sql & "'" & M_EntryMode & "',"
                M_Sql = M_Sql & M_MenuID & ","
                M_Sql = M_Sql & .UMID & ","
                M_Sql = M_Sql & .UMDepID & ","
                M_Sql = M_Sql & .UMDesID & ","
                M_Sql = M_Sql & .UMTypeID & ","
                M_Sql = M_Sql & "'" & .UMName & "',"
                M_Sql = M_Sql & "'" & .UMPwd & "',"
                M_Sql = M_Sql & .UMUNID & ","
                M_Sql = M_Sql & .UMAutoLogOutPeriod & ","
                M_Sql = M_Sql & "'" & .ActiveStatus & "',"
                M_Sql = M_Sql & .MakerID & ","
                M_Sql = M_Sql & "'" & UserTime & "',"
                M_Sql = M_Sql & .UpdaterID & ","
                M_Sql = M_Sql & "'" & IIf(M_EntryMode = "NEW", "01/01/1900", UserTime) & "',"
                M_Sql = M_Sql & "'" & M_AllotedUnitSw & "'"
            End With

            M_UserID = M_DBConn.ExecuteScalar(M_Sql)

            Return M_UserID

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function



    Public Function Locate_Data(ByVal M_UserID As Integer) As UserMasterBO
        Try
            Dim M_Dt As New DataTable
            Dim M_User As New UserMasterBO
            Dim Qry As String
            Qry = "Select * From UserMaster_Vw where UM_ID = " & M_UserID
            M_DBConn.ExecuteDataTable(M_Dt, Qry)
            If M_Dt.Rows.Count > 0 Then
                With M_User
                    .UMID = M_Dt.Rows(0).Item("UM_ID")
                    .UMDepID = M_Dt.Rows(0).Item("UM_DepID")
                    .UMDesID = M_Dt.Rows(0).Item("UM_DesID")
                    .UMTypeID = M_Dt.Rows(0).Item("UM_TypeID")
                    .UMUNID = M_Dt.Rows(0).Item("UM_UNID")
                    .UMAutoLogOutPeriod = M_Dt.Rows(0).Item("UM_AutoLogOutPeriod")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .UpdaterID = M_Dt.Rows(0).Item("Updater_ID")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                    .UMPwd = M_Dt.Rows(0).Item("PWD")
                    .UMDepartment = M_Dt.Rows(0).Item("UM_Department")
                    .UMDesignation = M_Dt.Rows(0).Item("UM_Designation")
                    .UMName = M_Dt.Rows(0).Item("UM_Name")
                    .UMUnit = M_Dt.Rows(0).Item("UM_Unit")
                    .ActiveStatus = M_Dt.Rows(0).Item("Active_Status")
                End With
            End If
            Return M_User
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Locate_DataWithName(ByVal M_UserName As String) As UserMasterBO
        Try
            Dim M_Dt As New DataTable
            Dim M_User As New UserMasterBO
            Dim Qry As String
            Qry = "Select * From UserMaster_Vw where UM_Name = '" & M_UserName & "'"

            M_DBConn.ExecuteDataTable(M_Dt, Qry)
            With M_User
                If M_Dt.Rows.Count > 0 Then
                    .UMID = M_Dt.Rows(0).Item("UM_ID")
                    .UMDepID = M_Dt.Rows(0).Item("UM_DepID")
                    .UMDesID = M_Dt.Rows(0).Item("UM_DesID")
                    .UMTypeID = M_Dt.Rows(0).Item("UM_TypeID")
                    .UMUNID = M_Dt.Rows(0).Item("UM_UNID")
                    .UMAutoLogOutPeriod = M_Dt.Rows(0).Item("UM_AutoLogOutPeriod")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .UpdaterID = M_Dt.Rows(0).Item("Updater_ID")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                    .UMPwd = M_Dt.Rows(0).Item("PWD")
                    .UMDepartment = M_Dt.Rows(0).Item("UM_Department")
                    .UMDesignation = M_Dt.Rows(0).Item("UM_Designation")
                    .UMName = M_Dt.Rows(0).Item("UM_Name")
                    .UMUnit = M_Dt.Rows(0).Item("UM_Unit")
                    .ActiveStatus = M_Dt.Rows(0).Item("Active_Status")
                Else
                    .UMID = 0
                    .UMDepID = 0
                    .UMDesID = 0
                    .UMTypeID = 0
                    .UMUNID = 0
                    .UMAutoLogOutPeriod = 0
                    .MakerID = 0
                    .UMPwd = ""
                    .UMDepartment = ""
                    .UMDesignation = ""
                    .UMName = ""
                    .UMUnit = ""
                    .ActiveStatus = ""
                End If
            End With
            Return M_User
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Validate_User(ByVal M_ID As Integer, ByVal Password As String) As Boolean
        Dim Qry As String
        Dim M_Dt As New DataTable
        Try
            Qry = " SELECT UM_Name, PWD From UserMaster_Vw WHERE (UM_ID = '" & M_ID & "') "

            M_DBConn.ExecuteDataTable(M_Dt, Qry)
            If M_Dt.Rows.Count > 0 Then
                If M_Dt.Rows(0).Item("PWD") <> Password Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Check_UserNameExists(ByVal UserName As String) As Boolean
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT UM_Name FROM UserMaster_Vw WHERE UM_Name = '" & UserName & "'"
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
        Try
            M_DBConn = New Connection
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Try
            M_DBConn = Nothing
            MyBase.Finalize()
        Catch ex As Exception
        End Try
    End Sub

End Class

