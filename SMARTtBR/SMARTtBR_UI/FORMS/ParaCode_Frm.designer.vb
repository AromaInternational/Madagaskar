<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParaCode_Frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ParaCode_Frm))
        Me.Tvw_ParamList = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Cmd_Close = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Save = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Txt_PCID = New System.Windows.Forms.TextBox()
        Me.Tp_Parameters = New System.Windows.Forms.TabPage()
        Me.Cmb_PCType = New System.Windows.Forms.ComboBox()
        Me.Cmb_ActiveStatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_PCOrder = New System.Windows.Forms.TextBox()
        Me.Txt_PCDescription = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SST_Accnt_Master = New System.Windows.Forms.TabControl()
        Me.Pnl_Head = New System.Windows.Forms.Panel()
        Me.lbl_Accountmaster = New System.Windows.Forms.Label()
        Me.Tp_Parameters.SuspendLayout()
        Me.SST_Accnt_Master.SuspendLayout()
        Me.Pnl_Head.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tvw_ParamList
        '
        Me.Tvw_ParamList.ImageIndex = 0
        Me.Tvw_ParamList.ImageList = Me.ImageList1
        Me.Tvw_ParamList.Location = New System.Drawing.Point(2, 57)
        Me.Tvw_ParamList.Name = "Tvw_ParamList"
        Me.Tvw_ParamList.SelectedImageKey = "señal.ico"
        Me.Tvw_ParamList.Size = New System.Drawing.Size(240, 283)
        Me.Tvw_ParamList.TabIndex = 27
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
        Me.Cmd_Close.Location = New System.Drawing.Point(440, 268)
        Me.Cmd_Close.Name = "Cmd_Close"
        Me.Cmd_Close.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Close.TabIndex = 8
        Me.Cmd_Close.Text = "&Close"
        Me.Cmd_Close.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Location = New System.Drawing.Point(354, 268)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Clear.TabIndex = 7
        Me.Cmd_Clear.Text = "C&lear"
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Save
        '
        Me.Cmd_Save.BackColor = System.Drawing.Color.DarkKhaki
        Me.Cmd_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Save.Location = New System.Drawing.Point(270, 268)
        Me.Cmd_Save.Name = "Cmd_Save"
        Me.Cmd_Save.Size = New System.Drawing.Size(78, 28)
        Me.Cmd_Save.TabIndex = 6
        Me.Cmd_Save.Text = "&Save"
        Me.Cmd_Save.UseVisualStyleBackColor = False
        '
        'Txt_PCID
        '
        Me.Txt_PCID.Location = New System.Drawing.Point(133, 6)
        Me.Txt_PCID.Name = "Txt_PCID"
        Me.Txt_PCID.Size = New System.Drawing.Size(95, 21)
        Me.Txt_PCID.TabIndex = 1
        Me.Txt_PCID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.Txt_PCID, "Press F3 to search")
        '
        'Tp_Parameters
        '
        Me.Tp_Parameters.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Tp_Parameters.Controls.Add(Me.Cmb_PCType)
        Me.Tp_Parameters.Controls.Add(Me.Cmb_ActiveStatus)
        Me.Tp_Parameters.Controls.Add(Me.Label3)
        Me.Tp_Parameters.Controls.Add(Me.Txt_PCID)
        Me.Tp_Parameters.Controls.Add(Me.Txt_PCOrder)
        Me.Tp_Parameters.Controls.Add(Me.Txt_PCDescription)
        Me.Tp_Parameters.Controls.Add(Me.Label16)
        Me.Tp_Parameters.Controls.Add(Me.Label15)
        Me.Tp_Parameters.Controls.Add(Me.Label14)
        Me.Tp_Parameters.Controls.Add(Me.Label13)
        Me.Tp_Parameters.Location = New System.Drawing.Point(4, 22)
        Me.Tp_Parameters.Name = "Tp_Parameters"
        Me.Tp_Parameters.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_Parameters.Size = New System.Drawing.Size(294, 158)
        Me.Tp_Parameters.TabIndex = 0
        Me.Tp_Parameters.Text = "Parameters"
        '
        'Cmb_PCType
        '
        Me.Cmb_PCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_PCType.FormattingEnabled = True
        Me.Cmb_PCType.Location = New System.Drawing.Point(133, 96)
        Me.Cmb_PCType.Name = "Cmb_PCType"
        Me.Cmb_PCType.Size = New System.Drawing.Size(153, 21)
        Me.Cmb_PCType.TabIndex = 4
        '
        'Cmb_ActiveStatus
        '
        Me.Cmb_ActiveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_ActiveStatus.FormattingEnabled = True
        Me.Cmb_ActiveStatus.Location = New System.Drawing.Point(133, 125)
        Me.Cmb_ActiveStatus.Name = "Cmb_ActiveStatus"
        Me.Cmb_ActiveStatus.Size = New System.Drawing.Size(153, 21)
        Me.Cmb_ActiveStatus.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(11, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Status "
        '
        'Txt_PCOrder
        '
        Me.Txt_PCOrder.Location = New System.Drawing.Point(133, 67)
        Me.Txt_PCOrder.Name = "Txt_PCOrder"
        Me.Txt_PCOrder.Size = New System.Drawing.Size(95, 21)
        Me.Txt_PCOrder.TabIndex = 3
        Me.Txt_PCOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_PCDescription
        '
        Me.Txt_PCDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_PCDescription.Location = New System.Drawing.Point(133, 37)
        Me.Txt_PCDescription.Name = "Txt_PCDescription"
        Me.Txt_PCDescription.Size = New System.Drawing.Size(152, 21)
        Me.Txt_PCDescription.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(9, 98)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(113, 13)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Parent Group Code"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(9, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Seq. No. "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(9, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Para.Name"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(9, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Para Code"
        '
        'SST_Accnt_Master
        '
        Me.SST_Accnt_Master.Controls.Add(Me.Tp_Parameters)
        Me.SST_Accnt_Master.Location = New System.Drawing.Point(245, 58)
        Me.SST_Accnt_Master.Name = "SST_Accnt_Master"
        Me.SST_Accnt_Master.SelectedIndex = 0
        Me.SST_Accnt_Master.Size = New System.Drawing.Size(302, 184)
        Me.SST_Accnt_Master.TabIndex = 0
        '
        'Pnl_Head
        '
        Me.Pnl_Head.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Pnl_Head.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnl_Head.Controls.Add(Me.lbl_Accountmaster)
        Me.Pnl_Head.Location = New System.Drawing.Point(0, 9)
        Me.Pnl_Head.Name = "Pnl_Head"
        Me.Pnl_Head.Size = New System.Drawing.Size(544, 44)
        Me.Pnl_Head.TabIndex = 32
        '
        'lbl_Accountmaster
        '
        Me.lbl_Accountmaster.AutoSize = True
        Me.lbl_Accountmaster.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Accountmaster.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lbl_Accountmaster.Location = New System.Drawing.Point(134, 11)
        Me.lbl_Accountmaster.Name = "lbl_Accountmaster"
        Me.lbl_Accountmaster.Size = New System.Drawing.Size(246, 24)
        Me.lbl_Accountmaster.TabIndex = 0
        Me.lbl_Accountmaster.Text = "COMMON PRAMETERS"
        '
        'ParaCode_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(547, 343)
        Me.Controls.Add(Me.Pnl_Head)
        Me.Controls.Add(Me.Cmd_Close)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Tvw_ParamList)
        Me.Controls.Add(Me.Cmd_Save)
        Me.Controls.Add(Me.SST_Accnt_Master)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ParaCode_Frm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "COMMON PRAMETERS"
        Me.Tp_Parameters.ResumeLayout(False)
        Me.Tp_Parameters.PerformLayout()
        Me.SST_Accnt_Master.ResumeLayout(False)
        Me.Pnl_Head.ResumeLayout(False)
        Me.Pnl_Head.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tvw_ParamList As System.Windows.Forms.TreeView
    Friend WithEvents Cmd_Close As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Save As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Tp_Parameters As System.Windows.Forms.TabPage
    Friend WithEvents Cmb_ActiveStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_PCID As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PCOrder As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PCDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents SST_Accnt_Master As System.Windows.Forms.TabControl
    Friend WithEvents Cmb_PCType As System.Windows.Forms.ComboBox
    Friend WithEvents Pnl_Head As System.Windows.Forms.Panel
    Friend WithEvents lbl_Accountmaster As System.Windows.Forms.Label
End Class
