<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseMaster_Frm
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseMaster_Frm))
        Me.Dgv_TranDetails = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtNarration = New System.Windows.Forms.TextBox()
        Me.LblNew = New System.Windows.Forms.Label()
        Me.Txt_ClientID = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TxtClientPhone = New System.Windows.Forms.TextBox()
        Me.TxtClientName = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtHandlingAmt = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TxtPkgAmt = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TxtGrTot = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TxtNetAmt = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TxtRoundoff = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Txt_TotalValue = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cmd_Client_Search = New System.Windows.Forms.Button()
        Me.Dtp_BillDate = New System.Windows.Forms.DateTimePicker()
        Me.Dtp_InvDate = New System.Windows.Forms.DateTimePicker()
        Me.TxtBillNo = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TxtInvNo = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmb_PrintType = New System.Windows.Forms.ComboBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Cmd_Prd_Search = New System.Windows.Forms.Button()
        Me.TxtMeasureFinal = New System.Windows.Forms.TextBox()
        Me.LblMeasureFinal = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtMeasure3 = New System.Windows.Forms.TextBox()
        Me.LblMeasure3 = New System.Windows.Forms.Label()
        Me.TxtMeasure2 = New System.Windows.Forms.TextBox()
        Me.LblMeasure2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_PrdName = New System.Windows.Forms.TextBox()
        Me.Txt_PrdCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_BuyingPrice = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtMeasure1 = New System.Windows.Forms.TextBox()
        Me.LblMeasure1 = New System.Windows.Forms.Label()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Close = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Save = New System.Windows.Forms.Button()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Txt_TotalQty = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Chk_AutoRoundOff = New System.Windows.Forms.CheckBox()
        Me.Txt_Description = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        CType(Me.Dgv_TranDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv_TranDetails
        '
        Me.Dgv_TranDetails.AllowUserToAddRows = False
        Me.Dgv_TranDetails.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_TranDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_TranDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_TranDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Dgv_TranDetails.Location = New System.Drawing.Point(2, 159)
        Me.Dgv_TranDetails.Name = "Dgv_TranDetails"
        Me.Dgv_TranDetails.RowHeadersWidth = 5
        Me.Dgv_TranDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_TranDetails.Size = New System.Drawing.Size(890, 232)
        Me.Dgv_TranDetails.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(-218, -134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 14)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Item"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(163, 1)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 14)
        Me.Label19.TabIndex = 73
        Me.Label19.Text = "Narration"
        '
        'TxtNarration
        '
        Me.TxtNarration.Location = New System.Drawing.Point(165, 17)
        Me.TxtNarration.Name = "TxtNarration"
        Me.TxtNarration.Size = New System.Drawing.Size(721, 22)
        Me.TxtNarration.TabIndex = 11
        '
        'LblNew
        '
        Me.LblNew.AutoSize = True
        Me.LblNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNew.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblNew.Location = New System.Drawing.Point(1041, 8)
        Me.LblNew.Name = "LblNew"
        Me.LblNew.Size = New System.Drawing.Size(71, 16)
        Me.LblNew.TabIndex = 75
        Me.LblNew.Text = "-- NEW --"
        '
        'Txt_ClientID
        '
        Me.Txt_ClientID.Location = New System.Drawing.Point(205, 14)
        Me.Txt_ClientID.Name = "Txt_ClientID"
        Me.Txt_ClientID.Size = New System.Drawing.Size(74, 22)
        Me.Txt_ClientID.TabIndex = 2
        Me.Txt_ClientID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(203, 1)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(69, 13)
        Me.Label32.TabIndex = 82
        Me.Label32.Text = "Supplier ID"
        '
        'TxtClientPhone
        '
        Me.TxtClientPhone.Location = New System.Drawing.Point(506, 14)
        Me.TxtClientPhone.Name = "TxtClientPhone"
        Me.TxtClientPhone.ReadOnly = True
        Me.TxtClientPhone.Size = New System.Drawing.Size(141, 22)
        Me.TxtClientPhone.TabIndex = 4
        Me.TxtClientPhone.TabStop = False
        '
        'TxtClientName
        '
        Me.TxtClientName.Location = New System.Drawing.Point(305, 14)
        Me.TxtClientName.Name = "TxtClientName"
        Me.TxtClientName.ReadOnly = True
        Me.TxtClientName.Size = New System.Drawing.Size(199, 22)
        Me.TxtClientName.TabIndex = 3
        Me.TxtClientName.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(503, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(42, 13)
        Me.Label21.TabIndex = 75
        Me.Label21.Text = "Phone"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(305, 1)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 13)
        Me.Label20.TabIndex = 74
        Me.Label20.Text = "Name"
        '
        'TxtHandlingAmt
        '
        Me.TxtHandlingAmt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHandlingAmt.Location = New System.Drawing.Point(183, 16)
        Me.TxtHandlingAmt.Name = "TxtHandlingAmt"
        Me.TxtHandlingAmt.Size = New System.Drawing.Size(178, 21)
        Me.TxtHandlingAmt.TabIndex = 41
        Me.TxtHandlingAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(182, 1)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(85, 13)
        Me.Label34.TabIndex = 97
        Me.Label34.Text = "Handling Chrg"
        '
        'TxtPkgAmt
        '
        Me.TxtPkgAmt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPkgAmt.Location = New System.Drawing.Point(3, 16)
        Me.TxtPkgAmt.Name = "TxtPkgAmt"
        Me.TxtPkgAmt.Size = New System.Drawing.Size(178, 21)
        Me.TxtPkgAmt.TabIndex = 40
        Me.TxtPkgAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(0, 1)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(63, 13)
        Me.Label33.TabIndex = 95
        Me.Label33.Text = "Pack Chrg"
        '
        'TxtGrTot
        '
        Me.TxtGrTot.Enabled = False
        Me.TxtGrTot.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGrTot.Location = New System.Drawing.Point(363, 16)
        Me.TxtGrTot.Name = "TxtGrTot"
        Me.TxtGrTot.ReadOnly = True
        Me.TxtGrTot.Size = New System.Drawing.Size(178, 21)
        Me.TxtGrTot.TabIndex = 42
        Me.TxtGrTot.TabStop = False
        Me.TxtGrTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(367, 1)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(73, 13)
        Me.Label31.TabIndex = 93
        Me.Label31.Text = "Grand Total"
        '
        'TxtNetAmt
        '
        Me.TxtNetAmt.BackColor = System.Drawing.Color.White
        Me.TxtNetAmt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetAmt.ForeColor = System.Drawing.Color.DarkRed
        Me.TxtNetAmt.Location = New System.Drawing.Point(708, 15)
        Me.TxtNetAmt.Name = "TxtNetAmt"
        Me.TxtNetAmt.ReadOnly = True
        Me.TxtNetAmt.Size = New System.Drawing.Size(178, 22)
        Me.TxtNetAmt.TabIndex = 44
        Me.TxtNetAmt.TabStop = False
        Me.TxtNetAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.DarkRed
        Me.Label30.Location = New System.Drawing.Point(705, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(85, 16)
        Me.Label30.TabIndex = 91
        Me.Label30.Text = "Net Amount"
        '
        'TxtRoundoff
        '
        Me.TxtRoundoff.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoundoff.Location = New System.Drawing.Point(542, 16)
        Me.TxtRoundoff.Name = "TxtRoundoff"
        Me.TxtRoundoff.Size = New System.Drawing.Size(164, 21)
        Me.TxtRoundoff.TabIndex = 43
        Me.TxtRoundoff.TabStop = False
        Me.TxtRoundoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(539, 1)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(62, 13)
        Me.Label29.TabIndex = 89
        Me.Label29.Text = "Round Off"
        '
        'Txt_TotalValue
        '
        Me.Txt_TotalValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TotalValue.Location = New System.Drawing.Point(769, 16)
        Me.Txt_TotalValue.Name = "Txt_TotalValue"
        Me.Txt_TotalValue.ReadOnly = True
        Me.Txt_TotalValue.Size = New System.Drawing.Size(116, 21)
        Me.Txt_TotalValue.TabIndex = 39
        Me.Txt_TotalValue.TabStop = False
        Me.Txt_TotalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(794, 2)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(70, 13)
        Me.Label27.TabIndex = 85
        Me.Label27.Text = "Value.Total"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lbl_Heading)
        Me.Panel2.Location = New System.Drawing.Point(1, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(891, 26)
        Me.Panel2.TabIndex = 503
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.DimGray
        Me.lbl_Heading.Location = New System.Drawing.Point(312, 2)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(201, 22)
        Me.lbl_Heading.TabIndex = 0
        Me.lbl_Heading.Text = "PURCHASE MASTER"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Cmd_Client_Search)
        Me.Panel1.Controls.Add(Me.Dtp_BillDate)
        Me.Panel1.Controls.Add(Me.Dtp_InvDate)
        Me.Panel1.Controls.Add(Me.TxtBillNo)
        Me.Panel1.Controls.Add(Me.Label37)
        Me.Panel1.Controls.Add(Me.Txt_ClientID)
        Me.Panel1.Controls.Add(Me.TxtInvNo)
        Me.Panel1.Controls.Add(Me.TxtClientName)
        Me.Panel1.Controls.Add(Me.Label38)
        Me.Panel1.Controls.Add(Me.TxtClientPhone)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(1, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(891, 40)
        Me.Panel1.TabIndex = 0
        '
        'Cmd_Client_Search
        '
        Me.Cmd_Client_Search.BackgroundImage = CType(resources.GetObject("Cmd_Client_Search.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Client_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_Client_Search.Location = New System.Drawing.Point(280, 13)
        Me.Cmd_Client_Search.Name = "Cmd_Client_Search"
        Me.Cmd_Client_Search.Size = New System.Drawing.Size(25, 24)
        Me.Cmd_Client_Search.TabIndex = 556
        Me.Cmd_Client_Search.TabStop = False
        Me.Cmd_Client_Search.UseVisualStyleBackColor = True
        '
        'Dtp_BillDate
        '
        Me.Dtp_BillDate.Enabled = False
        Me.Dtp_BillDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_BillDate.Location = New System.Drawing.Point(94, 14)
        Me.Dtp_BillDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.Dtp_BillDate.Name = "Dtp_BillDate"
        Me.Dtp_BillDate.Size = New System.Drawing.Size(108, 22)
        Me.Dtp_BillDate.TabIndex = 1
        Me.Dtp_BillDate.TabStop = False
        '
        'Dtp_InvDate
        '
        Me.Dtp_InvDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_InvDate.Location = New System.Drawing.Point(776, 14)
        Me.Dtp_InvDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.Dtp_InvDate.Name = "Dtp_InvDate"
        Me.Dtp_InvDate.Size = New System.Drawing.Size(109, 22)
        Me.Dtp_InvDate.TabIndex = 6
        '
        'TxtBillNo
        '
        Me.TxtBillNo.Location = New System.Drawing.Point(4, 14)
        Me.TxtBillNo.Name = "TxtBillNo"
        Me.TxtBillNo.Size = New System.Drawing.Size(88, 22)
        Me.TxtBillNo.TabIndex = 0
        Me.TxtBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(770, -2)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(54, 14)
        Me.Label37.TabIndex = 84
        Me.Label37.Text = "Inv Date"
        '
        'TxtInvNo
        '
        Me.TxtInvNo.Location = New System.Drawing.Point(649, 14)
        Me.TxtInvNo.Name = "TxtInvNo"
        Me.TxtInvNo.Size = New System.Drawing.Size(125, 22)
        Me.TxtInvNo.TabIndex = 5
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(645, -2)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(43, 14)
        Me.Label38.TabIndex = 83
        Me.Label38.Text = "Inv.No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(89, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 14)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Bill Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 14)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "BIll No"
        '
        'Cmb_PrintType
        '
        Me.Cmb_PrintType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_PrintType.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Cmb_PrintType.FormattingEnabled = True
        Me.Cmb_PrintType.Location = New System.Drawing.Point(3, 17)
        Me.Cmb_PrintType.Name = "Cmb_PrintType"
        Me.Cmb_PrintType.Size = New System.Drawing.Size(160, 22)
        Me.Cmb_PrintType.TabIndex = 10
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(61, 14)
        Me.Label43.TabIndex = 86
        Me.Label43.Text = "Prn.Type"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Cmd_Prd_Search)
        Me.Panel3.Controls.Add(Me.TxtMeasureFinal)
        Me.Panel3.Controls.Add(Me.LblMeasureFinal)
        Me.Panel3.Controls.Add(Me.TextBox1)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.TxtMeasure3)
        Me.Panel3.Controls.Add(Me.LblMeasure3)
        Me.Panel3.Controls.Add(Me.TxtMeasure2)
        Me.Panel3.Controls.Add(Me.LblMeasure2)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Txt_PrdName)
        Me.Panel3.Controls.Add(Me.Txt_PrdCode)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Txt_BuyingPrice)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.TxtQty)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.TxtMeasure1)
        Me.Panel3.Controls.Add(Me.LblMeasure1)
        Me.Panel3.Location = New System.Drawing.Point(1, 72)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(891, 41)
        Me.Panel3.TabIndex = 12
        '
        'Cmd_Prd_Search
        '
        Me.Cmd_Prd_Search.BackgroundImage = CType(resources.GetObject("Cmd_Prd_Search.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Prd_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_Prd_Search.Location = New System.Drawing.Point(64, 14)
        Me.Cmd_Prd_Search.Name = "Cmd_Prd_Search"
        Me.Cmd_Prd_Search.Size = New System.Drawing.Size(25, 24)
        Me.Cmd_Prd_Search.TabIndex = 555
        Me.Cmd_Prd_Search.TabStop = False
        Me.Cmd_Prd_Search.UseVisualStyleBackColor = True
        '
        'TxtMeasureFinal
        '
        Me.TxtMeasureFinal.Location = New System.Drawing.Point(808, 15)
        Me.TxtMeasureFinal.Name = "TxtMeasureFinal"
        Me.TxtMeasureFinal.ReadOnly = True
        Me.TxtMeasureFinal.Size = New System.Drawing.Size(79, 22)
        Me.TxtMeasureFinal.TabIndex = 553
        Me.TxtMeasureFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblMeasureFinal
        '
        Me.LblMeasureFinal.AutoSize = True
        Me.LblMeasureFinal.ForeColor = System.Drawing.Color.Black
        Me.LblMeasureFinal.Location = New System.Drawing.Point(804, 0)
        Me.LblMeasureFinal.Name = "LblMeasureFinal"
        Me.LblMeasureFinal.Size = New System.Drawing.Size(38, 14)
        Me.LblMeasureFinal.TabIndex = 554
        Me.LblMeasureFinal.Text = "CBCm"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(699, 15)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(107, 22)
        Me.TextBox1.TabIndex = 551
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(695, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 14)
        Me.Label10.TabIndex = 552
        Me.Label10.Text = "Value"
        '
        'TxtMeasure3
        '
        Me.TxtMeasure3.Location = New System.Drawing.Point(464, 15)
        Me.TxtMeasure3.Name = "TxtMeasure3"
        Me.TxtMeasure3.ReadOnly = True
        Me.TxtMeasure3.Size = New System.Drawing.Size(65, 22)
        Me.TxtMeasure3.TabIndex = 549
        Me.TxtMeasure3.TabStop = False
        '
        'LblMeasure3
        '
        Me.LblMeasure3.AutoSize = True
        Me.LblMeasure3.Location = New System.Drawing.Point(462, 0)
        Me.LblMeasure3.Name = "LblMeasure3"
        Me.LblMeasure3.Size = New System.Drawing.Size(27, 14)
        Me.LblMeasure3.TabIndex = 550
        Me.LblMeasure3.Text = "Len"
        '
        'TxtMeasure2
        '
        Me.TxtMeasure2.Location = New System.Drawing.Point(397, 15)
        Me.TxtMeasure2.Name = "TxtMeasure2"
        Me.TxtMeasure2.ReadOnly = True
        Me.TxtMeasure2.Size = New System.Drawing.Size(65, 22)
        Me.TxtMeasure2.TabIndex = 547
        Me.TxtMeasure2.TabStop = False
        '
        'LblMeasure2
        '
        Me.LblMeasure2.AutoSize = True
        Me.LblMeasure2.Location = New System.Drawing.Point(395, 0)
        Me.LblMeasure2.Name = "LblMeasure2"
        Me.LblMeasure2.Size = New System.Drawing.Size(53, 14)
        Me.LblMeasure2.TabIndex = 548
        Me.LblMeasure2.Text = "Wid/Dim"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(88, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 546
        Me.Label9.Text = "Name :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_PrdName
        '
        Me.Txt_PrdName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_PrdName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PrdName.Location = New System.Drawing.Point(89, 15)
        Me.Txt_PrdName.Name = "Txt_PrdName"
        Me.Txt_PrdName.ReadOnly = True
        Me.Txt_PrdName.Size = New System.Drawing.Size(241, 22)
        Me.Txt_PrdName.TabIndex = 544
        Me.Txt_PrdName.TabStop = False
        '
        'Txt_PrdCode
        '
        Me.Txt_PrdCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PrdCode.Location = New System.Drawing.Point(3, 15)
        Me.Txt_PrdCode.Name = "Txt_PrdCode"
        Me.Txt_PrdCode.Size = New System.Drawing.Size(61, 22)
        Me.Txt_PrdCode.TabIndex = 7
        Me.Txt_PrdCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 545
        Me.Label4.Text = "Code :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_BuyingPrice
        '
        Me.Txt_BuyingPrice.Location = New System.Drawing.Point(614, 15)
        Me.Txt_BuyingPrice.Name = "Txt_BuyingPrice"
        Me.Txt_BuyingPrice.Size = New System.Drawing.Size(83, 22)
        Me.Txt_BuyingPrice.TabIndex = 9
        Me.Txt_BuyingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(611, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 14)
        Me.Label16.TabIndex = 517
        Me.Label16.Text = "Rate"
        '
        'TxtQty
        '
        Me.TxtQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtQty.Location = New System.Drawing.Point(531, 15)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(81, 22)
        Me.TxtQty.TabIndex = 8
        Me.TxtQty.Text = "0.000"
        Me.TxtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(527, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 14)
        Me.Label7.TabIndex = 510
        Me.Label7.Text = "Qty"
        '
        'TxtMeasure1
        '
        Me.TxtMeasure1.Location = New System.Drawing.Point(331, 15)
        Me.TxtMeasure1.Name = "TxtMeasure1"
        Me.TxtMeasure1.ReadOnly = True
        Me.TxtMeasure1.Size = New System.Drawing.Size(65, 22)
        Me.TxtMeasure1.TabIndex = 14
        Me.TxtMeasure1.TabStop = False
        '
        'LblMeasure1
        '
        Me.LblMeasure1.AutoSize = True
        Me.LblMeasure1.Location = New System.Drawing.Point(329, 0)
        Me.LblMeasure1.Name = "LblMeasure1"
        Me.LblMeasure1.Size = New System.Drawing.Size(24, 14)
        Me.LblMeasure1.TabIndex = 509
        Me.LblMeasure1.Text = "Hig"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Location = New System.Drawing.Point(832, 0)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(56, 41)
        Me.Cmd_Add.TabIndex = 11
        Me.Cmd_Add.Text = "Add"
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'Cmd_Close
        '
        Me.Cmd_Close.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Close.Location = New System.Drawing.Point(529, 523)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(78, 30)
        Me.Cmd_Close.TabIndex = 48
        Me.Cmd_Close.Text = "&Close"
        Me.Cmd_Close.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Location = New System.Drawing.Point(450, 523)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(78, 30)
        Me.Cmd_Clear.TabIndex = 47
        Me.Cmd_Clear.Text = "C&lear"
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Save
        '
        Me.Cmd_Save.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Save.Location = New System.Drawing.Point(292, 523)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(78, 30)
        Me.Cmd_Save.TabIndex = 45
        Me.Cmd_Save.Text = "&Save"
        Me.Cmd_Save.UseVisualStyleBackColor = False
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print.Location = New System.Drawing.Point(371, 523)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(78, 30)
        Me.Cmd_Print.TabIndex = 46
        Me.Cmd_Print.Text = "&Print"
        Me.Cmd_Print.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Cmb_PrintType)
        Me.Panel5.Controls.Add(Me.Label43)
        Me.Panel5.Controls.Add(Me.TxtNarration)
        Me.Panel5.Controls.Add(Me.Label19)
        Me.Panel5.Location = New System.Drawing.Point(1, 475)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(891, 44)
        Me.Panel5.TabIndex = 8
        Me.Panel5.TabStop = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label44)
        Me.Panel6.Controls.Add(Me.Txt_TotalQty)
        Me.Panel6.Controls.Add(Me.Txt_TotalValue)
        Me.Panel6.Controls.Add(Me.Label27)
        Me.Panel6.Location = New System.Drawing.Point(2, 393)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(890, 40)
        Me.Panel6.TabIndex = 33
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(644, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(62, 13)
        Me.Label44.TabIndex = 89
        Me.Label44.Text = "Qty. Total"
        '
        'Txt_TotalQty
        '
        Me.Txt_TotalQty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TotalQty.Location = New System.Drawing.Point(648, 16)
        Me.Txt_TotalQty.Name = "Txt_TotalQty"
        Me.Txt_TotalQty.ReadOnly = True
        Me.Txt_TotalQty.Size = New System.Drawing.Size(119, 21)
        Me.Txt_TotalQty.TabIndex = 90
        Me.Txt_TotalQty.TabStop = False
        Me.Txt_TotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Chk_AutoRoundOff)
        Me.Panel7.Controls.Add(Me.TxtNetAmt)
        Me.Panel7.Controls.Add(Me.TxtGrTot)
        Me.Panel7.Controls.Add(Me.Label30)
        Me.Panel7.Controls.Add(Me.TxtHandlingAmt)
        Me.Panel7.Controls.Add(Me.Label29)
        Me.Panel7.Controls.Add(Me.TxtRoundoff)
        Me.Panel7.Controls.Add(Me.Label31)
        Me.Panel7.Controls.Add(Me.Label33)
        Me.Panel7.Controls.Add(Me.Label34)
        Me.Panel7.Controls.Add(Me.TxtPkgAmt)
        Me.Panel7.Location = New System.Drawing.Point(2, 434)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(890, 40)
        Me.Panel7.TabIndex = 40
        '
        'Chk_AutoRoundOff
        '
        Me.Chk_AutoRoundOff.AutoSize = True
        Me.Chk_AutoRoundOff.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_AutoRoundOff.Location = New System.Drawing.Point(608, 1)
        Me.Chk_AutoRoundOff.Name = "Chk_AutoRoundOff"
        Me.Chk_AutoRoundOff.Size = New System.Drawing.Size(90, 15)
        Me.Chk_AutoRoundOff.TabIndex = 43
        Me.Chk_AutoRoundOff.Text = "Auto Round Off"
        Me.Chk_AutoRoundOff.UseVisualStyleBackColor = True
        '
        'Txt_Description
        '
        Me.Txt_Description.Location = New System.Drawing.Point(4, 16)
        Me.Txt_Description.MaxLength = 250
        Me.Txt_Description.Name = "Txt_Description"
        Me.Txt_Description.Size = New System.Drawing.Size(826, 22)
        Me.Txt_Description.TabIndex = 10
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(4, 1)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(71, 13)
        Me.Label47.TabIndex = 542
        Me.Label47.Text = "Description"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Cmd_Add)
        Me.Panel4.Controls.Add(Me.Label47)
        Me.Panel4.Controls.Add(Me.Txt_Description)
        Me.Panel4.Location = New System.Drawing.Point(1, 114)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(891, 43)
        Me.Panel4.TabIndex = 504
        '
        'PurchaseMaster_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(895, 558)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.Cmd_Close)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Save)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LblNew)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Dgv_TranDetails)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PurchaseMaster_Frm"
        Me.ShowInTaskbar = False
        Me.Text = "PURCHASE MASTER"
        CType(Me.Dgv_TranDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Dgv_TranDetails As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtNarration As System.Windows.Forms.TextBox
    Friend WithEvents LblNew As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtClientPhone As System.Windows.Forms.TextBox
    Friend WithEvents TxtClientName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_TotalValue As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxtNetAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TxtRoundoff As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TxtGrTot As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Txt_ClientID As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TxtHandlingAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TxtPkgAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Dtp_BillDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Txt_BuyingPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtMeasure1 As System.Windows.Forms.TextBox
    Friend WithEvents LblMeasure1 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Close As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Dtp_InvDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TxtInvNo As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Cmb_PrintType As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Txt_TotalQty As System.Windows.Forms.TextBox
    Friend WithEvents Chk_AutoRoundOff As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_Description As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_PrdName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PrdCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtMeasure2 As System.Windows.Forms.TextBox
    Friend WithEvents LblMeasure2 As System.Windows.Forms.Label
    Friend WithEvents TxtMeasure3 As System.Windows.Forms.TextBox
    Friend WithEvents LblMeasure3 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtMeasureFinal As System.Windows.Forms.TextBox
    Friend WithEvents LblMeasureFinal As System.Windows.Forms.Label
    Friend WithEvents Cmd_Client_Search As System.Windows.Forms.Button
    Friend WithEvents Cmd_Prd_Search As System.Windows.Forms.Button
End Class
