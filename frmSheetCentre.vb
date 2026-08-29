Imports System.ComponentModel
Imports System.Windows.Forms

Public Class frmSheetCentre
    Dim RootNode As New TreeNode
    Dim WithEvents ActivePlanSet As clsPlanSet
    Dim ActiveSheet As clsSheet
    Dim BX As New BindingList(Of String)
    Dim BS As New BindingSource

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub MakeSizes()

        SheetSizes.Clear()
        Dim S1 As New clsPlanSet.DwgSheet
        S1.Name = "A1"
        S1.Width = 841
        S1.Height = 594
        S1.MB = 100
        S1.ML = 10
        S1.MR = 10
        S1.MT = 10
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
        S1.MB = 100
        S1.ML = 10
        S1.MR = 10
        S1.MT = 10
        SheetSizes.Add(S1.Name, S1)

    End Sub
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        If Xrec.nXrecs >= 1 Then
            If MsgBox("Do you wish to load stored data.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SheetColl.Load()
            End If
        End If
        ' Add any initialization after the InitializeComponent() call.
        cbScale.SelectedIndex = 0
        nudOverlap.Value = 5
        RootNode.Name = "Project"
        RootNode.Text = "Project Name"
        'tvProject.Nodes.Clear()
        tvProject.Nodes.Add(RootNode)
        MakeSizes()
        lbXref.DataSource = BS
    End Sub

    Private Sub btCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCreate.Click

        If tbCreate.Text <> "" And bffLoc.Text <> "" Then
            Dim PlanSet As New clsPlanSet(tbCreate.Text, cbScale.Text, nudOverlap.Value, _
                bffLoc.Text)
            PlanSet.Template = bffTemplate.Text
            PlanSet.Prototype = Prototype
            SheetColl.Add(PlanSet)
            tbCreate.Text = ""
            RootNode.Nodes.Add(PlanSet.Node)
            tvProject.ExpandAll()
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
                ActivePlanSet.Draw()
                ActivePlanSet.Update()
                If ActivePlanSet IsNot Nothing Then
                    tbSheetSet.Text = ActivePlanSet.Name
                    tbCount.Text = ActivePlanSet.Sheets.Count
                    nudOverlap.Value = ActivePlanSet.Overlap
                    cbScale.Text = ActivePlanSet.Scale
                    bffLoc.Text = ActivePlanSet.Location
                    TabControl1.Enabled = True

                End If
                BS.DataSource = ActivePlanSet.XRefs
            Case 2
                ActivePlanSet = SheetColl.Item(TNode.Parent.Name)
                ActiveSheet = ActivePlanSet.Sheet(TNode.Name)
                tbSheetSet.Text = ActivePlanSet.Name
                tbCount.Text = ActivePlanSet.Sheets.Count
                nudOverlap.Value = ActivePlanSet.Overlap
                cbScale.Text = ActivePlanSet.Scale
                bffLoc.Text = ActivePlanSet.Location
                TabControl1.Enabled = True
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXY.Click
        Dim myform As New frmNewSheet

        myform.ActiveSheetSet = ActivePlanSet
        If Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(myform) = System.Windows.Forms.DialogResult.OK Then
            ActivePlanSet.Add(myform.NewSheet)
        Else
            myform.NewSheet.Delete()
        End If
        ActivePlanSet.Update()
    End Sub

    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        Dim FileNames() As String

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
    End Sub

    Private Sub lbXref_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbXref.SelectedIndexChanged

        If lbXref.SelectedIndex >= 0 Then
            btRemove.Enabled = True
        Else
            btRemove.Enabled = False
        End If
    End Sub
    Private Sub btRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRemove.Click

        ActivePlanSet.XRefs.RemoveAt(lbXref.SelectedIndex)
        BS.ResetBindings(False)
    End Sub
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim Myform As New frmDefaults

        If Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(Myform) = System.Windows.Forms.DialogResult.OK Then
            SheetColl = New clsProjectSet(APPID)
            tvProject.Enabled = True
            btCreate.Enabled = True
            tbCreate.Enabled = True
            Label1.Enabled = True
            cbScale.Enabled = True
            nudOverlap.Enabled = True
            bffLoc.Enabled = True
            Label2.Enabled = True
            Label3.Enabled = True
            Label8.Enabled = True
        End If
    End Sub
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click


        SheetColl.Load()
        btCreate.Enabled = True
        tbCreate.Enabled = True
        Label1.Enabled = True
    End Sub
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click

        SheetColl.Store()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ActiveSet_Change(ByVal Sender As Object, ByVal e As clsPlanSet.clsPlanSetChange) Handles ActivePlanSet.Change

        Select Case e.PlanSetChange
            Case clsPlanSet.PlanSetChange.Add
                Dim psNode As TreeNode
                psNode = RootNode.Nodes.Item(ActivePlanSet.Name)
                psNode.Nodes.Add(ActivePlanSet.Sheet(e.SheetName).Node)
                psNode.Expand()
            Case clsPlanSet.PlanSetChange.Delete
            Case clsPlanSet.PlanSetChange.Move
            Case clsPlanSet.PlanSetChange.Rename
        End Select



        'Select Case e.SheetChange
        '    Case clsSheet.SheetChange.Add 'add the node in

        '    Case clsSheet.SheetChange.Delete
        '    Case clsSheet.SheetChange.Move
        '    Case clsSheet.SheetChange.Rename

        'End Select
    End Sub

    Private Sub btTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTop.Click
        Dim A As String
        Dim Sheet As clsSheet
        Dim Newsheet As New clsSheet(ActivePlanSet, ActivePlanSet.Prototype)

        A = ActivePlanSet.GetSheet
        If A IsNot Nothing Then
            Sheet = ActivePlanSet.Sheet(A)
            Newsheet.IP = Sheet.TopSheet
            Newsheet.Angle = Sheet.Angle
            Newsheet.Name = ActivePlanSet.NextName
            ActivePlanSet.Add(Newsheet)
            Newsheet.Draw()
            ActivePlanSet.Update()
        End If
    End Sub

    Private Sub btRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRight.Click
        Dim A As String
        Dim Sheet As clsSheet
        Dim Newsheet As New clsSheet(ActivePlanSet, ActivePlanSet.Prototype)

        A = ActivePlanSet.GetSheet
        If A IsNot Nothing Then
            Sheet = ActivePlanSet.Sheet(A)
            Newsheet.IP = Sheet.RightSheet
            Newsheet.Angle = Sheet.Angle
            Newsheet.Name = ActivePlanSet.NextName
            ActivePlanSet.Add(Newsheet)
            Newsheet.Draw()
            ActivePlanSet.Update()
        End If
    End Sub

    Private Sub btLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLeft.Click
        Dim A As String
        Dim Sheet As clsSheet
        Dim Newsheet As New clsSheet(ActivePlanSet, ActivePlanSet.Prototype)

        A = ActivePlanSet.GetSheet
        If A IsNot Nothing Then
            Sheet = ActivePlanSet.Sheet(A)
            Newsheet.IP = Sheet.LeftSheet
            Newsheet.Angle = Sheet.Angle
            Newsheet.Name = ActivePlanSet.NextName
            ActivePlanSet.Add(Newsheet)
            Newsheet.Draw()
            ActivePlanSet.Update()
        End If
    End Sub

    Private Sub btBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBottom.Click
        Dim A As String
        Dim Sheet As clsSheet
        Dim Newsheet As New clsSheet(ActivePlanSet, ActivePlanSet.Prototype)

        A = ActivePlanSet.GetSheet
        If A IsNot Nothing Then
            Sheet = ActivePlanSet.Sheet(A)
            Newsheet.IP = Sheet.BottomSheet
            Newsheet.Angle = Sheet.Angle
            Newsheet.Name = ActivePlanSet.NextName
            ActivePlanSet.Add(Newsheet)
            Newsheet.Draw()
            ActivePlanSet.Update()
        End If
    End Sub

    Private Sub ActivePlanSetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivePlanSetToolStripMenuItem.Click
        'construct all the drawings for the active plan set

        ActivePlanSet.MakeDwgs()
    End Sub


    Private Sub AllPlanSetsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllPlanSetsToolStripMenuItem.Click
        Dim PlanSet As clsPlanSet

        For Each kvp As KeyValuePair(Of String, clsPlanSet) In SheetColl.Sets
            PlanSet = kvp.Value
            PlanSet.MakeDwgs()
        Next
    End Sub

    Private Sub ModifySheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifySheetToolStripMenuItem.Click
        Dim A As String
        Dim myform As New frmModifySheet
        Dim Sheet As clsSheet

        A = ActivePlanSet.GetSheet
        If A IsNot Nothing Then
            Sheet = ActivePlanSet.Sheet(A)
            myform.Sheet = Sheet
            If Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(myform) = System.Windows.Forms.DialogResult.OK Then

            End If

        End If
    End Sub
End Class