Imports SMARTtBR_DA
Imports SMARTtBR_BO
Imports SMARTtBR_BL.CommonBL
Imports SMARTtBR_CO.CommonClass
Public Class ClientMasterBL
    Private M_CMID As Integer

    Public Function Save_Data(ByVal M_Client As ClientMasterBO, ByVal M_EntryMode As String, ByVal Menu_ID As Integer) As Integer
        Try

            Dim M_ClientMasterDA As New ClientMasterDA
            Dim UserTime As String
            If CheckUserRight(M_EntryMode, User_ID, Menu_ID) = True Then
                UserTime = Get_UserTime()
                M_CMID = M_ClientMasterDA.Save_Data(M_Client, M_EntryMode, UserTime)
                M_ClientMasterDA = Nothing
                Return M_CMID
            Else
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function Locate_Data(ByVal M_CmpCode As Integer, ByVal M_CMID As String, Optional ByVal CMPhoneNo As String = "", Optional ByVal M_TypeID As Integer = 0) As ClientMasterBO
        Try
            Dim M_ClientMasterDA As New ClientMasterDA
            Return M_ClientMasterDA.Locate_Data(M_CmpCode, M_CMID, CMPhoneNo, M_TypeID)
            M_ClientMasterDA = Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
