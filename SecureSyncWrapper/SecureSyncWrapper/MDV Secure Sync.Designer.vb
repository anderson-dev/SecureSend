<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sendForm
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
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.loginButton = New System.Windows.Forms.Button
        Me.hideBrowserCheckBox = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(12, 37)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(441, 235)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.Url = New System.Uri("http://www.securesync.com", System.UriKind.Absolute)
        '
        'loginButton
        '
        Me.loginButton.Location = New System.Drawing.Point(12, 8)
        Me.loginButton.Name = "loginButton"
        Me.loginButton.Size = New System.Drawing.Size(75, 23)
        Me.loginButton.TabIndex = 1
        Me.loginButton.Text = "Log In"
        Me.loginButton.UseVisualStyleBackColor = True
        '
        'hideBrowserCheckBox
        '
        Me.hideBrowserCheckBox.AutoSize = True
        Me.hideBrowserCheckBox.Location = New System.Drawing.Point(358, 12)
        Me.hideBrowserCheckBox.Name = "hideBrowserCheckBox"
        Me.hideBrowserCheckBox.Size = New System.Drawing.Size(95, 17)
        Me.hideBrowserCheckBox.TabIndex = 2
        Me.hideBrowserCheckBox.Text = "Hide Browser?"
        Me.hideBrowserCheckBox.UseVisualStyleBackColor = True
        '
        'sendForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 266)
        Me.Controls.Add(Me.hideBrowserCheckBox)
        Me.Controls.Add(Me.loginButton)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Name = "sendForm"
        Me.Text = "MDV Secure Sync"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents loginButton As System.Windows.Forms.Button
    Friend WithEvents hideBrowserCheckBox As System.Windows.Forms.CheckBox

End Class
