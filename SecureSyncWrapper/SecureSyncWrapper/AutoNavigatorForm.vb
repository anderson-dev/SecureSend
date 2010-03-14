Public Class AutoNavigatorForm

    Private Sub AutoNavigatorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AutoNavigatorControl.Url = SendForm.AutoNavigatorControl.Url
    End Sub

End Class