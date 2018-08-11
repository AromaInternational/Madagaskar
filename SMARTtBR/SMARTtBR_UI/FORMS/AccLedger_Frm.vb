Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_BL
Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms

Public Class AccLedger_Frm

    Dim M_AccId As Long
    Dim M_CommonBL As New CommonBL
    Dim M_EntryMode As String
    Dim M_AccLedgerBL As New AccLedgerBL
    Dim M_DefaultVrType As String = ""
    Dim M_TranTbl As New DataTable
    Dim M_AccVrNo As Integer = 0
    Dim M_AccType As String = "D"
    Dim M_AccChqNo As String = ""
    Dim M_AccOrgFrom As String = "AT"
    Dim M_AccChqDate As Date = "01/01/1900"
    Dim M_FindResultTbl As DataTable
    Dim M_BindingSource As New BindingSource

    Private Sub Clear_Controls()
        Try
            Cmd_Save.Enabled = True  ''Enable Save Button
            M_EntryMode = "NEW"
            M_AccId = 0
            M_AccVrNo = 0
            M_AccType = "D"
            M_AccChqNo = ""
            M_AccOrgFrom = "AT"
            M_AccChqDate = "01/01/1900"

            Txt_AccId.Text = ""
            Txt_AccNarration.Text = ""
            Dtp_AccTrDate.Value = Tran_Date
            Cmb_ActveStatus.SelectedValue = "Y"

            Call Clear_ItemControls()

            M_TranTbl = M_TranTbl.Clone
            Call GridBind()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Fill_Details()
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Call Fill_Unit(Cmb_TrUnit, "Y", False, "S")
            Cmb_TrUnit.SelectedValue = User_UnitID

            Call Fill_ActiveStatus(Cmb_ActveStatus)
            Call Fill_AccountTransactionType(Cmb_AccTranType)

            Call M_CommonBL.Fill_AccVrType(Cmb_AccVrTyp, Company_Code, M_DefaultVrType)
            Cmb_AccVrTyp.SelectedValue = M_DefaultVrType

            M_TranTbl = M_AccLedgerBL.Fill_AccTran(M_AccId)
            Call GridBind()

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function ValidateControls() As Boolean

        Dim sMsg As String
        Try

            If Val(Txt_CrTotal.Text) = 0 And Val(Txt_DrTotal.Text) = 0 Then
                sMsg = "Can't Save Data..." & vbNewLine & "Please enter the transaction details...."
                Me.ActiveControl = Cmb_AccTranType
                GoTo Invalid
            End If

            If Val(Txt_TrBalance.Text) > 0 Then
                sMsg = "Can't Save Data..." & vbNewLine & "Transaction Total Not Mistmatch..."
                Me.ActiveControl = Cmb_AccTranType
                GoTo Invalid
            End If

            If M_AccType = "P" Then
                sMsg = "Can't Modify Posted Data..."
                GoTo Invalid
            End If

            If Txt_AccNarration.Text.Trim.Length = 0 Then
                sMsg = "Can't Save Data..." & vbNewLine & "Please enter the transaction Remarks...."
                Me.ActiveControl = Txt_AccNarration
                GoTo Invalid
            End If

            Return True
            Exit Function
