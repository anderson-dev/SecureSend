<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartupForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartupForm))
        Me.scanButton = New System.Windows.Forms.Button
        Me.sendButton = New System.Windows.Forms.Button
        Me.scanCheckBox = New System.Windows.Forms.CheckBox
        Me.sendCheckBox = New System.Windows.Forms.CheckBox
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddEditBackupTypesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CentralFileLocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'scanButton
        '
        Me.scanButton.Enabled = False
        Me.scanButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.scanButton.Image = CType(resources.GetObject("scanButton.Image"), System.Drawing.Image)
        Me.scanButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.scanButton.Location = New System.Drawing.Point(62, 53)
        Me.scanButton.Name = "scanButton"
        Me.scanButton.Size = New System.Drawing.Size(145, 42)
        Me.scanButton.TabIndex = 2
        Me.scanButton.Text = "&Scan Tapes"
        Me.scanButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.scanButton.UseVisualStyleBackColor = True
        '
        'sendButton
        '
        Me.sendButton.Enabled = False
        Me.sendButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sendButton.Image = CType(resources.GetObject("sendButton.Image"), System.Drawing.Image)
        Me.sendButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.sendButton.Location = New System.Drawing.Point(62, 108)
        Me.sendButton.Name = "sendButton"
        Me.sendButton.Size = New System.Drawing.Size(145, 42)
        Me.sendButton.TabIndex = 3
        Me.sendButton.Text = "S&end Tapes"
        Me.sendButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.sendButton.UseVisualStyleBackColor = True
        '
        'scanCheckBox
        '
        Me.scanCheckBox.AutoSize = True
        Me.scanCheckBox.Enabled = False
        Me.scanCheckBox.Location = New System.Drawing.Point(41, 68)
        Me.scanCheckBox.Name = "scanCheckBox"
        Me.scanCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.scanCheckBox.TabIndex = 5
        Me.scanCheckBox.UseVisualStyleBackColor = True
        '
        'sendCheckBox
        '
        Me.sendCheckBox.AutoSize = True
        Me.sendCheckBox.Enabled = False
        Me.sendCheckBox.Location = New System.Drawing.Point(41, 123)
        Me.sendCheckBox.Name = "sendCheckBox"
        Me.sendCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.sendCheckBox.TabIndex = 6
        Me.sendCheckBox.UseVisualStyleBackColor = True
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Choose a central location for the Application Queue and Log"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(248, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEditBackupTypesToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'AddEditBackupTypesToolStripMenuItem
        '
        Me.AddEditBackupTypesToolStripMenuItem.Image = Global.SecureSyncWrapper.My.Resources.Resources.padlock
        Me.AddEditBackupTypesToolStripMenuItem.Name = "AddEditBackupTypesToolStripMenuItem"
        Me.AddEditBackupTypesToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.AddEditBackupTypesToolStripMenuItem.Text = "Add/Edit &Backup Types..."
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CentralFileLocationToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'CentralFileLocationToolStripMenuItem
        '
        Me.CentralFileLocationToolStripMenuItem.Image = Global.SecureSyncWrapper.My.Resources.Resources.padlock
        Me.CentralFileLocationToolStripMenuItem.Name = "CentralFileLocationToolStripMenuItem"
        Me.CentralFileLocationToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.CentralFileLocationToolStripMenuItem.Text = "Central File &Location..."
        '
        'StartupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(248, 202)
        Me.Controls.Add(Me.sendCheckBox)
        Me.Controls.Add(Me.scanCheckBox)
        Me.Controls.Add(Me.sendButton)
        Me.Controls.Add(Me.scanButton)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "StartupForm"
        Me.Text = "StartupForm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents scanButton As System.Windows.Forms.Button
    Friend WithEvents sendButton As System.Windows.Forms.Button
    Friend WithEvents scanCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents sendCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddEditBackupTypesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CentralFileLocationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
