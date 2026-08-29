<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSheetCentre
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
        Me.components = New System.ComponentModel.Container
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.tbCreate = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btCreate = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.bffTemplate = New BrowseForFile.browseForFile
        Me.bffLoc = New BrowseForFolder.BrowseForFolder
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.nudOverlap = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbScale = New System.Windows.Forms.ComboBox
        Me.tvProject = New System.Windows.Forms.TreeView
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.btCreateSheet = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btTop = New System.Windows.Forms.Button
        Me.btBottom = New System.Windows.Forms.Button
        Me.btRight = New System.Windows.Forms.Button
        Me.btLeft = New System.Windows.Forms.Button
        Me.btXY = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbCount = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbSheetSet = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btRemove = New System.Windows.Forms.Button
        Me.btAdd = New System.Windows.Forms.Button
        Me.lbXref = New System.Windows.Forms.ListBox
        Me.OFD = New System.Windows.Forms.OpenFileDialog
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UpdateDrawingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.FBD = New System.Windows.Forms.FolderBrowserDialog
        Me.AllPlanSetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActivePlanSetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CreateDrawingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BS1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ModifySheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudOverlap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.btCreateSheet.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.BS1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(542, 533)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'tbCreate
        '
        Me.tbCreate.Enabled = False
        Me.tbCreate.Location = New System.Drawing.Point(62, 28)
        Me.tbCreate.Name = "tbCreate"
        Me.tbCreate.Size = New System.Drawing.Size(172, 20)
        Me.tbCreate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Name"
        '
        'btCreate
        '
        Me.btCreate.Enabled = False
        Me.btCreate.Location = New System.Drawing.Point(184, 160)
        Me.btCreate.Name = "btCreate"
        Me.btCreate.Size = New System.Drawing.Size(50, 21)
        Me.btCreate.TabIndex = 4
        Me.btCreate.Text = "Create"
        Me.btCreate.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.bffTemplate)
        Me.GroupBox1.Controls.Add(Me.bffLoc)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.nudOverlap)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbScale)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btCreate)
        Me.GroupBox1.Controls.Add(Me.tbCreate)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(284, 193)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Plan Set"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Location = New System.Drawing.Point(6, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Template"
        '
        'bffTemplate
        '
        Me.bffTemplate.Filter = "Templates  (*.dwt)|*.dwt"
        Me.bffTemplate.IsAcadFile = False
        Me.bffTemplate.Location = New System.Drawing.Point(62, 134)
        Me.bffTemplate.MaximumSize = New System.Drawing.Size(1000, 20)
        Me.bffTemplate.MinimumSize = New System.Drawing.Size(100, 20)
        Me.bffTemplate.Name = "bffTemplate"
        Me.bffTemplate.Size = New System.Drawing.Size(172, 20)
        Me.bffTemplate.TabIndex = 16
        Me.bffTemplate.Title = ""
        '
        'bffLoc
        '
        Me.bffLoc.Enabled = False
        Me.bffLoc.Location = New System.Drawing.Point(62, 107)
        Me.bffLoc.MaximumSize = New System.Drawing.Size(1000, 20)
        Me.bffLoc.MinimumSize = New System.Drawing.Size(100, 20)
        Me.bffLoc.Name = "bffLoc"
        Me.bffLoc.Size = New System.Drawing.Size(172, 20)
        Me.bffLoc.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(6, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Location"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(6, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Overlap"
        '
        'nudOverlap
        '
        Me.nudOverlap.Enabled = False
        Me.nudOverlap.Location = New System.Drawing.Point(62, 81)
        Me.nudOverlap.Name = "nudOverlap"
        Me.nudOverlap.Size = New System.Drawing.Size(172, 20)
        Me.nudOverlap.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(6, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Scale"
        '
        'cbScale
        '
        Me.cbScale.Enabled = False
        Me.cbScale.FormattingEnabled = True
        Me.cbScale.Items.AddRange(New Object() {"1000", "500", "250", "200", "100", "50"})
        Me.cbScale.Location = New System.Drawing.Point(62, 54)
        Me.cbScale.Name = "cbScale"
        Me.cbScale.Size = New System.Drawing.Size(172, 21)
        Me.cbScale.TabIndex = 5
        '
        'tvProject
        '
        Me.tvProject.Enabled = False
        Me.tvProject.Location = New System.Drawing.Point(12, 226)
        Me.tvProject.Name = "tvProject"
        Me.tvProject.Size = New System.Drawing.Size(284, 301)
        Me.tvProject.TabIndex = 6
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.btCreateSheet)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Enabled = False
        Me.TabControl1.Location = New System.Drawing.Point(302, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(392, 495)
        Me.TabControl1.TabIndex = 7
        '
        'btCreateSheet
        '
        Me.btCreateSheet.Controls.Add(Me.GroupBox2)
        Me.btCreateSheet.Controls.Add(Me.Label5)
        Me.btCreateSheet.Controls.Add(Me.tbCount)
        Me.btCreateSheet.Controls.Add(Me.Label4)
        Me.btCreateSheet.Controls.Add(Me.tbSheetSet)
        Me.btCreateSheet.Location = New System.Drawing.Point(4, 22)
        Me.btCreateSheet.Name = "btCreateSheet"
        Me.btCreateSheet.Padding = New System.Windows.Forms.Padding(3)
        Me.btCreateSheet.Size = New System.Drawing.Size(384, 469)
        Me.btCreateSheet.TabIndex = 0
        Me.btCreateSheet.Text = "Sheets"
        Me.btCreateSheet.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btTop)
        Me.GroupBox2.Controls.Add(Me.btBottom)
        Me.GroupBox2.Controls.Add(Me.btRight)
        Me.GroupBox2.Controls.Add(Me.btLeft)
        Me.GroupBox2.Controls.Add(Me.btXY)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(312, 117)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Create New Sheet"
        '
        'btTop
        '
        Me.btTop.Location = New System.Drawing.Point(110, 19)
        Me.btTop.Name = "btTop"
        Me.btTop.Size = New System.Drawing.Size(90, 25)
        Me.btTop.TabIndex = 14
        Me.btTop.Text = "Top"
        Me.btTop.UseVisualStyleBackColor = True
        '
        'btBottom
        '
        Me.btBottom.Location = New System.Drawing.Point(110, 74)
        Me.btBottom.Name = "btBottom"
        Me.btBottom.Size = New System.Drawing.Size(90, 25)
        Me.btBottom.TabIndex = 13
        Me.btBottom.Text = "Bottom"
        Me.btBottom.UseVisualStyleBackColor = True
        '
        'btRight
        '
        Me.btRight.Location = New System.Drawing.Point(200, 46)
        Me.btRight.Name = "btRight"
        Me.btRight.Size = New System.Drawing.Size(90, 25)
        Me.btRight.TabIndex = 12
        Me.btRight.Text = "Right"
        Me.btRight.UseVisualStyleBackColor = True
        '
        'btLeft
        '
        Me.btLeft.Location = New System.Drawing.Point(20, 46)
        Me.btLeft.Name = "btLeft"
        Me.btLeft.Size = New System.Drawing.Size(90, 25)
        Me.btLeft.TabIndex = 11
        Me.btLeft.Text = "Left"
        Me.btLeft.UseVisualStyleBackColor = True
        '
        'btXY
        '
        Me.btXY.Location = New System.Drawing.Point(110, 46)
        Me.btXY.Name = "btXY"
        Me.btXY.Size = New System.Drawing.Size(90, 25)
        Me.btXY.TabIndex = 10
        Me.btXY.Text = "XY"
        Me.btXY.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Count"
        '
        'tbCount
        '
        Me.tbCount.Enabled = False
        Me.tbCount.Location = New System.Drawing.Point(84, 49)
        Me.tbCount.Name = "tbCount"
        Me.tbCount.Size = New System.Drawing.Size(207, 20)
        Me.tbCount.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Plan Set"
        '
        'tbSheetSet
        '
        Me.tbSheetSet.Enabled = False
        Me.tbSheetSet.Location = New System.Drawing.Point(84, 23)
        Me.tbSheetSet.Name = "tbSheetSet"
        Me.tbSheetSet.Size = New System.Drawing.Size(207, 20)
        Me.tbSheetSet.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btRemove)
        Me.TabPage2.Controls.Add(Me.btAdd)
        Me.TabPage2.Controls.Add(Me.lbXref)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(384, 469)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "X-Refs"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btRemove
        '
        Me.btRemove.Enabled = False
        Me.btRemove.Location = New System.Drawing.Point(12, 363)
        Me.btRemove.Name = "btRemove"
        Me.btRemove.Size = New System.Drawing.Size(74, 28)
        Me.btRemove.TabIndex = 2
        Me.btRemove.Text = "Remove"
        Me.btRemove.UseVisualStyleBackColor = True
        '
        'btAdd
        '
        Me.btAdd.Location = New System.Drawing.Point(12, 329)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(74, 28)
        Me.btAdd.TabIndex = 1
        Me.btAdd.Text = "Add..."
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'lbXref
        '
        Me.lbXref.FormattingEnabled = True
        Me.lbXref.Location = New System.Drawing.Point(12, 20)
        Me.lbXref.Name = "lbXref"
        Me.lbXref.Size = New System.Drawing.Size(353, 303)
        Me.lbXref.TabIndex = 0
        '
        'OFD
        '
        Me.OFD.FileName = "OpenFileDialog1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(700, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.OpenToolStripMenuItem.Text = "Load"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateDrawingsToolStripMenuItem, Me.UpdateDrawingsToolStripMenuItem, Me.ModifySheetToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UpdateDrawingsToolStripMenuItem
        '
        Me.UpdateDrawingsToolStripMenuItem.Name = "UpdateDrawingsToolStripMenuItem"
        Me.UpdateDrawingsToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.UpdateDrawingsToolStripMenuItem.Text = "Update Drawings"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Count"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(84, 183)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 26)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Create"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(84, 49)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(207, 20)
        Me.TextBox1.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "SheetSet"
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(84, 23)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(207, 20)
        Me.TextBox2.TabIndex = 0
        '
        'AllPlanSetsToolStripMenuItem
        '
        Me.AllPlanSetsToolStripMenuItem.Name = "AllPlanSetsToolStripMenuItem"
        Me.AllPlanSetsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AllPlanSetsToolStripMenuItem.Text = "All Plan Sets"
        '
        'ActivePlanSetToolStripMenuItem
        '
        Me.ActivePlanSetToolStripMenuItem.Name = "ActivePlanSetToolStripMenuItem"
        Me.ActivePlanSetToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ActivePlanSetToolStripMenuItem.Text = "Active Plan Set"
        '
        'CreateDrawingsToolStripMenuItem
        '
        Me.CreateDrawingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllPlanSetsToolStripMenuItem, Me.ActivePlanSetToolStripMenuItem})
        Me.CreateDrawingsToolStripMenuItem.Name = "CreateDrawingsToolStripMenuItem"
        Me.CreateDrawingsToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CreateDrawingsToolStripMenuItem.Text = "Create Drawings"
        '
        'ModifySheetToolStripMenuItem
        '
        Me.ModifySheetToolStripMenuItem.Name = "ModifySheetToolStripMenuItem"
        Me.ModifySheetToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ModifySheetToolStripMenuItem.Text = "Modify Sheet"
        '
        'frmSheetCentre
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(700, 574)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.tvProject)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSheetCentre"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Drawing Layout Tool"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudOverlap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.btCreateSheet.ResumeLayout(False)
        Me.btCreateSheet.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.BS1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents tbCreate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btCreate As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudOverlap As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbScale As System.Windows.Forms.ComboBox
    Friend WithEvents tvProject As System.Windows.Forms.TreeView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents btCreateSheet As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbSheetSet As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbCount As System.Windows.Forms.TextBox
    Friend WithEvents btXY As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btRemove As System.Windows.Forms.Button
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents lbXref As System.Windows.Forms.ListBox
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents FBD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents UpdateDrawingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bffLoc As BrowseForFolder.BrowseForFolder
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btTop As System.Windows.Forms.Button
    Friend WithEvents btBottom As System.Windows.Forms.Button
    Friend WithEvents btRight As System.Windows.Forms.Button
    Friend WithEvents btLeft As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents bffTemplate As BrowseForFile.BrowseForFile
    Friend WithEvents CreateDrawingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllPlanSetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivePlanSetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModifySheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BS1 As System.Windows.Forms.BindingSource

End Class
