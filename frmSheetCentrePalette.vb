Imports System.Windows.Forms
Imports Autodesk.AutoCAD.Geometry


Public Class frmSheetCentrePalette
    Dim RootNode As New TreeNode
    Dim WithEvents ActivePlanSet As clsPlanSet
    Dim WithEvents ActiveSheet As clsSheet
    Dim BS As New BindingSource

    Private Sub MakeSizes()

        SheetSizes.Clear()
        Dim S1 As New clsPlanSet.DwgSheet
        S1.Name = "A1"
        S1.Width = 841
        S1.Height = 594
        S1.MB = 70
        S1.ML = 20
        S1.MR = 20
        S1.MT = 20
        SheetSizes.Add(S1.Name, S1)
        S1 = New clsPlanSet.DwgSheet
        S1.Name = "B1"
        S1.Width = 1000
        S1.Height = 707
        S1.MB = 100
        S1.ML = 10
        S1.MR = 10
        S1.MT = 10
        SheetSizes.Add(S1.Name, S1)
        S1 = New clsPlanSet.DwgSheet
        S1.Name = "A0"
        S1.Width = 1189
        S1.Height = 841
        S1.MB = 75
        S1.ML = 20
        S1.MR = 20
        S1.MT = 20
        SheetSizes.Add(S1.Name, S1)

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        MakeSizes()
        ' Add any initialization after the InitializeComponent() call.
        If Xrec.nXrecs >= 1 Then
            If MsgBox("Do you wish to load stored data.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SheetColl.Load()
                tvProject.Nodes.Clear()
                tvProject.Nodes.Add(SheetColl.Tree)
                lbXref.DataSource = BS
                tvProject.Enabled = True
            End If
        Else
            tvProject.Nodes.Clear()
            tvProject.Nodes.Add(SheetColl.Tree)
        End If
        ' Add any initialization after the InitializeComponent() call.
        lbXref.DataSource = BS

    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim Myform As New frmDefaults

        If Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(Myform) = System.Windows.Forms.DialogResult.OK Then
            SheetColl = New clsProjectSet(APPID)
            tvProject.Enabled = True
            EditToolStripMenuItem.Enabled = True
        End If
    End Sub
    Private Sub tvProject_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvProject.AfterSelect
        Dim TNode As TreeNode

        TNode = e.Node
        Select Case TNode.Level
            Case 0

            Case 1
                If ActivePlanSet IsNot Nothing Then
                    ActivePlanSet.Delete()
                    ActivePlanSet.Update()
                End If
                ActivePlanSet = SheetColl.Item(TNode.Text)
                tbAPS.Text = "Active Plan Set=" + ActivePlanSet.Name
                ActivePlanSet.Draw()
                ActivePlanSet.Update()
                If ActivePlanSet IsNot Nothing Then

                End If
                ToggleCreateOptions()
                BS.DataSource = ActivePlanSet.XRefs
            Case 2
                If ActivePlanSet IsNot Nothing Then
                    ActivePlanSet.Delete()
                    ActivePlanSet.Update()
                End If
                ToggleCreateOptions()
                ActivePlanSet = SheetColl.Item(TNode.Parent.Name)
                ActivePlanSet.Draw()
                ActivePlanSet.Update()
                If ActiveSheet IsNot Nothing Then
                    ActiveSheet.UnHighlight()
                End If
                ActiveSheet = ActivePlanSet.Sheet(TNode.Name)
                ActiveSheet.Highlight()
                tbAPS.Text = "Active Plan Set=" + ActivePlanSet.Name
                tbAPS.Text = tbAPS.Text + vbCrLf + "Active Sheet=" + ActiveSheet.Name
        End Select
    End Sub

    Private Sub LoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadToolStripMenuItem.Click

        Xrec = New clsXRecUtils(APPID)
        SheetColl.Load()
        If SheetColl.Count > 0 Then
            tvProject.Enabled = True
            tvProject.Nodes.Clear()
            tvProject.Nodes.Add(SheetColl.Tree)
            tvProject.ExpandAll()
            EditToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click

        SheetColl.Store()
    End Sub

    Private Sub ModifySheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifySheetToolStripMenuItem.Click
        Dim A As String
        Dim myform As New frmModifySheet

        If ActivePlanSet IsNot Nothing Then
            myform.ActiveSheetSet = ActivePlanSet
            A = ActivePlanSet.GetSheet
            If A IsNot Nothing Then
                ActiveSheet = ActivePlanSet.Sheet(A)
                If ActiveSheet IsNot Nothing Then
                    myform.Sheet = ActiveSheet
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(myform)
                    ActivePlanSet.ClearModifiedFlags()
                End If
            End If
        Else
            MsgBox("No active Plan set, please select one.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub AllPlanSetsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllPlanSetsToolStripMenuItem.Click
        Dim PlanSet As clsPlanSet

        For Each kvp As KeyValuePair(Of String, clsPlanSet) In SheetColl.Sets
            PlanSet = kvp.Value
            PlanSet.MakeDwgs()
        Next
    End Sub

    Private Sub ActivePlanSetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivePlanSetToolStripMenuItem.Click

        ActivePlanSet.MakeDwgs()
    End Sub

    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        Dim FileNames() As String

        If ActivePlanSet IsNot Nothing Then
            With OFD
                .CheckPathExists = True
                .CheckFileExists = True
                .Multiselect = True
                .DereferenceLinks = True
                .RestoreDirectory = True
                .ShowHelp = False
                .ValidateNames = True
                .Filter = "Drawing Files(*.dwg)|*.dwg"
                .Title = "Select drawings"
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    FileNames = OFD.FileNames
                    For Each S As String In FileNames
                        If Not (ActivePlanSet.XRefs.Contains(S)) Then
                            ActivePlanSet.XRefs.Add(S)
                        End If
                    Next
                    BS.DataSource = ActivePlanSet.XRefs
                    BS.ResetBindings(False)
                End If
            End With
        Else
            MsgBox("No active Plan set, please select one.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRemove.Click

        If ActivePlanSet IsNot Nothing Then
            ActivePlanSet.XRefs.RemoveAt(lbXref.SelectedIndex)
            BS.ResetBindings(False)
        Else
            MsgBox("No active Plan set, please select one.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub lbXref_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbXref.SelectedIndexChanged

        If lbXref.SelectedIndex >= 0 Then
            btRemove.Enabled = True
        Else
            btRemove.Enabled = False
        End If
    End Sub

    Private Sub CreatePlanSetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreatePlanSetToolStripMenuItem.Click
        Dim Myform As New frmNewPlanSet

        If Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(Myform) = DialogResult.OK Then
            If Myform.tbCreate.Text <> "" And Myform.bffLoc.Text <> "" Then
                Dim PlanSet As New clsPlanSet(Myform.tbCreate.Text, Myform.cbScale.Text, Myform.nudOverlap.Value, _
                    Myform.bffLoc.Text)
                PlanSet.Template = Myform.bffTemplate.Text
                PlanSet.Prototype = Prototype
                PlanSet.IsMetres = Myform.cbMetres.Checked
                SheetColl.Add(PlanSet)
                Myform.tbCreate.Text = ""
                tvProject.Nodes.Clear()
                tvProject.Nodes.Add(SheetColl.Tree)
                tvProject.Enabled = True
                tvProject.ExpandAll()
            End If
        End If
    End Sub
    Private Sub ActiveSet_Change(ByVal Sender As Object, ByVal e As clsPlanSet.clsPlanSetChange) Handles ActivePlanSet.Change

        Select Case e.PlanSetChange
            Case clsPlanSet.PlanSetChange.Add 'add the node in
                tvProject.Nodes.Clear()
                tvProject.Nodes.Add(SheetColl.Tree)
                tvProject.ExpandAll()
            Case clsPlanSet.PlanSetChange.Delete
                tvProject.Nodes.Clear()
                tvProject.Nodes.Add(SheetColl.Tree)
                tvProject.ExpandAll()
            Case Else

        End Select
        ToggleCreateOptions()
    End Sub
    Private Sub ToggleCreateOptions()

        If ActivePlanSet IsNot Nothing Then
            If ActivePlanSet.Count > 0 Then
                LeftToolStripMenuItem.Enabled = True
                RightToolStripMenuItem.Enabled = True
                TopToolStripMenuItem.Enabled = True
                BottomToolStripMenuItem.Enabled = True
            Else
                LeftToolStripMenuItem.Enabled = False
                RightToolStripMenuItem.Enabled = False
                TopToolStripMenuItem.Enabled = False
                BottomToolStripMenuItem.Enabled = False
            End If
        End If
    End Sub
    Private Sub AddRight()
        Dim Sheet As clsSheet
        Dim A As String
        Dim Newsheet As New clsSheet(ActivePlanSet, ActivePlanSet.Prototype)

        A = ActivePlanSet.GetSheet
        If A IsNot Nothing Then
            Sheet = ActivePlanSet.Sheet(A)
            Newsheet.IP = Sheet.RightSheet
            Newsheet.Angle = Sheet.Angle
            Newsheet.Name = ActivePlanSet.NextName
            Newsheet.Left = Sheet.Name
            Sheet.Right = Newsheet.Name
            ActivePlanSet.Add(Newsheet)
            Newsheet.Draw()
            ActivePlanSet.Update()
        End If
    End Sub
    Private Sub AddLeft()
        Dim Sheet As clsSheet
        Dim A As String
        Dim Newsheet As New clsSheet(ActivePlanSet, ActivePlanSet.Prototype)

        A = ActivePlanSet.GetSheet
        If A IsNot Nothing Then
            Sheet = ActivePlanSet.Sheet(A)
            Newsheet.IP = Sheet.LeftSheet
            Newsheet.Angle = Sheet.Angle
            Newsheet.Name = ActivePlanSet.NextName
            Newsheet.Right = Sheet.Name
            Sheet.Left = Newsheet.Name
            ActivePlanSet.Add(Newsheet)
            Newsheet.Draw()
            ActivePlanSet.Update()
        End If
    End Sub
    Private Sub AddTop()
        Dim Sheet As clsSheet
        Dim A As String
        Dim Newsheet As New clsSheet(ActivePlanSet, ActivePlanSet.Prototype)

        A = ActivePlanSet.GetSheet
        If A IsNot Nothing Then
            Sheet = ActivePlanSet.Sheet(A)
            Newsheet.IP = Sheet.TopSheet
            Newsheet.Angle = Sheet.Angle
            Newsheet.Name = ActivePlanSet.NextName
            Newsheet.Below = Sheet.Name
            Sheet.Above = Newsheet.Name
            ActivePlanSet.Add(Newsheet)
            Newsheet.Draw()
            ActivePlanSet.Update()
        End If
    End Sub
    Private Sub AddBottom()
        Dim Sheet As clsSheet
        Dim A As String
        Dim Newsheet As New clsSheet(ActivePlanSet, ActivePlanSet.Prototype)

        A = ActivePlanSet.GetSheet
        If A IsNot Nothing Then
            Sheet = ActivePlanSet.Sheet(A)
            Newsheet.IP = Sheet.BottomSheet
            Newsheet.Angle = Sheet.Angle
            Newsheet.Name = ActivePlanSet.NextName
            Newsheet.Above = Sheet.Name
            Sheet.Below = Newsheet.Name
            ActivePlanSet.Add(Newsheet)
            Newsheet.Draw()
            ActivePlanSet.Update()
        End If
    End Sub
    Private Sub AddXY()
        Dim myform1 As New frmNewSheet
        Dim Newsheet As New clsSheet

        myform1.ActiveSheetSet = ActivePlanSet
        If Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(myform1) = System.Windows.Forms.DialogResult.OK Then
            Newsheet = myform1.NewSheet
            ActivePlanSet.Add(Newsheet)
            Newsheet.Draw()
            ActivePlanSet.Update()
        Else
            myform1.NewSheet.Delete()
        End If
        ActivePlanSet.Update()
    End Sub

    Private Sub LeftToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftToolStripMenuItem.Click

        If ActivePlanSet IsNot Nothing Then
            AddLeft()
        Else
            MsgBox("No active Plan set, please select one.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub RightToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightToolStripMenuItem.Click
        If ActivePlanSet IsNot Nothing Then
            AddRight()
        Else
            MsgBox("No active Plan set, please select one.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub TopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopToolStripMenuItem.Click
        If ActivePlanSet IsNot Nothing Then
            AddTop()
        Else
            MsgBox("No active Plan set, please select one.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub BottomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BottomToolStripMenuItem.Click
        If ActivePlanSet IsNot Nothing Then
            AddBottom()
        Else
            MsgBox("No active Plan set, please select one.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub XYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XYToolStripMenuItem.Click
        If ActivePlanSet IsNot Nothing Then
            AddXY()
        Else
            MsgBox("No active Plan set, please select one.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub DeletePlanSetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletePlanSetToolStripMenuItem.Click
        'TODO
        'delete the plan set from the list.
        If ActivePlanSet IsNot Nothing Then
            ActivePlanSet.Delete()
            ActivePlanSet.Update()
            SheetColl.remove(ActivePlanSet.Name)
            tvProject.Nodes.Clear()
            tvProject.Nodes.Add(SheetColl.Tree)
            tvProject.ExpandAll()
        Else
            MsgBox("No active Plan set, please select one.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub DeleteSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSheetToolStripMenuItem.Click
        'remove a sheet from a plan set
        Dim Sheet As clsSheet
        Dim A As String

        A = ActivePlanSet.GetSheet
        If A IsNot Nothing Then
            Sheet = ActivePlanSet.Sheet(A)
            ActivePlanSet.remove(Sheet.Name)
            ActivePlanSet.Update()
        End If
    End Sub

    Private Sub AddXrefToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim FileNames() As String

        If ActivePlanSet IsNot Nothing Then
            With OFD
                .CheckPathExists = True
                .CheckFileExists = True
                .Multiselect = True
                .DereferenceLinks = True
                .RestoreDirectory = True
                .ShowHelp = False
                .ValidateNames = True
                .Filter = "Drawing Files(*.dwg)|*.dwg"
                .Title = "Select drawings"
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    FileNames = OFD.FileNames
                    For Each S As String In FileNames
                        If Not (ActivePlanSet.XRefs.Contains(S)) Then
                            ActivePlanSet.XRefs.Add(S)
                        End If
                    Next
                    BS.DataSource = ActivePlanSet.XRefs
                    BS.ResetBindings(False)
                End If
            End With
        Else
            MsgBox("No active Plan set, please select one.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub RemoveXrefToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ActivePlanSet IsNot Nothing Then
            ActivePlanSet.XRefs.RemoveAt(lbXref.SelectedIndex)
            BS.ResetBindings(False)
        Else
            MsgBox("No active Plan set, please select one.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub ExirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExirToolStripMenuItem.Click

        PSet.Visible = False
    End Sub

    Private Sub ActiveSheet_Change(ByVal Sender As Object, ByVal e As clsSheet.clsSheetChange) Handles ActiveSheet.Change
        Dim Sheet As clsSheet
        Dim SheetName As String


        Select Case e.SheetChange
            Case clsSheet.SheetChange.Rename

            Case clsSheet.SheetChange.MarginRightChange
                Dim EdgeSheet As clsSheet
                If ActivePlanSet.Sheets.ContainsKey(e.SheetName) Then
                    Sheet = ActivePlanSet.Sheet(e.SheetName)
                    SheetName = Sheet.Right
                    If SheetName <> "" Then
                        If ActivePlanSet.Sheets.ContainsKey(Sheet.Right) Then
                            EdgeSheet = ActivePlanSet.Sheet(Sheet.Right)
                            Dim P1 As Point3d = Sheet.RightSheet
                            EdgeSheet.IPEvent = P1
                        End If
                    End If
                End If
            Case clsSheet.SheetChange.MarginLeftChange
                Dim EdgeSheet As clsSheet
                If ActivePlanSet.Sheets.ContainsKey(e.SheetName) Then
                    Sheet = ActivePlanSet.Sheet(e.SheetName)
                    SheetName = Sheet.Left
                    If SheetName <> "" Then
                        If ActivePlanSet.Sheets.ContainsKey(Sheet.Right) Then
                            EdgeSheet = ActivePlanSet.Sheet(Sheet.Right)
                            Dim P1 As Point3d = Sheet.RightSheet
                            EdgeSheet.IPEvent = P1
                        End If
                    End If
                End If
            Case clsSheet.SheetChange.MarginTopChange
                Dim EdgeSheet As clsSheet
                If ActivePlanSet.Sheets.ContainsKey(e.SheetName) Then
                    Sheet = ActivePlanSet.Sheet(e.SheetName)
                    SheetName = Sheet.Above
                    If SheetName <> "" Then
                        If ActivePlanSet.Sheets.ContainsKey(Sheet.Above) Then
                            EdgeSheet = ActivePlanSet.Sheet(Sheet.Above)
                            Dim P1 As Point3d = Sheet.TopSheet
                            EdgeSheet.IPEvent = P1
                        End If
                    End If
                End If
            Case clsSheet.SheetChange.MarginBottomChange
                Dim EdgeSheet As clsSheet
                If ActivePlanSet.Sheets.ContainsKey(e.SheetName) Then
                    Sheet = ActivePlanSet.Sheet(e.SheetName)
                    SheetName = Sheet.Below
                    If SheetName <> "" Then
                        If ActivePlanSet.Sheets.ContainsKey(Sheet.Above) Then
                            EdgeSheet = ActivePlanSet.Sheet(Sheet.Above)
                            Dim P1 As Point3d = Sheet.TopSheet
                            EdgeSheet.IPEvent = P1
                        End If
                    End If
                End If
            Case clsSheet.SheetChange.Move
                'move all the sheets along with this one
                Dim EdgeSheet As clsSheet
                If ActivePlanSet.Sheets.ContainsKey(e.SheetName) Then
                    Sheet = ActivePlanSet.Sheet(e.SheetName)
                    'right side 
                    SheetName = Sheet.Right
                    If SheetName <> "" Then
                        If ActivePlanSet.Sheets.ContainsKey(SheetName) Then
                            EdgeSheet = ActivePlanSet.Sheet(SheetName)
                            If Not (EdgeSheet.Initiator) Then
                                Dim P1 As Point3d = EdgeSheet.IP
                                EdgeSheet.IPEvent = P1 + e.Vector
                            End If
                        End If
                    End If
                    'left side 
                    SheetName = Sheet.Left
                    If SheetName <> "" Then
                        If ActivePlanSet.Sheets.ContainsKey(SheetName) Then
                            EdgeSheet = ActivePlanSet.Sheet(SheetName)
                            If Not (EdgeSheet.Initiator) Then
                                Dim P1 As Point3d = EdgeSheet.IP
                                EdgeSheet.IPEvent = P1 + e.Vector
                            End If
                        End If
                    End If
                    'above  
                    SheetName = Sheet.Above
                    If SheetName <> "" Then
                        If ActivePlanSet.Sheets.ContainsKey(SheetName) Then
                            EdgeSheet = ActivePlanSet.Sheet(SheetName)
                            If Not (EdgeSheet.Initiator) Then
                                Dim P1 As Point3d = EdgeSheet.IP
                                EdgeSheet.IPEvent = P1 + e.Vector
                            End If
                        End If
                    End If
                    'below  
                    SheetName = Sheet.Below
                    If SheetName <> "" Then
                        If ActivePlanSet.Sheets.ContainsKey(SheetName) Then
                            EdgeSheet = ActivePlanSet.Sheet(SheetName)
                            If Not (EdgeSheet.Initiator) Then
                                Dim P1 As Point3d = EdgeSheet.IP
                                EdgeSheet.IPEvent = P1 + e.Vector
                            End If
                        End If
                    End If
                End If
            Case clsSheet.SheetChange.Rotate

        End Select
    End Sub
    Private Sub CopyPlanSetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyPlanSetToolStripMenuItem.Click
        Dim Myform As New frmCopyPlanSet
        Dim Name As String
        Dim PlanSet As clsPlanSet
        Dim OrigPlanSet As clsPlanSet
        Dim NewSheet As clsSheet
        Dim OSheet As clsSheet
        Dim SF As Double


        If Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(Myform) = System.Windows.Forms.DialogResult.OK Then
            Name = Myform.NewPlanSet
            If Not (SheetColl.Sets.ContainsKey(Name)) Then
                OrigPlanSet = Myform.OrigPlanSet
                SF = OrigPlanSet.ScaleFactor
                PlanSet = New clsPlanSet(Name, OrigPlanSet.Scale, OrigPlanSet.Overlap,
                    OrigPlanSet.Location)
                PlanSet.Template = OrigPlanSet.Template
                PlanSet.Prototype = Prototype
                PlanSet.IsMetres = OrigPlanSet.IsMetres
                For Each KVP As KeyValuePair(Of String, clsSheet) In OrigPlanSet.Sheets
                    OSheet = KVP.Value
                    Name = OSheet.Name.Replace(OrigPlanSet.Name, PlanSet.Name)
                    NewSheet = New clsSheet(PlanSet, Name, OSheet.Width / SF, OSheet.Height / SF,
                    OSheet.MarginLeft / SF, OSheet.MarginRight / SF, OSheet.MarginTop / SF, OSheet.MarginBottom / SF)
                    NewSheet.IP = OSheet.IP
                    NewSheet.Angle = OSheet.Angle
                    NewSheet.Left = OSheet.Left.Replace(OrigPlanSet.Name, PlanSet.Name)
                    NewSheet.Right = OSheet.Right.Replace(OrigPlanSet.Name, PlanSet.Name)
                    NewSheet.Above = OSheet.Above.Replace(OrigPlanSet.Name, PlanSet.Name)
                    NewSheet.Below = OSheet.Below.Replace(OrigPlanSet.Name, PlanSet.Name)
                    NewSheet.Scale = OSheet.Scale
                    NewSheet.Draw()
                    PlanSet.Add(NewSheet)
                Next
                SheetColl.Add(PlanSet)
            End If
        End If
        tvProject.Nodes.Clear()
        tvProject.Nodes.Add(SheetColl.Tree)
        tvProject.Enabled = True
        tvProject.ExpandAll()
    End Sub

    Private Sub ActivePlanSetToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivePlanSetToolStripMenuItem1.Click

        ActivePlanSet.UpdateDwgs()
    End Sub

    Private Sub RenumberSheetsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenumberSheetsToolStripMenuItem.Click
        Dim myform As New frmRenumberSheets
        Dim PlanSet As clsPlanSet

        If Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(myform) = DialogResult.OK Then
            PlanSet = myform.Planset
            PlanSet.Renumber()
            PlanSet.Update()
            tvProject.Nodes.Clear()
            tvProject.Nodes.Add(SheetColl.Tree)
            tvProject.Enabled = True
            tvProject.ExpandAll()
        End If

    End Sub

    Private Sub AllPlanSetsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllPlanSetsToolStripMenuItem1.Click
        Dim PlanSet As clsPlanSet

        For Each kvp As KeyValuePair(Of String, clsPlanSet) In SheetColl.Sets
            PlanSet = kvp.Value
            PlanSet.UpdateDwgs()
        Next
    End Sub

    Private Sub TEstToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEstToolStripMenuItem.Click

        clsAcad.MakeLayer("FFF")
    End Sub

    Private Sub InsertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertToolStripMenuItem.Click

        clsAcad.LoadBlock("HH")
    End Sub
End Class
