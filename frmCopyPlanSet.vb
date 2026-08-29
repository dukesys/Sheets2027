Public Class frmCopyPlanSet
    Dim _NewPlanSet As String
    Dim _OrigPlanSet As clsPlanSet

    Public ReadOnly Property OrigPlanSet() As clsPlanSet
        Get
            Return _OrigPlanSet
        End Get
    End Property

    Public ReadOnly Property NewPlanSet() As String
        Get
            Return _NewPlanSet
        End Get
    End Property
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For Each KVP As KeyValuePair(Of String, clsPlanSet) In SheetColl.Sets
            cbPlanSets.Items.Add(KVP.Key)
        Next
    End Sub

    Private Sub tbPlanSet_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPlanSet.TextChanged

        _NewPlanSet = tbPlanSet.Text
    End Sub

    Private Sub cbPlanSets_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPlanSets.SelectedIndexChanged
        _OrigPlanSet = SheetColl.Item(cbPlanSets.Text)
    End Sub
End Class
