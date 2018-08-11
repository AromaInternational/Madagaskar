<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccLedger_Frm
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccLedger_Frm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmd_Close = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Save = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Cmd_Find = New System.Windows.Forms.Button()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Txt_TrBalanceType = New System.Windows.Forms.TextBox()
        Me.Txt_TrBalance = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_DrTotal = New System.Windows.Forms.TextBox()
        Me.Txt_CrTotal = New System.Windows.Forms.TextBox()
        Me.Dgv_TranDetails = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Cmd_ADD = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_AccName = New System.Windows.Forms.TextBox()
        Me.Cmb_AccTranType = New System.Windows.Forms.ComboBox()
        Me.Txt_AccCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_AccAmt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmb_TrUnit = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Cmb_ActveStatus = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Dtp_AccTrDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmb_AccVrTyp = New System.Windows.Forms.ComboBox()
        Me.Txt_AccId = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Txt_AccNarration = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Txt_HiddenAccId = New System.Windows.Forms.TextBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.BN_AccTranSearch = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Dgv_TranDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.BN_AccTranSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BN_AccTranSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(2, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(582, 28)
        Me.Panel1.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(167, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(222, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "ACCOUNT TRANSACTION"
        '
        'Cmd_Close
        '
        Me.Cmd_Close.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Close.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Close.Location = New System.Drawing.Point(445, 5)
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
        Me.Cmd_Clear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Clear.Location = New System.Drawing.Point(286, 5)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Clear.TabIndex = 18
        Me.Cmd_Clear.Text = "C&lear"
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Save
        '
        Me.Cmd_Save.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Save.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Save.Location = New System.Drawing.Point(128, 5)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Save.TabIndex = 16
        Me.Cmd_Save.Text = "&Save"
        Me.Cmd_Save.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Cmd_Find)
        Me.Panel2.Controls.Add(Me.Cmd_Print)
        Me.Panel2.Controls.Add(Me.Cmd_Clear)
        Me.Panel2.Controls.Add(Me.Cmd_Save)
        Me.Panel2.Controls.Add(Me.Cmd_Close)
        Me.Panel2.Location = New System.Drawing.Point(2, 459)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(581, 39)
        Me.Panel2.TabIndex = 15
        '
        'Cmd_Find
        '
        Me.Cmd_Find.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Find.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Find.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Find.Location = New System.Drawing.Point(365, 5)
        Me.Cmd_Find.Name = "Cmd_Find"
        Me.Cmd_Find.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Find.TabIndex = 19
        Me.Cmd_Find.Text = "&Find"
        Me.Cmd_Find.UseVisualStyleBackColor = False
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Print.Location = New System.Drawing.Point(207, 5)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Print.TabIndex = 17
        Me.Cmd_Print.Text = "&Print"
        Me.Cmd_Print.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "ID :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Txt_TrBalanceType)
        Me.Panel3.Controls.Add(Me.Txt_TrBalance)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Txt_DrTotal)
        Me.Panel3.Controls.Add(Me.Txt_CrTotal)
        Me.Panel3.Controls.Add(Me.Dgv_TranDetails)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Location = New System.Drawing.Point(2, 87)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(582, 285)
        Me.Panel3.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(351, 264)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 101
        Me.Label12.Text = "Tran Balnce:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_TrBalanceType
        '
        Me.Txt_TrBalanceType.Location = New System.Drawing.Point(549, 261)
        Me.Txt_TrBalanceType.Name = "Txt_TrBalanceType"
        Me.Txt_TrBalanceType.ReadOnly = True
        Me.Txt_TrBalanceType.Size = New System.Drawing.Size(28, 20)
        Me.Txt_TrBalanceType.TabIndex = 100
        Me.Txt_TrBalanceType.TabStop = False
        Me.Txt_TrBalanceType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_TrBalance
        '
        Me.Txt_TrBalance.Location = New System.Drawing.Point(438, 261)
        Me.Txt_TrBalance.Name = "Txt_TrBalance"
        Me.Txt_TrBalance.ReadOnly = True
        Me.Txt_TrBalance.Size = New System.Drawing.Size(109, 20)
        Me.Txt_TrBalance.TabIndex = 99
        Me.Txt_TrBalance.TabStop = False
        Me.Txt_TrBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(307, 241)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 98
        Me.Label11.Text = "Total :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_DrTotal
        '
        Me.Txt_DrTotal.Location = New System.Drawing.Point(468, 238)
        Me.Txt_DrTotal.Name = "Txt_DrTotal"
        Me.Txt_DrTotal.ReadOnly = True
        Me.Txt_DrTotal.Size = New System.Drawing.Size(109, 20)
        Me.Txt_DrTotal.TabIndex = 83
        Me.Txt_DrTotal.TabStop = False
        Me.Txt_DrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_CrTotal
        '
        Me.Txt_CrTotal.Location = New System.Drawing.Point(357, 238)
        Me.Txt_CrTotal.Name = "Txt_CrTotal"
        Me.Txt_CrTotal.ReadOnly = True
        Me.Txt_CrTotal.Size = New System.Drawing.Size(109, 20)
        Me.Txt_CrTotal.TabIndex = 82
        Me.Txt_CrTotal.TabStop = False
        Me.Txt_CrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Dgv_TranDetails
        '
        Me.Dgv_TranDetails.AllowUserToAddRows = False
        Me.Dgv_TranDetails.AllowUserToDeleteRows = False
        Me.Dgv_TranDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_TranDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_TranDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_TranDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Dgv_TranDetails.Location = New System.Drawing.Point(2, 55)
        Me.Dgv_TranDetails.MultiSelect = False
        Me.Dgv_TranDetails.Name = "Dgv_TranDetails"
        Me.Dgv_TranDetails.RowHeadersWidth = 10
        Me.Dgv_TranDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_TranDetails.Size = New System.Drawing.Size(575, 181)
        Me.Dgv_TranDetails.TabIndex = 12
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Cmd_ADD)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Txt_AccName)
        Me.Panel4.Controls.Add(Me.Cmb_AccTranType)
        Me.Panel4.Controls.Add(Me.Txt_AccCode)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Txt_AccAmt)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(574, 48)
        Me.Panel4.TabIndex = 6
        '
        'Cmd_ADD
        '
        Me.Cmd_ADD.Enabled = False
        Me.Cmd_ADD.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Cmd_ADD.Location = New System.Drawing.Point(531, 2)
        Me.Cmd_ADD.Name = "Cmd_ADD"
        Me.Cmd_ADD.Size = New System.Drawing.Size(39, 42)
        Me.Cmd_ADD.TabIndex = 11
        Me.Cmd_ADD.Text = "+"
        Me.Cmd_ADD.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 97
        Me.Label10.Text = "Type :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(141, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 96
        Me.Label9.Text = "Name :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_AccName
        '
        Me.Txt_AccName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_AccName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AccName.Location = New System.Drawing.Point(142, 20)
        Me.Txt_AccName.Name = "Txt_AccName"
        Me.Txt_AccName.ReadOnly = True
        Me.Txt_AccName.Size = New System.Drawing.Size(284, 22)
        Me.Txt_AccName.TabIndex = 9
        Me.Txt_AccName.TabStop = False
        '
        'Cmb_AccTranType
        '
        Me.Cmb_AccTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_AccTranType.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_AccTranType.FormattingEnabled = True
        Me.Cmb_AccTranType.Location = New System.Drawing.Point(3, 20)
        Me.Cmb_AccTranType.Name = "Cmb_AccTranType"
        Me.Cmb_AccTranType.Size = New System.Drawing.Size(59, 22)
        Me.Cmb_AccTranType.TabIndex = 7
        '
        'Txt_AccCode
        '
        Me.Txt_AccCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AccCode.Location = New System.Drawing.Point(64, 20)
        Me.Txt_AccCode.Name = "Txt_AccCode"
        Me.Txt_AccCode.Size = New System.Drawing.Size(76, 22)
        Me.Txt_AccCode.TabIndex = 8
        Me.Txt_AccCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(65, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Code :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_AccAmt
        '
        Me.Txt_AccAmt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AccAmt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Txt_AccAmt.Location = New System.Drawing.Point(428, 20)
        Me.Txt_AccAmt.Name = "Txt_AccAmt"
        Me.Txt_AccAmt.Size = New System.Drawing.Size(102, 22)
        Me.Txt_AccAmt.TabIndex = 10
        Me.Txt_AccAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(425, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Amount :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_TrUnit
        '
        Me.Cmb_TrUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_TrUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_TrUnit.FormattingEnabled = True
        Me.Cmb_TrUnit.Location = New System.Drawing.Point(213, 19)
        Me.Cmb_TrUnit.Name = "Cmb_TrUnit"
        Me.Cmb_TrUnit.Size = New System.Drawing.Size(176, 21)
        Me.Cmb_TrUnit.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(213, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 97
        Me.Label8.Text = "Tr.Unit :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Cmb_ActveStatus)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Cmb_TrUnit)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Dtp_AccTrDate)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Cmb_AccVrTyp)
        Me.Panel5.Controls.Add(Me.Txt_AccId)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Location = New System.Drawing.Point(2, 39)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(582, 46)
        Me.Panel5.TabIndex = 0
        Me.Panel5.TabStop = True
        '
        'Cmb_ActveStatus
        '
        Me.Cmb_ActveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_ActveStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_ActveStatus.FormattingEnabled = True
        Me.Cmb_ActveStatus.Location = New System.Drawing.Point(488, 18)
        Me.Cmb_ActveStatus.Name = "Cmb_ActveStatus"
        Me.Cmb_ActveStatus.Size = New System.Drawing.Size(90, 22)
        Me.Cmb_ActveStatus.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(487, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 14)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Status :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dtp_AccTrDate
        '
        Me.Dtp_AccTrDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Dtp_AccTrDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_AccTrDate.Location = New System.Drawing.Point(392, 19)
        Me.Dtp_AccTrDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.Dtp_AccTrDate.Name = "Dtp_AccTrDate"
        Me.Dtp_AccTrDate.Size = New System.Drawing.Size(94, 21)
        Me.Dtp_AccTrDate.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(389, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 14)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Tr.Date :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_AccVrTyp
        '
        Me.Cmb_AccVrTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_AccVrTyp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmb_AccVrTyp.FormattingEnabled = True
        Me.Cmb_AccVrTyp.Location = New System.Drawing.Point(101, 19)
        Me.Cmb_AccVrTyp.Name = "Cmb_AccVrTyp"
        Me.Cmb_AccVrTyp.Size = New System.Drawing.Size(110, 21)
        Me.Cmb_AccVrTyp.TabIndex = 2
        '
        'Txt_AccId
        '
        Me.Txt_AccId.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_AccId.Location = New System.Drawing.Point(2, 19)
        Me.Txt_AccId.Name = "Txt_AccId"
        Me.Txt_AccId.Size = New System.Drawing.Size(97, 21)
        Me.Txt_AccId.TabIndex = 1
        Me.Txt_AccId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(98, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 14)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Voucher Type :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Txt_AccNarration)
        Me.Panel6.Location = New System.Drawing.Point(2, 373)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(582, 54)
        Me.Panel6.TabIndex = 13
        '
        'Txt_AccNarration
        '
        Me.Txt_AccNarration.Location = New System.Drawing.Point(1, 2)
        Me.Txt_AccNarration.MaxLength = 250
        Me.Txt_AccNarration.Multiline = True
        Me.Txt_AccNarration.Name = "Txt_AccNarration"
        Me.Txt_AccNarration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_AccNarration.Size = New System.Drawing.Size(576, 48)
        Me.Txt_AccNarration.TabIndex = 14
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Txt_HiddenAccId)
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Location = New System.Drawing.Point(2, 429)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(582, 29)
        Me.Panel7.TabIndex = 81
        '
        'Txt_HiddenAccId
        '
        Me.Txt_HiddenAccId.Enabled = False
        Me.Txt_HiddenAccId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_HiddenAccId.Location = New System.Drawing.Point(-98, 2)
        Me.Txt_HiddenAccId.Name = "Txt_HiddenAccId"
        Me.Txt_HiddenAccId.Size = New System.Drawing.Size(96, 22)
        Me.Txt_HiddenAccId.TabIndex = 17
        Me.Txt_HiddenAccId.TabStop = False
        Me.Txt_HiddenAccId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel8.Controls.Add(Me.BN_AccTranSearch)
        Me.Panel8.Location = New System.Drawing.Point(185, 1)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(217, 25)
        Me.Panel8.TabIndex = 16
        '
        'BN_AccTranSearch
        '
        Me.BN_AccTranSearch.AddNewItem = Nothing
        Me.BN_AccTranSearch.CountItem = Me.BindingNavigatorCountItem
        Me.BN_AccTranSearch.DeleteItem = Nothing
        Me.BN_AccTranSearch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BN_AccTranSearch.Location = New System.Drawing.Point(0, 0)
        Me.BN_AccTranSearch.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BN_AccTranSearch.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BN_AccTranSearch.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BN_AccTranSearch.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BN_AccTranSearch.Name = "BN_AccTranSearch"
        Me.BN_AccTranSearch.PositionItem = Me.BindingNavigatorPositionItem
        Me.BN_AccTranSearch.Size = New System.Drawing.Size(217, 25)
        Me.BN_AccTranSearch.TabIndex = 0
        Me.BN_AccTranSearch.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'AccLedger_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(584, 502)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AccLedger_Frm"
        Me.ShowInTaskbar = False
        Me.Text = "ACCOUNT TRANSACTION"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Dgv_TranDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.BN_AccTranSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BN_AccTranSearch.ResumeLayout(False)
        Me.BN_AccTranSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Close As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Txt_AccId As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Txt_AccName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_AccCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmb_AccVrTyp As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Dtp_AccTrDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_AccAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cmb_AccTranType As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Cmb_TrUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Cmd_ADD As System.Windows.Forms.Button
    Friend WithEvents Dgv_TranDetails As System.Windows.Forms.DataGridView
    Friend WithEvents Txt_DrTotal As System.Windows.Forms.TextBox
    Friend WithEvents Txt_CrTotal As System.Windows.Forms.TextBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Txt_AccNarration As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmb_ActveStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_TrBalanceType As System.Windows.Forms.TextBox
    Friend WithEvents Txt_TrBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Cmd_Find As System.Windows.Forms.Button
    Friend WithEvents Txt_HiddenAccId As System.Windows.Forms.TextBox
    Friend WithEvents BN_AccTranSearch As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
