<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserMaster_Frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserMaster_Frm))
        Me.Cmd_Save = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Close = New System.Windows.Forms.Button()
        Me.Txt_UMID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_ActveStatus = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_Accountmaster = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Cmb_UMDesID = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Cmb_UMDepID = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_UMPwdConfirm = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_UMPwd = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_UMName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cmb_UMTypeID = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmb_UMUNID = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_UMAutoLogOutPeriod = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Rd_CollapseAll = New System.Windows.Forms.RadioButton()
        Me.Rd_ExpandAll = New System.Windows.Forms.RadioButton()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Tvw_Unit = New System.Windows.Forms.TreeView()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cmd_Save
        '
        Me.Cmd_Save.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Save.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Save.Location = New System.Drawing.Point(63, 6)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(61, 23)
        Me.Cmd_Save.TabIndex = 13
        Me.Cmd_Save.Text = "&Save"
        Me.Cmd_Save.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Clear.Location = New System.Drawing.Point(127, 6)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(61, 23)
        Me.Cmd_Clear.TabIndex = 14
        Me.Cmd_Clear.Text = "C&lear"
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Close
        '
        Me.Cmd_Close.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Close.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Close.Location = New System.Drawing.Point(190, 6)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(61, 23)
        Me.Cmd_Close.TabIndex = 15
        Me.Cmd_Close.Text = "&Close"
        Me.Cmd_Close.UseVisualStyleBackColor = False
        '
        'Txt_UMID
        '
        Me.Txt_UMID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_UMID.Location = New System.Drawing.Point(123, 4)
        Me.Txt_UMID.Name = "Txt_UMID"
        Me.Txt_UMID.Size = New System.Drawing.Size(97, 21)
        Me.Txt_UMID.TabIndex = 0
        Me.Txt_UMID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(63, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "User ID :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(66, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Status :"
        '
        'Cmb_ActveStatus
        '
        Me.Cmb_ActveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_ActveStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_ActveStatus.FormattingEnabled = True
        Me.Cmb_ActveStatus.Location = New System.Drawing.Point(121, 51)
        Me.Cmb_ActveStatus.Name = "Cmb_ActveStatus"
        Me.Cmb_ActveStatus.Size = New System.Drawing.Size(121, 21)
        Me.Cmb_ActveStatus.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lbl_Accountmaster)
        Me.Panel2.Location = New System.Drawing.Point(3, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(319, 32)
        Me.Panel2.TabIndex = 34
        '
        'lbl_Accountmaster
        '
        Me.lbl_Accountmaster.AutoSize = True
        Me.lbl_Accountmaster.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Accountmaster.ForeColor = System.Drawing.Color.DimGray
        Me.lbl_Accountmaster.Location = New System.Drawing.Point(45, 4)
        Me.lbl_Accountmaster.Name = "lbl_Accountmaster"
        Me.lbl_Accountmaster.Size = New System.Drawing.Size(227, 24)
        Me.lbl_Accountmaster.TabIndex = 0
        Me.lbl_Accountmaster.Text = "USER REGISTRATION"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Cmd_Clear)
        Me.Panel1.Controls.Add(Me.Cmd_Close)
        Me.Panel1.Controls.Add(Me.Cmd_Save)
        Me.Panel1.Location = New System.Drawing.Point(3, 487)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(319, 37)
        Me.Panel1.TabIndex = 12
        Me.Panel1.TabStop = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Cmb_UMDesID)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Cmb_UMDepID)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Txt_UMPwdConfirm)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Txt_UMPwd)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Txt_UMName)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Cmb_UMTypeID)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Txt_UMID)
        Me.Panel3.Location = New System.Drawing.Point(3, 39)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(319, 175)
        Me.Panel3.TabIndex = 0
        '
        'Cmb_UMDesID
        '
        Me.Cmb_UMDesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_UMDesID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_UMDesID.FormattingEnabled = True
        Me.Cmb_UMDesID.Location = New System.Drawing.Point(123, 53)
        Me.Cmb_UMDesID.Name = "Cmb_UMDesID"
        Me.Cmb_UMDesID.Size = New System.Drawing.Size(187, 21)
        Me.Cmb_UMDesID.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(36, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Designation :"
        '
        'Cmb_UMDepID
        '
        Me.Cmb_UMDepID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_UMDepID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_UMDepID.FormattingEnabled = True
        Me.Cmb_UMDepID.Location = New System.Drawing.Point(123, 29)
        Me.Cmb_UMDepID.Name = "Cmb_UMDepID"
        Me.Cmb_UMDepID.Size = New System.Drawing.Size(187, 21)
        Me.Cmb_UMDepID.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Confirm Password :"
        '
        'Txt_UMPwdConfirm
        '
        Me.Txt_UMPwdConfirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_UMPwdConfirm.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_UMPwdConfirm.Location = New System.Drawing.Point(123, 149)
        Me.Txt_UMPwdConfirm.Name = "Txt_UMPwdConfirm"
        Me.Txt_UMPwdConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_UMPwdConfirm.Size = New System.Drawing.Size(187, 21)
        Me.Txt_UMPwdConfirm.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(51, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Password :"
        '
        'Txt_UMPwd
        '
        Me.Txt_UMPwd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_UMPwd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_UMPwd.Location = New System.Drawing.Point(123, 125)
        Me.Txt_UMPwd.Name = "Txt_UMPwd"
        Me.Txt_UMPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_UMPwd.Size = New System.Drawing.Size(187, 21)
        Me.Txt_UMPwd.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(44, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "User Name :"
        '
        'Txt_UMName
        '
        Me.Txt_UMName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_UMName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_UMName.Location = New System.Drawing.Point(123, 101)
        Me.Txt_UMName.Name = "Txt_UMName"
        Me.Txt_UMName.Size = New System.Drawing.Size(187, 21)
        Me.Txt_UMName.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(36, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Department :"
        '
        'Cmb_UMTypeID
        '
        Me.Cmb_UMTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_UMTypeID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_UMTypeID.FormattingEnabled = True
        Me.Cmb_UMTypeID.Location = New System.Drawing.Point(123, 77)
        Me.Cmb_UMTypeID.Name = "Cmb_UMTypeID"
        Me.Cmb_UMTypeID.Size = New System.Drawing.Size(97, 21)
        Me.Cmb_UMTypeID.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "User Type :"
        '
        'Cmb_UMUNID
        '
        Me.Cmb_UMUNID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_UMUNID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_UMUNID.FormattingEnabled = True
        Me.Cmb_UMUNID.Location = New System.Drawing.Point(121, 3)
        Me.Cmb_UMUNID.Name = "Cmb_UMUNID"
        Me.Cmb_UMUNID.Size = New System.Drawing.Size(189, 21)
        Me.Cmb_UMUNID.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(36, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Default Unit :"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Txt_UMAutoLogOutPeriod)
        Me.Panel4.Controls.Add(Me.Cmb_UMUNID)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Cmb_ActveStatus)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Location = New System.Drawing.Point(3, 408)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(319, 78)
        Me.Panel4.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Auto Log Out Period :"
        '
        'Txt_UMAutoLogOutPeriod
        '
        Me.Txt_UMAutoLogOutPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_UMAutoLogOutPeriod.Location = New System.Drawing.Point(146, 27)
        Me.Txt_UMAutoLogOutPeriod.Name = "Txt_UMAutoLogOutPeriod"
        Me.Txt_UMAutoLogOutPeriod.Size = New System.Drawing.Size(97, 21)
        Me.Txt_UMAutoLogOutPeriod.TabIndex = 10
        Me.Txt_UMAutoLogOutPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Rd_CollapseAll)
        Me.Panel5.Controls.Add(Me.Rd_ExpandAll)
        Me.Panel5.Location = New System.Drawing.Point(3, 216)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(319, 22)
        Me.Panel5.TabIndex = 36
        '
        'Rd_CollapseAll
        '
        Me.Rd_CollapseAll.AutoSize = True
        Me.Rd_CollapseAll.Location = New System.Drawing.Point(173, 1)
        Me.Rd_CollapseAll.Name = "Rd_CollapseAll"
        Me.Rd_CollapseAll.Size = New System.Drawing.Size(79, 17)
        Me.Rd_CollapseAll.TabIndex = 1
        Me.Rd_CollapseAll.Text = "Collapse All"
        Me.Rd_CollapseAll.UseVisualStyleBackColor = True
        '
        'Rd_ExpandAll
        '
        Me.Rd_ExpandAll.AutoSize = True
        Me.Rd_ExpandAll.Checked = True
        Me.Rd_ExpandAll.Location = New System.Drawing.Point(56, 2)
        Me.Rd_ExpandAll.Name = "Rd_ExpandAll"
        Me.Rd_ExpandAll.Size = New System.Drawing.Size(75, 17)
        Me.Rd_ExpandAll.TabIndex = 0
        Me.Rd_ExpandAll.TabStop = True
        Me.Rd_ExpandAll.Text = "Expand All"
        Me.Rd_ExpandAll.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Tvw_Unit)
        Me.Panel6.Location = New System.Drawing.Point(3, 240)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(319, 167)
        Me.Panel6.TabIndex = 35
        '
        'Tvw_Unit
        '
        Me.Tvw_Unit.CheckBoxes = True
        Me.Tvw_Unit.Location = New System.Drawing.Point(1, 1)
        Me.Tvw_Unit.Name = "Tvw_Unit"
        Me.Tvw_Unit.SelectedImageKey = "señal.ico"
        Me.Tvw_Unit.Size = New System.Drawing.Size(314, 163)
        Me.Tvw_Unit.TabIndex = 98
        '
        'UserMaster_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(326, 525)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UserMaster_Frm"
        Me.ShowInTaskbar = False
        Me.Text = "USER REGISTRATION"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Close As System.Windows.Forms.Button
    Friend WithEvents Txt_UMID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmb_ActveStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_Accountmaster As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Cmb_UMTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cmb_UMUNID As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_UMPwdConfirm As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_UMPwd As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_UMName As System.Windows.Forms.TextBox
    Friend WithEvents Cmb_UMDepID As System.Windows.Forms.ComboBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Cmb_UMDesID As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_UMAutoLogOutPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Rd_CollapseAll As System.Windows.Forms.RadioButton
    Friend WithEvents Rd_ExpandAll As System.Windows.Forms.RadioButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Tvw_Unit As System.Windows.Forms.TreeView
End Class
