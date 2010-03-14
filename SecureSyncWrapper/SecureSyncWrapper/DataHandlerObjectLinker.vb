Imports System.ComponentModel
Imports System.Reflection

Public Class DataHandlerObjectLinker

    Private m_dataHandlerClassName As String

    Public Property DataHandlerClassName() As String
        Get
            Return m_dataHandlerClassName
        End Get
        Set(ByVal value As String)
            m_dataHandlerClassName = value
        End Set
    End Property

End Class
