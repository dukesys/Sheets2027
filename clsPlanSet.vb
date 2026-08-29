Imports System.Windows.Forms
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.Runtime


<Serializable()> Public Class clsPlanSet
        Dim _Name As String
        Dim _Location As String
        Dim _Scale As Double
        Dim _Overlap As Double
        Dim _Prototype As New DwgSheet
        Dim _Template As String
        Dim _Xrefs As New List(Of String)
        Dim _Sheets As New Dictionary(Of String, clsSheet)
        Public Event Change(ByVal Sender As System.Object, ByVal e As clsPlanSetChange)
        Dim _IsDrawn As Boolean
        Dim _ObjID As ObjectId
        Dim _SheetCnt As Integer
        Dim _ScaleFactor As Double
        Dim _IsMetres As Boolean = True

        Enum PlanSetChange As Integer
            Add
            Delete
            Move
            Rename
        End Enum
        Public Structure DwgSheet
            Public Name As String
            Public Width As Double
            Public Height As Double
            Public ML As Double
            Public MR As Double
            Public MT As Double
            Public MB As Double
        End Structure
        Public Property IsMetres() As Boolean
            Get
                Return _IsMetres
            End Get
            Set(ByVal value As Boolean)
                _IsMetres = value
            End Set
        End Property
        Public ReadOnly Property ObjectID() As ObjectId
            Get
                Return _ObjID
            End Get
        End Property
        Public ReadOnly Property ScaleFactor() As Double
            Get
                Return _ScaleFactor
            End Get
        End Property

        Public Property Template() As String
            Get
                Return _Template
            End Get
            Set(ByVal value As String)
                _Template = value
            End Set
        End Property
        Public Property Prototype() As DwgSheet
            Get
                Return _Prototype
            End Get
            Set(ByVal value As DwgSheet)
                _Prototype = value
            End Set
        End Property
        Public Property IsDrawn() As Boolean
            Get
                Return _IsDrawn
            End Get
            Set(ByVal value As Boolean)
                _IsDrawn = value
            End Set
        End Property
        Public Property XRefs() As List(Of String)
            Get
                Return _Xrefs
            End Get
            Set(ByVal value As List(Of String))
                _Xrefs = value
            End Set
        End Property
        Public Property Overlap() As Double
            Get
                Return _Overlap
            End Get
            Set(ByVal value As Double)
                _Overlap = value
            End Set
        End Property
        Public Property Scale() As Double
            Get
                Return _Scale
            End Get
            Set(ByVal value As Double)
                _Scale = value
                _ScaleFactor = _Scale / 1000.0
            End Set
        End Property
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        Public Property Location() As String
            Get
                Return _Location
            End Get
            Set(ByVal value As String)
                _Location = value
            End Set
        End Property
        Public ReadOnly Property NextName() As String
            Get
                Select Case Len(CStr(_SheetCnt + 1))
                    Case 1
                        Return Me.Name + "-00" + CStr(_SheetCnt + 1)
                    Case 2
                        Return Me.Name + "-0" + CStr(_SheetCnt + 1)
                    Case 3
                        Return Me.Name + "-" + CStr(_SheetCnt + 1)
                End Select
                Return ""
            End Get
        End Property
        Public Property Sheets() As Dictionary(Of String, clsSheet)

            Get
                Return _Sheets
            End Get
            Set(ByVal value As Dictionary(Of String, clsSheet))
                _Sheets = value
            End Set
        End Property
        Public ReadOnly Property Sheet(ByVal Name As String) As clsSheet
            Get
                Return _Sheets.Item(Name)
            End Get
        End Property
        Public Sub MakeDwgs()
            Dim sheet As clsSheet

            If _Xrefs.Count = 0 Then
                If MsgBox("There are no Xrefs specified in Plan Set " + _Name _
                    + " are you sure you want to proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Return
                End If
            End If
            For Each KVP As KeyValuePair(Of String, clsSheet) In _Sheets
                sheet = KVP.Value
                sheet.MakeDWG()
            Next
        End Sub
        Public Sub ClearModifiedFlags()
            Dim sheet As clsSheet

            For Each KVP As KeyValuePair(Of String, clsSheet) In _Sheets
                sheet = KVP.Value
                sheet.IsModified = False
                sheet.Initiator = False
            Next
        End Sub
        Public Sub UpdateDwgs()
            Dim sheet As clsSheet

            For Each KVP As KeyValuePair(Of String, clsSheet) In _Sheets
                sheet = KVP.Value
                sheet.UpdateDWG()
            Next
        End Sub
        Public Sub Add(ByVal Sheet As clsSheet)
            If Not (_Sheets.ContainsKey(Sheet.Name)) Then
                _Sheets.Add(Sheet.Name, Sheet)
                Update()
                _SheetCnt = _SheetCnt + 1
                Dim PSChange As New clsPlanSetChange
            clsPlanSetChange.PlanSetChange = PlanSetChange.Add
            clsPlanSetChange.SheetName = Sheet.Name
            RaiseEvent Change(Me, PSChange)
            End If
        End Sub
        Public Sub Remove(ByVal Name As String)
            Dim Sheet As clsSheet

            If Sheets.ContainsKey(Name) Then
                Sheet = _Sheets.Item(Name)
                'delete the link info from each bounding sheet
                If Sheet.Right <> "" Then _Sheets.Item(Sheet.Right).Left = ""
                If Sheet.Left <> "" Then _Sheets.Item(Sheet.Left).Right = ""
                If Sheet.Above <> "" Then _Sheets.Item(Sheet.Above).Below = ""
                If Sheet.Below <> "" Then _Sheets.Item(Sheet.Below).Above = ""
                Sheet.Delete()
                _Sheets.Remove(Name)
                Dim PSChange As New clsPlanSetChange
            clsPlanSetChange.PlanSetChange = PlanSetChange.Delete
            clsPlanSetChange.SheetName = Name
            RaiseEvent Change(Me, PSChange)
            End If
        End Sub
        Public ReadOnly Property Count() As Integer
            Get
                Return _Sheets.Count
            End Get
        End Property
        Public Sub Draw()

            For Each KVP As KeyValuePair(Of String, clsSheet) In _Sheets
                KVP.Value.Draw()
            Next
            _IsDrawn = True
        End Sub
        Public Sub Delete()

            For Each KVP As KeyValuePair(Of String, clsSheet) In _Sheets
                KVP.Value.Delete()
            Next
            _IsDrawn = False
        End Sub
        Public ReadOnly Property Node() As TreeNode
            Get
                Dim SSNode As New TreeNode
                SSNode.Name = Me.Name
                SSNode.Text = Me.Name
                Return SSNode
            End Get
        End Property
        Public Sub GetNode(ByRef ParentNode As TreeNode)
            Dim sheet As clsSheet

            For Each KVP As KeyValuePair(Of String, clsSheet) In _Sheets
                Dim SheetNode As New TreeNode
                sheet = KVP.Value

                SheetNode.Name = sheet.Name
                SheetNode.Text = sheet.Name
                ParentNode.Nodes.Add(SheetNode)
            Next
        End Sub
        Public Sub New(ByVal Name As String, ByVal Scale As Double, ByVal Overlap As Double, ByVal Location As String)

            _Name = Name
            _Scale = Scale
            _Overlap = Overlap
            _Location = Location
            _ScaleFactor = _Scale / 1000.0
            MakeBlockReference()
        End Sub
        Public Sub Update()
            Dim DB As Database = HostApplicationServices.WorkingDatabase
            Dim ent As BlockReference

            Using docLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument
                Using Trans As Transaction = DB.TransactionManager.StartTransaction
                    Try
                        If Not (_ObjID.IsNull) Then
                            ent = Trans.GetObject(_ObjID, OpenMode.ForWrite, False)
                            If Not (ent.IsErased) Then
                                ent.RecordGraphicsModified(True)
                                ent.BlockTableRecord = ent.BlockTableRecord
                                Trans.Commit()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End Using
            End Using
        End Sub
        Private Sub MakeBlockReference()
            Dim DB As Database = HostApplicationServices.WorkingDatabase
            Dim Doc As Document = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument
            Dim Ed As Editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor()
            Dim PlanSetBTR As BlockTableRecord
            Dim ModelSpaceBTR As BlockTableRecord
            Dim BlockRef As BlockReference
            Dim iPnt As New Point3d(0, 0, 0)

            Using DocLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument()
                Using trans As Transaction = DB.TransactionManager.StartTransaction()
                    Try
                        Dim BlockTable As BlockTable = trans.GetObject(DB.BlockTableId, OpenMode.ForWrite, True)
                        If BlockTable.Has(_Name) Then      'check to see if it exists
                            PlanSetBTR = trans.GetObject(BlockTable(_Name), OpenMode.ForWrite)
                            Dim Ent As Entity
                            For Each ID As ObjectId In PlanSetBTR
                                Ent = trans.GetObject(ID, OpenMode.ForWrite, False)
                                Ent.Erase()
                            Next
                            'erase the block if it is in the drawing
                            Dim oid As ObjectIdCollection = PlanSetBTR.GetBlockReferenceIds(True, True)
                            For Each ID As ObjectId In oid
                                Ent = trans.GetObject(ID, OpenMode.ForWrite, False)
                                Ent.Erase()
                            Next
                        Else                                'create the block and insert it
                            PlanSetBTR = New BlockTableRecord
                            PlanSetBTR.Name = _Name
                            BlockTable.Add(PlanSetBTR)
                            trans.AddNewlyCreatedDBObject(PlanSetBTR, True)
                        End If
                        ModelSpaceBTR = trans.GetObject(BlockTable(BlockTableRecord.ModelSpace), OpenMode.ForWrite)
                        BlockRef = New BlockReference(iPnt, BlockTable(_Name))
                        BlockRef.Layer = "0"
                        BlockRef.Rotation = 0
                        BlockRef.ScaleFactors = New Scale3d(1, 1, 1)
                        _ObjID = ModelSpaceBTR.AppendEntity(BlockRef)

                        trans.AddNewlyCreatedDBObject(BlockRef, True)
                        trans.Commit()
                    Catch aex As Autodesk.AutoCAD.Runtime.Exception
                        MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
                    Catch ex As System.Exception
                        MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try
                End Using
            End Using
        End Sub
        Public Sub getRB(ByRef RB As ResultBuffer)

            RB.Add(New TypedValue(DxfCode.Text, _Name))
            RB.Add(New TypedValue(DxfCode.Text, _Location))
            RB.Add(New TypedValue(DxfCode.Real, _Scale))
            RB.Add(New TypedValue(DxfCode.Real, _Overlap))
            RB.Add(New TypedValue(DxfCode.Bool, _IsMetres))
            'prototype
            RB.Add(New TypedValue(DxfCode.Text, _Prototype.Name))
            RB.Add(New TypedValue(DxfCode.Real, _Prototype.Width))
            RB.Add(New TypedValue(DxfCode.Real, _Prototype.Height))
            RB.Add(New TypedValue(DxfCode.Real, _Prototype.ML))
            RB.Add(New TypedValue(DxfCode.Real, _Prototype.MR))
            RB.Add(New TypedValue(DxfCode.Real, _Prototype.MT))
            RB.Add(New TypedValue(DxfCode.Real, _Prototype.MB))
            RB.Add(New TypedValue(DxfCode.Text, _Template))
            'xrefs
            RB.Add(New TypedValue(DxfCode.Int16, _Xrefs.Count))
            For Each str As String In _Xrefs
                RB.Add(New TypedValue(DxfCode.Text, str))
            Next
            'sheets
            RB.Add(New TypedValue(DxfCode.Int16, _Sheets.Count))
            For Each KVP As KeyValuePair(Of String, clsSheet) In _Sheets
                Dim Sheet As clsSheet
                Sheet = KVP.Value
                Sheet.getRB(RB)
            Next

        End Sub
        Public Function GetSheet()
            Dim Ed As Editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor
            Dim EntitySelectionOptions As PromptNestedEntityOptions = _
                New PromptNestedEntityOptions(vbCrLf & "Select Sheet: ")
            Dim EntitySelectionResult As PromptEntityResult = Ed.GetNestedEntity(EntitySelectionOptions)
            Dim BlockName As String

            Using docLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument()
                Using trans As Autodesk.AutoCAD.DatabaseServices.Transaction = Ed.Document.TransactionManager.StartTransaction
                    Try
                        If EntitySelectionResult.Status = PromptStatus.OK Then
                            Dim OID As ObjectId
                            Dim Ent As Entity
                            OID = EntitySelectionResult.ObjectId
                            Ent = trans.GetObject(OID, OpenMode.ForRead, False)
                            BlockName = Ent.BlockName
                            If _Sheets.ContainsKey(BlockName) Then
                                Return BlockName
                            Else
                                Return Nothing
                            End If
                        Else
                            Return Nothing
                        End If
                    Catch ex As Exception
                    End Try
                End Using
            End Using
        End Function
        Public Sub Renumber()
            Dim NewColl As New Dictionary(Of String, clsSheet)
            Dim icnt As Integer
            Dim rlist() As Rename


            For Each KVP As KeyValuePair(Of String, clsSheet) In _Sheets
                Dim Sheet As clsSheet
                Sheet = KVP.Value
                Dim rename As New Rename
                rename.OldName = Sheet.Name
                rename.NewName = RenumberName(icnt)
                ReDim Preserve rlist(icnt)
                rlist(icnt) = rename
                icnt = icnt + 1
            Next

            icnt = 0
            For Each KVP As KeyValuePair(Of String, clsSheet) In _Sheets
                Dim Sheet As clsSheet
                Sheet = KVP.Value
                If Sheet.Right <> "" Then Sheet.Right = GetName(rlist, Sheet.Right)
                If Sheet.Left <> "" Then Sheet.Left = GetName(rlist, Sheet.Left)
                If Sheet.Above <> "" Then Sheet.Above = GetName(rlist, Sheet.Above)
                If Sheet.Below <> "" Then Sheet.Below = GetName(rlist, Sheet.Below)
                Sheet.Name = GetName(rlist, Sheet.Name)
                icnt = icnt + 1
                Sheet.MakeBlockReference()
                NewColl.Add(Sheet.Name, Sheet)
            Next
            _Sheets = NewColl
        End Sub
        Public Function GetName(ByVal List() As Rename, ByVal oldname As String) As String
            Dim i As Integer

            For i = 0 To UBound(List)
                If List(i).OldName = oldname Then
                    Return List(i).NewName
                End If
            Next
            Return ""
        End Function
        Public Function RenumberName(ByVal Cnt As Integer) As String

            Select Case Len(CStr(Cnt + 1))
                Case 1
                    Return Me.Name + "-00" + CStr(Cnt + 1)
                Case 2
                    Return Me.Name + "-0" + CStr(Cnt + 1)
                Case 3
                    Return Me.Name + "-" + CStr(Cnt + 1)
            End Select
            Return ""
        End Function

        Public Sub New()

        End Sub
        Public Overrides Function tostring() As String

            Return _Name
        End Function
        Public Class clsPlanSetChange
            Inherits EventArgs
            Public Shared PlanSetChange As PlanSetChange
        Public Shared SheetName As String
        Public Shared SheetChange As clsSheet.clsSheetChange
    End Class
        Public Class Rename
            Public OldName As String
            Public NewName As String
        End Class
    End Class
