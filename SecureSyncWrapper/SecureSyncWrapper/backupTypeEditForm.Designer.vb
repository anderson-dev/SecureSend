<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class backupTypeEditForm
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
        Me.backupTypeComboBox = New System.Windows.Forms.ComboBox
        Me.deleteButton = New System.Windows.Forms.Button
        Me.addButton = New System.Windows.Forms.Button
        Me.snRulesLabel = New System.Windows.Forms.Label
        Me.snRuleEditButton = New System.Windows.Forms.Button
        Me.snRulesListBox = New System.Windows.Forms.ListBox
        Me.editButton = New System.Windows.Forms.Button
        Me.okButton = New System.Windows.Forms.Button
        Me.myCancelButton = New System.Windows.Forms.Button
        Me.noSNRuleSelectedLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'backupTypeComboBox
        '
        Me.backupTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.backupTypeComboBox.FormattingEnabled = True
        Me.backupTypeComboBox.Location = New System.Drawing.Point(12, 12)
        Me.backupTypeComboBox.Name = "backupTypeComboBox"
        Me.backupTypeComboBox.Size = New System.Drawing.Size(121, 21)
        Me.backupTypeComboBox.TabIndex = 0
        '
        'deleteButton
        '
        Me.deleteButton.Location = New System.Drawing.Point(220, 10)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(75, 23)
        Me.deleteButton.TabIndex = 2
        Me.deleteButton.Text = "&Delete"
        Me.deleteButton.UseVisualStyleBackColor = True
        Me.deleteButton.Visible = False
        '
        'addButton
        '
        Me.addButton.Location = New System.Drawing.Point(139, 10)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(75, 23)
        Me.addButton.TabIndex = 3
        Me.addButton.Text = "&Add"
        Me.addButton.UseVisualStyleBackColor = True
        Me.addButton.Visible = False
        '
        'snRulesLabel
        '
        Me.snRulesLabel.AutoSize = True
        Me.snRulesLabel.Location = New System.Drawing.Point(9, 56)
        Me.snRulesLabel.Name = "snRulesLabel"
        Me.snRulesLabel.Size = New System.Drawing.Size(150, 13)
        Me.snRulesLabel.TabIndex = 4
        Me.snRulesLabel.Text = "Follows Serial Number Rule(s):"
        Me.snRulesLabel.Visible = False
        '
        'snRuleEditButton
        '
        Me.snRuleEditButton.Location = New System.Drawing.Point(31, 173)
        Me.snRuleEditButton.Name = "snRuleEditButton"
        Me.snRuleEditButton.Size = New System.Drawing.Size(82, 23)
        Me.snRuleEditButton.TabIndex = 5
        Me.snRuleEditButton.Text = "Edit &SN Rules"
        Me.snRuleEditButton.UseVisualStyleBackColor = True
        Me.snRuleEditButton.Visible = False
        '
        'snRulesListBox
        '
        Me.snRulesListBox.Enabled = False
        Me.snRulesListBox.FormattingEnabled = True
        Me.snRulesListBox.Location = New System.Drawing.Point(12, 72)
        Me.snRulesListBox.Name = "snRulesListBox"
        Me.snRulesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.snRulesListBox.Size = New System.Drawing.Size(121, 95)
        Me.snRulesListBox.TabIndex = 6
        Me.snRulesListBox.Visible = False
        '
        'editButton
        '
        Me.editButton.Location = New System.Drawing.Point(139, 10)
        Me.editButton.Name = "editButton"
        Me.editButton.Size = New System.Drawing.Size(75, 23)
        Me.editButton.TabIndex = 7
        Me.editButton.Text = "&Edit"
        Me.editButton.UseVisualStyleBackColor = True
        Me.editButton.Visible = False
        '
        'okButton
        '
        Me.okButton.Location = New System.Drawing.Point(266, 231)
        Me.okButton.Name = "okButton"
        Me.okButton.Size = New System.Drawing.Size(75, 23)
        Me.okButton.TabIndex = 8
        Me.okButton.Text = "&OK"
        Me.okButton.UseVisualStyleBackColor = True
        '
        'myCancelButton
        '
        Me.myCancelButton.Location = New System.Drawing.Point(347, 231)
        Me.myCancelButton.Name = "myCancelButton"
        Me.myCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.myCancelButton.TabIndex = 9
        Me.myCancelButton.Text = "&Cancel"
        Me.myCancelButton.UseVisualStyleBackColor = True
        '
        'noSNRuleSelectedLabel
        '
        Me.noSNRuleSelectedLabel.AutoSize = True
        Me.noSNRuleSelectedLabel.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.noSNRuleSelectedLabel.Location = New System.Drawing.Point(9, 173)
        Me.noSNRuleSelectedLabel.Name = "noSNRuleSelectedLabel"
        Me.noSNRuleSelectedLabel.Size = New System.Drawing.Size(190, 13)
        Me.noSNRuleSelectedLabel.TabIndex = 10
        Me.noSNRuleSelectedLabel.Text = "At least one SN Rule Must be selected"
        Me.noSNRuleSelectedLabel.Visible = False
        '
        'backupTypeEditForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 266)
        Me.Controls.Add(Me.myCancelButton)
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.snRulesListBox)
        Me.Controls.Add(Me.snRuleEditButton)
        Me.Controls.Add(Me.snRulesLabel)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.backupTypeComboBox)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.noSNRuleSelectedLabel)
        Me.Name = "backupTypeEditForm"
        Me.Text = "backupTypeMakerForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents backupTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents deleteButton As System.Windows.Forms.Button
    Friend WithEvents addButton As System.Windows.Forms.Button
    Friend WithEvents snRulesLabel As System.Windows.Forms.Label
    Friend WithEvents snRuleEditButton As System.Windows.Forms.Button
    Friend WithEvents snRulesListBox As System.Windows.Forms.ListBox
    Friend WithEvents editButton As System.Windows.Forms.Button
    Friend WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents myCancelButton As System.Windows.Forms.Button
    Friend WithEvents noSNRuleSelectedLabel As System.Windows.Forms.Label
End Class
