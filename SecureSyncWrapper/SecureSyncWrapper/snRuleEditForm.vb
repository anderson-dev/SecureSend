Imports System.Windows.Forms
Imports SecureSyncWrapper.TapeDataTypes

Public Class snRuleEditForm

    Private inputControlCollection As New Collection
    Private inputTextControlCollection As New Collection
    Private inputSelectionControlCollection As New Collection

    Private Sub snRuleEditForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With snRuleComboBox

            'fill snRuleComboBox with existing rule names
            StartupForm.TapeDataHandler.ControlInterface(TapeDataHandlerClass.Fill.FillSNRules, snRuleComboBox)

            'initialize control collections to reference multiple controls simultaniously
            InitializeControlCollections()

        End With
    End Sub

    Private WriteOnly Property ShowInputFields() As Boolean
        Set(ByVal value As Boolean)

            For Each controlItem As Control In inputControlCollection
                controlItem.Visible = value
            Next

        End Set
    End Property

    Private Sub ClearInputFields()
        With Me
            .snRuleTextLengthComboBox.SelectedIndex = -1
            .snRuleRegExPatternTextBox.Clear()
            'disable the delete button
            deleteButton.Enabled = False
        End With
    End Sub

    Private Sub snRuleComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles snRuleComboBox.SelectedIndexChanged

        With snRuleComboBox

            'fill in editing field based on chosen SN rule
            If .SelectedIndex <> -1 Then

                If .SelectedItem.ToString() <> "New..." Then

                    'display input fields for editing
                    ShowInputFields = True

                    'enable delete button if a valid existing snRule is selected
                    deleteButton.Enabled = True

                    'display the current respective values of currently selected snRule
                    'StartupForm.TapeDataHandler.ComboBoxInterface.FillSNRuleDetailsByComboBox(.SelectedItem.ToString(), snRuleTextLengthComboBox, snPatternComboBox)

                Else 'user selected "New..."
                    'hide input fields
                    ShowInputFields() = False
                    'hide editButton
                    editButton.Visible = False
                    'make snRulesComboBox editable
                    .DropDownStyle = ComboBoxStyle.DropDown
                    'show addRuleButton while in editable mode
                    addButton.Visible = True
                    Me.AcceptButton = addButton

                End If
            Else 'no item has been selected
                ShowInputFields() = False
            End If

        End With
    End Sub

    Private Sub InitializeControlCollections()

        'initialize inputControlCollections
        With inputControlCollection
            .Add(snRuleTextLengthLabel)
            .Add(snRuleTextLengthComboBox)
            .Add(snRuleRegExPatternLabel)
            .Add(snRuleRegExPatternTextBox)
        End With

        With inputTextControlCollection
            .Add(snRuleRegExPatternTextBox)
        End With

        With inputSelectionControlCollection
            .Add(snRuleTextLengthComboBox)
        End With

    End Sub

    Private Sub addButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addButton.Click

        With snRuleComboBox

            If .Items.Contains(.Text) = False And .Text <> "" Then
                .Text = .Text.Trim()

                .Items.Add(.Text)
                .SelectedItem = .Text
                .DropDownStyle = ComboBoxStyle.DropDownList
                Me.AcceptButton = OK_Button
                addButton.Visible = False
                editButton.Visible = True
            End If
        End With
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub snRuleMakerForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        snRuleComboBox.Items.Clear() 'purge filled textBox
        ClearInputFields() 'clear input fields
    End Sub

    Private Sub snRuleRegExPatternTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles snRuleRegExPatternTextBox.TextChanged
        'when text changes store it to the corresponding snRule value
        'With snRuleComboBox
        '    If .SelectedIndex <> -1 Then
        '        inputTextControlValues(.SelectedIndex - 1) = snRuleRegExPatternTextBox.Text
        '    End If
        'End With
    End Sub

    Private Sub editButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editButton.Click
        'enables editing of all input controls

        Static editFlag As Boolean

        'enable/disable editing of controls
        editFlag = Not editFlag

        If editFlag = True Then
            For Each controlItem As TextBox In inputTextControlCollection
                controlItem.ReadOnly = False
            Next

            For Each controlItem As ComboBox In inputSelectionControlCollection
                controlItem.Enabled = True
                controlItem.DropDownStyle = ComboBoxStyle.DropDownList
            Next

            editButton.Text = "&Done"
            deleteButton.Visible = True

        Else 'editing is off
            For Each controlItem As TextBox In inputTextControlCollection
                controlItem.ReadOnly = True
            Next

            For Each controlItem As ComboBox In inputSelectionControlCollection
                controlItem.Enabled = False
                controlItem.DropDownStyle = ComboBoxStyle.Simple
            Next

            editButton.Text = "&Edit"
            deleteButton.Visible = False
        End If
    End Sub

    Private Sub deleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteButton.Click
        'With snRuleComboBox
        '    StartupForm.TapeDataHandler.DeleteSNrule(.SelectedIndex.ToString())
        '    .Items.RemoveAt(.SelectedIndex)
        '    ShowInputFields = False
        '    deleteButton.Enabled = False
        'End With
    End Sub
End Class