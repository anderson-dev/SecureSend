Imports SecureSyncWrapper.TapeDataTypes

Public Class backupTypeEditForm

    Private inputControlCollection As New Collection
    Private editingControlsCollection As New Collection

    Private changesMade As Boolean
    Private pendingDelete As Boolean

    Private WriteOnly Property ShowInputFields() As Boolean
        Set(ByVal value As Boolean)
            If inputControlCollection.Count >= 1 Then
                For Each controlItem As Control In inputControlCollection
                    controlItem.Visible = value
                Next
            Else
                'initialize inputControlCollection
                With inputControlCollection
                    .Add(snRulesLabel)
                    .Add(editButton)
                    .Add(snRulesListBox)
                    .Add(snRuleEditButton)
                End With

                For Each controlItem As Control In inputControlCollection
                    controlItem.Visible = value
                Next
            End If
        End Set
    End Property

    Private Sub backupTypeMakerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With StartupForm.TapeDataHandler

            'make backup of all existing backupTypes before any potential changes are made
            .CreateBackupTypesRestorePoint()

            'fill backupTypeComboBox with existing backupTypes
            .ControlInterface(TapeDataHandlerClass.Fill.FillBackupTypes, backupTypeComboBox)

            'fill snRulesListBox with all existing snRules
            .ControlInterface(TapeDataHandlerClass.Fill.FillSNRules, snRulesListBox)

        End With
    End Sub

    Private Sub backupTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backupTypeComboBox.SelectedIndexChanged
        'clear out temporary instructional items from snRuleComboBox
        With backupTypeComboBox

            'fill in editing field based on chosen SN rule
            If .SelectedIndex >= 1 Then

                'display input fields for editing
                ShowInputFields = True

                ''clear snRulesListBox selections
                snRulesListBox.SelectedItems.Clear()

                ' ''fill the snRulesListBox with current respective values
                StartupForm.TapeDataHandler.ControlInterface(TapeDataHandlerClass.Selection.SelectValidSNRulesByBackupType, .SelectedItem.ToString(), snRulesListBox)

            ElseIf .SelectedIndex = 0 Then 'user selected "New..."
                'hide input fields
                ShowInputFields = False
                'make snRulesComboBox editable
                .DropDownStyle = ComboBoxStyle.DropDown
                'show addRuleButton while in editable mode
                addButton.Visible = True
                Me.AcceptButton = addButton

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
                editButton.Visible = True
                editButton_Click(sender, e)
            End If
        End With
    End Sub

    Private Sub snRuleEditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles snRuleEditButton.Click
        Dim dialogResult As DialogResult = snRuleEditForm.ShowDialog()
    End Sub

    Private Sub editButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editButton.Click

        Static toggle As Boolean

        changesMade = True
        toggle = Not toggle

        If toggle = True Then
            editButton.Text = "&Done"
            okButton.Enabled = False
            myCancelButton.Enabled = False
            backupTypeComboBox.Enabled = False
            deleteButton.Visible = True
            snRulesListBox.Enabled = True
            snRuleEditButton.Visible = False

            AddHandler snRulesListBox.SelectedIndexChanged, AddressOf DetermineIfChangesAreMadeToLinkedSNRules

        Else
            If snRulesListBox.SelectedIndices.Count >= 1 Then
                noSNRuleSelectedLabel.Visible = False
                If pendingDelete = True Then
                    With backupTypeComboBox
                        StartupForm.TapeDataHandler.DeleteBackupType(.SelectedItem.ToString())
                        Dim lastSelectedItem As String = .SelectedItem.ToString()
                        .SelectedIndex = -1
                        .Items.Remove(lastSelectedItem)
                    End With
                    pendingDelete = False
                End If
                editButton.Text = "&Edit"
                okButton.Enabled = True
                myCancelButton.Enabled = True
                backupTypeComboBox.Enabled = True
                deleteButton.Visible = False
                snRulesListBox.Enabled = False
                snRuleEditButton.Visible = True
            Else
                noSNRuleSelectedLabel.Visible = True
            End If

            RemoveHandler snRulesListBox.SelectedIndexChanged, AddressOf DetermineIfChangesAreMadeToLinkedSNRules
        End If

    End Sub

    Private Sub DetermineIfChangesAreMadeToLinkedSNRules(ByVal sender As Object, ByVal e As System.EventArgs)

        StartupForm.TapeDataHandler.ControlInterface(TapeDataHandlerClass.AddUpdate.AddUpdateBackupType, backupTypeComboBox.SelectedItem.ToString(), snRulesListBox)

    End Sub

    Private Sub deleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteButton.Click
        pendingDelete = Not pendingDelete

        If pendingDelete = True Then
            deleteButton.Text = "Undo"
        Else
            deleteButton.Text = "&Delete"
        End If
    End Sub

    Private Sub okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okButton.Click
        If changesMade = True Then
            Dim messageBoxResult As DialogResult
            messageBoxResult = MessageBox.Show("Save all changes before exiting?", "Save File Dialog", MessageBoxButtons.YesNoCancel)
            If messageBoxResult = Windows.Forms.DialogResult.Yes Then
                StartupForm.TapeDataHandler.SaveBackupTypes()
                Me.Close()
            ElseIf messageBoxResult = Windows.Forms.DialogResult.No Then
                StartupForm.TapeDataHandler.RevertToBackupTypesRestorePoint()
                Me.Close()
            Else
                'allow user to continue editing where they left off
            End If
        End If
    End Sub

    Private Sub myCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myCancelButton.Click
        Me.Close()
    End Sub
End Class