<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnitMaster_Frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UnitMaster_Frm))
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Cmd_Close = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Save = New System.Windows.Forms.Button()
        Me.Dgd_Logs = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Cmb_Company = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cmb_ActveStatus = New System.Windows.Forms.ComboBox()
        Me.Txt_UNName = New System.Windows.Forms.TextBox()
        Me.Txt_UNID = New System.Windows.Forms.TextBox()
        Me.Cmd_UnitSearch = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Panel9.SuspendLayout()
        CType(Me.Dgd_Logs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.Cmd_Close)
        Me.Panel9.Controls.Add(Me.Cmd_Clear)
        Me.Panel9.Controls.Add(Me.Cmd_Save)
        Me.Panel9.Location = New System.Drawing.Point(1, 263)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(648, 29)
        Me.Panel9.TabIndex = 5
        Me.Panel9.TabStop = True
        '
        'Cmd_Close
        '
        Me.Cmd_Close.Location = New System.Drawing.Point(384, 0)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(60, 27)
        Me.Cmd_Close.TabIndex = 8
        Me.Cmd_Close.Text = "Close"
        Me.Cmd_Close.UseVisualStyleBackColor = True
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Location = New System.Drawing.Point(324, 0)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(60, 27)
        Me.Cmd_Clear.TabIndex = 7
        Me.Cmd_Clear.Text = "Clear"
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'Cmd_Save
        '
        Me.Cmd_Save.Location = New System.Drawing.Point(265, 0)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(60, 27)
        Me.Cmd_Save.TabIndex = 6
        Me.Cmd_Save.Text = "Save"
        Me.Cmd_Save.UseVisualStyleBackColor = True
        '
        'Dgd_Logs
        '
        Me.Dgd_Logs.AllowUserToAddRows = False
        Me.Dgd_Logs.AllowUserToDeleteRows = False
        Me.Dgd_Logs.AllowUserToOrderColumns = True
        Me.Dgd_Logs.AllowUserToResizeRows = False
        Me.Dgd_Logs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dgd_Logs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dgd_Logs.DefaultCellStyle = DataGridViewCellStyle1
        Me.Dgd_Logs.Location = New System.Drawing.Point(1, 95)
        Me.Dgd_Logs.MultiSelect = False
        Me.Dgd_Logs.Name = "Dgd_Logs"
        Me.Dgd_Logs.ReadOnly = True
        Me.Dgd_Logs.RowHeadersWidth = 5
        Me.Dgd_Logs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgd_Logs.Size = New System.Drawing.Size(648, 166)
        Me.Dgd_Logs.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Cmb_Company)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Cmb_ActveStatus)
        Me.Panel2.Controls.Add(Me.Txt_UNName)
        Me.Panel2.Controls.Add(Me.Txt_UNID)
        Me.Panel2.Controls.Add(Me.Cmd_UnitSearch)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Location = New System.Drawing.Point(1, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(648, 91)
        Me.Panel2.TabIndex = 0
        Me.Panel2.TabStop = True
        '
        'Cmb_Company
        '
        Me.Cmb_Company.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Company.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Company.FormattingEnabled = True
        Me.Cmb_Company.Location = New System.Drawing.Point(77, 9)
        Me.Cmb_Company.Name = "Cmb_Company"
        Me.Cmb_Company.Size = New System.Drawing.Size(262, 21)
        Me.Cmb_Company.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Company :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Name :"
        '
        'Cmb_ActveStatus
        '
        Me.Cmb_ActveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_ActveStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_ActveStatus.FormattingEnabled = True
        Me.Cmb_ActveStatus.Location = New System.Drawing.Point(77, 63)
        Me.Cmb_ActveStatus.Name = "Cmb_ActveStatus"
        Me.Cmb_ActveStatus.Size = New System.Drawing.Size(143, 21)
        Me.Cmb_ActveStatus.TabIndex = 4
        '
        'Txt_UNName
        '
        Me.Txt_UNName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_UNName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_UNName.Location = New System.Drawing.Point(77, 36)
        Me.Txt_UNName.Name = "Txt_UNName"
        Me.Txt_UNName.Size = New System.Drawing.Size(262, 21)
        Me.Txt_UNName.TabIndex = 1
        '
        'Txt_UNID
        '
        Me.Txt_UNID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_UNID.Location = New System.Drawing.Point(341, 36)
        Me.Txt_UNID.Name = "Txt_UNID"
        Me.Txt_UNID.ReadOnly = True
        Me.Txt_UNID.Size = New System.Drawing.Size(73, 21)
        Me.Txt_UNID.TabIndex = 2
        Me.Txt_UNID.TabStop = False
        Me.Txt_UNID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Cmd_UnitSearch
        '
        Me.Cmd_UnitSearch.BackgroundImage = CType(resources.GetObject("Cmd_UnitSearch.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_UnitSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_UnitSearch.Location = New System.Drawing.Point(416, 35)
        Me.Cmd_UnitSearch.Name = "Cmd_UnitSearch"
        Me.Cmd_UnitSearch.Size = New System.Drawing.Size(36, 23)
        Me.Cmd_UnitSearch.TabIndex = 3
        Me.Cmd_UnitSearch.TabStop = False
        Me.Cmd_UnitSearch.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(23, 67)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(50, 13)
        Me.Label24.TabIndex = 42
        Me.Label24.Text = "Status :"
        '
        'UnitMaster_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(650, 293)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Dgd_Logs)
        Me.Controls.Add(Me.Panel9)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UnitMaster_Frm"
        Me.ShowInTaskbar = False
        Me.Text = "UNIT MASTER"
        Me.Panel9.ResumeLayout(False)
        CType(Me.Dgd_Logs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
    Friend WithEvents Dgd_Logs As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmb_ActveStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_UNName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_UNID As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_UnitSearch As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Company As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Close As System.Windows.Forms.Button
End Class
