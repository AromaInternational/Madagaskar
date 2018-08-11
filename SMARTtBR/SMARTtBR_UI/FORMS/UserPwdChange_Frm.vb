Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_BL
Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms

Public Class UserPwdChange_Frm

    Dim M_UPID As Long

    Dim M_CommonBL As New CommonBL
    Dim M_EntryMode As String
    Dim M_UserPwdChangeBL As New UserPwdChangeBL


    Private Sub Clear_Controls()
        Try
            Cmd_Save.Enabled = True  ''Enable Save Button
            M_EntryMode = "NEW"
            Txt_CnfrmUPNewPwd.Text = ""
            Txt_UPCurrPwd.Text = ""
            Txt_UPNewPwd.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function ValidateControls() As Boolean

        Dim sMsg As String

        Try
            If Txt_UPCurrPwd.Text.Trim <> User_Password Then
                sMsg = "Current Password Not valid... !"
                Me.ActiveControl = Txt_UPCurrPwd
                GoTo Invalid
            End If

            If Txt_UPNewPwd.Text.Trim <> Txt_CnfrmUPNewPwd.Text.Trim Then
                sMsg = "Check Confirm Password... !"
                Me.ActiveControl = Txt_CnfrmUPNewPwd
                GoTo Invalid
            End If

            Return True
            Exit Function
Invalid:
            If sMsg <> "" Then MsgBox(sMsg, MsgBoxStyle.Critical, "Could not Save")
            Return False
            Exit Function
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub UserPwdChange_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub


    Private Sub UserPwdChange_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Call Clear_Controls()
            Txt_UserName.Text = User_Name
            Me.ActiveControl = Txt_UPCurrPwd

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub


    Private Sub UserPwdChange_Frm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        Call SendKeyTab(Me, Me.ActiveControl, e)

    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click

        Dim M_UserPwdChange As New SMARTtBR_BO.UserPwdChangeBO

        If ValidateControls() = False Then Exit Sub
        Cmd_Save.Enabled = False  ''Disable Save Button

        With M_UserPwdChange
            .UPUMID = User_ID
            .MakerID = User_ID
            .UPID = 0
            .UPCurrPwd = Txt_UPCurrPwd.Text.Trim
            .UPNewPwd = Txt_UPNewPwd.Text.Trim
        End With

        Try
            Dim M_UserPwdChangeBL As New UserPwdChangeBL
            M_UPID = M_UserPwdChangeBL.Save_Data(M_UserPwdChange, M_EntryMode, Me.Tag)
            If M_UPID > 0 Then
                MessageBox.Show("Data Saved... UPID : " & M_UPID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call Clear_Controls()
                M_UserPwdChangeBL = Nothing
            Else
                Cmd_Save.Enabled = True  ''Enable Save Button
            End If
            M_UserPwdChangeBL = Nothing
        Catch ex As Exception
            Cmd_Save.Enabled = True  ''Enable Save Button
        End Try
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call Clear_Controls()
    End Sub
End Class
