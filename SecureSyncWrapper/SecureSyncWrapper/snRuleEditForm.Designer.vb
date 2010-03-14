<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class snRuleEditForm
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.snRuleComboBox = New System.Windows.Forms.ComboBox
        Me.snRuleTextLengthComboBox = New System.Windows.Forms.ComboBox
        Me.snRuleTextLengthLabel = New System.Windows.Forms.Label
        Me.snRuleRegExPatternLabel = New System.Windows.Forms.Label
        Me.snRuleRegExPatternTextBox = New System.Windows.Forms.TextBox
        Me.deleteButton = New System.Windows.Forms.Button
        Me.addButton = New System.Windows.Forms.Button
        Me.editButton = New System.Windows.Forms.Button
        Me.snPatternLabel = New System.Windows.Forms.Label
        Me.snPatternComboBox = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 274)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'snRuleComboBox
        '
        Me.snRuleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.snRuleComboBox.FormattingEnabled = True
        Me.snRuleComboBox.Location = New System.Drawing.Point(12, 12)
        Me.snRuleComboBox.Name = "snRuleComboBox"
        Me.snRuleComboBox.Size = New System.Drawing.Size(121, 21)
        Me.snRuleComboBox.TabIndex = 0
        '
        'snRuleTextLengthComboBox
        '
        Me.snRuleTextLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.snRuleTextLengthComboBox.Enabled = False
        Me.snRuleTextLengthComboBox.FormattingEnabled = True
        Me.snRuleTextLengthComboBox.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.snRuleTextLengthComboBox.Location = New System.Drawing.Point(233, 66)
        Me.snRuleTextLengthComboBox.Name = "snRuleTextLengthComboBox"
        Me.snRuleTextLengthComboBox.Size = New System.Drawing.Size(39, 21)
        Me.snRuleTextLengthComboBox.TabIndex = 3
        Me.snRuleTextLengthComboBox.Visible = False
        '
        'snRuleTextLengthLabel
        '
        Me.snRuleTextLengthLabel.AutoSize = True
        Me.snRuleTextLengthLabel.Location = New System.Drawing.Point(12, 66)
        Me.snRuleTextLengthLabel.Name = "snRuleTextLengthLabel"
        Me.snRuleTextLengthLabel.Size = New System.Drawing.Size(130, 13)
        Me.snRuleTextLengthLabel.TabIndex = 2
        Me.snRuleTextLengthLabel.Text = "Length of Serial Number:  "
        Me.snRuleTextLengthLabel.Visible = False
        '
        'snRuleRegExPatternLabel
        '
        Me.snRuleRegExPatternLabel.AutoSize = True
        Me.snRuleRegExPatternLabel.Location = New System.Drawing.Point(12, 107)
        Me.snRuleRegExPatternLabel.Name = "snRuleRegExPatternLabel"
        Me.snRuleRegExPatternLabel.Size = New System.Drawing.Size(154, 13)
        Me.snRuleRegExPatternLabel.TabIndex = 4
        Me.snRuleRegExPatternLabel.Text = "Serial Number RegEx Pattern:  "
        Me.snRuleRegExPatternLabel.Visible = False
        '
        'snRuleRegExPatternTextBox
        '
        Me.snRuleRegExPatternTextBox.Location = New System.Drawing.Point(172, 104)
        Me.snRuleRegExPatternTextBox.Name = "snRuleRegExPatternTextBox"
        Me.snRuleRegExPatternTextBox.ReadOnly = True
        Me.snRuleRegExPatternTextBox.Size = New System.Drawing.Size(100, 20)
        Me.snRuleRegExPatternTextBox.TabIndex = 5
        Me.snRuleRegExPatternTextBox.Visible = False
        '
        'deleteButton
        '
        Me.deleteButton.Location = New System.Drawing.Point(221, 12)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(75, 23)
        Me.deleteButton.TabIndex = 5
        Me.deleteButton.Text = "Delete Rule"
        Me.deleteButton.UseVisualStyleBackColor = True
        Me.deleteButton.Visible = False
        '
        'addButton
        '
        Me.addButton.Location = New System.Drawing.Point(140, 12)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(75, 23)
        Me.addButton.TabIndex = 1
        Me.addButton.Text = "Add Rule"
        Me.addButton.UseVisualStyleBackColor = True
        Me.addButton.Visible = False
        '
        'editButton
        '
        Me.editButton.Location = New System.Drawing.Point(140, 12)
        Me.editButton.Name = "editButton"
        Me.editButton.Size = New System.Drawing.Size(75, 23)
        Me.editButton.TabIndex = 8
        Me.editButton.Text = "&Edit"
        Me.editButton.UseVisualStyleBackColor = True
        '
        'snPatternLabel
        '
        Me.snPatternLabel.AutoSize = True
        Me.snPatternLabel.Location = New System.Drawing.Point(15, 138)
        Me.snPatternLabel.Name = "snPatternLabel"
        Me.snPatternLabel.Size = New System.Drawing.Size(119, 13)
        Me.snPatternLabel.TabIndex = 9
        Me.snPatternLabel.Text = "Serial Number Pattern:  "
        '
        'snPatternComboBox
        '
        Me.snPatternComboBox.FormattingEnabled = True
        Me.snPatternComboBox.Location = New System.Drawing.Point(151, 130)
        Me.snPatternComboBox.Name = "snPatternComboBox"
        Me.snPatternComboBox.Size = New System.Drawing.Size(121, 21)
        Me.snPatternComboBox.TabIndex = 10
        '
        'snRuleEditForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 315)
        Me.Controls.Add(Me.snPatternComboBox)
        Me.Controls.Add(Me.snPatternLabel)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.snRuleRegExPatternTextBox)
        Me.Controls.Add(Me.snRuleRegExPatternLabel)
        Me.Controls.Add(Me.snRuleTextLengthLabel)
        Me.Controls.Add(Me.snRuleTextLengthComboBox)
        Me.Controls.Add(Me.snRuleComboBox)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.addButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "snRuleEditForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "snRuleEditForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents snRuleComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents snRuleTextLengthComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents snRuleTextLengthLabel As System.Windows.Forms.Label
    Friend WithEvents snRuleRegExPatternLabel As System.Windows.Forms.Label
    Friend WithEvents snRuleRegExPatternTextBox As System.Windows.Forms.TextBox
    Friend WithEvents deleteButton As System.Windows.Forms.Button
    Friend WithEvents addButton As System.Windows.Forms.Button
    Friend WithEvents editButton As System.Windows.Forms.Button
    Friend WithEvents snPatternLabel As System.Windows.Forms.Label
    Friend WithEvents snPatternComboBox As System.Windows.Forms.ComboBox

End Class
