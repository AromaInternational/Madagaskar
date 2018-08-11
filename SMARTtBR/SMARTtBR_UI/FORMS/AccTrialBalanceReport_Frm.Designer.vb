<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccTrialBalanceReport_Frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccTrialBalanceReport_Frm))
        Me.Cmd_Show = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Close = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Cmd_UnitFilter = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmb_ReportType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dtp_ToDt = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Dtp_FromDt = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cmd_Show
        '
        Me.Cmd_Show.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Show.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Show.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Show.Location = New System.Drawing.Point(67, 142)
        Me.Cmd_Show.Name = "Cmd_Show"
        Me.Cmd_Show.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Show.TabIndex = 4
        Me.Cmd_Show.Text = "&Show"
        Me.Cmd_Show.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(2, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(364, 32)
        Me.Panel1.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(25, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(316, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "ACCOUNT TRIAL BALACE REPORT"
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Clear.Location = New System.Drawing.Point(147, 142)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Clear.TabIndex = 5
        Me.Cmd_Clear.Text = "C&lear"
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Close
        '
        Me.Cmd_Close.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Close.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Close.Location = New System.Drawing.Point(227, 142)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Close.TabIndex = 6
        Me.Cmd_Close.Text = "&Close"
        Me.Cmd_Close.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Cmd_UnitFilter)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Cmb_ReportType)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Dtp_ToDt)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Dtp_FromDt)
        Me.Panel2.Location = New System.Drawing.Point(2, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(364, 95)
        Me.Panel2.TabIndex = 0
        '
        'Cmd_UnitFilter
        '
        Me.Cmd_UnitFilter.BackgroundImage = CType(resources.GetObject("Cmd_UnitFilter.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_UnitFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Cmd_UnitFilter.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_UnitFilter.Location = New System.Drawing.Point(84, 5)
        Me.Cmd_UnitFilter.Name = "Cmd_UnitFilter"
        Me.Cmd_UnitFilter.Size = New System.Drawing.Size(98, 24)
        Me.Cmd_UnitFilter.TabIndex = 0
        Me.Cmd_UnitFilter.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Unit Filter :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "Rpt.Type :"
        '
        'Cmb_ReportType
        '
        Me.Cmb_ReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_ReportType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_ReportType.FormattingEnabled = True
        Me.Cmb_ReportType.Location = New System.Drawing.Point(85, 62)
        Me.Cmb_ReportType.Name = "Cmb_ReportType"
        Me.Cmb_ReportType.Size = New System.Drawing.Size(270, 21)
        Me.Cmb_ReportType.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "From Date :"
        '
        'Dtp_ToDt
        '
        Me.Dtp_ToDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_ToDt.Location = New System.Drawing.Point(258, 35)
        Me.Dtp_ToDt.Name = "Dtp_ToDt"
        Me.Dtp_ToDt.Size = New System.Drawing.Size(97, 20)
        Me.Dtp_ToDt.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(197, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "To Date :"
        '
        'Dtp_FromDt
        '
        Me.Dtp_FromDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_FromDt.Location = New System.Drawing.Point(85, 35)
        Me.Dtp_FromDt.Name = "Dtp_FromDt"
        Me.Dtp_FromDt.Size = New System.Drawing.Size(97, 20)
        Me.Dtp_FromDt.TabIndex = 1
        '
        'AccTrialBalanceReport_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(366, 175)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Cmd_Close)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Cmd_Show)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AccTrialBalanceReport_Frm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ACCOUNT TRIAL BALACE REPORT"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cmd_Show As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Close As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Dtp_ToDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cmb_ReportType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FromDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cmd_UnitFilter As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
