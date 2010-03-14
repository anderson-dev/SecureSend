Imports System.ComponentModel

<ProvideProperty("FillMethodName", GetType(IComponent)), ProvideProperty("FillMethodType", GetType(IComponent)), _
ProvideProperty("FillMethodParameters", GetType(IComponent))> _
Public Class FillMethodInfoProvider
    Inherits Component
    Implements IExtenderProvider

    Protected fillMethodNames As New Hashtable()
    Protected fillMethodTypes As New Hashtable()
    Protected fillMethodParameters As New Hashtable()

    Public Function CanExtend(ByVal extendee As Object) As Boolean Implements IExtenderProvider.CanExtend

        If TypeOf extendee Is ComboBox Then
            Return True
        ElseIf TypeOf extendee Is ListBox Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetFillMethodName(ByVal o As Object) As String
        Dim returnString As String = ""

        If fillMethodNames(o) IsNot Nothing Then
            returnString = fillMethodNames(o).ToString()
        End If

        Return returnString

    End Function

    Public Sub SetFillMethodName(ByVal o As Object, ByVal value As String)

        If value <> "" Then
            fillMethodNames(o) = value
        Else
            fillMethodNames.Remove(o)
        End If
    End Sub

    Public Function GetFillMethodType(ByVal o As Object) As String
        Dim returnString As String = ""

        If fillMethodTypes(o) IsNot Nothing Then
            returnString = fillMethodTypes(o).ToString()
        End If

        Return returnString
    End Function

    Public Sub SetFillMethodType(ByVal o As Object, ByVal value As String)

        If value <> "" Then
            fillMethodNames(o) = value
        Else
            fillMethodNames.Remove(o)
        End If
    End Sub


    Public Function GetFillMethodParameters(ByVal o As Object) As String
        Dim returnString As String = ""

        If fillMethodParameters(o) IsNot Nothing Then
            returnString = fillMethodParameters(o).ToString()
        End If
        Return returnString
    End Function

    Public Sub SetFillMethodParameters(ByVal o As Object, ByVal value As String)
        If value <> "" Then
            fillMethodParameters(o) = value
        End If
    End Sub
End Class
