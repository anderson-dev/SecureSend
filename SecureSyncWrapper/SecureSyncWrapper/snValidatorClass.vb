Imports System.Text.RegularExpressions
Imports SecureSyncWrapper.TapeDataTypes
Imports System.IO
Imports System.Xml

' Note: When building this code, you must reference the
' System.Runtime.Serialization.Formatters.Soap.dll assembly.
Imports System.Runtime.Serialization.Formatters.Soap

Public Class snValidatorClass

    Protected m_backupTypes() As BackupTypeStruct
    Protected m_snFormats() As snRuleStruct

    Protected tapeInventory As New List(Of TapeInventoryStruct)

    Friend Sub New(ByVal backupTypeArray() As BackupTypeStruct, ByVal snRulesArray() As snRuleStruct)

        m_backupTypes = backupTypeArray
        m_snFormats = snRulesArray

    End Sub

    Public Function ScanForValidSN(ByVal text2validate As String, ByVal backupTypeName As String) As String
        Dim snFormatMatch As String = ""


        'determine validSNformats
        For backupTypeCounter As Integer = 0 To m_backupTypes.Length - 1
            With m_backupTypes(backupTypeCounter)
                If backupTypeName = .backupTypeName Then

                    'cycle through all snFormats
                    For snFormatCounter As Integer = 0 To m_snFormats.Length - 1

                        'check to see if there is a match for any validSNformat specified for the specific backupType
                        For counter As Integer = 0 To .validSNformats.Length - 1
                            Dim validSNformat As String = .validSNformats(counter).ToString()
                            With m_snFormats(snFormatCounter)
                                If validSNformat = .snRuleName Then
                                    If .snRegExPattern.IsMatch(text2validate) Then 'prevent from overriting a valid match
                                        snFormatMatch = .snRegExPattern.Match(text2validate).ToString()
                                    End If
                                End If
                            End With
                        Next
                    Next
                End If
            End With

        Next

        Return snFormatMatch
    End Function
End Class
