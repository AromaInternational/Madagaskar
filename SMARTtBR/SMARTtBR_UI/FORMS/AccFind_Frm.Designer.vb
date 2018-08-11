<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccFind_Frm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccFind_Frm))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.PnlCoupon = New System.Windows.Forms.Panel()
        Me.Cmb_FinYear = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Narration = New System.Windows.Forms.TextBox()
        Me.Chk_Narration = New System.Windows.Forms.CheckBox()
        Me.Chk_AccountCode = New System.Windows.Forms.CheckBox()
        Me.Txt_AccName = New System.Windows.Forms.TextBox()
        Me.Txt_AccCode = New System.Windows.Forms.TextBox()
        Me.Chk_TrType = New System.Windows.Forms.CheckBox()
        Me.Cmb_AccTranType = New System.Windows.Forms.ComboBox()
        Me.Txt_AmountTo = New System.Windows.Forms.TextBox()
        Me.Txt_AmountFrom = New System.Windows.Forms.TextBox()
        Me.Chk_Amount = New System.Windows.Forms.CheckBox()
        Me.Txt_VrNoTo = New System.Windows.Forms.TextBox()
        Me.Txt_VrNoFrom = New System.Windows.Forms.TextBox()
        Me.Chk_VrNo = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dtp_DateTo = New System.Windows.Forms.DateTimePicker()
        Me.Chk_TrDate = New System.Windows.Forms.CheckBox()
        Me.Chk_TrUnit = New System.Windows.Forms.CheckBox()
        Me.Chk_VoucherType = New System.Windows.Forms.CheckBox()
        Me.Dtp_DateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Cmb_TrUnit = New System.Windows.Forms.ComboBox()
        Me.Cmb_AccVrTyp = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PnlCoupon.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.lbl_Heading)
        Me.Panel2.Location = New System.Drawing.Point(3, 7)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(358, 29)
        Me.Panel2.TabIndex = 504
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(9, 59)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(437, 52)
        Me.Panel1.TabIndex = 505
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(114, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(326, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ACCOUNT TRANSACTION FIND"
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Heading.Location = New System.Drawing.Point(10, 3)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(336, 22)
        Me.lbl_Heading.TabIndex = 0
        Me.lbl_Heading.Text = "ACCOUNT TRANSACTION SEARCH"
        '
        'PnlCoupon
        '
        Me.PnlCoupon.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PnlCoupon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlCoupon.Controls.Add(Me.Cmb_FinYear)
        Me.PnlCoupon.Controls.Add(Me.Label4)
        Me.PnlCoupon.Controls.Add(Me.Txt_Narration)
        Me.PnlCoupon.Controls.Add(Me.Chk_Narration)
        Me.PnlCoupon.Controls.Add(Me.Chk_AccountCode)
        Me.PnlCoupon.Controls.Add(Me.Txt_AccName)
        Me.PnlCoupon.Controls.Add(Me.Txt_AccCode)
        Me.PnlCoupon.Controls.Add(Me.Chk_TrType)
        Me.PnlCoupon.Controls.Add(Me.Cmb_AccTranType)
        Me.PnlCoupon.Controls.Add(Me.Txt_AmountTo)
        Me.PnlCoupon.Controls.Add(Me.Txt_AmountFrom)
        Me.PnlCoupon.Controls.Add(Me.Chk_Amount)
        Me.PnlCoupon.Controls.Add(Me.Txt_VrNoTo)
        Me.PnlCoupon.Controls.Add(Me.Txt_VrNoFrom)
        Me.PnlCoupon.Controls.Add(Me.Chk_VrNo)
        Me.PnlCoupon.Controls.Add(Me.Label2)
        Me.PnlCoupon.Controls.Add(Me.Dtp_DateTo)
        Me.PnlCoupon.Controls.Add(Me.Chk_TrDate)
        Me.PnlCoupon.Controls.Add(Me.Chk_TrUnit)
        Me.PnlCoupon.Controls.Add(Me.Chk_VoucherType)
        Me.PnlCoupon.Controls.Add(Me.Dtp_DateFrom)
        Me.PnlCoupon.Controls.Add(Me.Cmb_TrUnit)
        Me.PnlCoupon.Controls.Add(Me.Cmb_AccVrTyp)
        Me.PnlCoupon.Location = New System.Drawing.Point(3, 42)
        Me.PnlCoupon.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PnlCoupon.Name = "PnlCoupon"
        Me.PnlCoupon.Size = New System.Drawing.Size(358, 264)
        Me.PnlCoupon.TabIndex = 0
        '
        'Cmb_FinYear
        '
        Me.Cmb_FinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_FinYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmb_FinYear.FormattingEnabled = True
        Me.Cmb_FinYear.Location = New System.Drawing.Point(138, 8)
        Me.Cmb_FinYear.Name = "Cmb_FinYear"
        Me.Cmb_FinYear.Size = New System.Drawing.Size(101, 21)
        Me.Cmb_FinYear.TabIndex = 523
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(61, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 14)
        Me.Label4.TabIndex = 524
        Me.Label4.Text = "Fin.Year :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_Narration
        '
        Me.Txt_Narration.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Narration.Location = New System.Drawing.Point(138, 229)
        Me.Txt_Narration.MaxLength = 100
        Me.Txt_Narration.Name = "Txt_Narration"
        Me.Txt_Narration.Size = New System.Drawing.Size(202, 21)
        Me.Txt_Narration.TabIndex = 20
        '
        'Chk_Narration
        '
        Me.Chk_Narration.AutoSize = True
        Me.Chk_Narration.Checked = True
        Me.Chk_Narration.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Narration.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Narration.Location = New System.Drawing.Point(45, 231)
        Me.Chk_Narration.Name = "Chk_Narration"
        Me.Chk_Narration.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Chk_Narration.Size = New System.Drawing.Size(77, 17)
        Me.Chk_Narration.TabIndex = 19
        Me.Chk_Narration.Text = "Remarks"
        Me.Chk_Narration.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chk_Narration.UseVisualStyleBackColor = True
        '
        'Chk_AccountCode
        '
        Me.Chk_AccountCode.AutoSize = True
        Me.Chk_AccountCode.Checked = True
        Me.Chk_AccountCode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_AccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_AccountCode.Location = New System.Drawing.Point(16, 203)
        Me.Chk_AccountCode.Name = "Chk_AccountCode"
        Me.Chk_AccountCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Chk_AccountCode.Size = New System.Drawing.Size(107, 17)
        Me.Chk_AccountCode.TabIndex = 16
        Me.Chk_AccountCode.Text = "Account Name"
        Me.Chk_AccountCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chk_AccountCode.UseVisualStyleBackColor = True
        '
        'Txt_AccName
        '
        Me.Txt_AccName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_AccName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AccName.Location = New System.Drawing.Point(216, 199)
        Me.Txt_AccName.Name = "Txt_AccName"
        Me.Txt_AccName.ReadOnly = True
        Me.Txt_AccName.Size = New System.Drawing.Size(124, 22)
        Me.Txt_AccName.TabIndex = 18
        Me.Txt_AccName.TabStop = False
        '
        'Txt_AccCode
        '
        Me.Txt_AccCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AccCode.Location = New System.Drawing.Point(138, 199)
        Me.Txt_AccCode.Name = "Txt_AccCode"
        Me.Txt_AccCode.Size = New System.Drawing.Size(76, 22)
        Me.Txt_AccCode.TabIndex = 17
        Me.Txt_AccCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Chk_TrType
        '
        Me.Chk_TrType.AutoSize = True
        Me.Chk_TrType.Checked = True
        Me.Chk_TrType.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_TrType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_TrType.Location = New System.Drawing.Point(55, 176)
        Me.Chk_TrType.Name = "Chk_TrType"
        Me.Chk_TrType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Chk_TrType.Size = New System.Drawing.Size(69, 17)
        Me.Chk_TrType.TabIndex = 14
        Me.Chk_TrType.Text = "Tr.Type"
        Me.Chk_TrType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chk_TrType.UseVisualStyleBackColor = True
        '
        'Cmb_AccTranType
        '
        Me.Cmb_AccTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_AccTranType.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_AccTranType.FormattingEnabled = True
        Me.Cmb_AccTranType.Location = New System.Drawing.Point(138, 173)
        Me.Cmb_AccTranType.Name = "Cmb_AccTranType"
        Me.Cmb_AccTranType.Size = New System.Drawing.Size(59, 22)
        Me.Cmb_AccTranType.TabIndex = 15
        '
        'Txt_AmountTo
        '
        Me.Txt_AmountTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AmountTo.Location = New System.Drawing.Point(246, 147)
        Me.Txt_AmountTo.Name = "Txt_AmountTo"
        Me.Txt_AmountTo.Size = New System.Drawing.Size(94, 21)
        Me.Txt_AmountTo.TabIndex = 13
        Me.Txt_AmountTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_AmountFrom
        '
        Me.Txt_AmountFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AmountFrom.Location = New System.Drawing.Point(138, 147)
        Me.Txt_AmountFrom.Name = "Txt_AmountFrom"
        Me.Txt_AmountFrom.Size = New System.Drawing.Size(94, 21)
        Me.Txt_AmountFrom.TabIndex = 12
        Me.Txt_AmountFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Chk_Amount
        '
        Me.Chk_Amount.AutoSize = True
        Me.Chk_Amount.Checked = True
        Me.Chk_Amount.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_Amount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Amount.Location = New System.Drawing.Point(1, 149)
        Me.Chk_Amount.Name = "Chk_Amount"
        Me.Chk_Amount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Chk_Amount.Size = New System.Drawing.Size(123, 17)
        Me.Chk_Amount.TabIndex = 11
        Me.Chk_Amount.Text = "Amount From/To"
        Me.Chk_Amount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chk_Amount.UseVisualStyleBackColor = True
        '
        'Txt_VrNoTo
        '
        Me.Txt_VrNoTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_VrNoTo.Location = New System.Drawing.Point(247, 119)
        Me.Txt_VrNoTo.Name = "Txt_VrNoTo"
        Me.Txt_VrNoTo.Size = New System.Drawing.Size(94, 21)
        Me.Txt_VrNoTo.TabIndex = 10
        Me.Txt_VrNoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_VrNoFrom
        '
        Me.Txt_VrNoFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_VrNoFrom.Location = New System.Drawing.Point(138, 119)
        Me.Txt_VrNoFrom.Name = "Txt_VrNoFrom"
        Me.Txt_VrNoFrom.Size = New System.Drawing.Size(94, 21)
        Me.Txt_VrNoFrom.TabIndex = 9
        Me.Txt_VrNoFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Chk_VrNo
        '
        Me.Chk_VrNo.AutoSize = True
        Me.Chk_VrNo.Checked = True
        Me.Chk_VrNo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_VrNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_VrNo.Location = New System.Drawing.Point(18, 121)
        Me.Chk_VrNo.Name = "Chk_VrNo"
        Me.Chk_VrNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Chk_VrNo.Size = New System.Drawing.Size(107, 17)
        Me.Chk_VrNo.TabIndex = 8
        Me.Chk_VrNo.Text = "Vr.No From/To"
        Me.Chk_VrNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chk_VrNo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(233, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 15)
        Me.Label2.TabIndex = 522
        Me.Label2.Text = "-"
        '
        'Dtp_DateTo
        '
        Me.Dtp_DateTo.Enabled = False
        Me.Dtp_DateTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_DateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_DateTo.Location = New System.Drawing.Point(247, 92)
        Me.Dtp_DateTo.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.Dtp_DateTo.Name = "Dtp_DateTo"
        Me.Dtp_DateTo.Size = New System.Drawing.Size(94, 21)
        Me.Dtp_DateTo.TabIndex = 7
        Me.Dtp_DateTo.TabStop = False
        '
        'Chk_TrDate
        '
        Me.Chk_TrDate.AutoSize = True
        Me.Chk_TrDate.Checked = True
        Me.Chk_TrDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_TrDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_TrDate.Location = New System.Drawing.Point(5, 92)
        Me.Chk_TrDate.Name = "Chk_TrDate"
        Me.Chk_TrDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Chk_TrDate.Size = New System.Drawing.Size(120, 17)
        Me.Chk_TrDate.TabIndex = 5
        Me.Chk_TrDate.Text = "Tr.Date From/To"
        Me.Chk_TrDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chk_TrDate.UseVisualStyleBackColor = True
        '
        'Chk_TrUnit
        '
        Me.Chk_TrUnit.AutoSize = True
        Me.Chk_TrUnit.Checked = True
        Me.Chk_TrUnit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_TrUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_TrUnit.Location = New System.Drawing.Point(61, 63)
        Me.Chk_TrUnit.Name = "Chk_TrUnit"
        Me.Chk_TrUnit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Chk_TrUnit.Size = New System.Drawing.Size(64, 17)
        Me.Chk_TrUnit.TabIndex = 3
        Me.Chk_TrUnit.Text = "Tr.Unit"
        Me.Chk_TrUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chk_TrUnit.UseVisualStyleBackColor = True
        '
        'Chk_VoucherType
        '
        Me.Chk_VoucherType.AutoSize = True
        Me.Chk_VoucherType.Checked = True
        Me.Chk_VoucherType.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_VoucherType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_VoucherType.Location = New System.Drawing.Point(22, 37)
        Me.Chk_VoucherType.Name = "Chk_VoucherType"
        Me.Chk_VoucherType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Chk_VoucherType.Size = New System.Drawing.Size(103, 17)
        Me.Chk_VoucherType.TabIndex = 1
        Me.Chk_VoucherType.Text = "Voucher Type"
        Me.Chk_VoucherType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chk_VoucherType.UseVisualStyleBackColor = True
        '
        'Dtp_DateFrom
        '
        Me.Dtp_DateFrom.Enabled = False
        Me.Dtp_DateFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_DateFrom.Location = New System.Drawing.Point(138, 91)
        Me.Dtp_DateFrom.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.Dtp_DateFrom.Name = "Dtp_DateFrom"
        Me.Dtp_DateFrom.Size = New System.Drawing.Size(94, 21)
        Me.Dtp_DateFrom.TabIndex = 6
        Me.Dtp_DateFrom.TabStop = False
        '
        'Cmb_TrUnit
        '
        Me.Cmb_TrUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_TrUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_TrUnit.FormattingEnabled = True
        Me.Cmb_TrUnit.Location = New System.Drawing.Point(138, 63)
        Me.Cmb_TrUnit.Name = "Cmb_TrUnit"
        Me.Cmb_TrUnit.Size = New System.Drawing.Size(204, 21)
        Me.Cmb_TrUnit.TabIndex = 4
        '
        'Cmb_AccVrTyp
        '
        Me.Cmb_AccVrTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_AccVrTyp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_AccVrTyp.FormattingEnabled = True
        Me.Cmb_AccVrTyp.Location = New System.Drawing.Point(138, 36)
        Me.Cmb_AccVrTyp.Name = "Cmb_AccVrTyp"
        Me.Cmb_AccVrTyp.Size = New System.Drawing.Size(204, 21)
        Me.Cmb_AccVrTyp.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnCancel)
        Me.Panel3.Controls.Add(Me.BtnOK)
        Me.Panel3.Location = New System.Drawing.Point(2, 314)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(358, 39)
        Me.Panel3.TabIndex = 21
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.BtnCancel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(179, 1)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(91, 34)
        Me.BtnCancel.TabIndex = 23
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnOK
        '
        Me.BtnOK.BackColor = System.Drawing.Color.LightSteelBlue
        Me.BtnOK.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOK.Location = New System.Drawing.Point(87, 1)
        Me.BtnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(91, 34)
        Me.BtnOK.TabIndex = 22
        Me.BtnOK.Text = "&OK"
        Me.BtnOK.UseVisualStyleBackColor = False
        '
        'AccFind_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(362, 371)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PnlCoupon)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "AccFind_Frm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ACCOUNT TRANSACTION SEARCH"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PnlCoupon.ResumeLayout(False)
        Me.PnlCoupon.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents PnlCoupon As System.Windows.Forms.Panel
    Friend WithEvents Cmb_TrUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_AccVrTyp As System.Windows.Forms.ComboBox
    Friend WithEvents Dtp_DateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Chk_VoucherType As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_TrUnit As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_TrDate As System.Windows.Forms.CheckBox
    Friend WithEvents Dtp_DateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Chk_VrNo As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_VrNoTo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_VrNoFrom As System.Windows.Forms.TextBox
    Friend WithEvents Txt_AmountTo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_AmountFrom As System.Windows.Forms.TextBox
    Friend WithEvents Chk_Amount As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_TrType As System.Windows.Forms.CheckBox
    Friend WithEvents Cmb_AccTranType As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_AccName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_AccCode As System.Windows.Forms.TextBox
    Friend WithEvents Chk_AccountCode As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Narration As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_Narration As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents Cmb_FinYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
