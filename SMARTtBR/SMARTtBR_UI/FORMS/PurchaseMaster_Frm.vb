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
        Dim M_Product As New DataTable
        Try

            'Call Fill_InvTranMode(Cmb_TranMode)
            'Call Fill_TaxGroup(Cmb_TaxGroup)

            'M_Product = M_CommonBL.Fill_Product(Cmb_Item, Company_Code, False, "Y", "", "", M_ClientType)
            'ProductList.AddRange((From This In M_Product.AsEnumerable Select This.Field(Of String)("Pr_Name")).ToArray)
            'Cmb_Item.DropDownStyle = ComboBoxStyle.DropDown
            'Cmb_Item.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            'Cmb_Item.AutoCompleteSource = AutoCompleteSource.CustomSource
            'Cmb_Item.AutoCompleteCustomSource = ProductList

            'M_CommonBL.Fill_DiscType(CmbDiscQtyType, Company_Code, CommonBL.EnmTrType.Purchase, "QTY")
            'M_CommonBL.Fill_DiscType(Cmb_DiscOthType, Company_Code, CommonBL.EnmTrType.Purchase, "OTH")
            'M_CommonBL.Fill_TaxType(CmbTaxType, Company_Code, CommonBL.EnmTrType.Purchase, Cmb_TaxGroup.Text)

            'M_CommonBL.Fill_ReportName(Cmb_PrintType, 2)

            'Call Fill_FormNo(Cmb_FormNo, "P", False)
            'If Cmb_FormNo.Items.Count > 0 Then Cmb_FormNo.SelectedValue = "8"

            M_TranTbl = M_TranMasterBL.Fill_TranGrid(M_TranID)
            'M_BillTbl = M_TranMasterBL.Fill_BillMaster(M_TranID)
            'M_PayTbl = M_TranMasterBL.Fill_PayGrid(M_TranID)
            'M_InvExpTbl = M_TranMasterBL.Fill_InvExpGrid(M_TranID)

            Call GridBind()
            M_EntryMode = "NEW"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Cmb_Item_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim M_Product As New DataTable
        Try
            If e.KeyCode = Keys.F5 Then

                'M_Product = M_CommonBL.Fill_Product(Cmb_Item, Company_Code, False, "Y", "", "", M_ClientType)
                'ProductList.AddRange((From This In M_Product.AsEnumerable Select This.Field(Of String)("Pr_Name")).ToArray)
                'Cmb_Item.DropDownStyle = ComboBoxStyle.DropDown
                'Cmb_Item.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                'Cmb_Item.AutoCompleteSource = AutoCompleteSource.CustomSource
                'Cmb_Item.AutoCompleteCustomSource = ProductList
                'Cmb_Item.SelectedIndex = -1
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Cmb_Item_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim M_ProductTbl As DataTable
        Dim M_Dr() As DataRow
        Dim ProfitPerc As Double
        Dim M_BatchTbl As DataTable
        Dim Mrp As Double = 0
        Dim SP As Double = 0
        Dim M_BatchExists As Boolean = False

        Try
            'Pnl_PrchDetails.Visible = False
            Print("")

            '    If Cmb_Item.Items.Count = 0 Or Cmb_Item.ValueMember.Length = 0 Then Cmb_DiscOthType.Focus() : Exit Sub

            '    If Val(Cmb_Item.SelectedValue) > 0 Then
            '        M_ProductTbl = Cmb_Item.DataSource
            '        M_Dr = M_ProductTbl.Select("Pr_ID=" & Cmb_Item.SelectedValue.ToString)
            '        If UBound(M_Dr) >= 0 Then
            '            Txt_Height.Text = M_Dr(0)("Unit_Name").ToString
            '            CmbTaxType.SelectedValue = M_Dr(0)("Pr_PTax").ToString
            '            CmbTaxType.Tag = M_Dr(0)("Pr_TaxInclusive").ToString
            '            ProfitPerc = Val(M_Dr(0)("Pr_ProfitPerc").ToString)
            '            Txt_ProfitPerc.Text = Format(ProfitPerc, "#0.00")
            '            ExpInDays = Val(M_Dr(0)("Pr_ExpInDays").ToString)
            '            FRCStatus = (M_Dr(0)("Pr_FRCStatus").ToString = "Y")
            '            Call CalcExpDate()

            '            M_BatchTbl = M_CommonBL.Fill_BatchDtls(Cmb_Item.SelectedValue.ToString, M_OrgBrCode, Nothing, False, "P", "D")
            '            If M_BatchTbl.Rows.Count > 0 Then
            '                M_BatchExists = True
            '                Mrp = Val(M_BatchTbl.Rows(0)("Stk_Mrp").ToString)
            '                Txt_Mrp.Text = Format(Mrp, "#0.00")
            '                Txt_SP.Text = Format(Mrp, "#0.00")
            '                Txt_BuyingPrice.Text = Format(Val(M_BatchTbl.Rows(0)("Stk_PRate").ToString), "#0.00")
            '            Else
            '                M_BatchExists = False
            '                Txt_Mrp.Text = Format(Mrp, "#0.00")
            '                Txt_SP.Text = Format(Mrp, "#0.00")
            '                Txt_BuyingPrice.Text = Format(Mrp, "#0.00")
            '            End If

            '            If User_TypeID < 2 Then
            '                Txt_Mrp.TabStop = True
            '                Txt_Mrp.ReadOnly = False
            '                Txt_SP.TabStop = True
            '                Txt_SP.ReadOnly = False
            '            Else
            '                If PrchMRPEdit_Allowed Then
            '                    Txt_Mrp.TabStop = True
            '                    Txt_Mrp.ReadOnly = False
            '                    Txt_SP.TabStop = True
            '                    Txt_SP.ReadOnly = False
            '                Else
            '                    If M_BatchExists Then
            '                        Txt_Mrp.TabStop = (FRCStatus = False)
            '                        Txt_Mrp.ReadOnly = (FRCStatus = True)
            '                        Txt_SP.TabStop = (FRCStatus = False)
            '                        Txt_SP.ReadOnly = (FRCStatus = True)
            '                    Else
            '                        Txt_Mrp.TabStop = True
            '                        Txt_Mrp.ReadOnly = False
            '                        Txt_SP.TabStop = True
            '                        Txt_SP.ReadOnly = False
            '                    End If
            '                End If
            '            End If
            '            Show_PurchaseHistory(Cmb_Item.SelectedValue.ToString)
            '        End If
            '        If CmbTaxType.SelectedIndex < 0 Then CmbTaxType.SelectedIndex = 0
            '    End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '    Public Sub Show_PurchaseHistory(ByVal ItemID As Integer)
    '        Dim PurchaseHistTbl As DataTable
    '        Dim Col As Integer
    '        Dim DgCol As DataGridViewColumn

    '        Try
    '            PurchaseHistTbl = M_TranMasterBL.PurchaseHistory(ItemID, M_OrgBrCode)
    '            Dgd_PrchDetails.DataSource = PurchaseHistTbl

    '            If PurchaseHistTbl.Rows.Count > 0 Then
    '                Pnl_PrchDetails.Visible = True

    '                For Col = 0 To Dgd_PrchDetails.Columns.Count - 1
    '                    DgCol = Dgd_PrchDetails.Columns(Col)
    '                    If DgCol.Name = "Pr_ID" Or DgCol.Name = "Br_Code" Then
    '                        Dgd_PrchDetails.Columns(Col).Visible = False
    '                    ElseIf DgCol.Name = "MRP" Or DgCol.Name = "Prch Price" Then
    '                        DgCol.Width = 100
    '                        DgCol.DefaultCellStyle.Format = "n2"
    '                        DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    ElseIf DgCol.Name = "Supplier" Then
    '                        DgCol.HeaderText = "Supplier"
    '                        DgCol.Width = 100
    '                    End If

    '                    If DgCol.ValueType Is GetType(System.Int64) Or DgCol.ValueType Is GetType(System.Int32) Or DgCol.ValueType Is GetType(System.Int16) Then
    '                        DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '                    ElseIf DgCol.ValueType Is GetType(System.String) Then
    '                        DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '                    ElseIf DgCol.ValueType Is GetType(Double) Or DgCol.ValueType Is GetType(System.Decimal) Then
    '                        DgCol.DefaultCellStyle.Format = "n2"
    '                        DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                    ElseIf DgCol.ValueType Is GetType(Date) Then
    '                        If UCase(DgCol.Name.ToString).Contains("TIME") Then
    '                            DgCol.DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss"
    '                        Else
    '                            DgCol.DefaultCellStyle.Format = "dd/MM/yyyy"
    '                        End If
    '                    End If
    '                Next Col

    '                Dgd_PrchDetails.Refresh()
    '            Else
    '                Pnl_PrchDetails.Visible = False
    '            End If
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End Sub

    '    Public Sub CalcExpDate()
    '        Dim ExpDate As Date

    '        ExpDate = DateAdd(DateInterval.Day, ExpInDays, Dtp_ManufacturingDate.Value)
    '        Dtp_ExpiryDate.Value = ExpDate
    '    End Sub

    '    Private Sub CmbDiscQtyType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Try
    '            Dim DiscPercent As Double = 0
    '            Dim M_Dr As DataRow
    '            If CmbDiscQtyType.Items.Count = 0 Or CmbDiscQtyType.ValueMember.Length = 0 Then Exit Sub

    '            If CmbDiscQtyType.SelectedIndex >= 0 Then
    '                If UBound(CmbDiscQtyType.DataSource.Select("DT_ID='" & CmbDiscQtyType.SelectedValue & "'")) >= 0 Then
    '                    M_Dr = CmbDiscQtyType.DataSource.Select("DT_ID='" & CmbDiscQtyType.SelectedValue & "'")(0)
    '                    If M_Dr Is Nothing Then
    '                        DiscPercent = 0
    '                    Else
    '                        DiscPercent = Val(M_Dr("DT_Rate").ToString)
    '                    End If
    '                End If
    '            End If
    '            TxtDiscQtyPercent.Text = Format(DiscPercent, "#0.00")
    '            Call CalcItemTot()
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    '    Private Sub CmbTaxType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Dim TaxPercent As Double
    '        Try
    '            If CmbTaxType.Items.Count = 0 Or CmbTaxType.ValueMember.Length = 0 Then Exit Sub

    '            If CmbTaxType.SelectedIndex >= 0 And CmbTaxType.DisplayMember.Length > 0 Then
    '                TaxPercent = CDbl(CmbTaxType.Text.Substring(100).ToString)
    '                TxtTaxPercent.Text = Format(TaxPercent, "#0.00")
    '            End If
    '            Call CalcItemTot()
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    '    Private Sub CmbTaxGrp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        M_CommonBL.Fill_TaxType(CmbTaxType, Company_Code, CommonBL.EnmTrType.Purchase, Cmb_TaxGroup.Text)
    '    End Sub

    Private Sub Clear_Controls()
        Try
            'M_OrgBrCode = Branch_Code
            M_ActiveStatus = "Y"
            Cmd_Save.Enabled = True  ''Enable Save Button
            M_TranID = 0
            M_CMAccCode = 0
            M_CMCreditEnabled = "N"
            M_IMApproverID = User_ID
            'M_IMApprovedTime = M_CommonBL.Get_UserTime()

            'If Cmb_TaxGroup.Items.Count > 0 Then Cmb_TaxGroup.SelectedValue = Default_BranchPrchTaxGroup
            'If Cmb_TranMode.Items.Count > 0 Then Cmb_TranMode.SelectedValue = Default_BranchPrchTranMode

            TxtBillNo.Text = ""
            TxtInvNo.Text = ""
            'Txt_POID.Text = ""
            'If PurchasePO_Required Then
            '    Txt_POID.TabStop = True
            'Else
            '    Txt_POID.TabStop = False
            'End If
            Txt_ClientID.Text = ""
            TxtClientPhone.Text = ""
            TxtClientName.Text = ""
            Txt_PrdName.Tag = ""
            Txt_PrdName.Text = ""
            Dtp_BillDate.Value = Tran_Date
            Dtp_BillDate.Enabled = (User_TypeID = 0)
            Dtp_InvDate.Value = Tran_Date
            'If CmbTaxType.Items.Count > 0 Then CmbTaxType.SelectedIndex = 0
            'If Cmb_FormNo.Items.Count > 0 Then Cmb_FormNo.SelectedValue = "8"
            Call Clear_ItemControls()

            M_TranTbl = M_TranTbl.Clone
            M_BillTbl = M_BillTbl.Clone
            M_PayTbl = M_PayTbl.Clone
            'M_InvExpTbl = M_TranMasterBL.Fill_InvExpGrid(M_TranID)

            'Call GridBind()

            'If Cmb_Item.Items.Count > 0 Then Cmb_Item.SelectedIndex = -1
            'If Cmb_DiscOthType.Items.Count > 0 Then Cmb_DiscOthType.SelectedValue = Default_BranchPrchDiscType

            TxtNarration.Text = ""
            ' Txt_Mrp.Text = "0.00"
            TxtPkgAmt.Text = "0.00"
            TxtHandlingAmt.Text = "0.00"

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
            TxtRoundoff.Text = "0.00"

            M_EntryMode = "NEW"

            ExpInDays = 0

            Call CalcFinalTotal()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub Clear_ItemControls()
        Try
            Cmd_Add.Enabled = True
            'Cmb_Item.SelectedIndex = -1
            'Cmb_Item.Text = ""
            'If CmbTaxType.Items.Count > 0 Then CmbTaxType.SelectedIndex = 0
            'If Cmb_DiscOthType.Items.Count > 0 Then CmbDiscQtyType.SelectedIndex = 0
            'Txt_SP.Text = ""
            Txt_PrdCode.Text = ""
            LblMeasure1.Visible = False
            TxtMeasure1.Visible = True
            TxtMeasure1.Text = ""
            LblMeasure2.Visible = False
            TxtMeasure2.Visible = True
            TxtMeasure2.Text = ""
            LblMeasure3.Visible = False
            TxtMeasure3.Visible = True
            TxtMeasure3.Text = ""
            LblMeasureFinal.Visible = False
            TxtMeasureFinal.Visible = True
            TxtMeasureFinal.Text = ""
            TxtQty.Text = "0.000"
            TxtRate.Text = ""
            'Txt_Mrp.Text = "0.00"
            'Txt_LandingCostPerUnit.Text = "0.00"
            'Txt_BatchNo.Text = ""
            'Txt_BatchNo.Tag = ""
            Txt_Description.Text = ""
            M_SlNo = 0
            'Pnl_PrchDetails.Visible = False
            'Call CalcItemTot()
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

            Dim M_TranSw As New IO.StringWriter
            M_TranTbl.WriteXml(M_TranSw)
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
        Dim M_Dr() As DataRow
        Try
            If Val(TxtQty.Text) <= 0 Then
                MessageBox.Show("Invalid Quantity, Please check..", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TxtQty.Focus()
                Exit Function

                'If Cmb_Item.SelectedValue > 0 Then
                '    M_Dr = M_TranTbl.Select("IT_ItemID=" & Cmb_Item.SelectedValue.ToString)

                '    If Val(Txt_BuyingPrice.Text) <= 0 Then
                '        MessageBox.Show("Invalid Buying Price, Please check..", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        Txt_BuyingPrice.Focus()
                '        Exit Function
                '    End If


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
            'M_Dr("Pr_Name") = Cmb_Item.Text
            'M_Dr("SOPItem") = ""
            'M_Dr("IT_PCID") = 0
            'M_Dr("IT_IMID") = 0
            'M_Dr("IT_StkID") = Val(Txt_BatchNo.Tag)
            'M_Dr("Stk_BatchNo") = Txt_BatchNo.Text
            'M_Dr("IT_ItemID") = Val(Cmb_Item.SelectedValue)
            'M_Dr("IT_Qty") = Val(TxtQty.Text)
            'M_Dr("IT_DiscID") = CmbDiscQtyType.SelectedValue
            'M_Dr("IT_DiscPer") = Val(TxtDiscQtyPercent.Text)
            'M_Dr("IT_DiscAmount") = Val(TxtDiscQtyAmt.Text)
            'M_Dr("IT_TaxID") = CmbTaxType.SelectedValue
            'M_Dr("IT_TaxPer") = Val(TxtTaxPercent.Text)
            'M_Dr("IT_TaxAmount") = Val(TxtTaxAmt.Text)

            'M_Dr("IT_CGSTPer") = 0
            'M_Dr("IT_CGSTAmount") = 0
            'M_Dr("IT_SGSTPer") = 0
            'M_Dr("IT_SGSTAmount") = 0

            'M_Dr("IT_UnitPriceWOT") = Val(Txt_BuyingPrice.Text)
            'M_Dr("IT_UnitPriceWT") = Val(TxtItemGrTot.Text) / Val(TxtQty.Text)
            'M_Dr("IT_ValueWOT") = Val(TxtTotAmt.Text)
            'M_Dr("IT_ValueWT") = Val(TxtItemGrTot.Text)
            'M_Dr("IT_Mrp") = Val(Txt_Mrp.Text)
            'M_Dr("IT_SP") = Val(Txt_SP.Text)
            'M_Dr("IT_Nraation") = Txt_Description.Text.Trim
            'M_Dr("Stk_MFDate") = CDate(Dtp_ManufacturingDate.Value)
            'M_Dr("Stk_EXPDate") = CDate(Dtp_ExpiryDate.Value)
            'M_Dr("Stk_PRate") = Val(Txt_BuyingPrice.Text)
            'M_Dr("Active_Status") = "Y"

            'M_Dr("Stk_QtyPerUnit") = 0
            'M_Dr("Stk_LandingCost") = Val(Txt_LandingCostPerUnit.Text)
            'M_Dr("Stk_IMDate") = "01/01/1900"
            'M_Dr("Stk_ITSlNo") = 0
            'M_Dr("Stk_IMID") = 0
            'M_Dr("DT_Type") = ""
            'M_Dr("DT_Name") = ""
            'M_Dr("DT_Group") = ""
            'M_Dr("Typ_Name") = ""
            'M_Dr("Typ_StockFactor") = 0
            'M_Dr("Unit_ID") = 0


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
            'Dgv_TranDetails.AutoResizeRow = DataGridViewAutoSizeRowMode.AllCells
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
                    DgCol.Width = 110
                ElseIf DgCol.Name = "DiscountPercent" Then
                    DgCol.HeaderText = "Discount%"
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
        Dim DiscPercent As Double
        Dim DiscAmt As Double
        Dim GrTot As Double
        Dim Roundoff As Double
        Dim NetTot As Double
        Dim TotQty As Double = 0
        Try
            'TxtGrTotWOT.Text = "0.00"
            'TxtGrDisc.Text = "0.00"
            'TxtGrDisc.Text = "0.00"
            'TxtGrTax.Text = "0.00"
            'TxtGrTotWT.Text = "0.00"

            If M_TranTbl.Rows.Count > 0 Then
                objSum = M_TranTbl.Compute("Sum(IT_ValueWOT)", "")
                'TxtGrTotWOT.Text = Format(Val(objSum.ToString()), "#0.00")
                objSum = M_TranTbl.Compute("Sum(IT_DiscAmount)", "")
                'TxtGrDisc.Text = Format(Val(objSum.ToString()), "#0.00")
                objSum = M_TranTbl.Compute("Sum(IT_TaxAmount)", "")
                'TxtGrTax.Text = Format(Val(objSum.ToString()), "#0.00")
                objSum = M_TranTbl.Compute("Sum(IT_ValueWT)", "")
                'TxtGrTotWT.Text = Format(Val(objSum.ToString()), "#0.00")
                objSum = M_TranTbl.Compute("Sum(IT_Qty)", "")
                TotQty = Val(objSum.ToString())
            End If

            Txt_TotalQty.Text = Format(TotQty, "#0.000")

            'DiscPercent = Val(TxtDiscOthPercent.Text)
            'If Get_CalcType(Cmb_DiscOthType.DataSource, IIf(Cmb_DiscOthType.SelectedIndex >= 0, Cmb_DiscOthType.SelectedValue, 0)) = "V" Then
            '    DiscAmt = (Val(TxtGrTotWOT.Text) * DiscPercent / 100)
            'Else
            '    DiscAmt = DiscPercent
            'End If
            Txt_TotalValue.Text = Format(DiscAmt, "#0.00")

            'GrTot = Val(TxtGrTotWOT.Text) - Val(TxtDiscOthAmt.Text) + Val(TxtPkgAmt.Text) + Val(TxtHandlingAmt.Text)
            'TxtGrTot.Text = Format(GrTot, "#0.00")

            'NetTot = Val(TxtGrTot.Text) + Val(TxtGrTax.Text)

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
        'Call CalcItemTot()
    End Sub

    Public Sub CalcItemTot(Optional ByVal SP As Double = 0)
        Dim Qty As Double = 0
        Dim BP As Double = 0 ' Buying Price
        Dim TotalAmt As Double = 0
        Dim DiscPercent As Double = 0
        Dim DiscAmt As Double = 0
        Dim TaxPercent As Double = 0
        Dim TaxAmt As Double = 0
        Dim TotWithTax As Double = 0
        Dim ProfitPercent As Double = 0
        Dim LandingCost As Double = 0

        Try
            Qty = Val(TxtQty.Text)
            BP = Val(TxtRate.Text)
            'ProfitPercent = Val(Txt_ProfitPerc.Text)

            'If Val(Txt_SP.Text) = 0 Then
            '    SP = Val(Txt_Mrp.Text)
            'Else
            '    SP = Val(Txt_SP.Text)
            'End If

            'TaxPercent = Val(TxtTaxPercent.Text)
            'TotalAmt = Qty * BP

            'DiscPercent = Val(TxtDiscQtyPercent.Text)
            'DiscAmt = (TotalAmt * DiscPercent / 100)
            'TxtDiscQtyAmt.Text = Format(DiscAmt, "#0.00")

            'TotalAmt = TotalAmt - Val(TxtDiscQtyAmt.Text)

            'Select Case Cmb_TaxGroup.SelectedValue
            '    Case "VAT", "CST"
            '        If TaxPercent > 0 Then
            '            TaxAmt = (TotalAmt * TaxPercent / 100)
            '        End If
            '    Case "GST"
            '        If TaxPercent > 0 Then
            '            TaxPercent = TaxPercent / 2
            '            TaxAmt = (TotalAmt * TaxPercent / 100)
            '            TaxAmt = System.Math.Round(TaxAmt, 2)
            '            TaxAmt = TaxAmt * 2
            '        End If
            'End Select

            'TxtTotAmt.Text = Format(TotalAmt, "#0.00")

            'TxtTaxAmt.Text = Format(TaxAmt, "#0.00")

            'TotWithTax = TotalAmt + TaxAmt

            'LandingCost = IIf(Val(TotWithTax / Qty) > 0, Val(TotWithTax / Qty), 0)

            'Txt_LandingCostPerUnit.Text = Format(LandingCost, "#0.00")

            'TxtItemGrTot.Text = Format(TotWithTax, "#0.00")

            'Txt_SP.Text = Format(SP, "#0.00")

        Catch ex As Exception
        End Try
    End Sub

    '    Private Sub Cmb_Item_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '        Call Cmb_Item_SelectedIndexChanged(sender, System.EventArgs.Empty)
    '        If Cmb_Item.SelectedIndex = -1 Then Me.ActiveControl = Cmb_DiscOthType
    '    End Sub

    '    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click, Cmd_Save.KeyDown
    '        Dim M_InvMaster As New SMARTtBR_BO.InvMasterBO

    '        If ValidateControls() = False Then Exit Sub

    '        If PrchExpEntry_Allow Then
    '            Dim FrmExp As New InvExpDetails_Frm
    '            FrmExp.M_InvExpTbl = M_InvExpTbl
    '            FrmExp.StartPosition = FormStartPosition.CenterParent
    '            FrmExp.ShowDialog(Me)
    '            M_InvExpTbl = FrmExp.M_InvExpTbl
    '            FrmExp = Nothing
    '        End If

    '        Dim FrmPay As New Payment_Frm
    '        FrmPay.IMID = M_TranID
    '        FrmPay.M_CMAccCode = M_CMAccCode
    '        FrmPay.M_CMCreditEnabled = M_CMCreditEnabled
    '        FrmPay.OrgBrCode = M_OrgBrCode
    '        FrmPay.NetTotal = Val(TxtNetAmt.Text)
    '        FrmPay.M_PayTbl = M_PayTbl
    '        FrmPay.StartPosition = FormStartPosition.CenterParent
    '        FrmPay.ShowDialog(Me)

    '        Try
    '            If FrmPay.M_Ok = False Then Exit Sub

    '            M_PayTbl = FrmPay.M_PayTbl
    '            FrmPay = Nothing

    '            If M_PayTbl Is Nothing Then
    '                MessageBox.Show("Invalid Pay Details..... Please Check")
    '                Exit Sub
    '            End If

    '            If M_PayTbl.Rows.Count = 0 Then
    '                MessageBox.Show("Invalid Pay Details..... Please Check")
    '                Exit Sub
    '            End If

    '            Cmd_Save.Enabled = False  ''Disable Save Button

    '            Dim M_PaySw As New IO.StringWriter
    '            M_PayTbl.WriteXml(M_PaySw)

    '            With M_InvMaster
    '                .BrCode = M_OrgBrCode
    '                .IMType = M_ClientType
    '                .MakerID = User_ID
    '                If M_EntryMode = "VIEW" Then
    '                    .UpdaterID = User_ID
    '                Else
    '                    .UpdaterID = 0
    '                End If
    '                .IMDate = Dtp_BillDate.Value
    '                .IMID = M_TranID
    '                .IMNo = Val(TxtBillNo.Text)
    '                .IMIssueID = 0
    '                .IMModalID = 0
    '                .IMClientID = Val(Txt_ClientID.Text)
    '                .IMNarration = TxtNarration.Text
    '                .IMApproverID = M_IMApproverID
    '                .IMApprovedTime = M_IMApprovedTime
    '                .ActiveStatus = M_ActiveStatus
    '                .ClientName = TxtClientName.Text
    '                .ClientPhone = TxtClientPhone.Text
    '                .IMPOID = Val(Txt_POID.Text)
    '            End With


    '            Dim M_TranMasterBL As New TranMasterBL
    '            Dim M_TranSw As New IO.StringWriter
    '            M_TranTbl.WriteXml(M_TranSw)

    '            Dim M_Dr As DataRow
    '            M_BillTbl.Clear()
    '            M_Dr = M_BillTbl.NewRow

    '            M_Dr("Br_Code") = M_OrgBrCode
    '            M_Dr("IM_ID") = M_TranID
    '            M_Dr("BL_Type") = M_ClientType
    '            M_Dr("BL_TranMode") = Cmb_TranMode.SelectedValue
    '            M_Dr("BL_TaxGroup") = Cmb_TaxGroup.SelectedValue
    '            M_Dr("BL_FormNo") = Cmb_FormNo.SelectedValue
    '            M_Dr("BL_No") = Val(TxtBillNo.Text)
    '            M_Dr("BL_Date") = Dtp_BillDate.Value.Date
    '            M_Dr("BL_DocNo") = TxtInvNo.Text.Trim
    '            M_Dr("BL_DocDate") = Dtp_InvDate.Value.Date
    '            M_Dr("BL_ClientID") = Val(Txt_ClientID.Text)
    '            M_Dr("BL_CounterNo") = 0
    '            M_Dr("BL_SmanID") = 0
    '            M_Dr("BL_Total") = Val(TxtGrTotWOT.Text)
    '            M_Dr("BL_DiscType") = Val(Cmb_DiscOthType.SelectedValue)
    '            M_Dr("BL_DiscPer") = Val(TxtDiscOthPercent.Text)
    '            M_Dr("BL_DiscAmount") = Val(Txt_TotalValue.Text)
    '            M_Dr("BL_PointDiscAmt") = 0
    '            M_Dr("BL_PointAmt") = 0
    '            M_Dr("BL_CpnDiscAmt") = 0
    '            M_Dr("BL_MiscAmt") = 0
    '            M_Dr("BL_PackCharge") = Val(TxtPkgAmt.Text)
    '            M_Dr("BL_HandlingCharge") = Val(TxtHandlingAmt.Text)
    '            M_Dr("BL_PostageCharge") = 0
    '            M_Dr("BL_FreightType") = ""
    '            M_Dr("BL_Freight") = 0
    '            M_Dr("BL_MiscAdd") = 0
    '            M_Dr("BL_MiscLess") = 0
    '            M_Dr("BL_GrandTotal") = Val(TxtGrTot.Text)
    '            M_Dr("BL_AutoRoundOff") = IIf(Chk_AutoRoundOff.Checked = True, "Y", "N")
    '            M_Dr("BL_RoundOff") = Val(TxtRoundoff.Text)
    '            M_Dr("BL_NetAmount") = Val(TxtNetAmt.Text)
    '            M_Dr("BL_AdvAmount") = 0
    '            M_Dr("BL_PDCAmount") = 0
    '            M_Dr("BL_PaidAmount") = 0
    '            M_Dr("BL_PayMode") = ""
    '            M_Dr("BL_WSRT") = ""
    '            M_Dr("BL_Narration") = TxtNarration.Text
    '            M_Dr("BL_AccId") = 0
    '            M_Dr("Active_Status") = M_ActiveStatus
    '            M_Dr("Maker_ID") = User_ID
    '            M_Dr("Making_Time") = "01/01/1900"
    '            M_Dr("Updater_ID") = 0
    '            M_Dr("Updating_Time") = "01/01/1900"

    '            If M_EntryMode = "VIEW" Then
    '                If M_BillTbl.Rows.Count > 0 Then
    '                    For Each M_DataRow As DataRow In M_BillTbl.[Select]("IM_ID=" & M_TranID.ToString)
    '                        M_Dr("BL_PDCAmount") = M_DataRow("BL_PDCAmount")
    '                        M_Dr("BL_PaidAmount") = M_DataRow("BL_PaidAmount")
    '                        M_Dr("BL_PayMode") = M_DataRow("BL_PayMode")
    '                        M_Dr("BL_WSRT") = M_DataRow("BL_WSRT")
    '                        M_Dr("BL_Narration") = TxtNarration.Text
    '                        M_Dr("BL_AccId") = M_DataRow("BL_AccId")
    '                        M_Dr("Maker_ID") = User_ID
    '                        M_Dr("Making_Time") = M_DataRow("Making_Time")
    '                    Next
    '                End If
    '                M_BillTbl.Rows.Clear()
    '            End If

    '            M_BillTbl.Rows.Add(M_Dr)

    '            Dim M_BillMasterSw As New IO.StringWriter
    '            M_BillTbl.WriteXml(M_BillMasterSw)

    '            Dim M_InvExpSw As New IO.StringWriter
    '            M_InvExpTbl.WriteXml(M_InvExpSw)

    '            M_TranID = M_TranMasterBL.Save_Data(M_InvMaster, M_EntryMode, Me.Tag, M_TranSw.ToString.Replace("DocumentElement", "NewDataSet"), M_BillMasterSw.ToString.Replace("DocumentElement", "NewDataSet"), M_PaySw.ToString.Replace("DocumentElement", "NewDataSet"), "", "", M_InvExpSw.ToString.Replace("DocumentElement", "NewDataSet"))
    '            If M_TranID > 0 Then

    '                If MsgBox("Data Saved....!!!! Do You Want To Print.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "SMART BiZ") = MsgBoxResult.Yes Then
    '                    Dim M_InvReportsBL As New InvReportsBL
    '                    Dim M_DataSet As DataSet
    '                    M_DataSet = M_InvReportsBL.ProcRpt_InvRec(M_OrgBrCode, Cmb_PrintType.SelectedValue, M_TranID, User_ID, Me.Tag)
    '                    If Cmb_PrintType.Text.ToUpper.Substring(100, 1) = "Y" Then
    '                        Call PrintContinuous(M_DataSet, User_ID, Me.Tag)
    '                    Else
    '                        Call DisplayCrystalReport(M_DataSet, Me.Tag)
    '                    End If
    '                End If

    '                Call Clear_Controls()
    '                Me.ActiveControl = TxtBillNo
    '            Else
    '                Cmd_Save.Enabled = True  ''Enable Save Button
    '            End If
    '        Catch ex As Exception
    '            Cmd_Save.Enabled = True  ''Enable Save Button
    '            FrmPay = Nothing
    '            MessageBox.Show(ex.Message)
    '        End Try
    '    End Sub

    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        If M_TranTbl.Rows.Count > 0 Then
            If MsgBox("Do You Want To Clear.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "SMART BiZ") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        'Call Clear_Controls()
        Me.ActiveControl = TxtBillNo
    End Sub

    '    Private Sub Cmb_DiscOthType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_DiscOthType.SelectedIndexChanged, TxtHandlingAmt.Validating, TxtPkgAmt.Validating, TxtRoundoff.Validating, Chk_AutoRoundOff.CheckedChanged
    '        Try
    '            If Cmb_DiscOthType.Items.Count = 0 Or Cmb_DiscOthType.ValueMember.Length = 0 Then Exit Sub

    '            Dim DiscPercent As Double = 0
    '            Dim M_Dr As DataRow
    '            If Cmb_DiscOthType.SelectedIndex >= 0 Then
    '                If UBound(Cmb_DiscOthType.DataSource.Select("DT_ID='" & Cmb_DiscOthType.SelectedValue & "'")) >= 0 Then
    '                    M_Dr = Cmb_DiscOthType.DataSource.Select("DT_ID='" & Cmb_DiscOthType.SelectedValue & "'")(0)
    '                    If M_Dr Is Nothing Then
    '                        DiscPercent = 0
    '                    Else
    '                        DiscPercent = Val(M_Dr("DT_Rate").ToString)
    '                    End If
    '                End If
    '            End If
    '            TxtDiscOthPercent.Text = Format(DiscPercent, "#0.00")
    '            Call CalcFinalTotal()
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    '    Private Sub Locate_Data(ByVal M_InvMasterBO As SMARTtBR_BO.InvMasterBO)
    '        Try
    '            If M_InvMasterBO.IMID = 0 Then
    '                M_EntryMode = "NEW"
    '                Call Clear_Controls()
    '                Exit Sub
    '            End If
    '            With M_InvMasterBO

    '                M_OrgBrCode = .BrCode
    '                M_TranID = .IMID
    '                TxtBillNo.Text = .IMNo
    '                M_ActiveStatus = .ActiveStatus
    '                TxtClientPhone.Text = ""
    '                Txt_ClientID.Text = .IMClientID
    '                Dtp_BillDate.Value = .IMDate
    '                Txt_POID.Text = .IMPOID
    '                TxtNarration.Text = .IMNarration
    '            End With

    '            Call Load_CustDtls(Val(Txt_ClientID.Text), "")

    '            M_TranTbl = M_TranMasterBL.Fill_InvTranGrid(M_TranID)
    '            M_BillTbl = M_TranMasterBL.Fill_BillMaster(M_TranID)
    '            M_PayTbl = M_TranMasterBL.Fill_PayGrid(M_TranID)
    '            M_InvExpTbl = M_TranMasterBL.Fill_InvExpGrid(M_TranID)

    '            If M_BillTbl.Rows.Count > 0 Then
    '                Cmb_TranMode.SelectedValue = M_BillTbl.Rows(0).Item("BL_TranMode")
    '                Cmb_TaxGroup.SelectedValue = M_BillTbl.Rows(0).Item("BL_TaxGroup")
    '                Cmb_FormNo.SelectedValue = M_BillTbl.Rows(0).Item("BL_FormNo")
    '                Dtp_InvDate.Value = M_BillTbl.Rows(0).Item("BL_DocDate")
    '                TxtInvNo.Text = M_BillTbl.Rows(0).Item("BL_DocNo")
    '                Cmb_DiscOthType.SelectedValue = M_BillTbl.Rows(0).Item("BL_DiscType")
    '                TxtDiscOthPercent.Text = M_BillTbl.Rows(0).Item("BL_DiscPer")
    '                Txt_TotalValue.Text = M_BillTbl.Rows(0).Item("BL_DiscAmount")
    '                TxtPkgAmt.Text = M_BillTbl.Rows(0).Item("BL_PackCharge")
    '                TxtHandlingAmt.Text = M_BillTbl.Rows(0).Item("BL_HandlingCharge")
    '                Chk_AutoRoundOff.Checked = (M_BillTbl.Rows(0).Item("BL_AutoRoundOff") = "Y")
    '                TxtRoundoff.Text = M_BillTbl.Rows(0).Item("BL_RoundOff")
    '            End If

    '            Call GridBind()
    '            Call CalcFinalTotal()

    '            M_EntryMode = "VIEW"
    '        Catch ex As Exception
    '        End Try
    '    End Sub

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
                '      Dim M_InvMasterBO As New SMARTtBR_BO.InvMasterBO
                '      Dim M_TranMasterBL As New TranMasterBL
                '      M_InvMasterBO = M_TranMasterBL.Locate_Data(M_OrgBrCode, M_ClientType, TxtBillNo.Text)
                ''      Call Locate_Data(M_InvMasterBO)
                '      M_TranMasterBL = Nothing
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
        'Call CalcItemTot()
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
        Dim M_BatchTbl As DataTable
        Dim M_Dr As DataRow
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
        Dim M_DataSet As System.Data.DataSet
        Dim M_Dt As DataTable
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
    End Function

    Private Sub Txt_PrdCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_PrdCode.KeyDown
        If e.KeyCode = Keys.F3 Then
            SMARTtBR_MDI.Search(Me, 11, 1, Txt_PrdCode, SMARTtBR_MDI.Enm_SearchProperty.Text) ' Purchase Product Search
        End If
    End Sub

    Private Sub Txt_PrdCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Txt_PrdCode.Validating
        Try
            If Val(Txt_PrdCode.Text) = 0 Then
                Txt_PrdCode.Text = ""
                LblMeasure1.Visible = False
                TxtMeasure1.Visible = True
                TxtMeasure1.Text = ""
                LblMeasure2.Visible = False
                TxtMeasure2.Visible = True
                TxtMeasure2.Text = ""
                LblMeasure3.Visible = False
                TxtMeasure3.Visible = True
                TxtMeasure3.Text = ""
                LblMeasureFinal.Visible = False
                TxtMeasureFinal.Visible = True
                TxtMeasureFinal.Text = ""
            Else
                Call Load_ProductDetails(Val(Txt_PrdCode.Text))
                If Txt_PrdName.Text.Length = 0 And Val(Txt_PrdCode.Text) <> 0 Then
                    MessageBox.Show("Invalid Product...")
                    e.Cancel = True
                End If
            End If


            If M_ProductBO.Measurement1Text.Length = 0 Then
                LblMeasure1.Visible = False
                TxtMeasure1.Visible = False
            Else
                LblMeasure1.Visible = True
                TxtMeasure1.Visible = True
                LblMeasure1.Text = M_ProductBO.Measurement1Text
                TxtMeasure1.Text = M_ProductBO.Measurement1Value.ToString() & " " & BasicMeasureUnitShort
            End If

            If M_ProductBO.Measurement2Text.Length = 0 Then
                LblMeasure2.Visible = False
                TxtMeasure2.Visible = False
            Else
                LblMeasure2.Visible = True
                TxtMeasure2.Visible = True
                LblMeasure2.Text = M_ProductBO.Measurement2Text
                TxtMeasure2.Text = M_ProductBO.Measurement2Value.ToString() & " " & BasicMeasureUnitShort
            End If

            If M_ProductBO.Measurement3Text.Length = 0 Then
                LblMeasure3.Visible = False
                TxtMeasure3.Visible = False
            Else
                LblMeasure3.Visible = True
                TxtMeasure3.Visible = True
                LblMeasure3.Text = M_ProductBO.Measurement3Text
                TxtMeasure3.Text = M_ProductBO.Measurement3Value.ToString() & " " & BasicMeasureUnitShort
            End If

            If M_ProductBO.MeasurementFinalText.Length = 0 Then
                LblMeasureFinal.Visible = False
                TxtMeasureFinal.Visible = False
            Else
                LblMeasureFinal.Visible = True
                TxtMeasureFinal.Visible = True
                LblMeasureFinal.Text = M_ProductBO.MeasurementFinalText
                TxtMeasureFinal.Text = ""
            End If

            Txt_PrdName.Tag = M_ProductBO.ProductNameDetailed

        Catch ex As Exception
        End Try
    End Sub
End Class


