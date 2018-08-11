Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_BL
Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms

Public Class AccOpBal_Frm

    Dim M_AccOpId As Long

    Dim M_CommonBL As New CommonBL
    Dim M_EntryMode As String
    Dim M_AccOpBalBL As New AccOpBalBL
    Dim M_DefaultFinYear As String = ""
    Dim M_FinOBDate As Date = Tran_Date
    Dim M_FinStartDate As Date = Tran_Date
    Dim M_AccOpMode As String = "T"
    Private Sub Clear_Controls()
        Try
            M_EntryMode = "NEW"
            Cmd_Save.Enabled = True  ''Enable Save Button
            M_AccOpId = 0
            M_AccOpMode = "T"
            Txt_AccOpId.Text = ""
            Txt_AccCode.Text = ""
            Txt_AccName.Text = ""
            Txt_AccBalance.Text = "0.00"
            Dtp_AccOpDate.Value = M_FinOBDate
            Cmb_TrUnit.SelectedValue = User_UnitID
            Cmb_AccBalType.SelectedValue = 1
            Cmb_ActveStatus.SelectedValue = "Y"
            Cmb_FinYear.SelectedValue = M_DefaultFinYear
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Fill_Details()
        Dim M_Product As New DataTable
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Call Fill_Unit(Cmb_TrUnit, "Y", False, "S")
            Call Fill_ActiveStatus(Cmb_ActveStatus)
            Call Fill_AccountTransactionType(Cmb_AccBalType)
            Call M_CommonBL.Fill_FinYear(Cmb_FinYear, Company_Code, Tran_Date, M_DefaultFinYear, M_FinOBDate, M_FinStartDate)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function ValidateControls() As Boolean

        Dim sMsg As String
        Try

            If Val(Txt_AccCode.Text) = 0 Then
                sMsg = "Please Enter a Valid Account Head.."
                Me.ActiveControl = Txt_AccBalance
                GoTo Invalid
            End If

            If Val(Txt_AccBalance.Text) = 0 Then
                sMsg = "Please Enter a Valid Amount"
                Me.ActiveControl = Txt_AccBalance
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

    Private Sub AccOpBal_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub

    Private Sub AccOpBal_Frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call SendKeyTab(Me, Me.ActiveControl, e)
    End Sub

    Private Sub AccOpBal_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call Fill_Details()
            Call Clear_Controls()
            Me.ActiveControl = Txt_AccOpId
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click

        Dim M_AccOpBal As New SMARTtBR_BO.AccOpBalBO

        If ValidateControls() = False Then Exit Sub
        Cmd_Save.Enabled = False  ''Disable Save Button

        With M_AccOpBal
            .AccUNID = Cmb_TrUnit.SelectedValue
            .AccOpId = M_AccOpId
            .AccCode = Val(Txt_AccCode.Text)
            .AccBalType = Val(Cmb_AccBalType.SelectedValue)
            .MakerID = User_ID
            If M_EntryMode = "NEW" Then
                .UpdaterID = 0
            Else
                .UpdaterID = User_ID
            End If
            .AccOpMode = M_AccOpMode
            .AccOpDate = Dtp_AccOpDate.Value
            .AccBalance = Val(Txt_AccBalance.Text)
            .ActiveStatus = Cmb_ActveStatus.SelectedValue
        End With

        Try
            M_AccOpId = M_AccOpBalBL.Save_Data(M_AccOpBal, M_EntryMode, Me.Tag)
            If M_AccOpId > 0 Then
                MessageBox.Show("Data Saved... AccOpId : " & M_AccOpId, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call Clear_Controls()
            Else
                Cmd_Save.Enabled = True  ''Enable Save Button
            End If
        Catch ex As Exception
            Cmd_Save.Enabled = True  ''Enable Save Button
        End Try
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call Clear_Controls()
        Me.ActiveControl = Txt_AccOpId
    End Sub

    Private Sub Locate_Data(ByVal M_AccOpBal As SMARTtBR_BO.AccOpBalBO)

        If M_AccOpBal.AccOpId = 0 Then
            M_EntryMode = "NEW"
            Call Clear_Controls()
            Exit Sub
        End If

        With M_AccOpBal
            M_AccOpId = .AccOpId
            M_AccOpMode = .AccOpMode
            Txt_AccOpId.Text = M_AccOpId
            Dtp_AccOpDate.Value = .AccOpDate
            Txt_AccCode.Text = .AccCode
            Txt_AccName.Text = .AccName
            Txt_AccBalance.Text = .AccBalance
            Cmb_TrUnit.SelectedValue = .AccUNID
            Cmb_AccBalType.SelectedValue = .AccBalType
            Cmb_FinYear.SelectedValue = .FinPeriod
            Cmb_ActveStatus.SelectedValue = .ActiveStatus
        End With
        M_EntryMode = "VIEW"

    End Sub

    Private Sub Txt_AccOpId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_AccOpId.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 8, 0, Txt_AccOpId, SMARTtBR_MDI.Enm_SearchProperty.Text, " AND Fin_Period = '" & Cmb_FinYear.SelectedValue & "' AND Cmp_Code = " & Company_Code)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Txt_AccOpId_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_AccOpId.Validating
        If Txt_AccOpId.Text.Length = 0 Then
            Call Clear_Controls()
            M_EntryMode = "NEW"
        Else
            Try
                Dim M_AccOpBal As New SMARTtBR_BO.AccOpBalBO
                M_AccOpBal = M_AccOpBalBL.Locate_Data(Txt_AccOpId.Text)
                Call Locate_Data(M_AccOpBal)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Txt_AccCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_AccCode.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 7, 1, Txt_AccCode, SMARTtBR_MDI.Enm_SearchProperty.Text)
            End If
        Catch ex As Exception
            LogErrorToLogFile(Me.Name & " - Txt_AccCode_KeyDown ", ex.Message)
        End Try
    End Sub

    Private Sub Txt_AccCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Txt_AccCode.Validating
        Dim M_AccMasterBO As New AccountMasterBO
        Dim M_AccMasterBL As New AccountMasterBL

        Try
            If Val(Txt_AccCode.Text) > 0 Then
                M_AccMasterBO = M_AccMasterBL.Locate_Data(Company_Code, Val(Txt_AccCode.Text))
                With M_AccMasterBO
                    If .AccCode = 0 Then
                        MessageBox.Show("Invalid Account Head....", "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                        Txt_AccCode.Text = ""
                    Else
                        Txt_AccName.Text = .AccName
                        Cmb_AccBalType.SelectedValue = IIf(.AccBalType = "D", -1, 1)
                    End If
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cmb_FinYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_FinYear.SelectedIndexChanged
        If Cmb_FinYear.Items.Count = 0 Or Cmb_FinYear.ValueMember.Length = 0 Then Exit Sub
        Try
            Dim sBRows() As DataRow = Cmb_FinYear.DataSource.Select("Fin_Period = " & Cmb_FinYear.SelectedValue)
            For J = 0 To sBRows.Count - 1
                Dtp_AccOpDate.Value = sBRows(J).Item("Fin_OBDate").ToString
            Next
        Catch ex As Exception
            LogErrorToLogFile(Me.Name & " - Cmb_FinYear_SelectedIndexChanged ", ex.Message)
        End Try
    End Sub
End Class

