Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Geometry
Imports AcadAp = Autodesk.AutoCAD.ApplicationServices.Application

Public Class clsAcad
        Shared Function GetPoint(ByVal msg As String) As PromptPointResult
            Dim db As Database = HostApplicationServices.WorkingDatabase
            Dim trans As Transaction = db.TransactionManager.StartTransaction()
            Dim ed As Editor = Application.DocumentManager.MdiActiveDocument.Editor()
            Dim docLock As DocumentLock = Application.DocumentManager.MdiActiveDocument.LockDocument()

            Try
                Dim PrPos As PromptPointOptions = New PromptPointOptions(msg)
                PrPos.AllowNone = False
                Dim prPosRes As PromptPointResult = ed.GetPoint(PrPos)
                If prPosRes.Status <> PromptStatus.OK Then
                    trans.Abort()
                    Return Nothing
                Else
                    Return prPosRes
                End If
                trans.Commit()
            Catch aex As Autodesk.AutoCAD.Runtime.Exception
                MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
            Catch ex As System.Exception
                MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
            Finally
                trans.Dispose()
                docLock.Dispose()
            End Try
        End Function
        Shared Function makeXref(ByRef DB As Database, ByVal XrefName As String) As Boolean
            Dim trans As Transaction = DB.TransactionManager.StartTransaction()
            Dim Doc As Document = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument
            Dim Ed As Editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor()
            Dim DocLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument()
            Dim BTR As BlockTableRecord
            Dim BRef As BlockReference
            Dim iPnt As New Point3d(0, 0, 0)
            Dim Xname As String = Path.GetFileNameWithoutExtension(XrefName)
            Dim _OID As ObjectId
            Try
                Dim BT As BlockTable = trans.GetObject(DB.BlockTableId, OpenMode.ForWrite, True)
                If BT.Has(Xname) Then   'check to see if it exists
                    Return True
                Else                    'create the block and insert it
                    BTR = trans.GetObject(BT(BlockTableRecord.ModelSpace), OpenMode.ForWrite)
                    _OID = DB.AttachXref(XrefName, Xname)
                    BRef = New BlockReference(iPnt, _OID)
                    BTR.AppendEntity(BRef)
                    trans.AddNewlyCreatedDBObject(BRef, True)
                End If
                trans.Commit()
            Catch aex As Autodesk.AutoCAD.Runtime.Exception
                MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
            Catch ex As System.Exception
                MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
            Finally
                trans.Dispose()
                DocLock.Dispose()
            End Try
        End Function
        Shared Function AddViewPort(ByRef DB As Database, ByVal VPCentre As Point3d, ByVal ViewCentre As Point3d, ByVal Width As Double, _
        ByVal Height As Double, ByVal Angle As Double, _
        ByVal Scale As String, ByVal Locked As Boolean, ByVal IsMetres As Boolean) As String
            Dim OID As ObjectId
            Dim Trans As Transaction = DB.TransactionManager.StartTransaction()
            Dim DocLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument()
            Dim ThisHandle As String = ""
            Try
                Dim acVP As Viewport = New Viewport
                Dim pCP As New Point3d
                Dim AScale As AnnotationScale = MakeScale(DB, Scale, IsMetres)
                Dim bt As BlockTable = Trans.GetObject(DB.BlockTableId, OpenMode.ForRead)
                Dim btr As BlockTableRecord = Trans.GetObject(bt(BlockTableRecord.PaperSpace), OpenMode.ForWrite)

                Dim RbFrom As ResultBuffer = New ResultBuffer(New TypedValue(5003, 0))
                Dim RbTo As ResultBuffer = New ResultBuffer(New TypedValue(5003, 2))
                Dim ret() As Double = {0, 0, 0}

                acVP.CenterPoint = VPCentre
                acVP.Height = Height
                acVP.Width = Width
                acVP.Locked = Locked
                acVP.ViewDirection = New Vector3d(0, 0, 1)

                acVP.CustomScale = IIf(IsMetres, 1000.0 / CDbl(Scale), 1.0 / CDbl(Scale))
                acedTrans(ViewCentre.ToArray, RbFrom.UnmanagedObject, RbTo.UnmanagedObject, 0, ret)
                'this is the detail provided  by autodesk
                Dim matirx As New Matrix2d
                matirx = Matrix2d.Rotation(-Angle, Point2d.Origin)
                Dim pt As Point2d = New Point2d(ret(0), ret(1))
                pt = pt.TransformBy(matirx)
                'end of detail
                acVP.ViewCenter = pt
                acVP.TwistAngle = -Angle

                OID = btr.AppendEntity(acVP)
                Trans.AddNewlyCreatedDBObject(acVP, True)
                ThisHandle = acVP.Handle.ToString

                acVP = Trans.GetObject(OID, OpenMode.ForWrite, False, True)
                acVP.On = True
                acVP.AnnotationScale = AScale
                Trans.Commit()

            Catch aex As Autodesk.AutoCAD.Runtime.Exception
                MsgBox("AutoCAD Exception (VIEWPORT): " & aex.Message, MsgBoxStyle.Exclamation)
            Catch ex As System.Exception
                MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
            Finally
                Trans.Dispose()
                DocLock.Dispose()
            End Try
            Return ThisHandle
        End Function
        Shared Function XrefExists(ByRef DB As Database, ByVal Name As String) As Boolean
            Dim Doclock As DocumentLock = Application.DocumentManager.MdiActiveDocument.LockDocument
            Dim Trans As Transaction = DB.TransactionManager.StartTransaction
            Dim ExtBT As BlockTable = Trans.GetObject(DB.BlockTableId, OpenMode.ForRead)
            Dim Blocks() As String = {}

            Try
                If ExtBT.Has(Name) Then
                    Dim BTR As BlockTableRecord = Trans.GetObject(ExtBT.Item(Name), OpenMode.ForRead)
                    If BTR.IsFromExternalReference Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Catch aex As Autodesk.AutoCAD.Runtime.Exception
                MsgBox("AutoCAD Exception (XrefExists): " & aex.Message, MsgBoxStyle.Exclamation)
            Catch ex As System.Exception
                MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
            Finally
                Trans.Dispose()
                Doclock.Dispose()
            End Try
        End Function
        Shared Sub DeleteObj(ByRef DB As Database, ByVal Handle As String)
            Dim VPID As ObjectId
            Dim Ln As Long

            Ln = Convert.ToInt64(Handle, 16)
            Dim Hn As Handle = New Handle(Ln)
            VPID = DB.GetObjectId(False, Hn, 0)
            Try
                Dim Trans As Transaction = DB.TransactionManager.StartTransaction
                Using Trans
                    Dim obj As DBObject = Trans.GetObject(VPID, OpenMode.ForWrite)
                    obj.Erase()
                    Trans.Commit()
                End Using
            Catch aex As Autodesk.AutoCAD.Runtime.Exception
                MsgBox("AutoCAD Exception (DeleteOBJ): " & aex.Message, MsgBoxStyle.Exclamation)
            Catch ex As System.Exception
                MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End Sub
        Shared Function MakeScale(ByRef DB As Database, ByVal Scale As Integer, ByVal IsMetres As Boolean) As AnnotationScale
            Dim Desc As String = "1:" & CStr(Scale) + IIf(IsMetres, "m", "mm")
            Dim cm As ObjectContextManager = DB.ObjectContextManager
            Dim occ As ObjectContextCollection = cm.GetContextCollection("ACDB_ANNOTATIONSCALES")
            Dim asc As AnnotationScale = New AnnotationScale

            Try
                asc.Name = Desc
                asc.PaperUnits = 1
                asc.DrawingUnits = Scale
                occ.AddContext(asc)
                Return asc
            Catch ex As System.Exception
                Return occ.GetContext(Desc)
            End Try
        End Function
        Shared Sub MakeView(ByVal ViewName As String, ByVal Centre As Point3d, _
        ByVal Width As Double, ByVal Height As Double, ByVal Angle As Double)
            Dim DB As Database = HostApplicationServices.WorkingDatabase
            Dim trans As Transaction = DB.TransactionManager.StartTransaction()
            Dim Doc As Document = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument
            Dim Ed As Editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor()
            Dim DocLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument()
            Dim VTR As ViewTableRecord
            Dim RbFrom As ResultBuffer = New ResultBuffer(New TypedValue(5003, 2))
            Dim RbTo As ResultBuffer = New ResultBuffer(New TypedValue(5003, 3))
            Dim ret() As Double = {0, 0, 0}

            Try
                Dim VT As ViewTable = trans.GetObject(DB.ViewTableId, OpenMode.ForWrite, True)
                If VT.Has(ViewName) Then
                    VTR = trans.GetObject(VT.Item(ViewName), OpenMode.ForWrite, False)
                Else
                    VTR = New ViewTableRecord
                End If

                acedTrans(Centre.ToArray, RbFrom.UnmanagedObject, RbTo.UnmanagedObject, 0, ret)
                'end of detail
                VTR.CenterPoint = New Point2d(ret(0), ret(1))
                VTR.Target = Centre
                VTR.SetUcsToWorld()
                VTR.Height = Height
                VTR.Width = Width
                VTR.Name = ViewName
                VT.Add(VTR)
                trans.AddNewlyCreatedDBObject(VTR, True)
                trans.Commit()
            Catch aex As Autodesk.AutoCAD.Runtime.Exception
                MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
            Catch ex As System.Exception
                MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
            Finally
                trans.Dispose()
                DocLock.Dispose()
            End Try
        End Sub
        Shared Sub MakeViewADN(ByVal ViewName As String, ByVal Centre As Point3d, _
               ByVal Width As Double, ByVal Height As Double, ByVal Angle As Double)
            Dim DB As Database = HostApplicationServices.WorkingDatabase
            Dim trans As Transaction = DB.TransactionManager.StartTransaction()
            Dim Doc As Document = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument
            Dim Ed As Editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor()
            Dim DocLock As DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument()
            Dim VTR As ViewTableRecord

            Try
                Dim VT As ViewTable = trans.GetObject(DB.ViewTableId, OpenMode.ForWrite, True)
                If VT.Has(ViewName) Then
                    VTR = trans.GetObject(VT.Item(ViewName), OpenMode.ForWrite, False)
                    SetViewValues(VTR, Centre, Angle, Height, Width, ViewName)
                Else
                    VTR = New ViewTableRecord
                    SetViewValues(VTR, Centre, Angle, Height, Width, ViewName)
                    VT.Add(VTR)
                    trans.AddNewlyCreatedDBObject(VTR, True)
                End If
                trans.Commit()

                'Ed.SetCurrentView(VTR)
            Catch aex As Autodesk.AutoCAD.Runtime.Exception
                MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
            Catch ex As System.Exception
                MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
            Finally
                trans.Dispose()
                DocLock.Dispose()
            End Try
        End Sub
        Shared Sub SetViewValues(ByRef VTR As ViewTableRecord, ByVal Centre As Point3d, _
            ByVal Angle As Double, ByVal Height As Double, ByVal Width As Double, _
            ByVal ViewName As String)

            VTR.CenterPoint = Point2d.Origin 'pt
            VTR.Target = Centre
            Dim viewCameraPnt As Point3d = New Point3d(Centre.X, Centre.Y, 1)
            VTR.ViewDirection = VTR.Target.GetVectorTo(viewCameraPnt)
            VTR.ViewTwist = -Angle

            VTR.SetUcsToWorld()
            VTR.Height = Height
            VTR.Width = Width
            VTR.Name = ViewName
        End Sub
        Shared Sub MakeLayer(ByVal Name As String)
            Dim DB As Database = HostApplicationServices.WorkingDatabase
            Dim DC As DocumentCollection = AcadAp.DocumentManager
            Dim Locked As Boolean
            Dim DocLock As DocumentLock

            If DC.IsApplicationContext Then
                DocLock = AcadAp.DocumentManager.MdiActiveDocument.LockDocument
                Locked = True
            End If
            Using trans As Transaction = DB.TransactionManager.StartTransaction
                Dim lt As LayerTable = trans.GetObject(DB.LayerTableId, OpenMode.ForWrite)
                Dim LTR As LayerTableRecord = New LayerTableRecord()
                LTR.Color.FromColorIndex(Autodesk.AutoCAD.Colors.ColorMethod.ByAci, 5)
                LTR.Name = Name
                lt.Add(LTR)
                trans.AddNewlyCreatedDBObject(LTR, True)
                If Locked Then DocLock.Dispose()
                trans.Commit()
            End Using
        End Sub
        Shared Sub LoadBlock(ByVal Name As String)

            Dim A As Assembly = Assembly.GetExecutingAssembly
            Dim resnames() As String = A.GetManifestResourceNames

            Dim istream As Stream = A.GetManifestResourceStream("Sheets.des-cont_pave.dwg")
            Dim BW As New BinaryWriter(istream)


            'Dim DB1 As Database = CType(Image.fromstream(istream), Database)



            Dim DB As New Database(False, False)


            'DB.ReadDwgFile(My.Resources.des_cont_pave, False, Nothing)


        End Sub
    '<DllImport("acad.exe", CallingConvention:=CallingConvention.Cdecl, EntryPoint:="acedTrans")>
    'Private Shared Function acedTrans(ByVal point As Double(), ByVal fromRB As IntPtr, ByVal toRb As IntPtr, ByVal disp As Integer, ByVal result As Double()) As Integer

    'End Function

    ' AutoCAD 2027 exports global legacy ARX functions via accore.dll
    <DllImport("accore.dll", CallingConvention:=CallingConvention.Cdecl, EntryPoint:="acedTrans")>
    Private Shared Function acedTrans(
        ByVal pt As Double(),          ' 3-element array (ads_point)
        ByVal fromSys As IntPtr,       ' Handle to the source resbuf
        ByVal toSys As IntPtr,         ' Handle to the destination resbuf
        ByVal disp As Integer,         ' 0 = Point, 1 = Vector
        ByVal result As Double()       ' 3-element array to receive the output
    ) As Integer
    End Function

End Class
