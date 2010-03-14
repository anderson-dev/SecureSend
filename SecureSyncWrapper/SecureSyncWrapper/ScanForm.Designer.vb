<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScanForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScanForm))
        Me.backupTypeComboBox = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.submitButton = New System.Windows.Forms.Button
        Me.overrideLabel = New System.Windows.Forms.LinkLabel
        Me.inputTextBox = New System.Windows.Forms.RichTextBox
        Me.backupDateLabel = New System.Windows.Forms.Label
        Me.backupDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.okButton = New System.Windows.Forms.Button
        Me.myCancelButton = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'backupTypeComboBox
        '
        Me.backupTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.backupTypeComboBox.FormattingEnabled = True
        Me.backupTypeComboBox.Location = New System.Drawing.Point(106, 33)
        Me.backupTypeComboBox.Name = "backupTypeComboBox"
        Me.backupTypeComboBox.Size = New System.Drawing.Size(121, 21)
        Me.backupTypeComboBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Type of Backup"
        '
        'submitButton
        '
        Me.submitButton.Location = New System.Drawing.Point(233, 100)
        Me.submitButton.Name = "submitButton"
        Me.submitButton.Size = New System.Drawing.Size(75, 23)
        Me.submitButton.TabIndex = 3
        Me.submitButton.Text = "Submit"
        Me.submitButton.UseVisualStyleBackColor = True
        Me.submitButton.Visible = False
        '
        'overrideLabel
        '
        Me.overrideLabel.AutoSize = True
        Me.overrideLabel.Location = New System.Drawing.Point(115, 126)
        Me.overrideLabel.Name = "overrideLabel"
        Me.overrideLabel.Size = New System.Drawing.Size(123, 13)
        Me.overrideLabel.TabIndex = 4
        Me.overrideLabel.TabStop = True
        Me.overrideLabel.Text = "Enter This Tape Anyway"
        Me.overrideLabel.Visible = False
        '
        'inputTextBox
        '
        Me.inputTextBox.Location = New System.Drawing.Point(127, 100)
        Me.inputTextBox.Multiline = False
        Me.inputTextBox.Name = "inputTextBox"
        Me.inputTextBox.Size = New System.Drawing.Size(100, 22)
        Me.inputTextBox.TabIndex = 7
        Me.inputTextBox.Text = ""
        Me.inputTextBox.Visible = False
        '
        'backupDateLabel
        '
        Me.backupDateLabel.AutoSize = True
        Me.backupDateLabel.Location = New System.Drawing.Point(18, 68)
        Me.backupDateLabel.Name = "backupDateLabel"
        Me.backupDateLabel.Size = New System.Drawing.Size(79, 13)
        Me.backupDateLabel.TabIndex = 10
        Me.backupDateLabel.Text = "Backup Date:  "
        Me.backupDateLabel.Visible = False
        '
        'backupDateTimePicker
        '
        Me.backupDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.backupDateTimePicker.Location = New System.Drawing.Point(127, 64)
        Me.backupDateTimePicker.Name = "backupDateTimePicker"
        Me.backupDateTimePicker.Size = New System.Drawing.Size(100, 20)
        Me.backupDateTimePicker.TabIndex = 9
        Me.backupDateTimePicker.Visible = False
        '
        'okButton
        '
        Me.okButton.Location = New System.Drawing.Point(198, 160)
        Me.okButton.Name = "okButton"
        Me.okButton.Size = New System.Drawing.Size(75, 23)
        Me.okButton.TabIndex = 12
        Me.okButton.Text = "&Done"
        Me.okButton.UseVisualStyleBackColor = True
        '
        'myCancelButton
        '
        Me.myCancelButton.Location = New System.Drawing.Point(279, 160)
        Me.myCancelButton.Name = "myCancelButton"
        Me.myCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.myCancelButton.TabIndex = 13
        Me.myCancelButton.Text = "&Cancel"
        Me.myCancelButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(233, 34)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(121, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'ScanForm
        '
        Me.AcceptButton = Me.submitButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 195)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.myCancelButton)
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.backupDateLabel)
        Me.Controls.Add(Me.backupDateTimePicker)
        Me.Controls.Add(Me.inputTextBox)
        Me.Controls.Add(Me.overrideLabel)
        Me.Controls.Add(Me.submitButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.backupTypeComboBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ScanForm"
        Me.Text = "ScanForm"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents backupTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents submitButton As System.Windows.Forms.Button
    Friend WithEvents overrideLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents inputTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents backupDateLabel As System.Windows.Forms.Label
    Friend WithEvents backupDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents myCancelButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
