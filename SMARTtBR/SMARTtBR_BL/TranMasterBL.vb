Imports SMARTtBR_DA
Imports SMARTtBR_BO
Imports SMARTtBR_BL.CommonBL
Imports SMARTtBR_CO.CommonClass
Public Class TranMasterBL
    Private M_TranID As Integer

    Public Function Fill_TranGrid(Optional ByVal TranID As Integer = 0) As DataTable

        Try
            Dim M_DataTable As DataTable
            Dim M_TranMasterDA As New TranMasterDA
            M_DataTable = M_TranMasterDA.Fill_TranGrid(TranID)
            M_TranMasterDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function Locate_Data(ByVal M_TranID As Integer) As TranMasterBO        Try            Dim M_TranMasterDA As New TranMasterDA            Return M_TranMasterDA.Locate_Data(M_TranID)            M_TranMasterDA = Nothing        Catch ex As Exception            Return Nothing        End Try    End Function    Public Function Save_Data(ByVal M_TranMaster As TranMasterBO, ByVal M_EntryMode As String, ByVal M_MenuID As Integer, ByVal M_TranSw As String) As Integer        Try            Dim M_TranMasterDA As New TranMasterDA            Dim UserTime As String            If CheckUserRight(M_EntryMode, M_TranMaster.MakerID, M_MenuID) = True Then                UserTime = Get_UserTime()                M_TranID = M_TranMasterDA.Save_Data(M_TranMaster, M_EntryMode, M_MenuID, UserTime, M_TranSw)                M_TranMasterDA = Nothing                Return M_TranID            Else                Return 0            End If        Catch ex As Exception            'MsgBox(ex.Message)            Return False        End Try
    End Function
End Class
