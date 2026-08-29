
Module mdlGlobal
        Public SheetSizes As New Dictionary(Of String, clsPlanSet.DwgSheet)
        Public Const ZERTOL As Double = 0.000001
        Public Const CVGTOL As Double = 0.00001
        Public Const INFIN As Double = 999999.9
        Public Const ZERO As Double = 0.0#
        Public Const PI As Double = System.Math.PI
        Public Const HPI As Double = System.Math.PI * 0.5
        Public Const TPI As Double = System.Math.PI * 2.0

        Public Const APPID As String = "PROJECTSET"
        Public WithEvents SheetColl As New clsProjectSet(APPID)
        Public Xrec As clsXRecUtils
        Public WithEvents PSet As Autodesk.AutoCAD.Windows.PaletteSet

        Public Prototype As clsPlanSet.DwgSheet
    End Module
