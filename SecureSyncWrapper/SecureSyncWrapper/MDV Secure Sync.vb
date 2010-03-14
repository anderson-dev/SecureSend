Public Class sendForm

    Private Sub loginButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginButton.Click
        '/* begin auto login process()

        '//Debug module
        Dim htmlElements As HtmlElementCollection
        htmlElements = WebBrowser1.Document.GetElementsByTagName("input")
        Debug.WriteLine("List of HTML Elements used for Input:")
        For i As Integer = 0 To htmlElements.Count - 1
            Debug.WriteLine(htmlElements(i).Id.ToString)
        Next
        Debug.WriteLine("End List")

        '//fill in username

        If Not WebBrowser1.Document.GetElementById("txtUserName") Is Nothing Then
            WebBrowser1.Document.All("txtUserName").SetAttribute("value", "aflorence")
        End If

        '//fill in password

        If Not WebBrowser1.Document.GetElementById("txtPassword") Is Nothing Then
            WebBrowser1.Document.All("txtPassword").SetAttribute("value", "SyncUser2008")
        End If

        '//press submit button
        If Not WebBrowser1.Document.GetElementById("butSubmit") Is Nothing Then
            WebBrowser1.Document.All("butSubmit").InvokeMember("click")
        End If
        '*/ end auto login process
    End Sub

    Private Sub hideBrowserCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hideBrowserCheckBox.CheckedChanged
        WebBrowser1.Visible = Not WebBrowser1.Visible
    End Sub
End Class
