Public Class AutoLoginNotificationClass
    Public Event SuccessfullLogin()

    Public Sub RaiseSuccessfullLoginEvent()
        RaiseEvent SuccessfullLogin()
    End Sub
End Class
