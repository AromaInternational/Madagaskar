Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms

Public Class ServerSelection_Frm

    Private Sub ServerSelection_Frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyChar = Chr(27) Then
            sender.Close()
        End If
    End Sub

    Private Sub ServerSelection_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ServerType = "L" Then
            Me.ActiveControl = Opt_Local
        Else
            Me.ActiveControl = Opt_Public
        End If
    End Sub

    Private Sub Cmd_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Ok.Click
        If Opt_Local.Checked Then
            ServerType = "L"
        Else
            ServerType = "P"
        End If
        Me.Close()
    End Sub
End Class