<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Designation_Frm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Designation_Frm))
        Me.Pnl_Head = New System.Windows.Forms.Panel()
        Me.lbl_Accountmaster = New System.Windows.Forms.Label()
        Me.Cmd_Close = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Save = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cmb_ActveStatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_DesName = New System.Windows.Forms.TextBox()
        Me.Txt_DesID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Dgd_Designation = New System.Windows.Forms.DataGridView()
        Me.Pnl_Head.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Dgd_Designation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Head
        '
        Me.Pnl_Head.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Pnl_Head.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnl_Head.Controls.Add(Me.lbl_Accountmaster)
        Me.Pnl_Head.Location = New System.Drawing.Point(0, 11)
        Me.Pnl_Head.Name = "Pnl_Head"
        Me.Pnl_Head.Size = New System.Drawing.Size(378, 44)
        Me.Pnl_Head.TabIndex = 30
        '
        'lbl_Accountmaster
        '
        Me.lbl_Accountmaster.AutoSize = True
        Me.lbl_Accountmaster.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Accountmaster.ForeColor = System.Drawing.Color.DimGray
        Me.lbl_Accountmaster.Location = New System.Drawing.Point(109, 11)
        Me.lbl_Accountmaster.Name = "lbl_Accountmaster"
        Me.lbl_Accountmaster.Size = New System.Drawing.Size(153, 24)
        Me.lbl_Accountmaster.TabIndex = 0
        Me.lbl_Accountmaster.Text = "DESIGNATION"
        '
        'Cmd_Close
        '
        Me.Cmd_Close.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Close.Location = New System.Drawing.Point(236, 395)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Close.TabIndex = 5
        Me.Cmd_Close.Text = "&Close"
        Me.Cmd_Close.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Location = New System.Drawing.Point(150, 395)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Clear.TabIndex = 4
        Me.Cmd_Clear.Text = "C&lear"
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Save
        '
        Me.Cmd_Save.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Save.Location = New System.Drawing.Point(66, 395)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Save.TabIndex = 3
        Me.Cmd_Save.Text = "&Save"
        Me.Cmd_Save.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Cmb_ActveStatus)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Txt_DesName)
        Me.Panel1.Controls.Add(Me.Txt_DesID)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(0, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(378, 78)
        Me.Panel1.TabIndex = 36
        '
        'Cmb_ActveStatus
        '
        Me.Cmb_ActveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_ActveStatus.FormattingEnabled = True
        Me.Cmb_ActveStatus.Location = New System.Drawing.Point(132, 52)
        Me.Cmb_ActveStatus.Name = "Cmb_ActveStatus"
        Me.Cmb_ActveStatus.Size = New System.Drawing.Size(153, 21)
        Me.Cmb_ActveStatus.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(76, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Status :"
        '
        'Txt_DesName
        '
        Me.Txt_DesName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DesName.Location = New System.Drawing.Point(132, 28)
        Me.Txt_DesName.Name = "Txt_DesName"
        Me.Txt_DesName.Size = New System.Drawing.Size(210, 21)
        Me.Txt_DesName.TabIndex = 1
        '
        'Txt_DesID
        '
        Me.Txt_DesID.Location = New System.Drawing.Point(132, 6)
        Me.Txt_DesID.Name = "Txt_DesID"
        Me.Txt_DesID.Size = New System.Drawing.Size(95, 21)
        Me.Txt_DesID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Designation Code :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Designation Name :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Dgd_Designation)
        Me.Panel2.Location = New System.Drawing.Point(0, 139)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(378, 248)
        Me.Panel2.TabIndex = 37
        '
        'Dgd_Designation
        '
        Me.Dgd_Designation.AllowUserToAddRows = False
        Me.Dgd_Designation.AllowUserToDeleteRows = False
        Me.Dgd_Designation.AllowUserToOrderColumns = True
        Me.Dgd_Designation.AllowUserToResizeRows = False
        Me.Dgd_Designation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgd_Designation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgd_Designation.DefaultCellStyle = DataGridViewCellStyle1
        Me.Dgd_Designation.Location = New System.Drawing.Point(3, 3)
        Me.Dgd_Designation.MultiSelect = False
        Me.Dgd_Designation.Name = "Dgd_Designation"
        Me.Dgd_Designation.ReadOnly = True
        Me.Dgd_Designation.RowHeadersWidth = 5
        Me.Dgd_Designation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgd_Designation.Size = New System.Drawing.Size(371, 241)
        Me.Dgd_Designation.TabIndex = 6
        '
        'Designation_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(378, 432)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Cmd_Close)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Save)
        Me.Controls.Add(Me.Pnl_Head)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Designation_Frm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DESIGNATION"
        Me.Pnl_Head.ResumeLayout(False)
        Me.Pnl_Head.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.Dgd_Designation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Head As System.Windows.Forms.Panel
    Friend WithEvents lbl_Accountmaster As System.Windows.Forms.Label
    Friend WithEvents Cmd_Close As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Dgd_Designation As System.Windows.Forms.DataGridView
    Friend WithEvents Txt_DesName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DesID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cmb_ActveStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
