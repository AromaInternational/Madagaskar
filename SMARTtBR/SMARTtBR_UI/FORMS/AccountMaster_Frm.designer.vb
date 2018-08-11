<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountMaster_Frm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountMaster_Frm))
        Me.SST_Accnt_Master = New System.Windows.Forms.TabControl()
        Me.Tp_AccGroups = New System.Windows.Forms.TabPage()
        Me.Cmb_GPEnabled = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_GPParentName = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Txt_GPParentId = New System.Windows.Forms.TextBox()
        Me.Txt_GPID = New System.Windows.Forms.TextBox()
        Me.Txt_GPSeqNo = New System.Windows.Forms.TextBox()
        Me.Txt_GPName = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Tp_AccHeads = New System.Windows.Forms.TabPage()
        Me.Cmb_AccGPName = New System.Windows.Forms.ComboBox()
        Me.Cmb_AccEnabled = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cmb_BillBreakUp = New System.Windows.Forms.ComboBox()
        Me.Cmb_AccBalanceType = New System.Windows.Forms.ComboBox()
        Me.Cmb_AccType = New System.Windows.Forms.ComboBox()
        Me.Cmb_Position = New System.Windows.Forms.ComboBox()
        Me.Cmb_AccStmtType = New System.Windows.Forms.ComboBox()
        Me.Txt_AccSeqNo = New System.Windows.Forms.TextBox()
        Me.Txt_AccName = New System.Windows.Forms.TextBox()
        Me.Txt_AccCode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tvw_AccGroup = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Cmd_Close = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Save = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_Accountmaster = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Cmd_Delete = New System.Windows.Forms.Button()
        Me.SST_Accnt_Master.SuspendLayout()
        Me.Tp_AccGroups.SuspendLayout()
        Me.Tp_AccHeads.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SST_Accnt_Master
        '
        Me.SST_Accnt_Master.Controls.Add(Me.Tp_AccGroups)
        Me.SST_Accnt_Master.Controls.Add(Me.Tp_AccHeads)
        Me.SST_Accnt_Master.Location = New System.Drawing.Point(245, 62)
        Me.SST_Accnt_Master.Name = "SST_Accnt_Master"
        Me.SST_Accnt_Master.SelectedIndex = 0
        Me.SST_Accnt_Master.Size = New System.Drawing.Size(328, 299)
        Me.SST_Accnt_Master.TabIndex = 0
        '
        'Tp_AccGroups
        '
        Me.Tp_AccGroups.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Tp_AccGroups.Controls.Add(Me.Cmb_GPEnabled)
        Me.Tp_AccGroups.Controls.Add(Me.Label3)
        Me.Tp_AccGroups.Controls.Add(Me.Txt_GPParentName)
        Me.Tp_AccGroups.Controls.Add(Me.Label17)
        Me.Tp_AccGroups.Controls.Add(Me.Txt_GPParentId)
        Me.Tp_AccGroups.Controls.Add(Me.Txt_GPID)
        Me.Tp_AccGroups.Controls.Add(Me.Txt_GPSeqNo)
        Me.Tp_AccGroups.Controls.Add(Me.Txt_GPName)
        Me.Tp_AccGroups.Controls.Add(Me.Label16)
        Me.Tp_AccGroups.Controls.Add(Me.Label15)
        Me.Tp_AccGroups.Controls.Add(Me.Label14)
        Me.Tp_AccGroups.Controls.Add(Me.Label13)
        Me.Tp_AccGroups.Location = New System.Drawing.Point(4, 22)
        Me.Tp_AccGroups.Name = "Tp_AccGroups"
        Me.Tp_AccGroups.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_AccGroups.Size = New System.Drawing.Size(320, 273)
        Me.Tp_AccGroups.TabIndex = 0
        Me.Tp_AccGroups.Text = "Account Groups"
        '
        'Cmb_GPEnabled
        '
        Me.Cmb_GPEnabled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_GPEnabled.FormattingEnabled = True
        Me.Cmb_GPEnabled.Location = New System.Drawing.Point(159, 124)
        Me.Cmb_GPEnabled.Name = "Cmb_GPEnabled"
        Me.Cmb_GPEnabled.Size = New System.Drawing.Size(153, 21)
        Me.Cmb_GPEnabled.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Status "
        '
        'Txt_GPParentName
        '
        Me.Txt_GPParentName.Location = New System.Drawing.Point(159, 97)
        Me.Txt_GPParentName.Name = "Txt_GPParentName"
        Me.Txt_GPParentName.Size = New System.Drawing.Size(153, 21)
        Me.Txt_GPParentName.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 100)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(117, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Parent Group Name"
        '
        'Txt_GPParentId
        '
        Me.Txt_GPParentId.Location = New System.Drawing.Point(159, 74)
        Me.Txt_GPParentId.Name = "Txt_GPParentId"
        Me.Txt_GPParentId.Size = New System.Drawing.Size(95, 21)
        Me.Txt_GPParentId.TabIndex = 4
        '
        'Txt_GPID
        '
        Me.Txt_GPID.Location = New System.Drawing.Point(159, 5)
        Me.Txt_GPID.Name = "Txt_GPID"
        Me.Txt_GPID.Size = New System.Drawing.Size(95, 21)
        Me.Txt_GPID.TabIndex = 1
        Me.Txt_GPID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.Txt_GPID, "Press F3 to search")
        '
        'Txt_GPSeqNo
        '
        Me.Txt_GPSeqNo.Location = New System.Drawing.Point(159, 51)
        Me.Txt_GPSeqNo.Name = "Txt_GPSeqNo"
        Me.Txt_GPSeqNo.Size = New System.Drawing.Size(95, 21)
        Me.Txt_GPSeqNo.TabIndex = 3
        '
        'Txt_GPName
        '
        Me.Txt_GPName.Location = New System.Drawing.Point(159, 28)
        Me.Txt_GPName.Name = "Txt_GPName"
        Me.Txt_GPName.Size = New System.Drawing.Size(152, 21)
        Me.Txt_GPName.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 77)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(113, 13)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Parent Group Code"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Seq. No. "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "A\c Group Name"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "A\c Group Code"
        '
        'Tp_AccHeads
        '
        Me.Tp_AccHeads.BackColor = System.Drawing.Color.Linen
        Me.Tp_AccHeads.Controls.Add(Me.Cmb_AccGPName)
        Me.Tp_AccHeads.Controls.Add(Me.Cmb_AccEnabled)
        Me.Tp_AccHeads.Controls.Add(Me.Label12)
        Me.Tp_AccHeads.Controls.Add(Me.Cmb_BillBreakUp)
        Me.Tp_AccHeads.Controls.Add(Me.Cmb_AccBalanceType)
        Me.Tp_AccHeads.Controls.Add(Me.Cmb_AccType)
        Me.Tp_AccHeads.Controls.Add(Me.Cmb_Position)
        Me.Tp_AccHeads.Controls.Add(Me.Cmb_AccStmtType)
        Me.Tp_AccHeads.Controls.Add(Me.Txt_AccSeqNo)
        Me.Tp_AccHeads.Controls.Add(Me.Txt_AccName)
        Me.Tp_AccHeads.Controls.Add(Me.Txt_AccCode)
        Me.Tp_AccHeads.Controls.Add(Me.Label11)
        Me.Tp_AccHeads.Controls.Add(Me.Label10)
        Me.Tp_AccHeads.Controls.Add(Me.Label8)
        Me.Tp_AccHeads.Controls.Add(Me.Label7)
        Me.Tp_AccHeads.Controls.Add(Me.Label6)
        Me.Tp_AccHeads.Controls.Add(Me.Label5)
        Me.Tp_AccHeads.Controls.Add(Me.Label1)
        Me.Tp_AccHeads.Controls.Add(Me.Label2)
        Me.Tp_AccHeads.Controls.Add(Me.Label4)
        Me.Tp_AccHeads.Location = New System.Drawing.Point(4, 22)
        Me.Tp_AccHeads.Name = "Tp_AccHeads"
        Me.Tp_AccHeads.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_AccHeads.Size = New System.Drawing.Size(320, 273)
        Me.Tp_AccHeads.TabIndex = 1
        Me.Tp_AccHeads.Text = "Account Heads"
        '
        'Cmb_AccGPName
        '
        Me.Cmb_AccGPName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_AccGPName.FormattingEnabled = True
        Me.Cmb_AccGPName.Location = New System.Drawing.Point(104, 56)
        Me.Cmb_AccGPName.Name = "Cmb_AccGPName"
        Me.Cmb_AccGPName.Size = New System.Drawing.Size(210, 21)
        Me.Cmb_AccGPName.TabIndex = 9
        '
        'Cmb_AccEnabled
        '
        Me.Cmb_AccEnabled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_AccEnabled.FormattingEnabled = True
        Me.Cmb_AccEnabled.Location = New System.Drawing.Point(104, 245)
        Me.Cmb_AccEnabled.Name = "Cmb_AccEnabled"
        Me.Cmb_AccEnabled.Size = New System.Drawing.Size(210, 21)
        Me.Cmb_AccEnabled.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 249)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Status :"
        '
        'Cmb_BillBreakUp
        '
        Me.Cmb_BillBreakUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_BillBreakUp.FormattingEnabled = True
        Me.Cmb_BillBreakUp.Location = New System.Drawing.Point(104, 216)
        Me.Cmb_BillBreakUp.Name = "Cmb_BillBreakUp"
        Me.Cmb_BillBreakUp.Size = New System.Drawing.Size(210, 21)
        Me.Cmb_BillBreakUp.TabIndex = 15
        '
        'Cmb_AccBalanceType
        '
        Me.Cmb_AccBalanceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_AccBalanceType.FormattingEnabled = True
        Me.Cmb_AccBalanceType.Location = New System.Drawing.Point(104, 110)
        Me.Cmb_AccBalanceType.Name = "Cmb_AccBalanceType"
        Me.Cmb_AccBalanceType.Size = New System.Drawing.Size(210, 21)
        Me.Cmb_AccBalanceType.TabIndex = 11
        '
        'Cmb_AccType
        '
        Me.Cmb_AccType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_AccType.FormattingEnabled = True
        Me.Cmb_AccType.Location = New System.Drawing.Point(104, 135)
        Me.Cmb_AccType.Name = "Cmb_AccType"
        Me.Cmb_AccType.Size = New System.Drawing.Size(210, 21)
        Me.Cmb_AccType.TabIndex = 12
        '
        'Cmb_Position
        '
        Me.Cmb_Position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Position.FormattingEnabled = True
        Me.Cmb_Position.Location = New System.Drawing.Point(104, 162)
        Me.Cmb_Position.Name = "Cmb_Position"
        Me.Cmb_Position.Size = New System.Drawing.Size(210, 21)
        Me.Cmb_Position.TabIndex = 13
        '
        'Cmb_AccStmtType
        '
        Me.Cmb_AccStmtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_AccStmtType.FormattingEnabled = True
        Me.Cmb_AccStmtType.Location = New System.Drawing.Point(104, 189)
        Me.Cmb_AccStmtType.Name = "Cmb_AccStmtType"
        Me.Cmb_AccStmtType.Size = New System.Drawing.Size(210, 21)
        Me.Cmb_AccStmtType.TabIndex = 14
        '
        'Txt_AccSeqNo
        '
        Me.Txt_AccSeqNo.Location = New System.Drawing.Point(104, 83)
        Me.Txt_AccSeqNo.Name = "Txt_AccSeqNo"
        Me.Txt_AccSeqNo.Size = New System.Drawing.Size(210, 21)
        Me.Txt_AccSeqNo.TabIndex = 10
        '
        'Txt_AccName
        '
        Me.Txt_AccName.Location = New System.Drawing.Point(104, 28)
        Me.Txt_AccName.Name = "Txt_AccName"
        Me.Txt_AccName.Size = New System.Drawing.Size(210, 21)
        Me.Txt_AccName.TabIndex = 7
        '
        'Txt_AccCode
        '
        Me.Txt_AccCode.Location = New System.Drawing.Point(104, 6)
        Me.Txt_AccCode.Name = "Txt_AccCode"
        Me.Txt_AccCode.Size = New System.Drawing.Size(95, 21)
        Me.Txt_AccCode.TabIndex = 6
        Me.Txt_AccCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.Txt_AccCode, "Press F3 to search")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 192)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Stmt. Type :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 219)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Bill BreakUp :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Seq. No. :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Balance Type :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "A/c Type :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Position :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "A/c Code :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "A/c Name :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Group Code :"
        '
        'Tvw_AccGroup
        '
        Me.Tvw_AccGroup.ImageIndex = 0
        Me.Tvw_AccGroup.ImageList = Me.ImageList1
        Me.Tvw_AccGroup.Location = New System.Drawing.Point(2, 62)
        Me.Tvw_AccGroup.Name = "Tvw_AccGroup"
        Me.Tvw_AccGroup.SelectedImageKey = "señal.ico"
        Me.Tvw_AccGroup.Size = New System.Drawing.Size(240, 298)
        Me.Tvw_AccGroup.TabIndex = 27
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "dinero3.ico")
        Me.ImageList1.Images.SetKeyName(1, "dinero2.ico")
        Me.ImageList1.Images.SetKeyName(2, "señal2.ico")
        Me.ImageList1.Images.SetKeyName(3, "señal.ico")
        '
        'Cmd_Close
        '
        Me.Cmd_Close.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Close.Location = New System.Drawing.Point(454, 367)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Close.TabIndex = 20
        Me.Cmd_Close.Text = "&Close"
        Me.Cmd_Close.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Location = New System.Drawing.Point(290, 367)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Clear.TabIndex = 19
        Me.Cmd_Clear.Text = "C&lear"
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Save
        '
        Me.Cmd_Save.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Save.Location = New System.Drawing.Point(208, 367)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Save.TabIndex = 18
        Me.Cmd_Save.Text = "&Save"
        Me.Cmd_Save.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lbl_Accountmaster)
        Me.Panel2.Location = New System.Drawing.Point(2, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(571, 55)
        Me.Panel2.TabIndex = 29
        '
        'lbl_Accountmaster
        '
        Me.lbl_Accountmaster.AutoSize = True
        Me.lbl_Accountmaster.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Accountmaster.ForeColor = System.Drawing.Color.DimGray
        Me.lbl_Accountmaster.Location = New System.Drawing.Point(172, 18)
        Me.lbl_Accountmaster.Name = "lbl_Accountmaster"
        Me.lbl_Accountmaster.Size = New System.Drawing.Size(207, 24)
        Me.lbl_Accountmaster.TabIndex = 0
        Me.lbl_Accountmaster.Text = "ACCOUNT MASTER"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(37, 375)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(134, 17)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "Press F3 to search"
        '
        'Cmd_Delete
        '
        Me.Cmd_Delete.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Delete.Location = New System.Drawing.Point(372, 367)
        Me.Cmd_Delete.Name = "Cmd_Delete"
        Me.Cmd_Delete.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Delete.TabIndex = 31
        Me.Cmd_Delete.Text = "&Delete"
        Me.Cmd_Delete.UseVisualStyleBackColor = False
        '
        'AccountMaster_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(572, 401)
        Me.Controls.Add(Me.Cmd_Delete)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Cmd_Close)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Tvw_AccGroup)
        Me.Controls.Add(Me.Cmd_Save)
        Me.Controls.Add(Me.SST_Accnt_Master)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AccountMaster_Frm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ACCOUNT MASTER"
        Me.SST_Accnt_Master.ResumeLayout(False)
        Me.Tp_AccGroups.ResumeLayout(False)
        Me.Tp_AccGroups.PerformLayout()
        Me.Tp_AccHeads.ResumeLayout(False)
        Me.Tp_AccHeads.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SST_Accnt_Master As System.Windows.Forms.TabControl
    Friend WithEvents Tp_AccGroups As System.Windows.Forms.TabPage
    Friend WithEvents Tp_AccHeads As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cmb_BillBreakUp As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_AccBalanceType As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_AccType As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_Position As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_AccStmtType As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_AccSeqNo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_AccName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_AccCode As System.Windows.Forms.TextBox
    Friend WithEvents Cmb_AccEnabled As System.Windows.Forms.ComboBox
    Friend WithEvents Tvw_AccGroup As System.Windows.Forms.TreeView
    Friend WithEvents Cmd_Close As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Txt_GPParentId As System.Windows.Forms.TextBox
    Friend WithEvents Txt_GPID As System.Windows.Forms.TextBox
    Friend WithEvents Txt_GPSeqNo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_GPName As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_Accountmaster As System.Windows.Forms.Label
    Friend WithEvents Txt_GPParentName As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Cmb_AccGPName As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_GPEnabled As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Delete As System.Windows.Forms.Button
End Class
