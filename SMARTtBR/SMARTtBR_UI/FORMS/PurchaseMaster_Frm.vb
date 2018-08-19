Imports SMARTtBR_BL
Imports SMARTtBR_BO
Imports SMARTtBR_DAL
Imports SMARTtBR_CO.CommonClass

Public Class PurchaseMaster_Frm

    Private Const M_ClientType As ClientType = ClientType.Supplier
    Dim M_TranID As Long
    Dim M_OrgBrCode As Integer
    Dim M_CommonBL As New CommonBL
    Dim M_EntryMode As String
    Dim M_TranMasterBL As New TranMasterBL
    Dim M_ClientBL As New ClientMasterBL
    Dim M_ClientBO As ClientMasterBO
    Dim M_ProductBL As New ProductMasterBL
    Dim M_ProductBO As ProductMasterBO
    Dim M_ActiveStatus As String

    Dim ProductList As New AutoCompleteStringCollection()
    Dim I As Integer
    Dim M_CMAccCode As Integer = 0
    Dim M_CMCreditEnabled As String = "N"
    Private LastActiveControl As Control = Me
    'Friend Event FocusChanged As EventHandler(Of FocusChangedArg)
    Public M_TranTbl As New DataTable
    Public M_BillTbl As New DataTable
    Public M_PayTbl As DataTable
    Public M_InvExpTbl As DataTable

    Public ExpInDays As Integer
    Public FRCStatus As Boolean

    Public M_SlNo As Integer
    Private M_IMApproverID As Integer
    Private M_IMApprovedTime As String
    Private M_CurrencyEntryID As Integer = 0

    Private Sub PurchaseMaster_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub

    Private Sub PurchaseMaster_Frm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Enter And LastActiveControl.Name <> "Dgv_TranDetails" Then SendKeys.Send("{Tab}")

            If e.KeyCode = Keys.Escape Then
                'Pnl_PrchDetails.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub PurchaseMaster_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'If Branch_IsInventoryEnabled = False And User_TypeID <> 0 Then
            '    MessageBox.Show("Inventory... Not Enabled...!!!!!", "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.Close()
            '    Exit Sub
            'End If

            Call Fill_Details()
            Call Clear_Controls()
            Me.ActiveControl = TxtBillNo
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Fill_Details()
        Try

            Call Fill_TranGrid(M_TranID)
            M_EntryMode = "NEW"
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Fill_TranGrid(M_TranID As Long)
        M_TranTbl = M_TranMasterBL.Fill_TranGrid(M_TranID)
        Call GridBind()
    End Sub

    Private Sub Clear_Controls()
        Try
            'M_OrgBrCode = Branch_Code
            M_ActiveStatus = "Y"
            Cmd_Save.Enabled = True  ''Enable Save Button
            M_TranID = 0
            M_CMAccCode = 0
            M_CMCreditEnabled = "N"
            M_IMApproverID = User_ID

            TxtBillNo.Text = ""
            TxtInvNo.Text = ""

            Txt_ClientID.Text = ""
            TxtClientPhone.Text = ""
            TxtClientName.Text = ""
            Dtp_BillDate.Value = Tran_Date
            Dtp_BillDate.Enabled = (User_TypeID = 0)
            Dtp_InvDate.Value = Tran_Date
            Call Clear_ItemControls()

            M_TranTbl = M_TranTbl.Clone
            M_BillTbl = M_BillTbl.Clone
            M_PayTbl = M_PayTbl.Clone

            TxtNarration.Text = ""
            TxtDiscountOnTotal.Text = "0.00"
            TxtFrieght.Text = "0.00"

            'If PrchRoundOffEdit_Allowed Then
            '    TxtRoundoff.ReadOnly = False
            '    TxtRoundoff.TabStop = True
            '    Chk_AutoRoundOff.Visible = True
            '    Chk_AutoRoundOff.TabStop = True
            'Else
            '    TxtRoundoff.ReadOnly = True
            '    TxtRoundoff.TabStop = False
            '    Chk_AutoRoundOff.Visible = False
            '    
            '.TabStop = False
            'End If

            Chk_AutoRoundOff.Checked = True
            Cmd_Save.Enabled = True
            TxtRoundoff.Text = "0.00"

            M_EntryMode = "NEW"

            ExpInDays = 0

            Call CalcFinalTotal()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Locate_Data(ByVal M_TranMaster As SMARTtBR_BO.TranMasterBO)        If M_TranMaster.TranID = 0 Then            M_EntryMode = "NEW"            Call Clear_Controls()            Exit Sub        End If        With M_TranMaster            M_TranID = .TranID
            TxtBillNo.Text = .BillNo
            Dtp_BillDate.Value = .TrDate
            Txt_ClientID.Text = .ClientID

            Call Load_CustDtls(Val(Txt_ClientID.Text), "")

            TxtShippingAddress.Text = .ShipmentAddress
            TxtBillingAddress.Text = .BillingAddress
            Dtp_InvDate.Value = .InvoiceDate
            TxtInvNo.Text = .InvoiceNumber
            TxtRoundoff.Text = Format(.RoundOff, "#0.00")
            TxtGrTot.Text = Format(.GrossAmount, "#0.00")
            TxtNetAmt.Text = Format(.NetAmount, "#0.00")
            TxtFrieght.Text = Format(.Frieght, "#0.00")
            TxtDiscountOnTotal.Text = Format(.DiscountOnTotal, "#0.00")
            M_CurrencyEntryID = .CurrencyEntryID
            TxtNarration.Text = .Remarks
            Chk_AutoRoundOff.Checked = IIf(.AutoRoundOff = "T", True, False)
            'M_MakerID = .MakerID
            'M_MakingTime = .MakingTime
            'M_UpdaterId = .UpdaterId
            'M_UpdatingTime = .UpdatingTime
        End With

        Call Fill_TranGrid(M_TranID)
        Call CalcFinalTotal()

        M_EntryMode = "VIEW"
    End Sub

    Public Sub Clear_ItemControls()
        Try
            Cmd_Add.Enabled = True
            Txt_PrdCode.Text = ""
            LblMeasure1.Text = ""
            TxtMeasure1.Text = ""
            LblMeasure2.Text = ""
            TxtMeasure2.Text = ""
            LblMeasure3.Text = ""
            TxtMeasure3.Text = ""
            LblMeasureFinal.Text = ""
            TxtMeasureFinal.Text = ""
            TxtMeasureFinal.Tag = ""
            Txt_PrdName.Tag = ""
            TxtQty.Text = "0.000"
            TxtRate.Text = "0.00"
            Txt_Description.Text = ""
            M_SlNo = 0
            Call CalcItemTot()
        Catch ex As Exception
        End Try
    End Sub

    Public Function ValidateControls() As Boolean

        Dim sMsg As String = ""

        Try
            'If Not Validate_Server() Then sMsg = "Different Branch Server....!!!" & vbNewLine & "Transaction Not Allowed....!!!" : GoTo Invalid

            'If M_OrgBrCode <> Branch_Code Then
            '    sMsg = "Can not modify different branch Data... !"
            '    GoTo Invalid
            'End If

            If M_TranTbl.Rows.Count = 0 Then
                sMsg = "Select Items... !"
                '    Me.ActiveControl = Cmb_Item
                GoTo Invalid
            End If

            If Val(Txt_ClientID.Text) = 0 Then
                sMsg = "Enter Supplier...!"
                Me.ActiveControl = Txt_ClientID
                GoTo Invalid
            End If

            If TxtInvNo.Text.Length = 0 Then
                sMsg = "Enter Invoice No...!"
                Me.ActiveControl = TxtInvNo
                GoTo Invalid
            End If

            If Val(TxtNetAmt.Text) < 0 Then
                sMsg = "Net Bill Amount Should not be Less than Zero... !" & vbNewLine & " Please Check..."
                GoTo Invalid
            End If

            If Validate_PurchaseOrder() = False Then
                '   Me.ActiveControl = Txt_POID
                GoTo Invalid
            End If

            'Dim M_TranSw As New IO.StringWriter
            'M_TranTbl.WriteXml(M_TranSw)
            'If Not M_CommonBL.Proc_ValidateStock(M_EntryMode, M_OrgBrCode, M_ClientType, M_TranSw.ToString.Replace("DocumentElement", "NewDataSet"), sMsg) Then
            '    GoTo Invalid
            'End If

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

    Public Function ValidateItem() As Boolean
        Try
            If Val(TxtQty.Text) <= 0 Then
                MessageBox.Show("Invalid Quantity, Please check..", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TxtQty.Focus()
                Exit Function
            ElseIf Val(Txt_PrdCode.Text) <= 0 Then
                MessageBox.Show("Invalid Product, Please check..", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TxtQty.Focus()
                Exit Function
            ElseIf Val(TxtRate.Text) <= 0 Then
                MessageBox.Show("Invalid Rate, Please check..", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TxtQty.Focus()
                Exit Function
            Else
                ValidateItem = True
            End If
        Catch ex As Exception
        End Try
    End Function

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim M_Dr As DataRow
        Try
            Cmd_Add.Enabled = False
            If ValidateItem() = False Then
                Cmd_Add.Enabled = True
                Exit Sub
            End If

            M_Dr = M_TranTbl.NewRow
            M_Dr("ProductID") = (Txt_PrdCode.Text)
            M_Dr("Quantity") = Val(TxtQty.Text)
            M_Dr("Rate") = Val(TxtRate.Text)
            M_Dr("Price") = Val(TxtPrice.Text)
            M_Dr("ProductName_Detailed") = Txt_PrdName.Tag
            M_Dr("DiscountType") = ""
            M_Dr("DiscountPercent") = 0
            M_Dr("DiscountAmount") = 0
            M_Dr("Description") = Txt_Description.Text
            M_Dr("MeasurementFinal_Value") = Val(Replace(TxtMeasureFinal.Text, BasicMeasureUnitShort, ""))

            M_TranTbl.Rows.Add(M_Dr)

            Call GridBind()

            'Dgv_TranDetails.CurrentCell = Dgv_TranDetails(M_TranTbl.Columns("Pr_Name").Ordinal, Dgv_TranDetails.Rows.Count - 1)

            Clear_ItemControls()

            'Cmb_Item.Focus()
            Cmd_Add.Enabled = True

        Catch ex As Exception
            Cmd_Add.Enabled = True
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
                If DgCol.Name = "ProductName_Detailed" Then
                    DgCol.HeaderText = "Item Name"
                    DgCol.Width = 280
                    DgCol.DisplayIndex = 1
                ElseIf DgCol.Name = "Quantity" Then
                    DgCol.HeaderText = "Quantity"
                    DgCol.Width = 100
                    DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DgCol.DefaultCellStyle.Format = "n3"
                ElseIf DgCol.Name = "Rate" Then
                    DgCol.HeaderText = "Rate"
                    DgCol.Width = 80
                    DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DgCol.DefaultCellStyle.Format = "n3"
                ElseIf DgCol.Name = "Price" Then
                    DgCol.HeaderText = "Price"
                    DgCol.Width = 80
                    DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DgCol.DefaultCellStyle.Format = "n3"
                ElseIf DgCol.Name = "DiscountAmount" Then
                    DgCol.HeaderText = "Disc Amount"
                    DgCol.Width = 90
                    DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgCol.DefaultCellStyle.Format = "n2"
                ElseIf DgCol.Name = "DiscountType" Then
                    DgCol.HeaderText = "Discount Type"
                    DgCol.Width = 80
                ElseIf DgCol.Name = "DiscountPercent" Then
                    DgCol.HeaderText = "Disc%"
                    DgCol.Width = 40
                ElseIf DgCol.Name = "MeasurementFinal_Value" Then
                    DgCol.HeaderText = "CBcm"
                    DgCol.Width = 80
                ElseIf DgCol.Name = "TranSeqNo" Then
                    DgCol.HeaderText = "Sl No"
                    DgCol.Width = 50
                    DgCol.DisplayIndex = 0
                    Dgv_TranDetails.Sort(DgCol, System.ComponentModel.ListSortDirection.Ascending)
                    DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Else
                    Dgv_TranDetails.Columns(Col).Visible = False
                End If
            Next

            Dim M_Dr As DataRow
            Dim I As Integer
            For I = 0 To M_TranTbl.Rows.Count - 1
                M_Dr = M_TranTbl.Rows(I)
                M_Dr("TranSeqNo") = I + 1
            Next

            Dgv_TranDetails.Refresh()

            CalcFinalTotal()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub CalcFinalTotal()
        Dim objSum As Object
        'Dim DiscPercent As Double
        'Dim DiscAmt As Double
        Dim GrTot As Double
        Dim Roundoff As Double
        Dim NetTot As Double
        Dim TotQty As Double = 0
        Dim TotalValue As Double = 0
        Try
            'TxtGrTotWOT.Text = "0.00"
            'TxtGrDisc.Text = "0.00"
            'TxtGrDisc.Text = "0.00"
            'TxtGrTax.Text = "0.00"
            'TxtGrTotWT.Text = "0.00"

            If M_TranTbl.Rows.Count > 0 Then
                objSum = M_TranTbl.Compute("Sum(Price)", "")
                TotalValue = Val(objSum.ToString())
                objSum = M_TranTbl.Compute("Sum(Quantity)", "")
                TotQty = Val(objSum.ToString())
            End If

            Txt_TotalQty.Text = Format(TotQty, "#0.000")
            Txt_TotalValue.Text = Format(TotalValue, "#0.00")

            'DiscPercent = Val(TxtDiscOthPercent.Text)
            'If Get_CalcType(Cmb_DiscOthType.DataSource, IIf(Cmb_DiscOthType.SelectedIndex >= 0, Cmb_DiscOthType.SelectedValue, 0)) = "V" Then
            '    DiscAmt = (Val(TxtGrTotWOT.Text) * DiscPercent / 100)
            'Else
            '    DiscAmt = DiscPercent
            'End If

            GrTot = Val(Txt_TotalValue.Text) - Val(TxtDiscountOnTotal.Text) + Val(TxtFrieght.Text)
            TxtGrTot.Text = Format(GrTot, "#0.00")

            NetTot = GrTot

            If Chk_AutoRoundOff.Checked Then
                Roundoff = CDbl(Microsoft.VisualBasic.Right(Format(NetTot, "#0.00"), 3))
                If Roundoff < 0.5 Then
                    Roundoff = Roundoff * -1
                Else
                    Roundoff = 1 - Roundoff
                End If
            Else
                Roundoff = Val(TxtRoundoff.Text)
            End If

            TxtRoundoff.Text = IIf(Roundoff > 0, "+", "") & Format(Roundoff, "#0.00")
            NetTot = NetTot + Roundoff
            TxtNetAmt.Text = Format(NetTot, "#0.00")

        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtQty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtQty.Validating
        TxtQty.Text = Format(Val(TxtQty.Text), "#0.000")
        Call CalcItemTot()
    End Sub

    Public Sub CalcItemTot(Optional ByVal SP As Double = 0)
        Dim Qty As Double = 0
        Dim Rate As Double = 0 ' Buying Price
        Dim TotalAmt As Double = 0
        Dim DiscPercent As Double = 0
        Dim DiscAmt As Double = 0
        Dim TaxPercent As Double = 0
        Dim TaxAmt As Double = 0
        Dim TotWithTax As Double = 0
        Dim ProfitPercent As Double = 0
        Dim LandingCost As Double = 0
        Dim CBcm As Double = 0
        Dim CBcmItemlTotal As Double = 0

        Try
            Qty = Val(TxtQty.Text)
            Rate = Val(TxtRate.Text)
            TotalAmt = Qty * Rate

            TxtQty.Text = Format(Qty, "#0.000")
            TxtRate.Text = Format(Rate, "#0.00")

            CBcm = Val(TxtMeasureFinal.Tag)
            CBcmItemlTotal = CBcm * Qty

            TxtMeasureFinal.Text = Format(CBcmItemlTotal, "#0.00") + BasicMeasureUnitShort

            TxtPrice.Text = Format(TotalAmt, "#0.00")

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        If M_TranTbl.Rows.Count > 0 Then
            If MsgBox("Do You Want To Clear.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "SMART BiZ") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Call Clear_Controls()
        Me.ActiveControl = TxtBillNo
    End Sub

    Private Sub TxtBillNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBillNo.KeyDown
        If e.KeyCode = Keys.F3 Then
            SMARTtBR_MDI.Search(Me, 8, 0, TxtBillNo, SMARTtBR_MDI.Enm_SearchProperty.Text)
        End If
    End Sub


    Private Sub TxtBillNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBillNo.Validating
        If TxtBillNo.Text.Length = 0 Then
            If M_TranTbl.Rows.Count > 0 Then
                If MsgBox("Do You Want To Clear.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "SMART BiZ") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            '   Call Clear_Controls()
            M_EntryMode = "NEW"
        Else
            Try
                Dim M_TranMasterBO As New SMARTtBR_BO.TranMasterBO
                Dim M_TranMasterBL As New TranMasterBL
                M_TranMasterBO = M_TranMasterBL.Locate_Data(Val(TxtBillNo.Text))
                Call Locate_Data(M_TranMasterBO)
                M_TranMasterBL = Nothing
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TxtClientPhone_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtClientPhone.Validating
        Try
            If TxtClientPhone.Text.Length > 0 Then
                M_ClientBO = M_ClientBL.Locate_Data(Company_Code, 0, TxtClientPhone.Text, M_ClientType)
                Txt_ClientID.Text = M_ClientBO.CMID
                TxtClientName.Text = M_ClientBO.CMName
                M_CMAccCode = M_ClientBO.CMAccCode
                M_CMCreditEnabled = M_ClientBO.CMCreditEnabled
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgv_TranDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv_TranDetails.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If Dgv_TranDetails.SelectedRows(0).Index >= 0 Then
                    If Validate_StockStatus() Then Exit Sub
                    If MessageBox.Show("Are you want Delete ?", Me.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        M_TranTbl.Rows(Dgv_TranDetails.SelectedRows(0).Index).Delete()
                        M_TranTbl.AcceptChanges()
                        GridBind()
                        CalcFinalTotal()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Txt_BuyingPrice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRate.Validating
        Call CalcItemTot()
    End Sub

    Private Sub Dtp_ManufacturingDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'Call CalcExpDate()
    End Sub

    Private Sub Dgv_TranDetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dgv_TranDetails.DoubleClick
        Dim M_Dr As DataRow
        Try
            If Dgv_TranDetails.RowCount = 0 Then Exit Sub
            If Dgv_TranDetails.SelectedRows(0).Index >= 0 Then
                If Validate_StockStatus() Then Exit Sub

                M_Dr = M_TranTbl.Rows(Dgv_TranDetails.SelectedRows(0).Index)
                TxtMeasure1.Text = M_Dr("Unit_Name")
                'Cmb_Item.SelectedValue = M_Dr("IT_ItemID")
                'M_SlNo = M_Dr("IT_SlNo")
                'Txt_BatchNo.Text = M_Dr("Stk_BatchNo")
                'Txt_BatchNo.Tag = M_Dr("IT_StkID")
                'TxtQty.Text = Format(M_Dr("IT_Qty"), "#0.000")
                'CmbDiscQtyType.SelectedValue = M_Dr("IT_DiscID")
                'TxtDiscQtyPercent.Text = Format(M_Dr("IT_DiscPer"), "#0.00")
                'TxtDiscQtyAmt.Text = Format(M_Dr("IT_DiscAmount"), "#0.00")
                'CmbTaxType.SelectedValue = M_Dr("IT_TaxID")
                'TxtTaxPercent.Text = Format(M_Dr("IT_TaxPer"), "#0.00")
                'TxtTaxAmt.Text = Format(M_Dr("IT_TaxAmount"), "#0.00")
                'TxtTotAmt.Text = Format(M_Dr("IT_ValueWOT"), "#0.00")
                'TxtItemGrTot.Text = Format(M_Dr("IT_ValueWT"), "#0.00")
                'Txt_Mrp.Text = Format(M_Dr("IT_Mrp"), "#0.00")
                'Txt_SP.Text = Format(M_Dr("IT_SP"), "#0.00")
                'Txt_Description.Text = M_Dr("IT_Nraation")

                'Dtp_ManufacturingDate.Value = M_Dr("Stk_MFDate")
                'Dtp_ExpiryDate.Value = M_Dr("Stk_EXPDate")
                'Txt_BuyingPrice.Text = Format(M_Dr("Stk_PRate"), "#0.00")
                'Txt_LandingCostPerUnit.Text = Format(M_Dr("Stk_LandingCost"), "#0.00")
                'Call CalcItemTot()

                M_TranTbl.Rows(Dgv_TranDetails.SelectedRows(0).Index).Delete()
                M_TranTbl.AcceptChanges()
                Call GridBind()
                Call CalcFinalTotal()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Load_CustDtls(ByVal M_ID As Integer, ByVal M_PhNo As String)
        Try

            M_ClientBO = M_ClientBL.Locate_Data(Company_Code, M_ID, M_PhNo, M_ClientType)
            Txt_ClientID.Text = M_ClientBO.CMID
            TxtClientName.Text = M_ClientBO.CMName
            TxtClientPhone.Text = M_ClientBO.CMPhoneNo
            M_CMAccCode = M_ClientBO.CMAccCode
            M_CMCreditEnabled = M_ClientBO.CMCreditEnabled
            ' To do
            TxtBillingAddress.Text = M_ClientBO.CMPrAdrs1 + ", " + M_ClientBO.CMPrAdrs2 + ", " + M_ClientBO.CMPrAdrs3
            TxtShippingAddress.Text = M_ClientBO.CMPmAdrs1 + ", " + M_ClientBO.CMPmAdrs2 + ", " + M_ClientBO.CMPmAdrs3
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Load_ProductDetails(ByVal M_ProductID As Integer)
        Try
            M_ProductBO = M_ProductBL.Locate_Data(M_ProductID)
            Txt_PrdName.Text = M_ProductBO.ProductName

            If M_ProductBO.Measurement1Text.Length = 0 Then
                LblMeasure1.Visible = False
                TxtMeasure1.Visible = False
            Else
                LblMeasure1.Visible = True
                TxtMeasure1.Visible = True
                LblMeasure1.Text = M_ProductBO.Measurement1Text
                TxtMeasure1.Text = M_ProductBO.Measurement1Text & " " & BasicMeasureUnitShort
            End If

            If M_ProductBO.Measurement2Text.Length = 0 Then
                LblMeasure2.Visible = False
                TxtMeasure2.Visible = False
            Else
                LblMeasure2.Visible = True
                TxtMeasure2.Visible = True
                LblMeasure2.Text = M_ProductBO.Measurement2Text
                TxtMeasure2.Text = M_ProductBO.Measurement2Text & " " & BasicMeasureUnitShort
            End If

            If M_ProductBO.Measurement3Text.Length = 0 Then
                LblMeasure3.Visible = False
                TxtMeasure3.Visible = False
            Else
                LblMeasure3.Visible = True
                TxtMeasure3.Visible = True
                LblMeasure3.Text = M_ProductBO.Measurement3Text
                TxtMeasure3.Text = M_ProductBO.Measurement1Text & " " & BasicMeasureUnitShort
            End If

            If M_ProductBO.MeasurementFinalText.Length = 0 Then
                LblMeasureFinal.Visible = False
                TxtMeasureFinal.Visible = False
            Else
                LblMeasureFinal.Visible = True
                TxtMeasureFinal.Visible = True
                LblMeasureFinal.Text = M_ProductBO.MeasurementFinalText
                TxtMeasure3.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Txt_ClientID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_ClientID.KeyDown
        If e.KeyCode = Keys.F3 Then
            SMARTtBR_MDI.Search(Me, 10, 1, Txt_ClientID, SMARTtBR_MDI.Enm_SearchProperty.Text) ' Supplier Search
        End If
    End Sub

    Private Sub Txt_ClientID_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_ClientID.Validating
        Try
            If Val(Txt_ClientID.Text) = 0 Then
                Txt_ClientID.Text = ""
                TxtClientName.Text = ""
                TxtClientPhone.Text = ""
                M_CMAccCode = 0
                M_CMCreditEnabled = "N"
            Else
                TxtClientName.Text = ""
                TxtClientPhone.Text = ""
                M_CMAccCode = 0
                M_CMCreditEnabled = "N"
                Call Load_CustDtls(Val(Txt_ClientID.Text), "")
                If TxtClientName.Text.Length = 0 And Val(Txt_ClientID.Text) <> 0 Then
                    MessageBox.Show("Invalid Customer...")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Btn_Add_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmd_Add.KeyDown
        If e.KeyCode = Keys.Enter Then
            'BtnAdd_Click(sender, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        'Dim M_InvReportsBL As New InvReportsBL
        'Dim M_DataSet As DataSet
        'Try
        '    M_DataSet = M_InvReportsBL.ProcRpt_InvRec(M_OrgBrCode, Cmb_PrintType.SelectedValue, M_TranID, User_ID, Me.Tag)
        '    If Cmb_PrintType.Text.ToUpper.Substring(100, 1) = "Y" Then
        '        If MsgBox("Do You Want To Print.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "SMART BiZ") = MsgBoxResult.Yes Then
        '            Call PrintContinuous(M_DataSet, User_ID, Me.Tag)
        '        End If
        '    Else
        '        Call DisplayCrystalReport(M_DataSet, Me.Tag)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub


    Private Function Validate_StockStatus() As Boolean
        'Dim M_BatchTbl As DataTable
        'Dim M_Dr As DataRow
        Dim PrQty As Double = 0
        Dim CurQty As Double = 0
        Dim Result As Boolean = False
        Try
            'If M_EntryMode = "VIEW" Then
            '    M_Dr = M_TranTbl.Rows(Dgv_TranDetails.SelectedRows(0).Index)
            '    M_BatchTbl = M_TranMasterBL.Locate_Batch(M_Dr("Stk_BatchNo").ToString, M_OrgBrCode, False)
            '    PrQty = Val(M_BatchTbl.Rows(0)("Stk_ITQty").ToString)
            '    CurQty = Val(M_BatchTbl.Rows(0)("Stk_Qty").ToString)
            '    If PrQty <> CurQty And User_TypeID <> 0 Then
            '        MessageBox.Show("The item Can't Modify or Delete...!!!!" & vbNewLine & "Batch No :" & M_Dr("Stk_BatchNo"), "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Result = True
            '    End If
            'End If
            Return Result
        Catch ex As Exception
        End Try
    End Function

    Private Sub Txt_Mrp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Call CalcItemTot()
    End Sub

    Private Function Validate_PurchaseOrder() As Boolean
        'Dim M_DataSet As System.Data.DataSet
        'Dim M_Dt As DataTable
        'Dim M_PurchaseOrder As New PurchaseOrderMasterBL
        'Dim bResult As Boolean = False
        'Try
        '    M_DataSet = M_PurchaseOrder.Proc_ValidatePODetails(M_OrgBrCode, Val(Txt_POID.Text), Val(Txt_ClientID.Text), M_ClientType, M_TranID)
        '    If Not M_DataSet Is Nothing Then
        '        M_Dt = M_DataSet.Tables(0)
        '        If M_Dt.Rows.Count > 0 Then
        '            If M_Dt.Rows(0).Item("R_Status").ToString = "N" Then
        '                If M_Dt.Rows(0).Item("R_Message").ToString <> "" Then MessageBox.Show(M_Dt.Rows(0).Item("R_Message").ToString, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                bResult = False
        '            Else
        '                If M_Dt.Rows(0).Item("R_Message").ToString <> "" Then MessageBox.Show(M_Dt.Rows(0).Item("R_Message").ToString, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                bResult = True
        '            End If
        '        End If
        '    End If
        '    Return bResult
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK)
        '    Return bResult
        'End Try
        Validate_PurchaseOrder = True
    End Function

    Private Sub Txt_PrdCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_PrdCode.KeyDown
        If e.KeyCode = Keys.F3 Then
            SMARTtBR_MDI.Search(Me, 11, 1, Txt_PrdCode, SMARTtBR_MDI.Enm_SearchProperty.Text) ' Purchase Product Search
        End If
    End Sub

    Private Sub Txt_PrdCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Txt_PrdCode.Validating
        Try
            LblMeasure1.Text = ""
            TxtMeasure1.Text = ""
            LblMeasure2.Text = ""
            TxtMeasure2.Text = ""
            LblMeasure3.Text = ""
            TxtMeasure3.Text = ""
            LblMeasureFinal.Text = ""
            TxtMeasureFinal.Text = ""
            Txt_PrdName.Tag = ""
            TxtMeasureFinal.Tag = ""

            If Val(Txt_PrdCode.Text) = 0 Then
                Txt_PrdCode.Text = ""
            Else
                Call Load_ProductDetails(Val(Txt_PrdCode.Text))
                If Txt_PrdName.Text.Length = 0 And Val(Txt_PrdCode.Text) <> 0 Then
                    MessageBox.Show("Invalid Product...")
                    e.Cancel = True
                End If
            End If

            If M_ProductBO.Measurement1Text.Length > 0 Then
                LblMeasure1.Text = M_ProductBO.Measurement1Text
                TxtMeasure1.Text = M_ProductBO.Measurement1Value.ToString() & " " & BasicMeasureUnitShort
            End If

            If M_ProductBO.Measurement2Text.Length > 0 Then
                LblMeasure2.Text = M_ProductBO.Measurement2Text
                TxtMeasure2.Text = M_ProductBO.Measurement2Value.ToString() & " " & BasicMeasureUnitShort
            End If

            If M_ProductBO.Measurement3Text.Length > 0 Then
                LblMeasure3.Text = M_ProductBO.Measurement3Text
                TxtMeasure3.Text = M_ProductBO.Measurement3Value.ToString() & " " & BasicMeasureUnitShort
            End If

            If M_ProductBO.MeasurementFinalText.Length > 0 Then
                LblMeasureFinal.Text = M_ProductBO.MeasurementFinalText
                TxtMeasureFinal.Tag = M_ProductBO.MeasurementFinalValue
            End If

            Txt_PrdName.Tag = M_ProductBO.ProductNameDetailed

        Catch ex As Exception
        End Try
    End Sub


    Private Sub TxtDiscountOnTotal_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtDiscountOnTotal.Validating
        CalcFinalTotal()
    End Sub

    Private Sub TxtFrieght_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtFrieght.Validating
        CalcFinalTotal()
    End Sub

    Private Sub Chk_AutoRoundOff_Click(sender As Object, e As EventArgs) Handles Chk_AutoRoundOff.Click
        CalcFinalTotal()
    End Sub

    Private Sub TxtRoundoff_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtRoundoff.Validating
        CalcFinalTotal()
    End Sub

    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        Dim M_TranMaster As New SMARTtBR_BO.TranMasterBO
        Dim MasterBL As New TranMasterBL

        If ValidateControls() = False Then Exit Sub

        Try
            Cmd_Save.Enabled = False  ''Disable Save Button

            With M_TranMaster
                .TranID = Val(TxtBillNo.Text)
                .BillNo = Val(TxtBillNo.Text)
                .TrDate = Dtp_BillDate.Value
                .ClientID = Val(Txt_ClientID.Text)
                .ShipmentAddress = TxtShippingAddress.Text
                .BillingAddress = TxtBillingAddress.Text
                .InvoiceDate = Dtp_InvDate.Value
                .InvoiceNumber = TxtInvNo.Text
                .RoundOff = Val(TxtRoundoff.Text)
                .GrossAmount = Val(TxtGrTot.Text)
                .NetAmount = Val(TxtNetAmt.Text)
                .Frieght = Val(TxtFrieght.Text)
                .DiscountOnTotal = Val(TxtDiscountOnTotal.Text)
                .CurrencyEntryID = M_CurrencyEntryID
                .Remarks = TxtNarration.Text
                .AutoRoundOff = Chk_AutoRoundOff.Checked
                .MakerID = User_ID
                .UpdaterId = IIf(M_EntryMode = "NEW", 0, User_ID)
            End With            Dim M_TranSw As New IO.StringWriter
            M_TranTbl.WriteXml(M_TranSw)            M_TranID = M_TranMasterBL.Save_Data(M_TranMaster, M_EntryMode, Me.Tag, M_TranSw.ToString.Replace("DocumentElement", "NewDataSet"))            If M_TranID > 0 Then                MessageBox.Show("Data Saved... ID : " & M_TranID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)                Call Clear_Controls()                Call Fill_Details()                M_TranMasterBL = Nothing                TxtBillNo.Focus()            End If
        Catch ex As Exception
            Cmd_Save.Enabled = True  ''Enable Save Button
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class


