Public Class frmRenumberSheets
    Dim _PlanSet As clsPlanSet

    Public Property Planset() As clsPlanSet
        Get
            Return _PlanSet
        End Get
        Set(ByVal value As clsPlanSet)
            _PlanSet = value
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

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For Each KVP As KeyValuePair(Of String, clsPlanSet) In SheetColl.Sets
            cbPlanSets.Items.Add(KVP.Key)
        Next
    End Sub

    Private Sub cbPlanSets_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPlanSets.SelectedIndexChanged

        _PlanSet = SheetColl.Item(cbPlanSets.Text)
    End Sub
End Class
