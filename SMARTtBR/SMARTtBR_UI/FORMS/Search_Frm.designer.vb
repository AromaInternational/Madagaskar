<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search_Frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Search_Frm))
        Me.DgvSearch = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Rd_EndWith = New System.Windows.Forms.RadioButton()
        Me.Rd_Contains = New System.Windows.Forms.RadioButton()
        Me.Rd_StartWith = New System.Windows.Forms.RadioButton()
        Me.LblField = New System.Windows.Forms.Label()
        Me.TxtFilter = New System.Windows.Forms.TextBox()
        CType(Me.DgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvSearch
        '
        Me.DgvSearch.AllowUserToAddRows = False
        Me.DgvSearch.AllowUserToDeleteRows = False
        Me.DgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Bisque
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgvSearch.Location = New System.Drawing.Point(1, 35)
        Me.DgvSearch.Name = "DgvSearch"
        Me.DgvSearch.RowHeadersWidth = 5
        Me.DgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSearch.Size = New System.Drawing.Size(905, 463)
        Me.DgvSearch.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.LblField)
        Me.Panel2.Controls.Add(Me.TxtFilter)
        Me.Panel2.Location = New System.Drawing.Point(1, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(905, 33)
        Me.Panel2.TabIndex = 502
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Rd_EndWith)
        Me.Panel1.Controls.Add(Me.Rd_Contains)
        Me.Panel1.Controls.Add(Me.Rd_StartWith)
        Me.Panel1.Location = New System.Drawing.Point(679, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(222, 27)
        Me.Panel1.TabIndex = 1
        '
        'Rd_EndWith
        '
        Me.Rd_EndWith.AutoSize = True
        Me.Rd_EndWith.Location = New System.Drawing.Point(149, 4)
        Me.Rd_EndWith.Name = "Rd_EndWith"
        Me.Rd_EndWith.Size = New System.Drawing.Size(69, 17)
        Me.Rd_EndWith.TabIndex = 4
        Me.Rd_EndWith.Text = "&End With"
        Me.Rd_EndWith.UseVisualStyleBackColor = True
        '
        'Rd_Contains
        '
        Me.Rd_Contains.AutoSize = True
        Me.Rd_Contains.Location = New System.Drawing.Point(78, 4)
        Me.Rd_Contains.Name = "Rd_Contains"
        Me.Rd_Contains.Size = New System.Drawing.Size(66, 17)
        Me.Rd_Contains.TabIndex = 3
        Me.Rd_Contains.Text = "&Contains"
        Me.Rd_Contains.UseVisualStyleBackColor = True
        '
        'Rd_StartWith
        '
        Me.Rd_StartWith.AutoSize = True
        Me.Rd_StartWith.Checked = True
        Me.Rd_StartWith.Location = New System.Drawing.Point(4, 4)
        Me.Rd_StartWith.Name = "Rd_StartWith"
        Me.Rd_StartWith.Size = New System.Drawing.Size(72, 17)
        Me.Rd_StartWith.TabIndex = 2
        Me.Rd_StartWith.TabStop = True
        Me.Rd_StartWith.Text = "&Start With"
        Me.Rd_StartWith.UseVisualStyleBackColor = True
        '
        'LblField
        '
        Me.LblField.AutoSize = True
        Me.LblField.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblField.ForeColor = System.Drawing.Color.Red
        Me.LblField.Location = New System.Drawing.Point(6, 10)
        Me.LblField.Name = "LblField"
        Me.LblField.Size = New System.Drawing.Size(80, 13)
        Me.LblField.TabIndex = 4
        Me.LblField.Text = "Filter Display"
        '
        'TxtFilter
        '
        Me.TxtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFilter.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtFilter.Location = New System.Drawing.Point(337, 5)
        Me.TxtFilter.Name = "TxtFilter"
        Me.TxtFilter.Size = New System.Drawing.Size(333, 22)
        Me.TxtFilter.TabIndex = 0
        '
        'Search_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SMARTtBR_UI.My.Resources.Resources.Backgroud
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(907, 498)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.DgvSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Search_Frm"
        Me.ShowInTaskbar = False
        Me.Text = "Search(Press F2 For Freez Search)"
        CType(Me.DgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvSearch As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LblField As System.Windows.Forms.Label
    Friend WithEvents TxtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Rd_EndWith As System.Windows.Forms.RadioButton
    Friend WithEvents Rd_Contains As System.Windows.Forms.RadioButton
    Friend WithEvents Rd_StartWith As System.Windows.Forms.RadioButton
End Class
