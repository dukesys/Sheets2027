Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Geometry

Public Class frmModifySheet
    Dim _Sheet As clsSheet
    Dim IsInitialised As Boolean
    Dim _ActiveSheetSet As clsPlanSet
    Dim IPnt As Point3d

    Public Property ActiveSheetSet() As clsPlanSet
        Get
            Return _ActiveSheetSet
        End Get
        Set(ByVal PlanSet As clsPlanSet)
            _ActiveSheetSet = PlanSet
        End Set
    End Property
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Property Sheet() As clsSheet
        Get
            Return _Sheet
        End Get
        Set(ByVal value As clsSheet)
            IsInitialised = False
            _Sheet = value
            tbAngle.Text = clsGeoUtils.RTD(clsGeoUtils.wcb2ac(_Sheet.Angle))
            tbML.Text = _Sheet.MarginLeft / _ActiveSheetSet.ScaleFactor
            tbMR.Text = _Sheet.MarginRight / _ActiveSheetSet.ScaleFactor
            tbMT.Text = _Sheet.MarginTop / _ActiveSheetSet.ScaleFactor
            tbMB.Text = _Sheet.MarginBottom / _ActiveSheetSet.ScaleFactor
            tbX.Text = _Sheet.IP.X
            tbY.Text = _Sheet.IP.Y
            Me.Text = "Modify Sheet [" + _Sheet.Name + "]"
            IsInitialised = True
        End Set
    End Property
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        IsInitialised = True
    End Sub
    Private Sub tbML_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbML.TextChanged
        Dim Temp As Double

        If IsInitialised Then
            If IsNumeric(tbML.Text) Then
                Temp = Val(tbML.Text)
                _Sheet.MarginLeft = Temp
            End If
        End If
    End Sub
    Private Sub tbMB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMB.TextChanged
        Dim Temp As Double

        If IsInitialised Then
            If IsNumeric(tbMB.Text) Then
                Temp = Val(tbMB.Text)
                _Sheet.MarginBottom = Temp
            End If
        End If
    End Sub
    Private Sub tbMR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMR.TextChanged
        Dim Temp As Double

        If IsInitialised Then
            If IsNumeric(tbMR.Text) Then
                Temp = Val(tbMR.Text)
                _Sheet.MarginRight = Temp
            End If
        End If
    End Sub
    Private Sub tbMT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMT.TextChanged
        Dim Temp As Double

        If IsInitialised Then
            If IsNumeric(tbMT.Text) Then
                Temp = Val(tbMT.Text)
                _Sheet.MarginTop = Temp
            End If
        End If
    End Sub
    Private Sub tbAngle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbAngle.TextChanged
        Dim Temp As Double

        If IsInitialised Then
            If IsNumeric(tbAngle.Text) Then
                Temp = Val(tbAngle.Text)
                Temp = clsGeoUtils.DTR(Temp)
                Temp = clsGeoUtils.ac2wcb(Temp)
                _Sheet.AngleEvent = Temp
            End If
        End If
    End Sub
    Private Sub tbX_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbX.TextChanged
        Dim Temp As Double
        Dim P1 As point3d

        If IsInitialised Then
            If IsNumeric(tbX.Text) Then
                Temp = Val(tbX.Text)
                P1 = New Point3d(Temp, _Sheet.IP.Y, 0)
                _Sheet.IPEvent = P1
            End If
        End If
    End Sub
    Private Sub tbY_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbY.TextChanged
        Dim Temp As Double
        Dim P1 As Point3d

        If IsInitialised Then
            If IsNumeric(tbY.Text) Then
                Temp = Val(tbY.Text)
                P1 = New Point3d(_Sheet.IP.X, Temp, 0)
                _Sheet.IPEvent = P1
            End If
        End If
    End Sub

    Private Sub btPick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPick.Click
        Dim SelPt As PromptPointResult
        Dim myJig As New clsJigSheet(_Sheet)

        'insertion point ip
        If cbIP.Checked Then
            myJig.PromptCounter = 0
            myJig.Angle = clsGeoUtils.ac2wcb(clsGeoUtils.DTR(tbAngle.Text))
            SelPt = myJig.startJig()
            If SelPt IsNot Nothing Then
                IPnt = SelPt.Value
                tbX.Text = IPnt.X.ToString("0.000")
                tbY.Text = IPnt.Y.ToString("0.000")
                _Sheet.Initiator = True
                _Sheet.IPEvent = IPnt
            End If
        End If
        'rotation angle
        If cbAngle.Checked Then
            myJig.PromptCounter = 1
            myJig.Point = _Sheet.IP
            SelPt = myJig.startJig
            If SelPt IsNot Nothing Then
                tbAngle.Text = CInt(clsGeoUtils.RTD(clsGeoUtils.ac2wcb(myJig.Angle)))
                _Sheet.Angle = myJig.Angle
            End If
        End If

    End Sub
End Class
