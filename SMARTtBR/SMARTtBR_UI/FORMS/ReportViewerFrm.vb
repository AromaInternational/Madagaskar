Public Class ReportViewerFrm
    Public Rpt As String
    Public Head As String

    Private Sub ReportViewerFrm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 80 Then
            Me.Text = Rpt
        Else
            Me.Text = Head
        End If
    End Sub
End Class