Imports SMARTtBR_DA
Imports SMARTtBR_BO
Imports SMARTtBR_BL.CommonBL
Imports SMARTtBR_CO.CommonClass
Public Class DepartmentBL
    Private M_DepID As Integer

    Public Function Save_Data(ByVal M_Department As DepartmentBO, ByVal M_EntryMode As String, ByVal M_MenuID As Integer) As Integer
        Try

            Dim M_DepartmentDA As New DepartmentDA
            Dim UserTime As String
            If CheckUserRight(M_EntryMode, M_Department.MakerID, M_MenuID) = True Then
                UserTime = Get_UserTime()
                M_DepID = M_DepartmentDA.Save_Data(M_Department, M_EntryMode, M_MenuID, UserTime)
                M_DepartmentDA = Nothing
                Return M_DepID
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function Locate_Data(ByVal M_DepID As Integer) As DepartmentBO
        Try

            Dim M_DepartmentDA As New DepartmentDA
            Return M_DepartmentDA.Locate_Data(M_DepID)
            M_DepartmentDA = Nothing

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_Grid(ByVal M_Object As Object) As Boolean
        Try
            Dim M_DataTable As DataTable
            Dim M_DepartmentDA As New DepartmentDA
            M_DataTable = M_DepartmentDA.Fill_Grid()
            M_Object.DataSource = M_DataTable
            M_DepartmentDA = Nothing
            Return False
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function Check_DepartmentNameExists(ByVal DepName As String, Optional ByVal M_DepID As Integer = 0) As Boolean

        Try
            Dim M_Return As Boolean
            Dim M_DepartmentDA As New DepartmentDA
            M_Return = M_DepartmentDA.Check_DepartmentNameExists(DepName, M_DepID)
            M_DepartmentDA = Nothing
            Return M_Return

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
