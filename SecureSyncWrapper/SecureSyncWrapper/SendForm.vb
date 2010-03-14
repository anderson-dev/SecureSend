Imports System.IO

Public Class SendForm

    Private statusCounter As Integer

    Private Sub loginButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginButton.Click

        statusCounter = 0
        loginButton.Enabled = False

        AutoNavigatorControl.AutoLogin("http://www.securesync.com", _
        "txtUserName", usernameTextBox.Text, "txtPassword", passwordTextBox.Text, _
        "butSubmit", "https://www3.securesync.com/SSIEMain.aspx")

        AddHandler AutoNavigatorControl.Navigating, AddressOf UpdateAutoNavigatorStatus

    End Sub

    Private Sub UpdateAutoNavigatorStatus() Handles AutoNavigatorControl.LoggingIn

        Select Case statusCounter
            Case 0 'programmer did not link to loginButton
                With statusLabel
                    .Text = "Loading..."
                    .Visible = True
                    statusCounter += 1
                End With
            Case 1
                With statusLabel
                    .Text = "Logging In..."
                    .Visible = True
                    statusCounter += 1
                End With
            Case Else
                With statusLabel
                    .Text = "Loading..."
                    .Visible = True
                    statusCounter += 1
                End With
        End Select

    End Sub

    Private Sub UpdateAutoNavigatorStatus(ByVal sender As Object, ByVal e As Windows.Forms.WebBrowserNavigatingEventArgs)
        UpdateAutoNavigatorStatus()
        ShowProgressBar()

    End Sub

    Private Sub ShowProgressBar()
        ProgressBar.Visible = True
    End Sub

    Private Sub UpdateProgressBar(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles AutoNavigatorControl.ProgressChanged
        ' Check if e.MaximumProgress is 0 or 
        ' if e.MaximumProgress is less than e.CurrentProgress 
        If e.MaximumProgress <> 0 And _
         e.MaximumProgress >= e.CurrentProgress Then

            ProgressBar.Value = Convert.ToInt32( _
                      100 * e.CurrentProgress / e.MaximumProgress)
        End If

    End Sub

    Private Sub HideProgressBar(ByVal sender As Object, ByVal e As Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles AutoNavigatorControl.DocumentCompleted
        ProgressBar.Visible = False
        statusLabel.Visible = False
    End Sub

    Private Sub loginSuccessfullCheck(ByVal wasLoginSuccessful As Boolean) Handles AutoNavigatorControl.LoggedIn

        If wasLoginSuccessful = True Then
            MessageBox.Show("Login Successful")

        Else
            loginButton.Enabled = True
            AutoNavigatorForm.ShowDialog()
        End If

    End Sub

    Private Sub showBrowserCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showBrowserCheckBox.CheckedChanged
        If showBrowserCheckBox.Checked = True Then
            Me.Height = 309
        Else
            Me.Height = 167
        End If
    End Sub

End Class
