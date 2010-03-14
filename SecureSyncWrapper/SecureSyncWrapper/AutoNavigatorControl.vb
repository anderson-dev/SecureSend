Public Class AutoNavigatorControl

    Protected Structure LoginStruct
        Dim usernameHTMLelementID As String
        Dim username As String
        Dim userpassHTMLelementID As String
        Dim userpass As String
        Dim submitButtonHTMLelementID As String
    End Structure

    Protected loginInfo As LoginStruct

    Public Event LoggingIn()
    Public Event LoggedIn(ByVal wasLoginSuccessful As Boolean)
    Protected successfullURL As String

    Public Sub AutoLogin(ByVal loginURL As String, ByVal usernameHTMLelementID As String, _
    ByVal username As String, ByVal userpassHTMLelementID As String, _
    ByVal userpass As String, ByVal submitButtonHTMLelementID As String, ByVal loginSuccessfullURL As String)
        With Me
            successfullURL = loginSuccessfullURL
            'store all login credentials
            loginInfo.usernameHTMLelementID = usernameHTMLelementID
            loginInfo.username = username
            loginInfo.userpassHTMLelementID = userpassHTMLelementID
            loginInfo.userpass = userpass
            loginInfo.submitButtonHTMLelementID = submitButtonHTMLelementID

            '/* begin auto login process()
            RaiseEvent LoggingIn()

            '//navigate to the page
            .Navigate(loginURL)
            '//queue for FormFill
            AddHandler .DocumentCompleted, AddressOf FormFill

            '*/ end auto login process
        End With
    End Sub

    Protected Sub FormFill(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        With Me
            '//fill in username
            Try

                .Document.All(loginInfo.usernameHTMLelementID).SetAttribute("value", loginInfo.username)

                '//fill in password

                .Document.All(loginInfo.userpassHTMLelementID).SetAttribute("value", loginInfo.userpass)

                '//press submit button
                .Document.All(loginInfo.submitButtonHTMLelementID).InvokeMember("click")

                'unlink from DocumentCompleted event
                RemoveHandler .DocumentCompleted, AddressOf FormFill

                'queue LoginCheck()
                AddHandler .DocumentCompleted, AddressOf LoginCheck
            Catch

            End Try

        End With

    End Sub

    Protected Sub LoginCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)

        With Me
            Debug.WriteLine(.Url.ToString)
            If .Url.ToString() = successfullURL Then
                RaiseEvent LoggedIn(True)
            Else 'successfulLoginUrl is not equal to current URL
                RaiseEvent LoggedIn(False)
            End If

            'unlink from DocumentCompleted Event
            RemoveHandler .DocumentCompleted, AddressOf LoginCheck
        End With
    End Sub

    Public Property ListBoxSelectedIndex(ByVal ListBoxHTMLelementID As String) As Integer
        Get
            With Me.Document

                Dim listElement As HtmlElement = .GetElementById(ListBoxHTMLelementID)
                Dim optionElements As HtmlElementCollection = listElement.GetElementsByTagName("option")

                For counter As Integer = 0 To optionElements.Count - 1
                    If optionElements(counter).GetAttribute("selected") = "True" Then
                        Return counter
                    End If
                Next

            End With
        End Get
        Set(ByVal SelectedIndex As Integer)
            With Me.Document

                Dim listElement As HtmlElement = .GetElementById(ListBoxHTMLelementID)
                Dim optionElements As HtmlElementCollection = listElement.GetElementsByTagName("option")

                For counter As Integer = 0 To optionElements.Count - 1
                    optionElements(counter).SetAttribute("selected", "")
                Next

                'select the intended option from the listbox
                optionElements(SelectedIndex).SetAttribute("selected", "True")

            End With
        End Set
    End Property
    Public Property ListBoxSelectedItem(ByVal ListBoxHTMLelementID As String) As String

        Get
            With Me.Document

                Dim listElement As HtmlElement = .GetElementById(ListBoxHTMLelementID)
                Dim optionElements As HtmlElementCollection = listElement.GetElementsByTagName("option")
                Dim item(optionElements.Count - 1) As String
                Dim SelectedItem As String = ""

                For counter As Integer = 0 To optionElements.Count - 1
                    item(counter) = optionElements(counter).InnerText
                Next

                For counter As Integer = 0 To optionElements.Count - 1
                    If optionElements(counter).GetAttribute("selected") = "True" Then
                        SelectedItem = item(counter)
                    End If
                Next

                Return SelectedItem
            End With
        End Get
        Set(ByVal SelectedItem As String)
            With Me.Document

                Dim listElement As HtmlElement = .GetElementById(ListBoxHTMLelementID)
                Dim optionElements As HtmlElementCollection = listElement.GetElementsByTagName("option")
                Dim item(optionElements.Count - 1) As String

                For counter As Integer = 0 To optionElements.Count - 1
                    item(counter) = optionElements(counter).InnerText
                    optionElements(counter).SetAttribute("selected", "")
                Next

                'determine which item to select in listbox
                For counter As Integer = 0 To item.Length - 1
                    If SelectedItem = item(counter) Then
                        optionElements(counter).SetAttribute("selected", "True")
                    End If
                Next

            End With
        End Set
    End Property
End Class
