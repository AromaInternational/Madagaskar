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
End Class
