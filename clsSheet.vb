Imports System.IO
Imports System.Windows.Forms
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry

<Serializable()> Public Class clsSheet
        Dim _Name As String
        Dim _Scale As Double
        Dim _Width As Double
        Dim _Height As Double
        Dim _MR As Double
        Dim _ML As Double
        Dim _MT As Double
        Dim _MB As Double
        Dim _Angle As Double
        Dim _IP As Point3d
        Dim _IsDrawn As Boolean
        Dim _IsModified As Boolean
        Dim _Above As String = ""
        Dim _Below As String = ""
        Dim _Left As String = ""
        Dim _Right As String = ""
        Dim _PlanSet As clsPlanSet
        Dim _VPHandle As String
        Dim _OID As ObjectId
        Dim _Initiator As Boolean

        Public Event Change(ByVal Sender As System.Object, ByVal e As clsSheetChange)

        Enum SheetChange As Integer
            Add
            Delete
            Move
            Rename
            Rotate
            MarginLeftChange
            MarginRightChange
            MarginTopChange
            MarginBottomChange
        End Enum
        Public Sub getRB(ByRef RB As ResultBuffer)

            RB.Add(New TypedValue(DxfCode.Text, _Name))
            RB.Add(New TypedValue(DxfCode.Real, _Scale))
            RB.Add(New TypedValue(DxfCode.Real, _Width))
            RB.Add(New TypedValue(DxfCode.Real, _Height))
            RB.Add(New TypedValue(DxfCode.Real, _MR))
            RB.Add(New TypedValue(DxfCode.Real, _ML))
            RB.Add(New TypedValue(DxfCode.Real, _MT))
            RB.Add(New TypedValue(DxfCode.Real, _MB))
            RB.Add(New TypedValue(DxfCode.Real, _Angle))
            RB.Add(New TypedValue(DxfCode.Real, _IP.X))
            RB.Add(New TypedValue(DxfCode.Real, _IP.Y))
            RB.Add(New TypedValue(DxfCode.Text, _Above))
            RB.Add(New TypedValue(DxfCode.Text, _Below))
            RB.Add(New TypedValue(DxfCode.Text, _Left))
            RB.Add(New TypedValue(DxfCode.Text, _Right))
            RB.Add(New TypedValue(DxfCode.Text, _VPHandle))

        End Sub
        Public Property VPHandle() As String
            Get
                Return _VPHandle
            End Get
            Set(ByVal value As String)
                _VPHandle = value
            End Set
        End Property
        Public Property PlanSet() As clsPlanSet
            Get
                Return _PlanSet
            End Get
            Set(ByVal value As clsPlanSet)
                _PlanSet = value
            End Set
        End Property
        Public Property Initiator() As Boolean
            Get
                Return _Initiator
            End Get
            Set(ByVal value As Boolean)
                _Initiator = value
            End Set
        End Property
        Public Property IsModified() As Boolean
            Get
                Return _IsModified
            End Get
            Set(ByVal value As Boolean)
                _IsModified = value
            End Set
        End Property
        Public ReadOnly Property ViewCentre() As Point3d
            Get
                Dim X, Y As Double
                Dim X1, Y1 As Double
                Dim Dist As Double

                Dist = VPWidth / 2
                clsGeoUtils.lgm026(_IP.X, _IP.Y, clsGeoUtils.ac2wcb(_Angle), Dist, X, Y)
                Dist = VPHeight / 2
                clsGeoUtils.lgm026(X, Y, clsGeoUtils.ac2wcb(_Angle) - HPI, Dist, X1, Y1)

                Return New Point3d(X1, Y1, 0)
            End Get
        End Property
        Public ReadOnly Property RightSheet() As Point3d
            Get
                Dim X, Y As Double
                Dim Dist As Double

                Dist = VPWidth - (_PlanSet.Overlap * _PlanSet.ScaleFactor)
                clsGeoUtils.lgm026(_IP.X, _IP.Y, clsGeoUtils.ac2wcb(_Angle), Dist, X, Y)
                Return New Point3d(X, Y, 0)
            End Get
        End Property
        Public ReadOnly Property TopSheet() As Point3d
            Get
                Dim X, Y As Double
                Dim Dist As Double

                Dist = VPHeight - (_PlanSet.Overlap * _PlanSet.ScaleFactor)
                clsGeoUtils.lgm026(_IP.X, _IP.Y, clsGeoUtils.ac2wcb(_Angle) - HPI, Dist, X, Y)
                Return New Point3d(X, Y, 0)
            End Get
        End Property
        Public ReadOnly Property BottomSheet() As Point3d
            Get
                Dim X, Y As Double
                Dim Dist As Double

                Dist = VPHeight - (_PlanSet.Overlap * _PlanSet.ScaleFactor)
                clsGeoUtils.lgm026(_IP.X, _IP.Y, clsGeoUtils.ac2wcb(_Angle) + HPI, Dist, X, Y)
                Return New Point3d(X, Y, 0)
            End Get
        End Property
        Public ReadOnly Property LeftSheet() As Point3d
            Get
                Dim X, Y As Double
                Dim Dist As Double

                Dist = VPWidth - (_PlanSet.Overlap * _PlanSet.ScaleFactor)
                clsGeoUtils.lgm026(_IP.X, _IP.Y, clsGeoUtils.ac2wcb(_Angle) - PI, Dist, X, Y)
                Return New Point3d(X, Y, 0)
            End Get
        End Property
        Public ReadOnly Property VPHeight() As Double
            Get
                Return (_Height - _MT - _MB) * _PlanSet.ScaleFactor
            End Get
        End Property
        Public ReadOnly Property VPWidth() As Double
            Get
                Return (_Width - _ML - _MR) * _PlanSet.ScaleFactor
            End Get
        End Property

        Public Property Height() As Double
            Get
                Return _Height * _PlanSet.ScaleFactor
            End Get
            Set(ByVal value As Double)
                _Height = value
            End Set
        End Property
        Public Property Width() As Double
            Get
                Return _Width * _PlanSet.ScaleFactor
            End Get
            Set(ByVal value As Double)
                _Width = value
            End Set
        End Property
        Public Property Scale() As Double
            Get
                Return _Scale
            End Get
            Set(ByVal value As Double)
                _Scale = value
            End Set
        End Property

        Public Property IP() As Point3d
            Get
                Return _IP
            End Get
            Set(ByVal value As Point3d)
                _IP = value
            End Set
        End Property
        Public Property Left() As String
            Get
                Return _Left
            End Get
            Set(ByVal value As String)
                _Left = value
            End Set
        End Property
        Public Property Right() As String
            Get
                Return _Right
            End Get
            Set(ByVal value As String)
                _Right = value
            End Set
        End Property
        Public Property Below() As String
            Get
                Return _Below
            End Get
            Set(ByVal value As String)
                _Below = value
            End Set
        End Property
        Public Property Above() As String
            Get
                Return _Above
            End Get
            Set(ByVal value As String)
                _Above = value
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
        Public Property Angle() As Double
            Get
                Return _Angle
            End Get
            Set(ByVal value As Double)
                _Angle = value
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
        Public Property AngleEvent() As Double
            Get
                Return _Angle
            End Get
            Set(ByVal value As Double)
                _Angle = value
                ModifyBlockReference()
                _PlanSet.Update()
                Dim change As New clsSheetChange
                change.SheetName = Me.Name
                change.SheetChange = SheetChange.Rotate
                RaiseEvent Change(Me, change)
            End Set
        End Property
        Public Property IPEvent() As Point3d
            Get
                Return _IP
            End Get
            Set(ByVal value As Point3d)
                Dim V1 As Vector3d = _IP.GetVectorTo(value)
                _IP = value
                ModifyBlockReference()
                _PlanSet.Update()
                Dim change As New clsSheetChange
            clsSheetChange.SheetName = Me.Name
            clsSheetChange.SheetChange = SheetChange.Move
            clsSheetChange.Vector = V1
            RaiseEvent Change(Me, change)
            End Set
        End Property
        Public Property MarginLeft() As Double
            Get
                Return _ML * _PlanSet.ScaleFactor
            End Get
            Set(ByVal value As Double)
                If value + _MR < _Width Then
                    _ML = value
                    ModifyBlockDefinition()
                    _PlanSet.Update()
                    Dim change As New clsSheetChange
                clsSheetChange.SheetName = Me.Name
                clsSheetChange.SheetChange = SheetChange.MarginLeftChange
                RaiseEvent Change(Me, change)
                End If
            End Set
        End Property
        Public Property MarginRight() As Double
            Get
                Return _MR * _PlanSet.ScaleFactor
            End Get
            Set(ByVal value As Double)
                If value + _ML < _Width Then
                    _MR = value
                    ModifyBlockDefinition()
                    _PlanSet.Update()
                    Dim change As New clsSheetChange
                clsSheetChange.SheetName = Me.Name
                clsSheetChange.SheetChange = SheetChange.MarginRightChange
                RaiseEvent Change(Me, change)
                End If
            End Set
        End Property
        Public Property MarginTop() As Double
            Get
                Return _MT * _PlanSet.ScaleFactor
            End Get
            Set(ByVal value As Double)
                If value + _MB < _Height Then
                    _MT = value
                    ModifyBlockDefinition()
                    _PlanSet.Update()
                    Dim change As New clsSheetChange
                clsSheetChange.SheetName = Me.Name
                clsSheetChange.SheetChange = SheetChange.MarginTopChange
                RaiseEvent Change(Me, change)
                End If
            End Set
        End Property
        Public Property MarginBottom() As Double
            Get
                Return _MB * _PlanSet.ScaleFactor
            End Get
            Set(ByVal value As Double)
                If value + _MT < _Height Then
                    _MB = value
                    ModifyBlockDefinition()
                    _PlanSet.Update()
                    Dim change As New clsSheetChange
                clsSheetChange.SheetName = Me.Name
                clsSheetChange.SheetChange = SheetChange.MarginBottomChange
                RaiseEvent Change(Me, change)
                End If
            End Set
        End Property
        Public ReadOnly Property Node() As TreeNode
            Get
                Dim SNode As New TreeNode
                SNode.Name = Me.Name
                SNode.Text = Me.Name
                Return SNode
            End Get
        End Property

        Public Sub Draw()

            MakeBlockReference()
            clsAcad.MakeViewADN(Me.Name, Me.ViewCentre, Me.VPWidth, Me.VPHeight, Me.Angle)
            _IsDrawn = True

        End Sub
        Public Sub UnHighlight()
            Dim DB As Database = HostApplicationServices.WorkingDatabase
            Dim ent As BlockReference

            Using docLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument
                Using Trans As Transaction = DB.TransactionManager.StartTransaction
                    Try
                        If Not (_OID.IsNull) Then
                            ent = Trans.GetObject(_OID, OpenMode.ForWrite, False)
                            If Not (ent.IsErased) Then
                                ent.Unhighlight()
                                Trans.Commit()
                            End If
                        End If
                    Catch ex As Exception
                    Finally
                    End Try
                End Using
            End Using
        End Sub
        Public Sub Highlight()
            Dim DB As Database = HostApplicationServices.WorkingDatabase
            Dim ent As BlockReference

            Using docLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument
                Using Trans As Transaction = DB.TransactionManager.StartTransaction
                    Try
                        If Not (_OID.IsNull) Then
                            ent = Trans.GetObject(_OID, OpenMode.ForWrite, False)
                            If Not (ent.IsErased) Then
                                Dim Ids(1) As ObjectId
                                Ids(0) = _PlanSet.ObjectID
                                Ids(1) = _OID
                                Dim subent As SubentityId = New SubentityId(SubentityType.Null, 0)
                                Dim path As FullSubentityPath = New FullSubentityPath(Ids, subent)
                                ent.Highlight(path, False)
                                Trans.Commit()
                            End If
                        End If
                    Catch ex As Exception
                    Finally
                    End Try
                End Using
            End Using
        End Sub
        Public Sub Delete()
            Dim DB As Database = HostApplicationServices.WorkingDatabase
            Dim ent As BlockReference

            Using docLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument
                Using Trans As Transaction = DB.TransactionManager.StartTransaction
                    Try
                        If Not (_OID.IsNull) Then
                            ent = Trans.GetObject(_OID, OpenMode.ForWrite, False)
                            If Not (ent.IsErased) Then
                                ent.Erase()
                                Trans.Commit()
                            End If
                        End If
                    Catch ex As Exception
                    Finally
                        _IsDrawn = False
                    End Try
                End Using
            End Using
        End Sub
        Public Sub New(ByVal SheetSet As clsPlanSet, ByVal Name As String, ByVal Width As Double, ByVal Height As Double, ByVal ML As Double, _
            ByVal MR As Double, ByVal MT As Double, ByVal MB As Double)

            _PlanSet = SheetSet
            _Name = Name
            _Width = Width
            _Height = Height
            _ML = ML
            _MR = MR
            _MT = MT
            _MB = MB

        End Sub
        Public Sub MakeDWG()
            Dim DB As New Database(False, True)

            If File.Exists(_PlanSet.Template) Then
            DB.ReadDwgFile(_PlanSet.Template, FileShare.Read, True, "")
            'save it to the right folder
            DB.SaveAs(_PlanSet.Location + "\" + _Name + ".dwg", DwgVersion.Current)
            'add the xrefs
            For Each xref As String In _PlanSet.XRefs
                    clsAcad.makeXref(DB, xref)
                Next
                'make the viewport
                _VPHandle = clsAcad.AddViewPort(DB, New Point3d( _
                    _ML + ((VPWidth / 2) / _PlanSet.ScaleFactor), _
                    _MB + ((VPHeight / 2) / _PlanSet.ScaleFactor), _
                    0), _
                    ViewCentre, VPWidth / _PlanSet.ScaleFactor, VPHeight / _PlanSet.ScaleFactor, _
                    _Angle, _PlanSet.Scale, True, _PlanSet.IsMetres)
            'save the drawing
            DB.SaveAs(_PlanSet.Location + "\" + _Name + ".dwg", DwgVersion.Current)
            DB.Dispose()
        Else
                MsgBox("Unable to find template file", MsgBoxStyle.Information)
            End If
        End Sub
        Public Sub UpdateDWG()
            Dim DB As New Database(False, True)
            Dim Fname As String = _PlanSet.Location + "\" + _Name + ".dwg"

            If File.Exists(Fname) Then
                DB.ReadDwgFile(Fname, FileShare.ReadWrite, False, "")
                'delete the old viewport
                clsAcad.DeleteObj(DB, _VPHandle)
                'check to see if the xref exists
                For Each xref As String In _PlanSet.XRefs
                    If Not (clsAcad.XrefExists(DB, Path.GetFileNameWithoutExtension(xref))) Then
                        clsAcad.makeXref(DB, xref)
                    End If
                Next
                'make the viewport
                _VPHandle = clsAcad.AddViewPort(DB, New Point3d( _
                    _ML + ((VPWidth / 2) / _PlanSet.ScaleFactor), _
                    _MB + ((VPHeight / 2) / _PlanSet.ScaleFactor), _
                    0), _
                    ViewCentre, VPWidth / _PlanSet.ScaleFactor, VPHeight / _PlanSet.ScaleFactor, _
                    _Angle, _PlanSet.Scale, True, _PlanSet.IsMetres)
                'save the drawing
                DB.SaveAs(_PlanSet.Location + "\" + _Name + "-.dwg", DwgVersion.Current)
                DB.Dispose()
                File.Replace(_PlanSet.Location + "\" + _Name + "-.dwg", _
                _PlanSet.Location + "\" + _Name + ".dwg", _PlanSet.Location + "\" + _Name + ".bak")
            Else
                MsgBox("Cannot find Drawing: " + vbCrLf + _PlanSet.Location + "\" + _Name + ".dwg", MsgBoxStyle.Exclamation)
                MakeDWG()
            End If
        End Sub
        Public Sub New()

        End Sub
        Public Sub New(ByVal PlanSet As clsPlanSet, ByVal Proto As clsPlanSet.DwgSheet)

            _PlanSet = PlanSet
            _Width = Proto.Width
            _Height = Proto.Height
            _ML = Proto.ML
            _MR = Proto.MR
            _MT = Proto.MT
            _MB = Proto.MB
        End Sub
        Public Sub MakeBlockReference()
            Dim DB As Database = HostApplicationServices.WorkingDatabase
            Dim BlockName As String
            Dim BlockTable As BlockTable
            Dim SheetBTR As BlockTableRecord
            Dim PlanSetBTR As BlockTableRecord
            Dim PlanSetBlockRef As BlockReference
            Dim SF As Double = _PlanSet.ScaleFactor

            Using docLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument
                Using Trans As Transaction = DB.TransactionManager.StartTransaction
                    Try
                        BlockName = Me.Name
                        BlockTable = Trans.GetObject(DB.BlockTableId, OpenMode.ForRead)
                        'if the block record exists delete all entities or create new one
                        If BlockTable.Has(BlockName) Then               'the block exists so delete all contents
                            SheetBTR = Trans.GetObject(BlockTable(BlockName), OpenMode.ForWrite)
                            Dim Ent As Entity
                            For Each ID As ObjectId In SheetBTR
                                Ent = Trans.GetObject(ID, OpenMode.ForWrite, False)
                                Ent.Erase()
                            Next
                        Else
                            SheetBTR = New BlockTableRecord
                            SheetBTR.Name = BlockName
                            BlockTable.UpgradeOpen()
                            BlockTable.Add(SheetBTR)
                            Trans.AddNewlyCreatedDBObject(SheetBTR, True)
                        End If
                        PlanSetBTR = Trans.GetObject(BlockTable(_PlanSet.Name), OpenMode.ForWrite)

                        PlanSetBlockRef = New BlockReference(_IP, BlockTable(BlockName))
                        PlanSetBlockRef.Layer = "0"
                        PlanSetBlockRef.Rotation = _Angle

                        PlanSetBlockRef.ScaleFactors = New Scale3d(1, 1, 1)
                        _OID = PlanSetBTR.AppendEntity(PlanSetBlockRef)
                        Trans.AddNewlyCreatedDBObject(PlanSetBlockRef, True)
                        SheetBTR = Trans.GetObject(BlockTable(BlockName), OpenMode.ForWrite)
                        'add the two polylines
                        Dim VertexPoints As Point3dCollection = GetVPFrameVertices()
                        Dim B() As Double = {0, 0, 0, 0}
                        Dim Bulges As DoubleCollection = New DoubleCollection(B)

                        Dim VCPLine As New Polyline2d(Poly2dType.SimplePoly, VertexPoints, 0, True, 0, 0, Bulges)
                        VCPLine.ColorIndex = 6
                        VCPLine.Linetype = "ByBlock"
                        SheetBTR.AppendEntity(VCPLine)
                        Trans.AddNewlyCreatedDBObject(VCPLine, True)

                        VertexPoints = GetFrameVertices()
                        VCPLine = New Polyline2d(Poly2dType.SimplePoly, VertexPoints, 0, True, 0, 0, Bulges)
                        VCPLine.ColorIndex = 5
                        VCPLine.Linetype = "ByBlock"
                        SheetBTR.AppendEntity(VCPLine)
                        Trans.AddNewlyCreatedDBObject(VCPLine, True)
                        Trans.Commit()
                    Catch aex As Autodesk.AutoCAD.Runtime.Exception
                        MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
                    Catch ex As System.Exception
                        MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try
                End Using
            End Using
        End Sub
        'this updates the insertion point and angle
        Public Sub ModifyBlockReference()
            Dim DB As Database = HostApplicationServices.WorkingDatabase
            Dim BlockName As String = Me.Name
            Dim BlockTable As BlockTable
            Dim SheetBTR As BlockTableRecord
            Dim OIDColl As ObjectIdCollection
            Dim SheetRef As BlockReference

            Using docLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument
                Using Trans As Transaction = DB.TransactionManager.StartTransaction
                    Try
                        BlockTable = Trans.GetObject(DB.BlockTableId, OpenMode.ForRead)
                        If BlockTable.Has(BlockName) Then               'the block exists so delete all contents
                            SheetBTR = Trans.GetObject(BlockTable(BlockName), OpenMode.ForWrite)
                            OIDColl = SheetBTR.GetBlockReferenceIds(True, True)
                            If OIDColl.Count >= 1 Then
                                SheetRef = Trans.GetObject(OIDColl.Item(0), OpenMode.ForWrite, False)
                                SheetRef.Position = _IP
                                SheetRef.Rotation = _Angle
                            End If
                        End If
                        Trans.Commit()
                    Catch aex As Autodesk.AutoCAD.Runtime.Exception
                        MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
                    Catch ex As System.Exception
                        MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try
                End Using
            End Using
        End Sub
        'this modifies the shape of the block
        Public Sub ModifyBlockDefinition()
            Dim DB As Database = HostApplicationServices.WorkingDatabase
            Dim BlockName As String
            Dim BlockTable As BlockTable
            Dim SheetBTR As BlockTableRecord
            Dim SF As Double = _PlanSet.ScaleFactor

            Using docLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument
                Using Trans As Transaction = DB.TransactionManager.StartTransaction
                    Try
                        BlockName = Me.Name
                        BlockTable = Trans.GetObject(DB.BlockTableId, OpenMode.ForRead)
                        'if the block record exists delete all entities or create new one
                        If BlockTable.Has(BlockName) Then               'the block exists so delete all contents
                            SheetBTR = Trans.GetObject(BlockTable(BlockName), OpenMode.ForWrite)
                            Dim Ent As Entity
                            For Each ID As ObjectId In SheetBTR
                                Ent = Trans.GetObject(ID, OpenMode.ForWrite, False)
                                Ent.Erase()
                            Next
                        Else
                            SheetBTR = New BlockTableRecord
                            SheetBTR.Name = BlockName
                            BlockTable.UpgradeOpen()
                            BlockTable.Add(SheetBTR)
                            Trans.AddNewlyCreatedDBObject(SheetBTR, True)
                        End If

                        SheetBTR = Trans.GetObject(BlockTable(BlockName), OpenMode.ForWrite)
                        'add the two polylines
                        Dim VertexPoints As Point3dCollection = GetVPFrameVertices()
                        Dim B() As Double = {0, 0, 0, 0}
                        Dim Bulges As DoubleCollection = New DoubleCollection(B)

                        Dim VCPLine As New Polyline2d(Poly2dType.SimplePoly, VertexPoints, 0, True, 0, 0, Bulges)
                        VCPLine.ColorIndex = 6
                        VCPLine.Linetype = "ByBlock"
                        SheetBTR.AppendEntity(VCPLine)
                        Trans.AddNewlyCreatedDBObject(VCPLine, True)

                        VertexPoints = GetFrameVertices()
                        VCPLine = New Polyline2d(Poly2dType.SimplePoly, VertexPoints, 0, True, 0, 0, Bulges)
                        VCPLine.ColorIndex = 5
                        VCPLine.Linetype = "ByBlock"
                        SheetBTR.AppendEntity(VCPLine)
                        Trans.AddNewlyCreatedDBObject(VCPLine, True)
                        Trans.Commit()
                    Catch aex As Autodesk.AutoCAD.Runtime.Exception
                        MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
                    Catch ex As System.Exception
                        MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try
                End Using
            End Using
        End Sub
        Private Function GetVPFrameVertices() As Point3dCollection
            Dim P1, p2, p3, p4 As Point3d
            Dim P3DC As New Point3dCollection

            P1 = New Point3d(0, 0, 0)
            P3DC.Add(P1)
            p2 = New Point3d(Me.VPWidth, 0, 0)
            P3DC.Add(p2)
            p3 = New Point3d(Me.VPWidth, Me.VPHeight, 0)
            P3DC.Add(p3)
            p4 = New Point3d(0, Me.VPHeight, 0)
            P3DC.Add(p4)
            Return P3DC
        End Function
    Private Function GetFrameVertices() As Point3dCollection
        Dim P1, p2, p3, p4 As Point3d
        Dim P3DC As New Point3dCollection

        P1 = New Point3d(0 - Me.MarginLeft, 0 - Me.MarginBottom, 0)
        P3DC.Add(P1)
        p2 = New Point3d(0 + Me.VPWidth + Me.MarginRight, 0 - Me.MarginBottom, 0)
        P3DC.Add(p2)
        p3 = New Point3d(0 + Me.VPWidth + Me.MarginRight, 0 + Me.VPHeight + Me.MarginTop, 0)
        P3DC.Add(p3)
        p4 = New Point3d(0 - Me.MarginLeft, 0 + Me.VPHeight + Me.MarginTop, 0)
        P3DC.Add(p4)
        Return P3DC
    End Function

    Public Class clsSheetChange
            Inherits EventArgs
        Public Shared SheetChange As SheetChange
        Public Shared SheetName As String
            Public Shared Vector As Vector3d
        End Class
    End Class
