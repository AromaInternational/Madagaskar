Imports SMARTtBR_DA
Imports SMARTtBR_BO
Imports SMARTtBR_BL.CommonBL
Imports SMARTtBR_CO.CommonClass
Public Class UserRightsBL
    Private M_UserID As Integer

    Public Function Save_Data(ByVal M_UserRights As UserRightsBO, ByVal M_RightsSw As String, ByVal M_EntryMode As String, ByVal M_MenuID As Integer) As Integer
        Dim M_UserRightsDA As New UserRightsDA
        Dim UserTime As String
        Dim M_Result As Long = 0
        Try
            If CheckUserRight(M_EntryMode, M_UserRights.MakerID, M_MenuID) = True Then
                UserTime = Get_UserTime()
                M_Result = M_UserRightsDA.Save_Data(M_UserRights, M_RightsSw, M_EntryMode, M_MenuID, UserTime)
                M_UserRightsDA = Nothing
                Return M_Result
            Else
                Return M_Result
            End If
        Catch ex As Exception
            Return M_Result
        End Try
    End Function

    Public Function Locate_Data(ByVal M_UserID As Integer) As UserRightsBO
        Try

            Dim M_UserRightsDA As New UserRightsDA
            Return M_UserRightsDA.Locate_Data(M_UserID)
            M_UserRightsDA = Nothing

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_UserRightGrid(ByVal UserID As Integer, ByVal UserType As Integer, ByVal MakerID As Integer) As DataTable

        Try
            Dim M_DataTable As DataTable
            Dim M_UserRightsDA As New UserRightsDA
            M_DataTable = M_UserRightsDA.Fill_UserRightGrid(UserID, UserType, MakerID)
            M_UserRightsDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

End Class
