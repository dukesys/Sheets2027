<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSheetCentrePalette
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        components = New ComponentModel.Container()
        MenuStrip1 = New System.Windows.Forms.MenuStrip()
        FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        ExirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CreatePlanSetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CopyPlanSetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        DeletePlanSetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        CreateSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        LeftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        RightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        TopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        BottomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        XYToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        ModifySheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        DeleteSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        CreateDrawingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        AllPlanSetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        ActivePlanSetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        UpdateDrawingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        AllPlanSetsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        ActivePlanSetToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        RenumberSheetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        TEstToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        tvProject = New System.Windows.Forms.TreeView()
        btRemove = New System.Windows.Forms.Button()
        btAdd = New System.Windows.Forms.Button()
        lbXref = New System.Windows.Forms.ListBox()
        OFD = New System.Windows.Forms.OpenFileDialog()
        TT = New System.Windows.Forms.ToolTip(components)
        tbAPS = New System.Windows.Forms.TextBox()
        SplitContainer1 = New System.Windows.Forms.SplitContainer()
        SplitContainer2 = New System.Windows.Forms.SplitContainer()
        MenuStrip1.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {FileToolStripMenuItem, EditToolStripMenuItem})
        MenuStrip1.Location = New System.Drawing.Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New System.Windows.Forms.Padding(12, 5, 0, 5)
        MenuStrip1.Size = New System.Drawing.Size(631, 44)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {NewToolStripMenuItem, ToolStripSeparator3, LoadToolStripMenuItem, SaveToolStripMenuItem, ToolStripSeparator4, ExirToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New System.Drawing.Size(62, 34)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' NewToolStripMenuItem
        ' 
        NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        NewToolStripMenuItem.Size = New System.Drawing.Size(176, 40)
        NewToolStripMenuItem.Text = "New"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New System.Drawing.Size(173, 6)
        ' 
        ' LoadToolStripMenuItem
        ' 
        LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        LoadToolStripMenuItem.Size = New System.Drawing.Size(176, 40)
        LoadToolStripMenuItem.Text = "Load"
        ' 
        ' SaveToolStripMenuItem
        ' 
        SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        SaveToolStripMenuItem.Size = New System.Drawing.Size(176, 40)
        SaveToolStripMenuItem.Text = "Save"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New System.Drawing.Size(173, 6)
        ' 
        ' ExirToolStripMenuItem
        ' 
        ExirToolStripMenuItem.Name = "ExirToolStripMenuItem"
        ExirToolStripMenuItem.Size = New System.Drawing.Size(176, 40)
        ExirToolStripMenuItem.Text = "Exit"
        ' 
        ' EditToolStripMenuItem
        ' 
        EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {CreatePlanSetToolStripMenuItem, CopyPlanSetToolStripMenuItem, DeletePlanSetToolStripMenuItem, ToolStripSeparator1, CreateSheetToolStripMenuItem, ModifySheetToolStripMenuItem, DeleteSheetToolStripMenuItem, ToolStripSeparator2, CreateDrawingsToolStripMenuItem, UpdateDrawingsToolStripMenuItem, RenumberSheetsToolStripMenuItem})
        EditToolStripMenuItem.Enabled = False
        EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        EditToolStripMenuItem.Size = New System.Drawing.Size(66, 34)
        EditToolStripMenuItem.Text = "Edit"
        ' 
        ' CreatePlanSetToolStripMenuItem
        ' 
        CreatePlanSetToolStripMenuItem.Name = "CreatePlanSetToolStripMenuItem"
        CreatePlanSetToolStripMenuItem.Size = New System.Drawing.Size(293, 40)
        CreatePlanSetToolStripMenuItem.Text = "Create Plan Set"
        ' 
        ' CopyPlanSetToolStripMenuItem
        ' 
        CopyPlanSetToolStripMenuItem.Name = "CopyPlanSetToolStripMenuItem"
        CopyPlanSetToolStripMenuItem.Size = New System.Drawing.Size(293, 40)
        CopyPlanSetToolStripMenuItem.Text = "Copy Plan Set"
        ' 
        ' DeletePlanSetToolStripMenuItem
        ' 
        DeletePlanSetToolStripMenuItem.Name = "DeletePlanSetToolStripMenuItem"
        DeletePlanSetToolStripMenuItem.Size = New System.Drawing.Size(293, 40)
        DeletePlanSetToolStripMenuItem.Text = "Delete Plan Set"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New System.Drawing.Size(290, 6)
        ' 
        ' CreateSheetToolStripMenuItem
        ' 
        CreateSheetToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {LeftToolStripMenuItem, RightToolStripMenuItem, TopToolStripMenuItem, BottomToolStripMenuItem, XYToolStripMenuItem})
        CreateSheetToolStripMenuItem.Name = "CreateSheetToolStripMenuItem"
        CreateSheetToolStripMenuItem.Size = New System.Drawing.Size(293, 40)
        CreateSheetToolStripMenuItem.Text = "Create Sheet"
        ' 
        ' LeftToolStripMenuItem
        ' 
        LeftToolStripMenuItem.Enabled = False
        LeftToolStripMenuItem.Name = "LeftToolStripMenuItem"
        LeftToolStripMenuItem.Size = New System.Drawing.Size(199, 40)
        LeftToolStripMenuItem.Text = "Left"
        ' 
        ' RightToolStripMenuItem
        ' 
        RightToolStripMenuItem.Enabled = False
        RightToolStripMenuItem.Name = "RightToolStripMenuItem"
        RightToolStripMenuItem.Size = New System.Drawing.Size(199, 40)
        RightToolStripMenuItem.Text = "Right"
        ' 
        ' TopToolStripMenuItem
        ' 
        TopToolStripMenuItem.Enabled = False
        TopToolStripMenuItem.Name = "TopToolStripMenuItem"
        TopToolStripMenuItem.Size = New System.Drawing.Size(199, 40)
        TopToolStripMenuItem.Text = "Top"
        ' 
        ' BottomToolStripMenuItem
        ' 
        BottomToolStripMenuItem.Enabled = False
        BottomToolStripMenuItem.Name = "BottomToolStripMenuItem"
        BottomToolStripMenuItem.Size = New System.Drawing.Size(199, 40)
        BottomToolStripMenuItem.Text = "Bottom"
        ' 
        ' XYToolStripMenuItem
        ' 
        XYToolStripMenuItem.Name = "XYToolStripMenuItem"
        XYToolStripMenuItem.Size = New System.Drawing.Size(199, 40)
        XYToolStripMenuItem.Text = "XY"
        ' 
        ' ModifySheetToolStripMenuItem
        ' 
        ModifySheetToolStripMenuItem.Name = "ModifySheetToolStripMenuItem"
        ModifySheetToolStripMenuItem.Size = New System.Drawing.Size(293, 40)
        ModifySheetToolStripMenuItem.Text = "Modify Sheet"
        ' 
        ' DeleteSheetToolStripMenuItem
        ' 
        DeleteSheetToolStripMenuItem.Name = "DeleteSheetToolStripMenuItem"
        DeleteSheetToolStripMenuItem.Size = New System.Drawing.Size(293, 40)
        DeleteSheetToolStripMenuItem.Text = "Delete Sheet"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New System.Drawing.Size(290, 6)
        ' 
        ' CreateDrawingsToolStripMenuItem
        ' 
        CreateDrawingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {AllPlanSetsToolStripMenuItem, ActivePlanSetToolStripMenuItem})
        CreateDrawingsToolStripMenuItem.Name = "CreateDrawingsToolStripMenuItem"
        CreateDrawingsToolStripMenuItem.Size = New System.Drawing.Size(293, 40)
        CreateDrawingsToolStripMenuItem.Text = "Create Drawings"
        ' 
        ' AllPlanSetsToolStripMenuItem
        ' 
        AllPlanSetsToolStripMenuItem.Name = "AllPlanSetsToolStripMenuItem"
        AllPlanSetsToolStripMenuItem.Size = New System.Drawing.Size(269, 40)
        AllPlanSetsToolStripMenuItem.Text = "All Plan Sets"
        ' 
        ' ActivePlanSetToolStripMenuItem
        ' 
        ActivePlanSetToolStripMenuItem.Name = "ActivePlanSetToolStripMenuItem"
        ActivePlanSetToolStripMenuItem.Size = New System.Drawing.Size(269, 40)
        ActivePlanSetToolStripMenuItem.Text = "Active Plan Set"
        ' 
        ' UpdateDrawingsToolStripMenuItem
        ' 
        UpdateDrawingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {AllPlanSetsToolStripMenuItem1, ActivePlanSetToolStripMenuItem1})
        UpdateDrawingsToolStripMenuItem.Name = "UpdateDrawingsToolStripMenuItem"
        UpdateDrawingsToolStripMenuItem.Size = New System.Drawing.Size(293, 40)
        UpdateDrawingsToolStripMenuItem.Text = "Update Drawings"
        ' 
        ' AllPlanSetsToolStripMenuItem1
        ' 
        AllPlanSetsToolStripMenuItem1.Name = "AllPlanSetsToolStripMenuItem1"
        AllPlanSetsToolStripMenuItem1.Size = New System.Drawing.Size(269, 40)
        AllPlanSetsToolStripMenuItem1.Text = "All Plan Sets"
        ' 
        ' ActivePlanSetToolStripMenuItem1
        ' 
        ActivePlanSetToolStripMenuItem1.Name = "ActivePlanSetToolStripMenuItem1"
        ActivePlanSetToolStripMenuItem1.Size = New System.Drawing.Size(269, 40)
        ActivePlanSetToolStripMenuItem1.Text = "Active Plan Set"
        ' 
        ' RenumberSheetsToolStripMenuItem
        ' 
        RenumberSheetsToolStripMenuItem.Name = "RenumberSheetsToolStripMenuItem"
        RenumberSheetsToolStripMenuItem.Size = New System.Drawing.Size(293, 40)
        RenumberSheetsToolStripMenuItem.Text = "Renumber Sheets"
        ' 
        ' TEstToolStripMenuItem
        ' 
        TEstToolStripMenuItem.Name = "TEstToolStripMenuItem"
        TEstToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        TEstToolStripMenuItem.Text = "TEst"
        ' 
        ' InsertToolStripMenuItem
        ' 
        InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        InsertToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        InsertToolStripMenuItem.Text = "Insert"
        ' 
        ' tvProject
        ' 
        tvProject.Dock = System.Windows.Forms.DockStyle.Fill
        tvProject.Enabled = False
        tvProject.Location = New System.Drawing.Point(0, 0)
        tvProject.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        tvProject.Name = "tvProject"
        tvProject.Size = New System.Drawing.Size(625, 106)
        tvProject.TabIndex = 7
        ' 
        ' btRemove
        ' 
        btRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left
        btRemove.Enabled = False
        btRemove.Location = New System.Drawing.Point(178, 573)
        btRemove.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        btRemove.Name = "btRemove"
        btRemove.Size = New System.Drawing.Size(160, 58)
        btRemove.TabIndex = 10
        btRemove.Text = "Remove"
        TT.SetToolTip(btRemove, "Remove Xref")
        btRemove.UseVisualStyleBackColor = True
        ' 
        ' btAdd
        ' 
        btAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left
        btAdd.Location = New System.Drawing.Point(6, 573)
        btAdd.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        btAdd.Name = "btAdd"
        btAdd.Size = New System.Drawing.Size(160, 58)
        btAdd.TabIndex = 9
        btAdd.Text = "Add..."
        TT.SetToolTip(btAdd, "Add Xref")
        btAdd.UseVisualStyleBackColor = True
        ' 
        ' lbXref
        ' 
        lbXref.Dock = System.Windows.Forms.DockStyle.Fill
        lbXref.FormattingEnabled = True
        lbXref.Location = New System.Drawing.Point(0, 0)
        lbXref.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        lbXref.Name = "lbXref"
        lbXref.Size = New System.Drawing.Size(625, 155)
        lbXref.TabIndex = 8
        TT.SetToolTip(lbXref, "XRefs in Current Plan Set")
        ' 
        ' OFD
        ' 
        OFD.FileName = "OpenFileDialog1"
        ' 
        ' tbAPS
        ' 
        tbAPS.Dock = System.Windows.Forms.DockStyle.Fill
        tbAPS.Enabled = False
        tbAPS.Location = New System.Drawing.Point(0, 0)
        tbAPS.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        tbAPS.Multiline = True
        tbAPS.Name = "tbAPS"
        tbAPS.Size = New System.Drawing.Size(625, 249)
        tbAPS.TabIndex = 12
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        SplitContainer1.Location = New System.Drawing.Point(6, 47)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(tvProject)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(SplitContainer2)
        SplitContainer1.Size = New System.Drawing.Size(625, 518)
        SplitContainer1.SplitterDistance = 106
        SplitContainer1.TabIndex = 13
        ' 
        ' SplitContainer2
        ' 
        SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        SplitContainer2.Location = New System.Drawing.Point(0, 0)
        SplitContainer2.Name = "SplitContainer2"
        SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        ' 
        ' SplitContainer2.Panel1
        ' 
        SplitContainer2.Panel1.Controls.Add(lbXref)
        ' 
        ' SplitContainer2.Panel2
        ' 
        SplitContainer2.Panel2.Controls.Add(tbAPS)
        SplitContainer2.Size = New System.Drawing.Size(625, 408)
        SplitContainer2.SplitterDistance = 155
        SplitContainer2.TabIndex = 0
        ' 
        ' frmSheetCentrePalette
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(12F, 30F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Controls.Add(SplitContainer1)
        Controls.Add(btRemove)
        Controls.Add(btAdd)
        Controls.Add(MenuStrip1)
        Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Name = "frmSheetCentrePalette"
        Size = New System.Drawing.Size(631, 640)
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        SplitContainer2.Panel1.ResumeLayout(False)
        SplitContainer2.Panel2.ResumeLayout(False)
        SplitContainer2.Panel2.PerformLayout()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateDrawingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateDrawingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModifySheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllPlanSetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivePlanSetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateSheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreatePlanSetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyPlanSetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tvProject As System.Windows.Forms.TreeView
    Friend WithEvents btRemove As System.Windows.Forms.Button
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents lbXref As System.Windows.Forms.ListBox
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeletePlanSetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteSheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LeftToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RightToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BottomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XYToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TT As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbAPS As System.Windows.Forms.TextBox
    Friend WithEvents AllPlanSetsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivePlanSetToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenumberSheetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TEstToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer

End Class
