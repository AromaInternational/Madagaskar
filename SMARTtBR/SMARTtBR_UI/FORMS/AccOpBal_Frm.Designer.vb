<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccOpBal_Frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccOpBal_Frm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cmd_Close = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Save = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Cmb_TrUnit = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Cmb_AccBalType = New System.Windows.Forms.ComboBox()
        Me.Txt_AccBalance = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Dtp_AccOpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmb_FinYear = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Txt_AccName = New System.Windows.Forms.TextBox()
        Me.Txt_AccCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmb_ActveStatus = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_AccOpId = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(2, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(395, 28)
        Me.Panel1.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(67, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(265, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "ACCOUNT OPENING BALANCE"
        '
        'Cmd_Close
        '
        Me.Cmd_Close.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Close.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Close.Location = New System.Drawing.Point(220, 5)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Close.TabIndex = 13
        Me.Cmd_Close.Text = "&Close"
        Me.Cmd_Close.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Clear.Location = New System.Drawing.Point(141, 5)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Clear.TabIndex = 12
        Me.Cmd_Clear.Text = "C&lear"
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Save
        '
        Me.Cmd_Save.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Save.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Save.Location = New System.Drawing.Point(61, 5)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Save.TabIndex = 11
        Me.Cmd_Save.Text = "&Save"
        Me.Cmd_Save.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Cmd_Clear)
        Me.Panel2.Controls.Add(Me.Cmd_Save)
        Me.Panel2.Controls.Add(Me.Cmd_Close)
        Me.Panel2.Location = New System.Drawing.Point(2, 211)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(395, 39)
        Me.Panel2.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "OP.ID :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Cmb_TrUnit)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Cmb_AccBalType)
        Me.Panel3.Controls.Add(Me.Txt_AccBalance)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Cmb_ActveStatus)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Txt_AccOpId)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(2, 35)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(395, 170)
        Me.Panel3.TabIndex = 0
        '
        'Cmb_TrUnit
        '
        Me.Cmb_TrUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_TrUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_TrUnit.FormattingEnabled = True
        Me.Cmb_TrUnit.Location = New System.Drawing.Point(77, 69)
        Me.Cmb_TrUnit.Name = "Cmb_TrUnit"
        Me.Cmb_TrUnit.Size = New System.Drawing.Size(310, 21)
        Me.Cmb_TrUnit.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 97
        Me.Label8.Text = "For.Unit :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_AccBalType
        '
        Me.Cmb_AccBalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_AccBalType.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_AccBalType.FormattingEnabled = True
        Me.Cmb_AccBalType.Location = New System.Drawing.Point(180, 135)
        Me.Cmb_AccBalType.Name = "Cmb_AccBalType"
        Me.Cmb_AccBalType.Size = New System.Drawing.Size(50, 22)
        Me.Cmb_AccBalType.TabIndex = 9
        '
        'Txt_AccBalance
        '
        Me.Txt_AccBalance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AccBalance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Txt_AccBalance.Location = New System.Drawing.Point(77, 135)
        Me.Txt_AccBalance.Name = "Txt_AccBalance"
        Me.Txt_AccBalance.Size = New System.Drawing.Size(102, 22)
        Me.Txt_AccBalance.TabIndex = 8
        Me.Txt_AccBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Amount :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Dtp_AccOpDate)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Cmb_FinYear)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Location = New System.Drawing.Point(7, 7)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(380, 28)
        Me.Panel5.TabIndex = 0
        Me.Panel5.TabStop = True
        '
        'Dtp_AccOpDate
        '
        Me.Dtp_AccOpDate.Enabled = False
        Me.Dtp_AccOpDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Dtp_AccOpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp_AccOpDate.Location = New System.Drawing.Point(279, 3)
        Me.Dtp_AccOpDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.Dtp_AccOpDate.Name = "Dtp_AccOpDate"
        Me.Dtp_AccOpDate.Size = New System.Drawing.Size(94, 21)
        Me.Dtp_AccOpDate.TabIndex = 2
        Me.Dtp_AccOpDate.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(215, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "OP.Date :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_FinYear
        '
        Me.Cmb_FinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_FinYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmb_FinYear.FormattingEnabled = True
        Me.Cmb_FinYear.Location = New System.Drawing.Point(69, 3)
        Me.Cmb_FinYear.Name = "Cmb_FinYear"
        Me.Cmb_FinYear.Size = New System.Drawing.Size(101, 21)
        Me.Cmb_FinYear.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 14)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Fin.Year :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Txt_AccName)
        Me.Panel4.Controls.Add(Me.Txt_AccCode)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Location = New System.Drawing.Point(7, 96)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(380, 30)
        Me.Panel4.TabIndex = 6
        '
        'Txt_AccName
        '
        Me.Txt_AccName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_AccName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_AccName.Location = New System.Drawing.Point(141, 4)
        Me.Txt_AccName.Name = "Txt_AccName"
        Me.Txt_AccName.ReadOnly = True
        Me.Txt_AccName.Size = New System.Drawing.Size(231, 21)
        Me.Txt_AccName.TabIndex = 7
        Me.Txt_AccName.TabStop = False
        '
        'Txt_AccCode
        '
        Me.Txt_AccCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AccCode.Location = New System.Drawing.Point(69, 4)
        Me.Txt_AccCode.Name = "Txt_AccCode"
        Me.Txt_AccCode.Size = New System.Drawing.Size(71, 21)
        Me.Txt_AccCode.TabIndex = 6
        Me.Txt_AccCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-2, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Acc.Code :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_ActveStatus
        '
        Me.Cmb_ActveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_ActveStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_ActveStatus.FormattingEnabled = True
        Me.Cmb_ActveStatus.Location = New System.Drawing.Point(287, 135)
        Me.Cmb_ActveStatus.Name = "Cmb_ActveStatus"
        Me.Cmb_ActveStatus.Size = New System.Drawing.Size(99, 22)
        Me.Cmb_ActveStatus.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(232, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 14)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Status :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_AccOpId
        '
        Me.Txt_AccOpId.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_AccOpId.Location = New System.Drawing.Point(77, 42)
        Me.Txt_AccOpId.Name = "Txt_AccOpId"
        Me.Txt_AccOpId.Size = New System.Drawing.Size(102, 21)
        Me.Txt_AccOpId.TabIndex = 4
        Me.Txt_AccOpId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccOpBal_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(398, 261)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AccOpBal_Frm"
        Me.ShowInTaskbar = False
        Me.Text = "ACCOUNT OPENING BALANCE"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
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
    Friend WithEvents Cmb_ActveStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_AccOpId As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Txt_AccName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_AccCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmb_FinYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Dtp_AccOpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_AccBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cmb_AccBalType As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Cmb_TrUnit As System.Windows.Forms.ComboBox
End Class
