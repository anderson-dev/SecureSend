<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class backupTypeMakerForm
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
        Me.snRulesCheckedListBox = New System.Windows.Forms.CheckedListBox
        Me.deleteButton = New System.Windows.Forms.Button
        Me.addButton = New System.Windows.Forms.Button
        Me.snRulesLabel = New System.Windows.Forms.Label
        Me.snRuleNewButton = New System.Windows.Forms.Button
        Me.snRuleEditButton = New System.Windows.Forms.Button
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
        'snRulesCheckedListBox
        '
        Me.snRulesCheckedListBox.CheckOnClick = True
        Me.snRulesCheckedListBox.FormattingEnabled = True
        Me.snRulesCheckedListBox.Location = New System.Drawing.Point(12, 72)
        Me.snRulesCheckedListBox.Name = "snRulesCheckedListBox"
        Me.snRulesCheckedListBox.Size = New System.Drawing.Size(150, 94)
        Me.snRulesCheckedListBox.TabIndex = 1
        Me.snRulesCheckedListBox.Visible = False
        '
        'deleteButton
        '
        Me.deleteButton.Location = New System.Drawing.Point(139, 10)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(75, 23)
        Me.deleteButton.TabIndex = 2
        Me.deleteButton.Text = "&Delete"
        Me.deleteButton.UseVisualStyleBackColor = True
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
        'snRuleNewButton
        '
        Me.snRuleNewButton.Location = New System.Drawing.Point(169, 72)
        Me.snRuleNewButton.Name = "snRuleNewButton"
        Me.snRuleNewButton.Size = New System.Drawing.Size(75, 23)
        Me.snRuleNewButton.TabIndex = 5
        Me.snRuleNewButton.Text = "&New"
        Me.snRuleNewButton.UseVisualStyleBackColor = True
        Me.snRuleNewButton.Visible = False
        '
        'snRuleEditButton
        '
        Me.snRuleEditButton.Location = New System.Drawing.Point(169, 101)
        Me.snRuleEditButton.Name = "snRuleEditButton"
        Me.snRuleEditButton.Size = New System.Drawing.Size(75, 23)
        Me.snRuleEditButton.TabIndex = 6
        Me.snRuleEditButton.Text = "&Edit"
        Me.snRuleEditButton.UseVisualStyleBackColor = True
        Me.snRuleEditButton.Visible = False
        '
        'backupTypeMakerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 266)
        Me.Controls.Add(Me.snRuleEditButton)
        Me.Controls.Add(Me.snRuleNewButton)
        Me.Controls.Add(Me.snRulesLabel)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.snRulesCheckedListBox)
        Me.Controls.Add(Me.backupTypeComboBox)
        Me.Name = "backupTypeMakerForm"
        Me.Text = "backupTypeMakerForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents backupTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents snRulesCheckedListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents deleteButton As System.Windows.Forms.Button
    Friend WithEvents addButton As System.Windows.Forms.Button
    Friend WithEvents snRulesLabel As System.Windows.Forms.Label
    Friend WithEvents snRuleNewButton As System.Windows.Forms.Button
    Friend WithEvents snRuleEditButton As System.Windows.Forms.Button
End Class
