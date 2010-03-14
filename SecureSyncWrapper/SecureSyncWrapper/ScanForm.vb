Imports System.Media
Imports SecureSyncWrapper.TapeDataTypes
Imports System.Text.RegularExpressions

Public Class ScanForm

    ' Declare an EventLog for logging all important and critical events
    'including specific arguments and methods that caused them
    Protected ApplicationEventLog As New EventLog("SecureSyncWrapper")

    Friend backupDate As Date = Date.Now
    Friend snFormat As String
    Friend validatedSN As String

    Private Sub ScanForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'fill backupTypeComboBox with existing backupTypes
        With StartupForm.TapeDataHandler
            .ControlInterface(TapeDataHandlerClass.Fill.FillBackupTypes, backupTypeComboBox)
        End With

        'set current date as scanned tape default backup date
        backupDateTimePicker.Value = Date.Now

    End Sub

    Private Sub backupTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backupTypeComboBox.SelectedIndexChanged

        With backupTypeComboBox
            If .SelectedIndex <> -1 Then

                '// allow for input
                backupDateLabel.Visible = True
                backupDateTimePicker.Visible = True
                submitButton.Visible = True

                With inputTextBox
                    .Visible = True
                    .Clear()
                    .Focus()
                End With

            Else
                backupDateLabel.Visible = False
                backupDateTimePicker.Visible = False
                submitButton.Visible = False
                inputTextBox.Visible = False
            End If
        End With
    End Sub

    Private Sub submitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submitButton.Click

        inputTextBox_TextChanged(sender, e) 'rescan for valid SNs in input string

        If validatedSN <> "" Then

            'add the tape information to the DataHandler
            With StartupForm.TapeDataHandler
                .AddTape(backupTypeComboBox.SelectedItem.ToString(), backupDate, validatedSN)
            End With
            inputTextBox.Clear() 'then clear for next entry

            'make sure override linkLabel is not shown unless appropriate
            overrideLabel.Visible = False

        Else
            'show override linkLabel
            overrideLabel.Visible = True
            inputTextBox.SelectAll()
            SystemSounds.Exclamation.Play()
        End If

    End Sub

    Private Sub overrideLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles overrideLabel.LinkClicked
        'Allows user to save a tape SN even if validation fails

        'rehide overrideLabel
        overrideLabel.Visible = False

        'in the future this block will store the input SN into appropriate array
        With StartupForm.TapeDataHandler
            .AddTape(backupTypeComboBox.SelectedItem.ToString(), _
                    backupDate, validatedSN)
        End With
        With inputTextBox
            .Focus()
            .Clear()
        End With

    End Sub

    Private Sub prepareToSendTapesLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        'SendForm.Show()
    End Sub

    Private Sub backupDateTimePicker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        backupDate = backupDateTimePicker.Value
    End Sub

    Private Sub ScanForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        StartupForm.TapeDataHandler.QueueForSend()

        With backupTypeComboBox
            'reset backupTypeComboBox.SelectedIndex
            .SelectedIndex = -1
            'purge contents of backupTypeComboBox
            .Items.Clear()
        End With

    End Sub

    Private Sub inputTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inputTextBox.TextChanged

        Dim selectionStartLocation As Integer

        With inputTextBox
            If .Text <> "" Then

                Dim tempText As String = .Text
                tempText = tempText.ToUpper()
                .Clear()
                .Text = tempText
                validatedSN = StartupForm.TapeDataHandler.snValidator.ScanForValidSN(.Text, backupTypeComboBox.SelectedItem.ToString())

                If validatedSN <> "" Then
                    selectionStartLocation = .Text.IndexOf(validatedSN)
                    .SelectionStart = selectionStartLocation
                    .SelectionLength = validatedSN.Length
                    .SelectionBackColor = Color.Yellow
                    .SelectionStart = .Text.Length
                    .SelectionBackColor = Color.White
                Else
                    .SelectAll()
                    .SelectionBackColor = Color.White
                    .SelectionStart = .Text.Length
                End If
            End If
        End With

    End Sub

    Private Sub okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub myCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myCancelButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class