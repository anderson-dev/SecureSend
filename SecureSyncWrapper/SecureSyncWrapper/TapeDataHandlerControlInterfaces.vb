Imports SecureSyncWrapper.TapeDataTypes

Partial Class TapeDataHandlerClass

    Public Enum Fill
        FillSNRules
        FillBackupTypes
    End Enum

    Public Enum AddUpdate
        AddUpdateBackupType
    End Enum

    Public Enum Selection
        SelectValidSNRulesByBackupType
    End Enum

    ''' <summary>
    ''' Convenience method to fill a ComboBox with all currently existing backupTypes or snRules.
    ''' Also includes a "New..." item at top to facilitate adding backupTypes or snRules respectively.
    ''' </summary>
    ''' <param name="DataToFillControlWith"></param>
    ''' <param name="NameofComboBox"></param>
    ''' <remarks></remarks>
    Public Sub ControlInterface(ByVal DataToFillControlWith As Fill, ByRef NameofComboBox As ComboBox)

        'check to see which method is being called
        Select Case DataToFillControlWith
            Case Fill.FillSNRules
                NameofComboBox.Items.Add("New...")

                If snRules IsNot Nothing Then
                    For Each snRuleItem As snRuleStruct In snRules
                        NameofComboBox.Items.Add(snRuleItem.snRuleName)
                    Next
                End If
            Case Fill.FillBackupTypes
                NameofComboBox.Items.Add("New...")

                If backupTypes IsNot Nothing Then
                    For Each backupTypeItem As BackupTypeStruct In backupTypes
                        NameofComboBox.Items.Add(backupTypeItem.backupTypeName)
                    Next
                End If
        End Select

    End Sub

    ''' <summary>
    ''' Convenience method to fill a ListBox with all currently existing backupTypes or snRules.
    ''' Also includes a "New..." item at top to facilitate adding backupTypes or snRules respectively.
    ''' </summary>
    ''' <param name="DataToFillControlWith"></param>
    ''' <param name="NameofListBox"></param>
    ''' <remarks></remarks>
    Public Sub ControlInterface(ByVal DataToFillControlWith As Fill, ByRef NameofListBox As ListBox)

        'check to see which method is being called
        Select Case DataToFillControlWith
            Case Fill.FillSNRules
                NameofListBox.Items.Add("New...")

                If snRules IsNot Nothing Then
                    For Each snRuleItem As snRuleStruct In snRules
                        NameofListBox.Items.Add(snRuleItem.snRuleName)
                    Next
                End If
            Case Fill.FillBackupTypes
                NameofListBox.Items.Add("New...")

                If backupTypes IsNot Nothing Then
                    For Each backupTypeItem As BackupTypeStruct In backupTypes
                        NameofListBox.Items.Add(backupTypeItem.backupTypeName)
                    Next
                End If
        End Select

    End Sub

    ''' <summary>
    ''' Interface for adding or updating backupTypes.
    ''' Abstracts the lower-level direct adding or updating of backupTypes.
    ''' </summary>
    ''' <param name="DataThatControlWillUpdate"></param>
    ''' <param name="BackupTypeName"></param>
    ''' <param name="NameOfSNRulesListBox"></param>
    ''' <remarks></remarks>
    Public Sub ControlInterface(ByVal DataThatControlWillUpdate As AddUpdate, ByVal BackupTypeName As String, ByRef NameOfSNRulesListBox As ListBox)
        Dim newBackupType As New BackupTypeStruct

        ReDim newBackupType.validSNformats(NameOfSNRulesListBox.SelectedIndices.Count - 1)

        newBackupType.backupTypeName = BackupTypeName

        For counter As Integer = 0 To NameOfSNRulesListBox.SelectedIndices.Count - 1
            newBackupType.validSNformats(counter) = NameOfSNRulesListBox.SelectedItems(counter).ToString()
        Next

        StartupForm.TapeDataHandler.AddUpdateBackupType(newBackupType)
    End Sub

    ''' <summary>
    ''' Convenience method for selecting corresponding snRules in a ListBox based on backupTypeName given.
    ''' </summary>
    ''' <param name="DataThatControlWillSelect"></param>
    ''' <param name="BackupTypeName"></param>
    ''' <param name="NameOfSNRulesListBox"></param>
    ''' <remarks></remarks>
    Public Sub ControlInterface(ByVal DataThatControlWillSelect As Selection, ByVal BackupTypeName As String, ByRef NameOfSNRulesListBox As ListBox)
        Dim findIndex As Integer = -1

        With NameOfSNRulesListBox
            If .Items.Count > 0 Then

                If .SelectedItems.Count <> 0 Then
                    .SelectedItems.Clear()
                End If

                'find index position of backupTypeName in BackupType List
                For counter As Integer = 0 To backupTypes.Count - 1
                    If backupTypes(counter).backupTypeName = BackupTypeName Then
                        findIndex = counter
                        Exit For
                    End If
                Next

                If findIndex <> -1 Then
                    For counter As Integer = 0 To backupTypes(findIndex).validSNformats.Length - 1
                        Dim validSNitem As String = backupTypes(findIndex).validSNformats(counter).ToString()
                        If .Items.IndexOf(validSNitem) <> -1 Then
                            .SetSelected(.Items.IndexOf(validSNitem), True)
                        End If
                    Next
                End If
            End If
        End With
    End Sub

End Class
