Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class TranMasterDA
    Private M_DBConn As Connection
    Private M_TranID As Integer

    Public Function Fill_TranGrid(Optional ByVal TranID As Integer = 0) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = "Select * from Transaction_Vw "
            M_Sql = M_Sql & " Where TranID = " & TranID & " Order By TranSeqNo"

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable

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
