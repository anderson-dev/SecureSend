Imports SecureSyncWrapper.TapeDataTypes

Public Class backupTypeMakerForm

    Private backupTypes() As BackupTypeStruct
    Private snRules() As snRuleStruct
    Private inputControlCollection As New Collection

    Private WriteOnly Property ShowInputFields() As Boolean
        Set(ByVal value As Boolean)
            For Each controlItem As Control In inputControlCollection
                controlItem.Visible = value
            Next
        End Set
    End Property

    Private Sub backupTypeMakerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'initialize inputControlCollection
        With inputControlCollection
            .Add(deleteButton)
            .Add(snRulesLabel)
            .Add(snRulesCheckedListBox)
            .Add(snRuleNewButton)
        End With

        With backupTypeComboBox
            .Items.Insert(0, "New...")

            'fill backupTypeComboBox with existing backupTypes

            backupTypes = StartupForm.TapeDataHandler.GetBackupTypes()

            If backupTypes IsNot Nothing Then
                For backupTypeCounter As Integer = 0 To backupTypes.Length - 1
                    .Items.Add(backupTypes(backupTypeCounter).backupTypeName)
                Next
            End If

        End With
    End Sub

    Private Sub backupTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backupTypeComboBox.SelectedIndexChanged
        'clear out temporary instructional items from snRuleComboBox
        With backupTypeComboBox

            'fill in editing field based on chosen SN rule
            If .SelectedIndex <> -1 Then

                If .SelectedItem.ToString() <> "New..." Then

                    'display input fields for editing
                    ShowInputFields = True

                    'fill the input fields with current respective values
                    If snRules IsNot Nothing Then
                        For backupTypeCounter As Integer = 0 To snRules.Length - 1
                            If .SelectedItem.ToString() = backupTypes(backupTypeCounter).backupTypeName Then
                                For validSNruleCounter As Integer = 0 To backupTypes(backupTypeCounter).validSNformats.Length - 1
                                    snRulesCheckedListBox.Items.Add(backupTypes(backupTypeCounter).validSNformats(validSNruleCounter))
                                Next

                                snRuleEditButton.Visible = True
                            Else
                                snRuleEditButton.Visible = False
                            End If
                        Next
                    End If
                Else 'user selected "New..."
                    'hide input fields
                    ShowInputFields = False
                    'make snRulesComboBox editable
                    .DropDownStyle = ComboBoxStyle.DropDown
                    'show addRuleButton while in editable mode
                    addButton.Visible = True
                    Me.AcceptButton = addButton

                End If
            Else 'no item has been selected
                ShowInputFields = False
            End If
        End With
    End Sub

    Private Sub addButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addButton.Click
        With backupTypeComboBox

            If .Items.Contains(.Text) = False And .Text <> "" Then
                .Text = .Text.Trim()

                .Items.Add(.Text)
                .SelectedItem = .Text
                .DropDownStyle = ComboBoxStyle.DropDownList
                'Me.AcceptButton = OK_Button
                addButton.Visible = False
            End If
        End With
    End Sub

    Private Sub snRuleNewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles snRuleNewButton.Click
        Dim dialogResult As DialogResult
        dialogResult = snRuleMakerForm.ShowDialog()
        If dialogResult = Windows.Forms.DialogResult.OK Then
            'add newly created snRules to TapeDataHandler
            'StartupForm.TapeDataHandler.AddSNrules(snRuleMakerForm.GetNewSNrules())
        Else
            'do nothing
        End If
    End Sub

    Private Sub snRuleEditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles snRuleEditButton.Click
        snRuleEditForm.ShowDialog()
    End Sub
End Class