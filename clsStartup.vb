Imports Autodesk.AutoCAD.Runtime

<Assembly: ExtensionApplication(GetType(clsStartUp))> 
Public Class clsStartUp
    Implements IExtensionApplication
    Dim MyForm As frmSheetCentrePalette


    Public Sub Initialize() Implements Autodesk.AutoCAD.Runtime.IExtensionApplication.Initialize

        Xrec = New clsXRecUtils(APPID)


        PSet = New Autodesk.AutoCAD.Windows.PaletteSet("Drawing Sheet Layout")
        PSet.Style = Autodesk.AutoCAD.Windows.PaletteSetStyles.ShowPropertiesMenu Or _
            Autodesk.AutoCAD.Windows.PaletteSetStyles.ShowAutoHideButton Or _
            Autodesk.AutoCAD.Windows.PaletteSetStyles.ShowCloseButton
        PSet.MinimumSize = New System.Drawing.Size(320, 670)
        'main form
        MyForm = New frmSheetCentrePalette()
        PSet.Add("Drawing Sheet Layout", MyForm)

        PSet.Visible = True
        PSet.DockEnabled = Autodesk.AutoCAD.Windows.DockSides.None
        PSet.Dock = Autodesk.AutoCAD.Windows.DockSides.None
        PSet.AutoRollUp = False
    End Sub

    Public Sub Terminate() Implements Autodesk.AutoCAD.Runtime.IExtensionApplication.Terminate
        MsgBox("exiting Drawing sheet layout")
    End Sub
End Class
