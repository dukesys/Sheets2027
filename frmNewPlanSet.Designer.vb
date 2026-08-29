<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewPlanSet
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
        TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        OK_Button = New System.Windows.Forms.Button()
        Cancel_Button = New System.Windows.Forms.Button()
        GroupBox1 = New System.Windows.Forms.GroupBox()
        cbMetres = New System.Windows.Forms.CheckBox()
        Label9 = New System.Windows.Forms.Label()
        bffTemplate = New BrowseForFile.BrowseForFile()
        bffLoc = New BrowseForFolder.BrowseForFolder()
        Label8 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        nudOverlap = New System.Windows.Forms.NumericUpDown()
        Label2 = New System.Windows.Forms.Label()
        cbScale = New System.Windows.Forms.ComboBox()
        Label1 = New System.Windows.Forms.Label()
        tbCreate = New System.Windows.Forms.TextBox()
        TableLayoutPanel1.SuspendLayout()
        GroupBox1.SuspendLayout()
        CType(nudOverlap, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(OK_Button, 0, 0)
        TableLayoutPanel1.Controls.Add(Cancel_Button, 1, 0)
        TableLayoutPanel1.Location = New System.Drawing.Point(210, 510)
        TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New System.Drawing.Size(292, 67)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' OK_Button
        ' 
        OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        OK_Button.Location = New System.Drawing.Point(6, 7)
        OK_Button.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        OK_Button.Name = "OK_Button"
        OK_Button.Size = New System.Drawing.Size(134, 53)
        OK_Button.TabIndex = 0
        OK_Button.Text = "OK"
        ' 
        ' Cancel_Button
        ' 
        Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Cancel_Button.Location = New System.Drawing.Point(152, 7)
        Cancel_Button.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Cancel_Button.Name = "Cancel_Button"
        Cancel_Button.Size = New System.Drawing.Size(134, 53)
        Cancel_Button.TabIndex = 1
        Cancel_Button.Text = "Cancel"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(cbMetres)
        GroupBox1.Controls.Add(Label9)
        GroupBox1.Controls.Add(bffTemplate)
        GroupBox1.Controls.Add(bffLoc)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(nudOverlap)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(cbScale)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(tbCreate)
        GroupBox1.Location = New System.Drawing.Point(24, 28)
        GroupBox1.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New System.Windows.Forms.Padding(6, 7, 6, 7)
        GroupBox1.Size = New System.Drawing.Size(492, 450)
        GroupBox1.TabIndex = 6
        GroupBox1.TabStop = False
        GroupBox1.Text = "Plan Set"
        ' 
        ' cbMetres
        ' 
        cbMetres.AutoSize = True
        cbMetres.Checked = True
        cbMetres.CheckState = System.Windows.Forms.CheckState.Checked
        cbMetres.Location = New System.Drawing.Point(124, 369)
        cbMetres.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        cbMetres.Name = "cbMetres"
        cbMetres.Size = New System.Drawing.Size(164, 34)
        cbMetres.TabIndex = 18
        cbMetres.Text = "Units=Metres"
        cbMetres.UseVisualStyleBackColor = True
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New System.Drawing.Point(12, 316)
        Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(97, 30)
        Label9.TabIndex = 17
        Label9.Text = "Template"
        ' 
        ' bffTemplate
        ' 
        bffTemplate.Filter = "Templates  (*.dwt)|*.dwt"
        bffTemplate.IsAcadFile = False
        bffTemplate.Location = New System.Drawing.Point(124, 309)
        bffTemplate.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        bffTemplate.MaximumSize = New System.Drawing.Size(1996, 35)
        bffTemplate.MinimumSize = New System.Drawing.Size(196, 35)
        bffTemplate.Name = "bffTemplate"
        bffTemplate.Size = New System.Drawing.Size(340, 35)
        bffTemplate.TabIndex = 16
        bffTemplate.Title = ""
        ' 
        ' bffLoc
        ' 
        bffLoc.Location = New System.Drawing.Point(124, 251)
        bffLoc.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        bffLoc.MaximumSize = New System.Drawing.Size(1996, 35)
        bffLoc.MinimumSize = New System.Drawing.Size(196, 35)
        bffLoc.Name = "bffLoc"
        bffLoc.Size = New System.Drawing.Size(340, 35)
        bffLoc.TabIndex = 15
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(12, 254)
        Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(92, 30)
        Label8.TabIndex = 14
        Label8.Text = "Location"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(12, 192)
        Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(85, 30)
        Label3.TabIndex = 8
        Label3.Text = "Overlap"
        ' 
        ' nudOverlap
        ' 
        nudOverlap.Location = New System.Drawing.Point(124, 187)
        nudOverlap.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        nudOverlap.Name = "nudOverlap"
        nudOverlap.Size = New System.Drawing.Size(344, 35)
        nudOverlap.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(12, 132)
        Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(61, 30)
        Label2.TabIndex = 6
        Label2.Text = "Scale"
        ' 
        ' cbScale
        ' 
        cbScale.FormattingEnabled = True
        cbScale.Items.AddRange(New Object() {"1000", "500", "250", "200", "100", "50"})
        cbScale.Location = New System.Drawing.Point(124, 125)
        cbScale.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        cbScale.Name = "cbScale"
        cbScale.Size = New System.Drawing.Size(340, 38)
        cbScale.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 72)
        Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(69, 30)
        Label1.TabIndex = 3
        Label1.Text = "Name"
        ' 
        ' tbCreate
        ' 
        tbCreate.Location = New System.Drawing.Point(124, 65)
        tbCreate.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        tbCreate.Name = "tbCreate"
        tbCreate.Size = New System.Drawing.Size(340, 35)
        tbCreate.TabIndex = 2
        ' 
        ' frmNewPlanSet
        ' 
        AcceptButton = OK_Button
        AutoScaleDimensions = New System.Drawing.SizeF(12F, 30F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        CancelButton = Cancel_Button
        ClientSize = New System.Drawing.Size(526, 605)
        Controls.Add(GroupBox1)
        Controls.Add(TableLayoutPanel1)
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmNewPlanSet"
        ShowInTaskbar = False
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Text = "New Plan Set"
        TableLayoutPanel1.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(nudOverlap, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents bffTemplate As BrowseForFile.BrowseForFile
    Friend WithEvents bffLoc As BrowseForFolder.BrowseForFolder
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudOverlap As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbScale As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbCreate As System.Windows.Forms.TextBox
    Friend WithEvents cbMetres As System.Windows.Forms.CheckBox

End Class
