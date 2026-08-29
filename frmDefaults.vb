Public Class frmDefaults
    Dim IsInitialised As Boolean
    Dim OldProt As clsPlanSet.DwgSheet

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        Prototype = OldProt
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        OldProt = Prototype
        Prototype = New clsPlanSet.DwgSheet
        With Prototype
            .Height = 594
            .MB = 100
            .ML = 20
            .MR = 20
            .MT = 20
            .Width = 841
            .Name = "A1"
        End With

        Dim T(SheetSizes.Count - 1) As String
        SheetSizes.Keys.CopyTo(T, 0)
        cbSize.Items.AddRange(T)
        cbSize.SelectedIndex = 0

        IsInitialised = True
    End Sub

    Private Sub cbSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSize.SelectedIndexChanged

        If IsInitialised Then
            Prototype = SheetSizes.Item(cbSize.Text)
            With Me
                .tbMB.Text = Prototype.MB
                .tbMT.Text = Prototype.MT
                .tbML.Text = Prototype.ML
                .tbMR.Text = Prototype.MR
            End With
        End If
    End Sub
    Private Sub tbMB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMB.TextChanged

        If IsInitialised Then
            If IsNumeric(tbMB.Text) Then
                Prototype.MB = Val(tbMB.Text)
            End If
        End If
    End Sub
    Private Sub tbML_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbML.TextChanged

        If IsInitialised Then
            If IsNumeric(tbML.Text) Then
                Prototype.ML = Val(tbML.Text)
            End If
        End If
    End Sub
    Private Sub tbMR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMR.TextChanged

        If IsInitialised Then
            If IsNumeric(tbMR.Text) Then
                Prototype.MR = Val(tbMR.Text)
            End If
        End If
    End Sub
    Private Sub tbMT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMT.TextChanged

        If IsInitialised Then
            If IsNumeric(tbMT.Text) Then
                Prototype.MT = Val(tbMT.Text)
            End If
        End If
    End Sub
End Class
