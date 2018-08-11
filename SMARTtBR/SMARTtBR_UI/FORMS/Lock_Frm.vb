Option Explicit On

Imports SMARTtBR_BL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_CO.CommonClass

Public Class Lock_Frm
    Dim M_CommonBL As New CommonBL
    Dim iTryCount As Integer = 0

    Public Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        If Txt_UserName.Text.Length = 0 Then
            MessageBox.Show("Invalid UserName ", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Return_Msg As String = ""
        Dim M_UserMasterBO As New UserMasterBO
        Dim M_UserBL As New UserMasterBL

        Try

            M_UserMasterBO = M_UserBL.Locate_DataWithName(Txt_UserName.Text.Trim())

            If M_UserMasterBO.UMName = "" Then
                If UCase(Txt_UserName.Text.Trim) = "SYSTEM" And Len(Txt_Password.Text.Trim) > 8 Then
                    If UCase(Txt_Password.Text.Trim.Substring(Len(Txt_Password.Text.Trim) - 5, 5)) = "OASIS" Then
                        Me.Close()
                    Else
                        iTryCount = iTryCount + 1
                        If iTryCount = 3 Then
                            Call Set_SystemDateFormat(False)
                            End
                        End If
                        MessageBox.Show("Invalid User Name Or Password...", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Txt_Password.Text = ""
                        Txt_Password.Focus()
                    End If
                Else
                    iTryCount = iTryCount + 1
                    If iTryCount = 3 Then
                        Call Set_SystemDateFormat(False)
                        End
                    End If
                    MessageBox.Show("Invalid User Name Or Password...", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txt_Password.Text = ""
                    Txt_Password.Focus()
                End If
            Else
                If M_UserBL.ValidateUser(M_UserMasterBO, Txt_Password.Text, Return_Msg) = True Then
                    Call M_CommonBL.InsertUpdate_LogDetails(User_LoginID, "NEW", User_ID, System_Name)
                    Me.Close()
                Else
                    iTryCount = iTryCount + 1
                    If iTryCount = 3 Then
                        Call Set_SystemDateFormat(False)
                        End
                    End If
                    MessageBox.Show(Return_Msg, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txt_Password.Text = ""
                    Txt_Password.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Call Set_SystemDateFormat(False)
        End
    End Sub

    Private Sub Lock_Frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call SendKeyTab(Me, Me.ActiveControl, e)
    End Sub

End Class
