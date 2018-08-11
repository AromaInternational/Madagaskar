Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class DepartmentDA
    Private M_DBConn As Connection
    Private M_DepID As Integer
    Public Function Save_Data(ByVal M_Department As DepartmentBO, ByVal M_EntryMode As String, ByVal M_MenuID As Integer, ByVal UserTime As String) As Integer
        Try
            Dim M_Sql As String

            With M_Department
                M_Sql = "Exec IUM_Department_Sp "
                M_Sql = M_Sql & "'" & M_EntryMode & "',"
                M_Sql = M_Sql & M_MenuID & ","
                M_Sql = M_Sql & .DepID & ","
                M_Sql = M_Sql & "'" & .DepName & "',"
                M_Sql = M_Sql & "'" & .ActiveStatus & "',"
                M_Sql = M_Sql & .MakerID & ","
                M_Sql = M_Sql & "'" & UserTime & "',"
                M_Sql = M_Sql & .UpdaterID & ","
                M_Sql = M_Sql & "'" & IIf(M_EntryMode = "NEW", "01/01/1900", UserTime) & "'"
            End With

            M_DepID = M_DBConn.ExecuteScalar(M_Sql)

            Return M_DepID

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function


    Public Function Locate_Data(ByVal M_DepID As String) As DepartmentBO
        Try
            Dim M_Dt As New DataTable
            Dim M_Department As New DepartmentBO
            Dim Qry As String
            Qry = "Select * from Department_P_Tbl where Dep_ID = " & M_DepID
            M_DBConn.ExecuteDataTable(M_Dt, Qry)
            If M_Dt.Rows.Count > 0 Then
                With M_Department
                    .DepID = M_Dt.Rows(0).Item("Dep_ID")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .UpdaterID = M_Dt.Rows(0).Item("Updater_ID")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                    .DepName = M_Dt.Rows(0).Item("Dep_Name")
                    .ActiveStatus = M_Dt.Rows(0).Item("Active_Status")
                End With
            End If
            Return M_Department
        Catch ex As Exception

        End Try
    End Function

    Public Function Fill_Grid() As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT Dep_ID [Dep.ID], Dep_Name [Dep.Name], "
            M_Sql = M_Sql & "Case When Active_Status ='Y' Then 'Active' Else 'DeActive' End As  [Active.Status] "
            M_Sql = M_Sql & "FROM  Department_P_Tbl "
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function Check_DepartmentNameExists(ByVal DepName As String, ByVal M_DepID As Integer) As Boolean
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT Dep_Name FROM Department_P_Tbl WHERE Dep_Name = '" & DepName & "'" & IIf(M_DepID > 0, " And Dep_ID <> " & M_DepID, "")
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
