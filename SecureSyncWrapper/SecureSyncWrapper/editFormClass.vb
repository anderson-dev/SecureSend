Imports System.Windows.Forms
Imports System.Reflection
Imports System.Text.RegularExpressions

Public Class editFormClass

    ''' <summary>
    ''' Specify a seperate DataHandlerClass and its corresponding methods and parameters to
    ''' display or update data via Windows Form Controls.
    ''' </summary>
    ''' <remarks></remarks>
    Protected dataHandlerClassName As String = Me.DataHandlerObjectLinker1.DataHandlerClassName
    Protected Const DATAHANDLER_VIEW_METHOD As String = "ControlInterface"
    Protected Const DATAHANDLER_ADDUPDATE_METHOD As String = "ControlInterface"
    Protected viewMethodParamaters() As Object = {Nothing}
    Protected addUpdateMethodParameters() As Object = {Nothing}
    Protected fillMethodNames() As String = {"fillMethodNameAsString"}

    Protected executingAssemblyName As String = Assembly.GetExecutingAssembly().GetName().Name
    Protected DATAHANDLER_CLASS_FULLNAME As String = executingAssemblyName & "." & dataHandlerClassName
    Protected getDataHandlerObject As Type = Type.GetType(DATAHANDLER_CLASS_FULLNAME, True)
    Protected getDataHandlerViewMethod As MethodInfo = getDataHandlerObject.GetMethod(DATAHANDLER_VIEW_METHOD)

    Protected postInitControlCollection As Collection
    Protected viewControlCollection As Collection
    Protected editControlCollection As Collection

    Protected pendingDelete As Boolean
    Protected validInput As Boolean

    Protected WriteOnly Property showPostInitControlCollection() As Boolean
        Set(ByVal value As Boolean)
            Static initialized As Boolean

            If initialized = False Then

                'instantiate collection
                postInitControlCollection = New Collection

                'add all postInitControl on form to postInitControlCollection
                For Each controlItem As Control In Me.Controls
                    If controlItem.Tag Is "postInitControl" Then
                        postInitControlCollection.Add(controlItem)
                    End If
                Next
            End If

            'show/hide all controls in postInitControlCollection
            For Each controlItem As Control In postInitControlCollection
                controlItem.Visible = value
            Next
        End Set
    End Property

    Protected WriteOnly Property showViewControlCollection() As Boolean
        Set(ByVal value As Boolean)
            Static initialized As Boolean

            'If viewControlCollection has not been initialized...
            If initialized = False Then

                'instantiate collection
                viewControlCollection = New Collection

                'add all controls that are tagged as viewControl
                For Each controlItem As Control In Me.Controls
                    If controlItem.Tag Is "viewControl" Then
                        viewControlCollection.Add(controlItem)
                    End If
                Next
            End If

            'all controls have been added
            initialized = True

            'show/hide all controls in viewControlCollection
            For Each controlItem As Control In viewControlCollection
                controlItem.Visible = value
            Next

            If value = True Then
                'fill all view control fields with stored data from a seperate DataHandlerClass
                getDataHandlerViewMethod.Invoke(getDataHandlerObject, viewMethodParamaters)
            End If

        End Set
    End Property

    Protected WriteOnly Property showEditControlCollection() As Boolean
        Set(ByVal value As Boolean)
            Static initialized As Boolean

            'If viewControlCollection has not been initialized...
            If initialized = False Then

                'instantiate collection
                editControlCollection = New Collection

                'add all controls that are tagged as editControl
                For Each controlItem As Control In Me.Controls
                    If controlItem.Tag Is "editControl" Then
                        editControlCollection.Add(controlItem)
                    End If
                Next
            End If

            If value = True Then

                Dim ControlTypePattern As New Regex("(TextBox|Label|ComboBox|ListBox)\b")

                'copy viewControlCollection values over to editControlCollection as starting values

                For Each viewControlItem As Control In viewControlCollection
                    For Each editControlItem As Control In editControlCollection

                        Dim viewControlItemControlType As String
                        Dim editControlItemControlType As String
                        Dim viewControlName As String = ""
                        Dim editControlName As String = ""

                        viewControlItemControlType = ControlTypePattern.Match(viewControlItem.Name).ToString()
                        editControlItemControlType = ControlTypePattern.Match(editControlItem.Name).ToString()

                        'strip control type from name of controls prior to comparison
                        viewControlName = ControlTypePattern.Replace(viewControlItem.Name.ToString(), "")
                        viewControlName = viewControlName.Trim()
                        editControlName = ControlTypePattern.Replace(editControlItem.Name.ToString(), "")
                        editControlName = editControlName.Trim()

                        If viewControlName <> "" And editControlName <> "" _
                        And viewControlName = editControlName Then

                            'NEEDS WORK

                            Select Case viewControlItemControlType
                                Case "Label"
                                    Dim viewControl As Label = CType(viewControlItem, Label)

                                    Select Case editControlItemControlType
                                        Case "ComboBox"
                                            Dim editControl As ComboBox = CType(editControlItem, ComboBox)
                                            If editControl.Items.Count = 0 Then
                                                'loop through all Fill Method Names in fillMethodNames() Array and see if any reference
                                                'editControlName
                                                For Each fillMethodName As String In fillMethodNames
                                                    If fillMethodName.Contains(editControlName) Then
                                                        'fill control using fillMethod

                                                    End If
                                                Next
                                            End If

                                        Case "ListBox"
                                            Dim editControl As ListBox = CType(editControlItem, ListBox)
                                            If editControl.Items.Count = 0 Then
                                                'loop through all Fill Method Names in fillMethodNames() Array and see if any reference
                                                'editControlName
                                                For Each fillMethodName As String In fillMethodNames
                                                    If fillMethodName.Contains(editControlName) Then
                                                        'fill control using fillMethod

                                                    End If
                                                Next

                                            End If

                                        Case "TextBox"
                                            Dim editControl As TextBox = CType(editControlItem, TextBox)

                                            editControl.Text = viewControl.Text

                                    End Select
                                Case "TextBox"
                                    Dim viewControl As TextBox = CType(viewControlItem, TextBox)

                                    Select Case editControlItemControlType
                                        Case "ComboBox"
                                            Dim editControl As ComboBox = CType(editControlItem, ComboBox)
                                            If editControl.Items.Count = 0 Then
                                                'loop through all Fill Method Names in fillMethodNames() Array and see if any reference
                                                'editControlName
                                                For Each fillMethodName As String In fillMethodNames
                                                    If fillMethodName.Contains(editControlName) Then
                                                        'fill control using fillMethod

                                                    End If
                                                Next

                                            End If

                                        Case "TextBox"
                                            Dim editControl As TextBox = CType(editControlItem, TextBox)

                                            editControl.Text = viewControl.Text
                                        Case "ListBox"
                                            Dim editControl As ListBox = CType(editControlItem, ListBox)
                                            If editControl.Items.Count = 0 Then
                                                'loop through all Fill Method Names in fillMethodNames() Array and see if any reference
                                                'editControlName
                                                For Each fillMethodName As String In fillMethodNames
                                                    If fillMethodName.Contains(editControlName) Then
                                                        'fill control using fillMethod

                                                    End If
                                                Next

                                            End If

                                    End Select
                                Case "ListBox"
                                    Dim viewControl As ListBox = CType(viewControlItem, ListBox)

                                    Select Case editControlItemControlType
                                        Case "ComboBox"
                                            Dim editControl As ComboBox = CType(editControlItem, ComboBox)

                                            If viewControl.Items.Equals(editControl.Items) = False Then
                                                editControl.Items.Clear()
                                                For Each listBoxItem As Object In viewControl.Items
                                                    editControl.Items.Add(listBoxItem)
                                                Next
                                            End If

                                            editControl.SelectedIndex = viewControl.SelectedIndex

                                        Case "ListBox"
                                            Dim editControl As ListBox = CType(editControlItem, ListBox)

                                            If viewControl.Items.Equals(editControl.Items) = False Then
                                                editControl.Items.Clear()
                                                For Each listBoxItem As Object In viewControl.Items
                                                    editControl.Items.Add(listBoxItem)
                                                Next
                                            End If
                                            editControl.SelectedIndices.Clear()
                                            For Each selectedIndex As Integer In viewControl.SelectedIndices
                                                editControl.SetSelected(selectedIndex, True)
                                            Next

                                    End Select

                            End Select

                        End If

                    Next
                Next
            End If
            'show/hide all controls in editControlCollection
            For Each controlItem As Control In editControlCollection
                controlItem.Visible = value
            Next
        End Set
    End Property

    Protected Sub itemToEditComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles itemToEditComboBox.SelectedIndexChanged

        With itemToEditComboBox
            Select Case .SelectedIndex
                Case Is >= 1
                    'display postInitControlCollection
                    showPostInitControlCollection = True

                    'display viewControlCollection
                    showViewControlCollection = True

                    '<CustomCode>
                    'insert code to update other controls 
                    'based on the selectedIndex of 
                    'itemToEditComboBox(here)
                    '</CustomCode>

                Case 0 'user selected "New..."
                    'hide postInitControlCollection
                    showPostInitControlCollection = False
                    'make itemToEditComboBox editable
                    .DropDownStyle = ComboBoxStyle.DropDown
                    'show add button and make it the default accept button temporarily
                    addButton.Visible = True
                    'set Default Accept Button to addButton temporarily for easy add
                    Me.AcceptButton = addButton

                Case Else
                    'hide postInitControlCollection
                    showPostInitControlCollection = False

            End Select
        End With
    End Sub

    Protected Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Protected Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub addButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addButton.Click
        With itemToEditComboBox

            If .Items.Contains(.Text) = False And .Text <> "" Then
                .Text = .Text.Trim()

                .Items.Add(.Text)
                .SelectedItem = .Text
                .DropDownStyle = ComboBoxStyle.DropDownList
                addButton.Visible = False
                editButton.Visible = True
                'reset default Accept Button to OK_Button
                Me.AcceptButton = OK_Button
                editButton_Click(sender, e)
            End If
        End With
    End Sub

    Private Sub editButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editButton.Click

        Static toggle As Boolean

        'turn on/off edit flag
        toggle = Not toggle

        If toggle = True Then 'edit mode is on

            'editButton's temporary role is a "Done" button until done editing
            editButton.Text = "Do&ne"

            'enable all edit controls
            showEditControlCollection = True

            'disable itemToEditComboBox while in edit mode
            itemToEditComboBox.Enabled = False

        Else 'edit mode is off

            '<CustomCode>
            'Insert code to validate input before allowing user to exit edit mode here
            'i.e. validInput = methodToEvaluateInputFields(inputFieldsArray)
            '</CustomCode>

            If validInput = True Then
                'editButton's role is back to being an "Edit" button
                editButton.Text = "&Edit"

                'disable all edit controls
                showEditControlCollection = False

                'if user has marked item for deletion, remove from itemToEditComboBox
                With itemToEditComboBox
                    Dim deletedItem As String = .SelectedItem.ToString()
                    .SelectedIndex = -1

                    '<CustomCode>
                    'Insert code to remove item in a seperate data location here
                    'i.e. NameOfDataHandlerObject.DeleteItem(deletedItem)
                    '</CustomCode>

                    .Items.Remove(deletedItem)
                End With

                'enable itemToEditComboBox when not in edit mode
                itemToEditComboBox.Enabled = True
            Else 'inputFields are not valid
                'reset back to edit mode
                toggle = Not toggle

                '<CustomCode>
                'Insert code to notify user of which inputfield is invalid using ErrorProvider
                'i.e. ErrorProvider.SetError(controlWhereErrorOccurs, "Error String to show user")
                '</CustomCode>

            End If

        End If

    End Sub

    Private Sub deleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteButton.Click
        'toggle between delete and undo delete
        pendingDelete = Not pendingDelete

        If pendingDelete = True Then
            deleteButton.Text = "&Undo"
        Else 'not marked for deletion
            deleteButton.Text = "&Delete"
        End If
    End Sub

    Private Sub editFormClass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
