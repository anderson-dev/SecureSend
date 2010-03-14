<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoNavigatorForm
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
        Me.AutoNavigatorControl = New SecureSyncWrapper.AutoNavigatorControl
        Me.SuspendLayout()
        '
        'AutoNavigatorControl
        '
        Me.AutoNavigatorControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AutoNavigatorControl.Location = New System.Drawing.Point(0, 0)
        Me.AutoNavigatorControl.MinimumSize = New System.Drawing.Size(20, 20)
        Me.AutoNavigatorControl.Name = "AutoNavigatorControl"
        Me.AutoNavigatorControl.Size = New System.Drawing.Size(506, 267)
        Me.AutoNavigatorControl.TabIndex = 0
        '
        'AutoNavigatorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 267)
        Me.Controls.Add(Me.AutoNavigatorControl)
        Me.Name = "AutoNavigatorForm"
        Me.Text = "autoNavigatorForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AutoNavigatorControl As SecureSyncWrapper.AutoNavigatorControl
End Class
