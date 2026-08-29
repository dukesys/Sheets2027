Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Geometry


Public Class clsJigSheet
        Inherits DrawJig
        Dim myPr As PromptPointResult
        Dim BasePt As Point3d
        Dim _p1 As Point3d  'BL
        Dim _p2 As Point3d  'BR
        Dim _p3 As Point3d  'TR
        Dim _p4 As Point3d  'TL

        Dim _p1f As Point3d  'BL
        Dim _p2f As Point3d  'BR
        Dim _p3f As Point3d  'TR
        Dim _p4f As Point3d  'TL

        Dim _sheet As clsSheet
        Dim _angle As Double 'stored in AutoCAD radians
        Dim vec1 As Vector3d
        Dim vec2 As Vector3d
        Dim vec3 As Vector3d
        Dim vec4 As Vector3d
        Dim Dist, _Offset As Double
        Dim _Centre As Point3d
        Dim Points As New Point3dCollection
        Dim _PromptCounter As Integer
        Dim LastPt As Point3d
        Dim SF As Double

        Public Property Point() As Point3d
            Get
                Return _p1
            End Get
            Set(ByVal value As Point3d)
                _p1 = value
                BasePt = value
            End Set
        End Property
        Public Property PromptCounter() As Integer
            Get
                Return _PromptCounter
            End Get
            Set(ByVal value As Integer)
                _PromptCounter = value
            End Set
        End Property
        Public Sub New(ByVal sheet As clsSheet)

            _sheet = sheet
            _angle = Angle
            SF = _sheet.PlanSet.ScaleFactor
        End Sub
        Public Property Angle() As Double
            Get
                Return _angle
            End Get
            Set(ByVal value As Double)
                _angle = value
            End Set
        End Property
        Function startJig() As PromptPointResult
            Dim ed As Editor = Application.DocumentManager.MdiActiveDocument.Editor

            myPr = ed.Drag(Me)
            Do
                Try
                    Select Case myPr.Status
                        Case PromptStatus.OK
                            Return myPr
                            Exit Do
                        Case PromptStatus.Cancel, PromptStatus.Error
                            Return Nothing
                    End Select
                Catch ex As Exception
                    MsgBox("Exception" & ex.Message)
                End Try
            Loop While myPr.Status <> PromptStatus.Cancel
            Return myPr
        End Function
        Protected Overrides Function Sampler(ByVal prompts As Autodesk.AutoCAD.EditorInput.JigPrompts) As Autodesk.AutoCAD.EditorInput.SamplerStatus

            Try
                Dim JigOpts As New JigPromptPointOptions

                If PromptCounter = 0 Then
                    JigOpts.Message = vbCrLf & "Select Point(Bottom Left Corner): "
                    JigOpts.UserInputControls = UserInputControls.NoZeroResponseAccepted
                    myPr = prompts.AcquirePoint(JigOpts)
                    If LastPt = myPr.Value Then
                        Return SamplerStatus.NoChange
                    Else
                        BasePt = myPr.Value
                        'calculate the new point
                        Dim X, Y As Double
                        clsGeoUtils.lgm026(BasePt.X, BasePt.Y, clsGeoUtils.ac2wcb(_angle), _sheet.VPWidth, X, Y)
                        _p2 = New Point3d(X, Y, 0)
                        _p1 = BasePt
                        LastPt = myPr.Value
                    End If
                ElseIf PromptCounter = 1 Then
                    JigOpts.Message = vbCrLf & "Select Point(Bottom Right Corner): "
                    JigOpts.UserInputControls = UserInputControls.NoZeroResponseAccepted
                    myPr = prompts.AcquirePoint(JigOpts)
                    If myPr.Value.IsEqualTo(LastPt) Then
                        Return SamplerStatus.NoChange
                    Else
                        Dim WCB, Dist As Double
                        LastPt = myPr.Value
                        clsGeoUtils.lgm016(_p1.X, _p1.Y, LastPt.X, LastPt.Y, WCB, Dist)
                        _angle = clsGeoUtils.wcb2ac(WCB)
                        Dim X, Y As Double
                        clsGeoUtils.lgm026(BasePt.X, BasePt.Y, WCB, _sheet.VPWidth, X, Y)
                        _p2 = New Point3d(X, Y, 0)
                    End If
                    Return SamplerStatus.OK
                End If

            Catch ex As Exception
                MsgBox("Jiggy Exception" & ex.Message)
            End Try
        End Function
        Protected Overrides Function WorldDraw(ByVal draw As Autodesk.AutoCAD.GraphicsInterface.WorldDraw) As Boolean
            Dim SE As Autodesk.AutoCAD.GraphicsInterface.SubEntityTraits = draw.SubEntityTraits

            Try
                If PromptCounter = 0 Then
                    'draw the VP Frame
                    SE.Color = 6
                    Dim myLine As New Line(BasePt, _p2)
                    myLine.WorldDraw(draw)
                    vec1 = New Vector3d(_p2.X - BasePt.X, _p2.Y - BasePt.Y, 0)
                    Dim vec2 As Vector3d = vec1.GetPerpendicularVector.GetNormal
                    _p3 = New Point3d(_p2.Add(vec2.MultiplyBy(_sheet.VPHeight)).ToArray)
                    myLine = New Line(_p2, _p3)
                    myLine.WorldDraw(draw)
                    _p4 = New Point3d(BasePt.Add(vec2.MultiplyBy(_sheet.VPHeight)).ToArray)
                    myLine = New Line(_p3, _p4)
                    myLine.WorldDraw(draw)
                    myLine = New Line(_p4, BasePt)
                    myLine.WorldDraw(draw)
                    myLine = New Line(_p1, _p3)
                    myLine.WorldDraw(draw)
                    myLine = New Line(_p2, _p4)
                    myLine.WorldDraw(draw)

                    'draw the Sheet frame
                    _p1f = Transform(_angle, New Point3d(BasePt.X - _sheet.MarginLeft, _
                        BasePt.Y - _sheet.MarginBottom, 0), BasePt)
                    _p2f = Transform(_angle, New Point3d(_p2.X + _sheet.MarginRight, _
                        _p2.Y - _sheet.MarginBottom, 0), _p2)
                    _p3f = Transform(_angle, New Point3d(_p3.X + _sheet.MarginRight, _
                        _p3.Y + _sheet.MarginTop, 0), _p3)
                    _p4f = Transform(_angle, New Point3d(_p4.X - _sheet.MarginLeft, _
                        _p4.Y + _sheet.MarginTop, 0), _p4)

                    SE.Color = 5
                    myLine = New Line(_p1f, _p2f)
                    myLine.WorldDraw(draw)
                    myLine = New Line(_p2f, _p3f)
                    myLine.WorldDraw(draw)
                    myLine = New Line(_p3f, _p4f)
                    myLine.WorldDraw(draw)
                    myLine = New Line(_p4f, _p1f)
                    myLine.WorldDraw(draw)
                ElseIf PromptCounter = 1 Then
                    'draw the VP Frame
                    SE.Color = 6
                    Dim myLine As New Line(BasePt, _p2)
                    myLine.WorldDraw(draw)
                    vec1 = New Vector3d(_p2.X - BasePt.X, _p2.Y - BasePt.Y, 0)
                    Dim vec2 As Vector3d = vec1.GetPerpendicularVector.GetNormal
                    _p3 = New Point3d(_p2.Add(vec2.MultiplyBy(_sheet.VPHeight)).ToArray)
                    myLine = New Line(_p2, _p3)
                    myLine.WorldDraw(draw)
                    _p4 = New Point3d(BasePt.Add(vec2.MultiplyBy(_sheet.VPHeight)).ToArray)
                    myLine = New Line(_p3, _p4)
                    myLine.WorldDraw(draw)
                    myLine = New Line(_p4, BasePt)
                    myLine.WorldDraw(draw)
                    myLine = New Line(_p1, _p3)
                    myLine.WorldDraw(draw)
                    myLine = New Line(_p2, _p4)
                    myLine.WorldDraw(draw)
                    'draw the Sheet frame
                    _p1f = Transform(_angle, New Point3d(BasePt.X - _sheet.MarginLeft, _
                        BasePt.Y - _sheet.MarginBottom, 0), BasePt)
                    _p2f = Transform(_angle, New Point3d(_p2.X + _sheet.MarginRight, _
                        _p2.Y - _sheet.MarginBottom, 0), _p2)
                    _p3f = Transform(_angle, New Point3d(_p3.X + _sheet.MarginRight, _
                        _p3.Y + _sheet.MarginTop, 0), _p3)
                    _p4f = Transform(_angle, New Point3d(_p4.X - _sheet.MarginLeft, _
                        _p4.Y + _sheet.MarginTop, 0), _p4)

                    SE.Color = 5
                    myLine = New Line(_p1f, _p2f)
                    myLine.WorldDraw(draw)
                    myLine = New Line(_p2f, _p3f)
                    myLine.WorldDraw(draw)
                    myLine = New Line(_p3f, _p4f)
                    myLine.WorldDraw(draw)
                    myLine = New Line(_p4f, _p1f)
                    myLine.WorldDraw(draw)

                End If
            Catch aex As Autodesk.AutoCAD.Runtime.Exception
                MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
            Catch ex As System.Exception
                MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End Function
        Function Transform(ByVal Angle As Double, ByVal Point As Point3d, ByVal RotationPoint As Point3d) As Point3d
            Dim matrix As New Matrix2d
            Dim TPnt As Point2d

            matrix = Matrix2d.Rotation(Angle, New Point2d(RotationPoint.X, RotationPoint.Y))
            Dim pt As Point2d = New Point2d(Point.X, Point.Y)
            TPnt = pt.TransformBy(matrix)
            Return New Point3d(TPnt.X, TPnt.Y, 0)
        End Function
    End Class
