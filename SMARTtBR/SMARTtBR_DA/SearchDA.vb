Imports SMARTtBR_DAL
Public Class SearchDA

    Private M_DBConn As Connection

    Public Function ExecuteQuery(ByRef M_DgvSearch As Object, ByVal M_Qry As String) As Boolean
        Try

            Dim M_Dt As DataTable = Nothing
            M_DBConn.ExecuteDataTable(M_Dt, M_Qry)
            M_DgvSearch.DataSource = M_Dt

        Catch ex As Exception

        End Try
    End Function

    Public Function ExecuteQuery(ByVal M_Qry As String) As DataTable
        Dim M_Dt As DataTable = Nothing
        Try

            M_DBConn.ExecuteDataTable(M_Dt, M_Qry)
            Return M_Dt

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
