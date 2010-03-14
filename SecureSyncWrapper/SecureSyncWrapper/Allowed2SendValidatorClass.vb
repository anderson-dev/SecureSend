Public Class Allowed2SendValidatorClass
    Public Event OkToSend(ByVal okOrNot As Boolean)

    Public Sub Validate()

        ''/* Debug Module
        'RaiseEvent OkToSend(True)
        ''*/ End Debug Module

        If Date.Now.DayOfWeek = DayOfWeek.Saturday Or Date.Now.DayOfWeek = DayOfWeek.Sunday Then
            RaiseEvent OkToSend(False)
        ElseIf Date.Now.DayOfWeek = DayOfWeek.Friday And Date.Now.Hour >= 15 Then
            RaiseEvent OkToSend(False)
        Else
            RaiseEvent OkToSend(True)
        End If
    End Sub
End Class
