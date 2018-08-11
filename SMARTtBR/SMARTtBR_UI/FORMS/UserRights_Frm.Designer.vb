<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserRights_Frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserRights_Frm))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_Accountmaster = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmb_RefUser = New System.Windows.Forms.ComboBox()
        Me.Dgv_Rights = New System.Windows.Forms.DataGridView()
        Me.Cmb_User = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_UserID = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cmd_Close = New System.Windows.Forms.Button()
        Me.Cmd_Save = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Dgv_Rights, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lbl_Accountmaster)
        Me.Panel2.Location = New System.Drawing.Point(3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(588, 32)
        Me.Panel2.TabIndex = 35
        '
        'lbl_Accountmaster
        '
        Me.lbl_Accountmaster.AutoSize = True
        Me.lbl_Accountmaster.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Accountmaster.ForeColor = System.Drawing.Color.DimGray
        Me.lbl_Accountmaster.Location = New System.Drawing.Point(225, 4)
        Me.lbl_Accountmaster.Name = "lbl_Accountmaster"
        Me.lbl_Accountmaster.Size = New System.Drawing.Size(150, 24)
        Me.lbl_Accountmaster.TabIndex = 0
        Me.lbl_Accountmaster.Text = "USER RIGHTS"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Cmb_RefUser)
        Me.Panel3.Controls.Add(Me.Dgv_Rights)
        Me.Panel3.Controls.Add(Me.Cmb_User)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Txt_UserID)
        Me.Panel3.Location = New System.Drawing.Point(3, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(588, 343)
        Me.Panel3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(362, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Ref Name :"
        '
        'Cmb_RefUser
        '
        Me.Cmb_RefUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_RefUser.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_RefUser.FormattingEnabled = True
        Me.Cmb_RefUser.Location = New System.Drawing.Point(364, 22)
        Me.Cmb_RefUser.Name = "Cmb_RefUser"
        Me.Cmb_RefUser.Size = New System.Drawing.Size(217, 21)
        Me.Cmb_RefUser.TabIndex = 36
        '
        'Dgv_Rights
        '
        Me.Dgv_Rights.AllowUserToAddRows = False
        Me.Dgv_Rights.AllowUserToDeleteRows = False
        Me.Dgv_Rights.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgv_Rights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Rights.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Dgv_Rights.Location = New System.Drawing.Point(5, 48)
        Me.Dgv_Rights.MultiSelect = False
        Me.Dgv_Rights.Name = "Dgv_Rights"
        Me.Dgv_Rights.RowHeadersWidth = 5
        Me.Dgv_Rights.Size = New System.Drawing.Size(577, 291)
        Me.Dgv_Rights.TabIndex = 35
        '
        'Cmb_User
        '
        Me.Cmb_User.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_User.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_User.FormattingEnabled = True
        Me.Cmb_User.Location = New System.Drawing.Point(6, 22)
        Me.Cmb_User.Name = "Cmb_User"
        Me.Cmb_User.Size = New System.Drawing.Size(262, 21)
        Me.Cmb_User.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(271, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "ID :"
        '
        'Txt_UserID
        '
        Me.Txt_UserID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_UserID.Location = New System.Drawing.Point(271, 22)
        Me.Txt_UserID.Name = "Txt_UserID"
        Me.Txt_UserID.Size = New System.Drawing.Size(90, 21)
        Me.Txt_UserID.TabIndex = 1
        Me.Txt_UserID.TabStop = False
        Me.Txt_UserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Cmd_Close)
        Me.Panel1.Controls.Add(Me.Cmd_Save)
        Me.Panel1.Location = New System.Drawing.Point(3, 382)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(588, 40)
        Me.Panel1.TabIndex = 37
        '
        'Cmd_Close
        '
        Me.Cmd_Close.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Close.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Close.Location = New System.Drawing.Point(298, 6)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(83, 28)
        Me.Cmd_Close.TabIndex = 9
        Me.Cmd_Close.Text = "&Close"
        Me.Cmd_Close.UseVisualStyleBackColor = False
        '
        'Cmd_Save
        '
        Me.Cmd_Save.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Save.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Save.Location = New System.Drawing.Point(212, 6)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(83, 28)
        Me.Cmd_Save.TabIndex = 8
        Me.Cmd_Save.Text = "&Save"
        Me.Cmd_Save.UseVisualStyleBackColor = False
        '
        'UserRights_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.ClientSize = New System.Drawing.Size(594, 424)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "UserRights_Frm"
        Me.ShowInTaskbar = false
        Me.Text = "User Rights"
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        CType(Me.Dgv_Rights,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_Accountmaster As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Cmb_User As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_UserID As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cmd_Close As System.Windows.Forms.Button
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
    Friend WithEvents Dgv_Rights As System.Windows.Forms.DataGridView
    Friend WithEvents Cmb_RefUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
