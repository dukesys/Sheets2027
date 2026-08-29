Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Geometry

Public Class frmNewSheet
    Dim IPnt As Point3d
    Dim IsInitialised As Boolean
    Dim _NewSheet As clsSheet
    Dim _ActiveSheetSet As clsPlanSet

    Public Property ActiveSheetSet() As clsPlanSet
        Get
            Return _ActiveSheetSet
        End Get
        Set(ByVal PlanSet As clsPlanSet)
            _ActiveSheetSet = PlanSet
            _NewSheet = New clsSheet(PlanSet, Prototype)
            _NewSheet.Name = tbName.Text
            tbML.Text = _NewSheet.PlanSet.Prototype.ML
            tbMR.Text = _NewSheet.PlanSet.Prototype.MR
            tbMT.Text = _NewSheet.PlanSet.Prototype.MT
            tbMB.Text = _NewSheet.PlanSet.Prototype.MB
            tbName.Text = _ActiveSheetSet.NextName
        End Set
    End Property
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Public ReadOnly Property NewSheet() As clsSheet
        Get
            Return _NewSheet
        End Get
    End Property
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btPick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPick.Click
        Dim SelPt As PromptPointResult
        Dim myJig As New clsJigSheet(_NewSheet)

        'insertion point ip
        If cbIP.Checked Then
            myJig.PromptCounter = 0
            myJig.Angle = clsGeoUtils.ac2wcb(clsGeoUtils.DTR(tbAngle.Text))
            SelPt = myJig.startJig()
            If SelPt IsNot Nothing Then
                IPnt = SelPt.Value
                tbX.Text = IPnt.X.ToString("0.000")
                tbY.Text = IPnt.Y.ToString("0.000")
                _NewSheet.IP = IPnt
            End If
        End If
        'rotation angle
        If cbAngle.Checked Then
            myJig.PromptCounter = 1
            'myjig.point=
            SelPt = myJig.startJig
            If SelPt IsNot Nothing Then
                tbAngle.Text = CInt(clsGeoUtils.RTD(clsGeoUtils.wcb2ac(myJig.Angle)))
                _NewSheet.Angle = myJig.Angle
            End If
        End If

    End Sub
    Private Sub cbIP_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbIP.CheckedChanged

        lbX.Enabled = cbIP.Checked
        tbX.Enabled = cbIP.Checked
        lbY.Enabled = cbIP.Checked
        tbY.Enabled = cbIP.Checked
        btPick.Enabled = cbIP.Checked
        lbAngle.Enabled = cbIP.Checked
        tbAngle.Enabled = cbIP.Checked
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        tbX.Text = 0
        tbY.Text = 0
        tbAngle.Text = 0
        IsInitialised = True
    End Sub
    Private Sub tbMB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMB.TextChanged
        Dim Temp As Double

        If IsInitialised Then
            Temp = Val(tbMB.Text)
            If IsNumeric(tbMB.Text) Then
                _NewSheet.MarginBottom = Temp
            End If
        End If
    End Sub
    Private Sub tbML_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbML.TextChanged
        Dim Temp As Double

        If IsInitialised Then
            Temp = Val(tbML.Text)
            If IsNumeric(tbML.Text) Then
                _NewSheet.MarginLeft = Temp
            End If
        End If
    End Sub
    Private Sub tbMR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMR.TextChanged
        Dim Temp As Double

        If IsInitialised Then
            Temp = Val(tbMR.Text)
            If IsNumeric(tbMR.Text) Then
                _NewSheet.MarginRight = Temp
            End If
        End If
    End Sub
    Private Sub tbMT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMT.TextChanged
        Dim Temp As Double

        If IsInitialised Then
            Temp = Val(tbMT.Text)
            If IsNumeric(tbMT.Text) Then
                _NewSheet.MarginTop = Temp
            End If
        End If
    End Sub

    Private Sub tbName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbName.TextChanged

        _NewSheet.Name = tbName.Text
    End Sub

    Private Sub tbAngle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbAngle.TextChanged
        Dim Temp As Double

        If IsInitialised Then
            Temp = Val(tbAngle.Text)
            Temp = clsGeoUtils.DTR(Temp)
            Temp = clsGeoUtils.ac2wcb(Temp)
            _NewSheet.Angle = Temp
            If IsNumeric(tbAngle.Text) Then
                _NewSheet.Angle = Temp
            End If
        End If
    End Sub
End Class
