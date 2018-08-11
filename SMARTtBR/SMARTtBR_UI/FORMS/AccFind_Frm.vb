Imports SMARTtBR_BL
Imports SMARTtBR_BO
Imports SMARTtBR_CO.CommonClass
Public Class AccFind_Frm
    Dim M_CommonBL As New CommonBL
    Dim M_AccLedgerBL As New AccLedgerBL
    Public M_FindResultTbl As DataTable
    Public M_Ok As Boolean

    Dim M_DefaultVrType As String
    Dim M_DefaultFinYear As String = ""
    Dim M_FinOBDate As Date = Tran_Date
    Dim M_FinStartDate As Date = Tran_Date
    Private Sub AccFind_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call Fill_Details()
            Call ClearMe()
            Me.ActiveControl = Chk_VoucherType
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ClearMe()
        Try
            M_Ok = False
            Chk_VoucherType.Checked = False
            Chk_TrUnit.Checked = False
            Chk_TrDate.Checked = False
            Chk_Amount.Checked = False
            Chk_VrNo.Checked = False
            Chk_AccountCode.Checked = False
            Chk_TrType.Checked = False
            Chk_Narration.Checked = False

            Dtp_DateFrom.Value = M_FinStartDate
            Dtp_DateTo.Value = Tran_Date
            Cmb_AccVrTyp.SelectedValue = M_DefaultVrType
            Cmb_AccTranType.SelectedValue = 0
            Cmb_TrUnit.SelectedValue = User_UnitID
            Cmb_FinYear.SelectedValue = M_DefaultFinYear
        Catch ex As Exception : End Try
    End Sub


    Public Sub Fill_Details()
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Call Fill_Unit(Cmb_TrUnit, "Y", True, "A")
            Call Fill_AccountTransactionType(Cmb_AccTranType, True)
            Call M_CommonBL.Fill_AccVrType(Cmb_AccVrTyp, Company_Code, M_DefaultVrType, True, "S")
            Call M_CommonBL.Fill_FinYear(Cmb_FinYear, Company_Code, Tran_Date, M_DefaultFinYear, M_FinOBDate, M_FinStartDate)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        M_Ok = False
        Me.Dispose()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click

        Dim M_VoucherType As String = IIf(Chk_VoucherType.Checked, Cmb_AccVrTyp.SelectedValue, "")
        Dim M_TrUnit As Integer = IIf(Chk_TrUnit.Checked, Cmb_TrUnit.SelectedValue, 0)
        Dim M_TrDateFrom As Date = IIf(Chk_TrDate.Checked, Dtp_DateFrom.Value.Date, "01/01/1900")
        Dim M_TrDateTo As Date = IIf(Chk_TrDate.Checked, Dtp_DateTo.Value.Date, "01/01/1900")
        Dim M_VrNoFrom As Integer = IIf(Chk_VrNo.Checked, Val(Txt_VrNoFrom.Text), 0)
        Dim M_VrNoTo As Integer = IIf(Chk_VrNo.Checked, Val(Txt_VrNoTo.Text), 0)
        Dim M_AmountFrom As Double = IIf(Chk_Amount.Checked, Val(Txt_AmountFrom.Text), 0)
        Dim M_AmountTo As Double = IIf(Chk_Amount.Checked, Val(Txt_AmountTo.Text), 0)
        Dim M_TrType As Integer = IIf(Chk_TrType.Checked, Cmb_AccTranType.SelectedValue, 0)
        Dim M_AccCode As Integer = IIf(Chk_AccountCode.Checked, Val(Txt_AccCode.Text), 0)
        Dim M_Remarks As String = IIf(Chk_Narration.Checked, Txt_Narration.Text.Trim, "")
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            M_FindResultTbl = M_AccLedgerBL.Proc_AccTranSearch(Company_Code, Cmb_FinYear.Text, M_VoucherType, M_TrUnit, M_TrDateFrom, M_TrDateTo, M_VrNoFrom, M_VrNoTo, M_AmountFrom, M_AmountTo, M_TrType, M_AccCode, M_Remarks, User_ID)
            M_Ok = True
            Me.Hide()

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub AccFind_Frm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{Tab}")
    End Sub

    Private Sub Chk_VoucherType_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_VoucherType.CheckedChanged
        Cmb_AccVrTyp.Enabled = Chk_VoucherType.Checked
    End Sub

    Private Sub Chk_TrBranch_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_TrUnit.CheckedChanged
        Cmb_TrUnit.Enabled = Chk_TrUnit.Checked
    End Sub

    Private Sub Chk_TrDate_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_TrDate.CheckedChanged
        Dtp_DateFrom.Enabled = Chk_TrDate.Checked
        Dtp_DateTo.Enabled = Chk_TrDate.Checked
    End Sub

    Private Sub Chk_VrNo_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_VrNo.CheckedChanged
        Txt_VrNoFrom.Enabled = Chk_VrNo.Checked
        Txt_VrNoTo.Enabled = Chk_VrNo.Checked
    End Sub

    Private Sub Chk_Amount_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Amount.CheckedChanged
        Txt_AmountFrom.Enabled = Chk_Amount.Checked
        Txt_AmountTo.Enabled = Chk_Amount.Checked
    End Sub

    Private Sub Chk_TrType_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_TrType.CheckedChanged
        Cmb_AccTranType.Enabled = Chk_TrType.Checked
    End Sub

    Private Sub Chk_AccountCode_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_AccountCode.CheckedChanged
        Txt_AccCode.Enabled = Chk_AccountCode.Checked
    End Sub

    Private Sub Chk_Narration_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Narration.CheckedChanged
        Txt_Narration.Enabled = Chk_Narration.Checked
    End Sub

    Private Sub Txt_AccCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_AccCode.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 7, 1, Txt_AccCode, SMARTtBR_MDI.Enm_SearchProperty.Text, " AND Acc_CmpCode = " & Company_Code)
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
                        Txt_AccName.Text = ""
                    Else
                        Txt_AccName.Text = .AccName
                    End If
                End With
            Else
                Txt_AccCode.Text = ""
                Txt_AccName.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Txt_AccCode_TextChanged(sender As Object, e As EventArgs) Handles Txt_AccCode.TextChanged

    End Sub
End Class