<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.loginButton = New System.Windows.Forms.Button
        Me.usernameTextBox = New System.Windows.Forms.TextBox
        Me.usernameLabel = New System.Windows.Forms.Label
        Me.passwordLabel = New System.Windows.Forms.Label
        Me.passwordTextBox = New System.Windows.Forms.TextBox
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.statusLabel = New System.Windows.Forms.Label
        Me.showBrowserCheckBox = New System.Windows.Forms.CheckBox
        Me.AutoNavigatorControl = New SecureSyncWrapper.AutoNavigatorControl
        Me.SuspendLayout()
        '
        'loginButton
        '
        Me.loginButton.Location = New System.Drawing.Point(169, 76)
        Me.loginButton.Name = "loginButton"
        Me.loginButton.Size = New System.Drawing.Size(75, 23)
        Me.loginButton.TabIndex = 4
        Me.loginButton.Text = "Log In"
        Me.loginButton.UseVisualStyleBackColor = True
        '
        'usernameTextBox
        '
        Me.usernameTextBox.Location = New System.Drawing.Point(144, 10)
        Me.usernameTextBox.Name = "usernameTextBox"
        Me.usernameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.usernameTextBox.TabIndex = 1
        '
        'usernameLabel
        '
        Me.usernameLabel.AutoSize = True
        Me.usernameLabel.Location = New System.Drawing.Point(13, 13)
        Me.usernameLabel.Name = "usernameLabel"
        Me.usernameLabel.Size = New System.Drawing.Size(125, 13)
        Me.usernameLabel.TabIndex = 0
        Me.usernameLabel.Text = "SecureSync Username:  "
        '
        'passwordLabel
        '
        Me.passwordLabel.AutoSize = True
        Me.passwordLabel.Location = New System.Drawing.Point(13, 42)
        Me.passwordLabel.Name = "passwordLabel"
        Me.passwordLabel.Size = New System.Drawing.Size(123, 13)
        Me.passwordLabel.TabIndex = 2
        Me.passwordLabel.Text = "SecureSync Password:  "
        '
        'passwordTextBox
        '
        Me.passwordTextBox.Location = New System.Drawing.Point(144, 39)
        Me.passwordTextBox.Name = "passwordTextBox"
        Me.passwordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordTextBox.Size = New System.Drawing.Size(100, 20)
        Me.passwordTextBox.TabIndex = 3
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(88, 76)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(75, 23)
        Me.ProgressBar.TabIndex = 7
        Me.ProgressBar.Visible = False
        '
        'statusLabel
        '
        Me.statusLabel.AutoSize = True
        Me.statusLabel.Location = New System.Drawing.Point(13, 81)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(61, 13)
        Me.statusLabel.TabIndex = 8
        Me.statusLabel.Text = "statusLabel"
        Me.statusLabel.Visible = False
        '
        'showBrowserCheckBox
        '
        Me.showBrowserCheckBox.AutoSize = True
        Me.showBrowserCheckBox.Location = New System.Drawing.Point(169, 106)
        Me.showBrowserCheckBox.Name = "showBrowserCheckBox"
        Me.showBrowserCheckBox.Size = New System.Drawing.Size(94, 17)
        Me.showBrowserCheckBox.TabIndex = 11
        Me.showBrowserCheckBox.Text = "Show Browser"
        Me.showBrowserCheckBox.UseVisualStyleBackColor = True
        '
        'AutoNavigatorControl
        '
        Me.AutoNavigatorControl.Location = New System.Drawing.Point(12, 145)
        Me.AutoNavigatorControl.MinimumSize = New System.Drawing.Size(20, 20)
        Me.AutoNavigatorControl.Name = "AutoNavigatorControl"
        Me.AutoNavigatorControl.Size = New System.Drawing.Size(232, 118)
        Me.AutoNavigatorControl.TabIndex = 10
        '
        'SendForm
        '
        Me.AcceptButton = Me.loginButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(262, 133)
        Me.Controls.Add(Me.showBrowserCheckBox)
        Me.Controls.Add(Me.AutoNavigatorControl)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.passwordTextBox)
        Me.Controls.Add(Me.passwordLabel)
        Me.Controls.Add(Me.usernameLabel)
        Me.Controls.Add(Me.usernameTextBox)
        Me.Controls.Add(Me.loginButton)
        Me.Name = "SendForm"
        Me.Text = "MDV Secure Sync"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents loginButton As System.Windows.Forms.Button
    Friend WithEvents usernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents usernameLabel As System.Windows.Forms.Label
    Friend WithEvents passwordLabel As System.Windows.Forms.Label
    Friend WithEvents passwordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents statusLabel As System.Windows.Forms.Label
    Friend WithEvents AutoNavigatorControl As SecureSyncWrapper.AutoNavigatorControl
    Friend WithEvents showBrowserCheckBox As System.Windows.Forms.CheckBox

End Class