Invalid:
            If sMsg <> "" Then MsgBox(sMsg, MsgBoxStyle.Critical, "SMARTtBR")
            Return False
            Exit Function
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub AccLedger_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub

    Private Sub AccLedger_Frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call SendKeyTab(Me, Me.ActiveControl, e)
    End Sub

    Private Sub AccLedger_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call Fill_Details()
            Call Clear_Controls()
            Me.ActiveControl = Txt_AccId
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click

        Dim M_AccLedger As New SMARTtBR_BO.AccLedgerBO

        If ValidateControls() = False Then Exit Sub
        Cmd_Save.Enabled = False  ''Disable Save Button

        With M_AccLedger
            .AccUNID = Cmb_TrUnit.SelectedValue
            .AccId = M_AccId
            .AccVrNo = M_AccVrNo
            .AccType = M_AccType
            .AccChqNo = M_AccChqNo
            .AccOrgFrom = M_AccOrgFrom
            .MakerID = User_ID
            .UpdaterID = IIf(M_EntryMode = "NEW", 0, User_ID)
            .AccFinYear = ""
            .AccNarration = Txt_AccNarration.Text.Trim
            .AccChqDate = M_AccChqDate
            .AccTrDate = Dtp_AccTrDate.Value
            .AccVrTyp = Cmb_AccVrTyp.SelectedValue
            .ActiveStatus = Cmb_ActveStatus.SelectedValue
        End With

        Try
            Dim M_TranSw As New IO.StringWriter
            Dgv_TranDetails.DataSource.WriteXml(M_TranSw)

            M_AccId = M_AccLedgerBL.Save_Data(M_AccLedger, M_TranSw.ToString.Replace("DocumentElement", "NewDataSet"), M_EntryMode, Me.Tag)
            If M_AccId > 0 Then
                MessageBox.Show("Data Saved... ID : " & M_AccId, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Me.ActiveControl = Txt_AccId
    End Sub

    Private Sub Locate_Data(ByVal M_AccLedger As SMARTtBR_BO.AccLedgerBO)

        If M_AccLedger.AccId = 0 Then
            M_EntryMode = "NEW"
            Call Clear_Controls()
            Exit Sub
        End If

        With M_AccLedger
            M_AccId = .AccId
            Txt_AccId.Text = M_AccId
            Cmb_TrUnit.SelectedValue = .AccUNID
            M_AccVrNo = .AccVrNo
            Dtp_AccTrDate.Value = .AccTrDate
            M_AccChqDate = .AccChqDate
            Cmb_AccVrTyp.SelectedValue = .AccVrTyp
            M_AccChqNo = .AccChqNo
            M_AccOrgFrom = .AccOrgFrom
            Txt_AccNarration.Text = .AccNarration
            M_AccType = .AccType
            Cmb_ActveStatus.SelectedValue = .ActiveStatus
        End With

        M_TranTbl = M_AccLedgerBL.Fill_AccTran(M_AccId)
        Call GridBind()

        M_EntryMode = "VIEW"

    End Sub

    Private Sub Txt_AccId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_AccId.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 9, 0, Txt_AccId, SMARTtBR_MDI.Enm_SearchProperty.Text, " And Cmp_Code =" & Company_Code)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Txt_AccId_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_AccId.Validating
        If Txt_AccId.Text.Length = 0 Then
            Call Clear_Controls()
            M_EntryMode = "NEW"
        Else
            Try
                Dim M_AccLedger As New SMARTtBR_BO.AccLedgerBO
                M_AccLedger = M_AccLedgerBL.Locate_Data(Txt_AccId.Text)
                Call Locate_Data(M_AccLedger)
            Catch ex As Exception

            End Try
        End If
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
                If Dgv_TranDetails.DataSource.Rows.Count > 1 Then
                    Txt_AccNarration.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cmb_FinYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_AccVrTyp.SelectedIndexChanged
        If Cmb_AccVrTyp.Items.Count = 0 Or Cmb_AccVrTyp.ValueMember.Length = 0 Then Exit Sub
        Try
            Dim sBRows() As DataRow = Cmb_AccVrTyp.DataSource.Select("Fin_ID = " & Cmb_AccVrTyp.SelectedValue)
            For J = 0 To sBRows.Count - 1
                Dtp_AccTrDate.Value = sBRows(J).Item("Fin_OBDate").ToString
            Next
        Catch ex As Exception
            LogErrorToLogFile(Me.Name & " - Cmb_FinYear_SelectedIndexChanged ", ex.Message)
        End Try
    End Sub

    Private Sub Cmd_ADD_Click(sender As Object, e As EventArgs) Handles Cmd_ADD.Click
        Dim M_Dr As DataRow
        Cmd_ADD.Enabled = False

        If Val(Txt_AccCode.Text) = 0 Then
            MsgBox("Please Enter a Valid Account Head..", MsgBoxStyle.OkOnly, "SMARTtBR")
            Me.ActiveControl = Txt_AccAmt
            Exit Sub
        End If

        If Val(Txt_AccAmt.Text) = 0 Then
            MsgBox("Please Enter a Valid Amount", MsgBoxStyle.OkOnly, "SMARTtBR")
            Me.ActiveControl = Txt_AccAmt
            Exit Sub
        End If

        Try
            M_Dr = M_TranTbl.NewRow

            M_Dr("Acc_SlNo") = 0
            M_Dr("Acc_TrType") = Cmb_AccTranType.Text.Trim
            M_Dr("Acc_Code") = Val(Txt_AccCode.Text)
            M_Dr("Acc_Name") = Txt_AccName.Text
            M_Dr("Acc_CrAmount") = IIf(Cmb_AccTranType.SelectedValue = 1, Val(Txt_AccAmt.Text), 0)
            M_Dr("Acc_DrAmount") = IIf(Cmb_AccTranType.SelectedValue = -1, Val(Txt_AccAmt.Text), 0)
            M_Dr("Acc_TranType") = Cmb_AccTranType.SelectedValue
            M_Dr("Acc_Amt") = Val(Txt_AccAmt.Text)

            M_TranTbl.Rows.Add(M_Dr)

            Call GridBind()
            Dgv_TranDetails.CurrentCell = Dgv_TranDetails(M_TranTbl.Columns("Acc_Name").Ordinal, Dgv_TranDetails.Rows.Count - 1)

            Call Clear_ItemControls()
            Cmd_ADD.Enabled = True
            Me.ActiveControl = Cmb_AccTranType
        Catch ex As Exception
            Cmd_ADD.Enabled = True
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GridBind()
        Dim Col As Integer
        Dim DgCol As DataGridViewColumn
        Try
            Dgv_TranDetails.DataSource = M_TranTbl
            Dgv_TranDetails.Columns(Col).Visible = True
            For Col = 0 To Dgv_TranDetails.Columns.Count - 1
                DgCol = Dgv_TranDetails.Columns(Col)
                DgCol.SortMode = DataGridViewColumnSortMode.NotSortable
                If DgCol.Name = "Acc_SlNo" Then
                    DgCol.HeaderText = "SLNO"
                    DgCol.Width = 50
                    DgCol.DisplayIndex = 0
                    DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                ElseIf DgCol.Name = "Acc_TrType" Then
                    DgCol.HeaderText = "TYPE"
                    DgCol.Width = 50
                    DgCol.DisplayIndex = 1
                    DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                ElseIf DgCol.Name = "Acc_Code" Then
                    DgCol.HeaderText = "CODE"
                    DgCol.Width = 75
                    DgCol.DisplayIndex = 2
                    DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                ElseIf DgCol.Name = "Acc_Name" Then
                    DgCol.HeaderText = "NAME"
                    DgCol.Width = 175
                    DgCol.DisplayIndex = 3
                ElseIf DgCol.Name = "Acc_CrAmount" Then
                    DgCol.HeaderText = "CREDIT"
                    DgCol.Width = 125
                    DgCol.DisplayIndex = 4
                    DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgCol.DefaultCellStyle.Format = "n2"
                ElseIf DgCol.Name = "Acc_DrAmount" Then
                    DgCol.HeaderText = "DEBIT"
                    DgCol.DisplayIndex = 5
                    DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgCol.DefaultCellStyle.Format = "n2"
                    DgCol.Width = 125
                Else
                    Dgv_TranDetails.Columns(Col).Visible = False
                End If
            Next

            Dim M_Dr As DataRow
            Dim I As Integer
            For I = 0 To M_TranTbl.Rows.Count - 1
                M_Dr = M_TranTbl.Rows(I)
                M_Dr("Acc_SlNo") = I + 1
            Next

            Dgv_TranDetails.Refresh()
            Call CalcFinalTotal()
        Catch ex As Exception : End Try
    End Sub

    Public Sub CalcFinalTotal()
        Dim objSum As Object
        Try
            If M_TranTbl.Rows.Count > 0 Then
                objSum = M_TranTbl.Compute("Sum(Acc_CrAmount)", "")
                Txt_CrTotal.Text = Format(Val(objSum.ToString()), "#0.00")

                objSum = M_TranTbl.Compute("Sum(Acc_DrAmount)", "")
                Txt_DrTotal.Text = Format(Val(objSum.ToString()), "#0.00")
            Else
                Txt_CrTotal.Text = "0.00"
                Txt_DrTotal.Text = "0.00"
            End If

            Txt_TrBalance.Text = Format(Math.Abs(Val(Txt_CrTotal.Text) - Val(Txt_DrTotal.Text)), "#0.00")
            Txt_TrBalanceType.Text = IIf(Val(Txt_CrTotal.Text) - Val(Txt_DrTotal.Text) >= 0, "Cr", "Dr")

        Catch ex As Exception : End Try
    End Sub
    Public Sub Clear_ItemControls()
        Try
            Cmd_ADD.Enabled = True
            Txt_AccName.Text = ""
            Txt_AccCode.Text = ""
            Txt_AccAmt.Text = ""
            Cmb_AccTranType.SelectedValue = 1
         Catch ex As Exception : End Try
    End Sub

    Private Sub Dgv_TranDetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv_TranDetails.DoubleClick
        Dim M_Dr As DataRow
        Try
            If Dgv_TranDetails.RowCount = 0 Then Exit Sub
            If Dgv_TranDetails.SelectedRows(0).Index >= 0 Then
                M_Dr = M_TranTbl.Rows(Dgv_TranDetails.SelectedRows(0).Index)

                Cmb_AccTranType.SelectedValue = M_Dr("Acc_TranType")
                Txt_AccCode.Text = Val(M_Dr("Acc_Code"))
                Txt_AccName.Text = M_Dr("Acc_Name")
                Txt_AccAmt.Text = Format(Val(M_Dr("Acc_Amt")), "#0.00")

                M_TranTbl.Rows(Dgv_TranDetails.SelectedRows(0).Index).Delete()
                M_TranTbl.AcceptChanges()
                Call GridBind()
                Call CalcFinalTotal()
            End If
         Catch ex As Exception : End Try
    End Sub

    Private Sub Dgv_TranDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv_TranDetails.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If Dgv_TranDetails.SelectedRows(0).Index >= 0 Then
                    If MessageBox.Show("Are you want Delete ?", Me.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        M_TranTbl.Rows(Dgv_TranDetails.SelectedRows(0).Index).Delete()
                        M_TranTbl.AcceptChanges()
                        Call GridBind()
                        Call CalcFinalTotal()
                    End If
                End If
            ElseIf e.KeyCode = Keys.Space Then
                Call Dgv_TranDetails_DoubleClick(sender, Nothing)
            End If
        Catch ex As Exception : End Try
    End Sub

    Private Sub Txt_HiddenAccId_TextChanged(sender As Object, e As EventArgs) Handles Txt_HiddenAccId.TextChanged
        Try
            If Val(Txt_HiddenAccId.Text) > 0 Then
                Dim M_AccLedger As New SMARTtBR_BO.AccLedgerBO
                M_AccLedger = M_AccLedgerBL.Locate_Data(Txt_HiddenAccId.Text)
                Call Locate_Data(M_AccLedger)
            End If
        Catch ex As Exception : End Try
    End Sub

    Private Sub Cmd_Find_Click(sender As Object, e As EventArgs) Handles Cmd_Find.Click

        Dim FrmSearch As New AccFind_Frm
        FrmSearch.StartPosition = FormStartPosition.CenterParent
        FrmSearch.ShowDialog(Me)

        Try
            If FrmSearch.M_Ok = False Then Exit Sub

            M_FindResultTbl = FrmSearch.M_FindResultTbl
            FrmSearch = Nothing

            If M_FindResultTbl Is Nothing Then
                MessageBox.Show("No Record Found....", "SMARTtBR")
                Exit Sub
            End If

            If M_FindResultTbl.Rows.Count = 0 Then
                MessageBox.Show("No Record Found....", "SMARTtBR")
                Exit Sub
            End If
            M_BindingSource.DataSource = M_FindResultTbl
            Try : Txt_HiddenAccId.DataBindings.Add(New Binding("text", M_BindingSource, "Acc_Id")) : Catch ex As Exception : End Try
            BN_AccTranSearch.BindingSource = M_BindingSource

        Catch ex As Exception : MessageBox.Show(ex.Message) : End Try
    End Sub

    Private Sub Txt_AccNarration_GotFocus(sender As Object, e As EventArgs) Handles Txt_AccNarration.GotFocus
        KeyPreview = False
    End Sub

    Private Sub Txt_AccNarration_LostFocus(sender As Object, e As EventArgs) Handles Txt_AccNarration.LostFocus
        KeyPreview = True
    End Sub
End Class

