Imports System.Windows.Forms
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry


<Serializable()> Public Class clsProjectSet
        Dim _Name As String
        Dim _Sets As New Dictionary(Of String, clsPlanSet)

        Public Property Sets() As Dictionary(Of String, clsPlanSet)
            Get
                Return _Sets
            End Get
            Set(ByVal value As Dictionary(Of String, clsPlanSet))
                _Sets = value
            End Set
        End Property
        Public Function Item(ByVal Name As String) As clsPlanSet

            If _Sets.ContainsKey(Name) Then
                Return _Sets.Item(Name)
            Else
                Return Nothing
            End If
        End Function
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        Public Sub Add(ByVal SheetSet As clsPlanSet)

            If Not (_Sets.ContainsKey(SheetSet.Name)) Then
                _Sets.Add(SheetSet.Name, SheetSet)
            End If
        End Sub
        Public Sub remove(ByVal Name As String)

            If _Sets.ContainsKey(Name) Then
                _Sets.Remove(Name)
            End If
        End Sub
        Public ReadOnly Property Count() As Integer
            Get
                Return _Sets.Count
            End Get
        End Property
        Public Sub New(ByVal Name As String)

            _Name = Name
        End Sub
        Public Sub Load()
            Dim RB As ResultBuffer
            Dim KW() As String
            Dim i0, i1 As Integer
            Dim xRecordType() As Short
            Dim XData() As Object
            Dim TV As TypedValue
            Dim SCnt As Integer


            _Sets.Clear()
            KW = Xrec.GetPlanSets
            For Each str As String In KW
                RB = Xrec.LoadPlanSet(str)
                'extract the data from the Result buffer
                i0 = 0
                For Each TV In RB
                    ReDim Preserve xRecordType(i0)
                    ReDim Preserve XData(i0)
                    xRecordType(i0) = RB.AsArray(i0).TypeCode
                    XData(i0) = RB.AsArray(i0).Value
                    i0 = i0 + 1
                Next
                i1 = 0
                Dim PlanSet As New clsPlanSet(XData(i1), XData(i1 + 2), XData(i1 + 3), XData(i1 + 1))
                PlanSet.IsMetres = XData(i1 + 4)
                i1 = i1 + 5
                'prototype data
                Dim Proto As New clsPlanSet.DwgSheet
                Proto.Name = XData(i1)
                Proto.Width = XData(i1 + 1)
                Proto.Height = XData(i1 + 2)
                Proto.ML = XData(i1 + 3)
                Proto.MR = XData(i1 + 4)
                Proto.MT = XData(i1 + 5)
                Proto.MB = XData(i1 + 6)
                PlanSet.Template = XData(i1 + 7)
                PlanSet.Prototype = Proto
                i1 = i1 + 8
                For i0 = 0 To XData(i1) - 1
                    PlanSet.XRefs.Add(XData(i1 + 1 + i0))
                Next
                i1 = 14 + i0
                SCnt = XData(i1)
                For i0 = 0 To SCnt - 1
                    Dim sheet As New clsSheet(PlanSet, XData(i1 + 1), XData(i1 + 3), _
                    XData(i1 + 4), XData(i1 + 6), XData(i1 + 5), XData(i1 + 7), XData(i1 + 8))
                    sheet.Scale = XData(i1 + 2)
                    sheet.Angle = XData(i1 + 9)
                    sheet.IP = New Point3d(XData(i1 + 10), XData(i1 + 11), 0)
                    sheet.Above = XData(i1 + 12)
                    sheet.Below = XData(i1 + 13)
                    sheet.Left = XData(i1 + 14)
                    sheet.Right = XData(i1 + 15)
                    sheet.VPHandle = XData(i1 + 16)
                    i1 = i1 + 16
                    PlanSet.Add(sheet)
                Next
                _Sets.Add(PlanSet.Name, PlanSet)
            Next

        End Sub
        Public Sub Store()
            Dim RB As ResultBuffer

            For Each KVP As KeyValuePair(Of String, clsPlanSet) In _Sets
                RB = New ResultBuffer
                Dim PlanSet As clsPlanSet = KVP.Value
                PlanSet.getRB(RB)
                Xrec.SavePlanSet(PlanSet.Name, RB)
            Next
        End Sub
        Public Function Tree() As TreeNode
            Dim RootNode As New TreeNode

            RootNode.Name = "Project"
            RootNode.Text = "Project Name"

            For Each KVP As KeyValuePair(Of String, clsPlanSet) In _Sets
                Dim PlanSet As clsPlanSet
                Dim PSNode As New TreeNode
                PlanSet = KVP.Value

                PSNode.Name = PlanSet.Name
                PSNode.Text = PlanSet.Name

                PlanSet.GetNode(PSNode)
                RootNode.Nodes.Add(PSNode)
            Next
            Return RootNode
        End Function
    End Class
