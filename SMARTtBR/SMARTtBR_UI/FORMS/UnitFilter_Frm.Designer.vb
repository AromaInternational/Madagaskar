<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnitFilter_Frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UnitFilter_Frm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Tvw_Unit = New System.Windows.Forms.TreeView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Cmd_Ok = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Rd_CollapseAll = New System.Windows.Forms.RadioButton()
        Me.Rd_ExpandAll = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(308, 28)
        Me.Panel1.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(99, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "UNIT FILTER"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Tvw_Unit)
        Me.Panel2.Location = New System.Drawing.Point(0, 56)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(308, 284)
        Me.Panel2.TabIndex = 0
        '
        'Tvw_Unit
        '
        Me.Tvw_Unit.CheckBoxes = True
        Me.Tvw_Unit.Location = New System.Drawing.Point(1, 1)
        Me.Tvw_Unit.Name = "Tvw_Unit"
        Me.Tvw_Unit.SelectedImageKey = "señal.ico"
        Me.Tvw_Unit.Size = New System.Drawing.Size(304, 280)
        Me.Tvw_Unit.TabIndex = 98
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Cmd_Ok)
        Me.Panel3.Location = New System.Drawing.Point(0, 342)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(308, 31)
        Me.Panel3.TabIndex = 2
        '
        'Cmd_Ok
        '
        Me.Cmd_Ok.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Cmd_Ok.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Ok.Location = New System.Drawing.Point(110, 1)
        Me.Cmd_Ok.Name = "Cmd_Ok"
        Me.Cmd_Ok.Size = New System.Drawing.Size(78, 27)
        Me.Cmd_Ok.TabIndex = 2
        Me.Cmd_Ok.Text = "&Ok"
        Me.Cmd_Ok.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Rd_CollapseAll)
        Me.Panel4.Controls.Add(Me.Rd_ExpandAll)
        Me.Panel4.Location = New System.Drawing.Point(0, 32)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(308, 22)
        Me.Panel4.TabIndex = 12
        '
        'Rd_CollapseAll
        '
        Me.Rd_CollapseAll.AutoSize = True
        Me.Rd_CollapseAll.Location = New System.Drawing.Point(173, 1)
        Me.Rd_CollapseAll.Name = "Rd_CollapseAll"
        Me.Rd_CollapseAll.Size = New System.Drawing.Size(84, 18)
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
        Me.Rd_ExpandAll.Size = New System.Drawing.Size(81, 18)
        Me.Rd_ExpandAll.TabIndex = 0
        Me.Rd_ExpandAll.TabStop = True
        Me.Rd_ExpandAll.Text = "Expand All"
        Me.Rd_ExpandAll.UseVisualStyleBackColor = True
        '
        'UnitFilter_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.ClientSize = New System.Drawing.Size(309, 374)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UnitFilter_Frm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Cmd_Ok As System.Windows.Forms.Button
    Friend WithEvents Tvw_Unit As System.Windows.Forms.TreeView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Rd_CollapseAll As System.Windows.Forms.RadioButton
    Friend WithEvents Rd_ExpandAll As System.Windows.Forms.RadioButton
End Class
