Imports System.Reflection

Public Class StartupForm

    ' Declare an EventLog for logging all important and critical events
    'including specific arguments and methods that caused them
    Private ApplicationEventLog As New EventLog("SecureSyncWrapper")

    '// Declares a seperate class to handle all data & file methods
    Friend WithEvents TapeDataHandler As TapeDataHandlerClass

    Private Sub StartupForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'initialize the ApplicationEventLog
        ApplicationEventLog.Source = "StartupForm.StartupForm_Load"

        If My.Settings.centralPath <> "" Then

            TapeDataHandler = New TapeDataHandlerClass(My.Settings.centralPath)

            ' Check to see if scan is allowed
            ' snRules and backupTypes have to first be created
            TapeDataHandler.DetermineIfScanIsAllowed()

            ' check to see if any pending tapes in queue and if is a valid time to send
            TapeDataHandler.DetermineIfSendIsAllowed()

        End If


    End Sub

    Private Sub DisplayScanButtonIfOKToScan(ByVal allowed2Scan As Boolean) Handles TapeDataHandler.IsAllowedToScan
        scanButton.Enabled = allowed2Scan
    End Sub

    Private Sub DisplaySendButtonIfOkToSend(ByVal allowed2Send As Boolean) Handles TapeDataHandler.IsAllowedToSend
        sendButton.Enabled = allowed2Send
    End Sub

    Private Sub setupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub scanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scanButton.Click

        Dim dialogResult As New DialogResult

        dialogResult = ScanForm.ShowDialog()

        If dialogResult = Windows.Forms.DialogResult.OK Then
            scanCheckBox.Checked = True
        Else
            scanCheckBox.Checked = False
        End If
    End Sub

    Private Sub CentralFileLocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CentralFileLocationToolStripMenuItem.Click
        Dim dialogResult As New DialogResult

        'authorize before showing folder browser
        If LoginForm.ShowDialog() = Windows.Forms.DialogResult.OK Then

            'open a folder browser for user to choose centralPath for storing application files
            dialogResult = FolderBrowserDialog1.ShowDialog()

            'if user selected OK button, reset centralPath setting and refresh
            If dialogResult = Windows.Forms.DialogResult.OK Then
                My.Settings.centralPath = FolderBrowserDialog1.SelectedPath
                'refresh page
                StartupForm_Load(sender, e)
            End If
        End If
    End Sub

    Private Sub AddEditBackupTypesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEditBackupTypesToolStripMenuItem.Click
        'prevent normal users from making changes to the backupTypes and snRules
        'add Authentication
        Dim dialogResult As DialogResult
        dialogResult = LoginForm.ShowDialog()

        If dialogResult = Windows.Forms.DialogResult.OK Then
            backupTypeEditForm.ShowDialog()
        End If
    End Sub
End Class