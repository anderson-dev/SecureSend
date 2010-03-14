Imports SecureSyncWrapper.TapeDataTypes
Imports System.Text.RegularExpressions

''' <summary>
''' Keeps track of all data processes (data integrity, adds, updates, and deletes)
''' This class instantiates subclasses of ComboBoxInterfaceClass and ListBoxInterfaceClass
''' These are defined in TapeDataHandlerInterfaceClasses.vb
''' 
''' FileIO processes are defined in TapeDataHandlerFileIO.vb which is part of this class
''' </summary>
''' <remarks></remarks>
Partial Public Class TapeDataHandlerClass

    Friend snValidator As snValidatorClass

    Public Event IsAllowedToScan(ByVal allowed2scan As Boolean)
    Public Event IsAllowedToSend(ByVal allowed2send As Boolean)

    Protected backupTypes As New List(Of BackupTypeStruct)
    Protected backupTypesRestorePoint As New List(Of BackupTypeStruct)
    Protected snRules As New List(Of snRuleStruct)
    Protected snRulesRestorePoint As New List(Of snRuleStruct)

    Protected tape As TapeStruct
    Protected tapeList As New List(Of TapeStruct)

    Protected tapesAddedCounter As Integer

    ' Declare an EventLog for logging all important and critical events
    'including specific arguments and methods that caused them
    Protected ApplicationEventLog As New EventLog("SecureSyncWrapper")

    Public Sub New(ByVal CentralFilePathSetting As String)

        'set the source of the ApplicationEventLog to current Class.Method
        ApplicationEventLog.Source = "TapeDataHandlerClass.New"

        'determine centralFilePath
        centralFilePath = CentralFilePathSetting

        'verify that all directories exist and set the fileQueue & fileLog directory locations
        FilePathChecker()

        'load snRules
        ReadInExistingSNrules()

        'load backupTypes
        ReadInExistingBackupTypes()

        'instantiate snValidatorClass object to validate input data at the Form level
        snValidator = New snValidatorClass(backupTypes.ToArray(), snRules.ToArray())

    End Sub

    Friend Sub CreateSNRulesRestorePoint()
        snRulesRestorePoint = snRules
    End Sub

    Friend Sub RevertToSNRulesRestorePoint()
        snRules = snRulesRestorePoint
    End Sub

    Friend Sub AddUpdateSNRule(ByVal newSNRule As snRuleStruct)

        Dim findIndex As Integer = -1

        If snRules.Count >= 1 Then
            For snRuleCounter As Integer = 0 To snRules.Count - 1
                If snRules(snRuleCounter).snRuleName = newSNRule.snRuleName Then
                    findIndex = snRuleCounter
                    Exit For
                End If
            Next
        End If

        If findIndex <> -1 Then
            snRules.RemoveAt(findIndex)
            snRules.Insert(findIndex, newSNRule)
        Else
            snRules.Add(newSNRule)
        End If

    End Sub

    Friend Sub CreateBackupTypesRestorePoint()
        backupTypesRestorePoint = backupTypes
    End Sub

    Friend Sub RevertToBackupTypesRestorePoint()
        backupTypes = backupTypesRestorePoint
    End Sub

    Friend Sub AddUpdateBackupType(ByVal newBackupType As BackupTypeStruct)

        Dim findIndex As Integer = -1

        If backupTypes.Count >= 1 Then
            For backupTypeCounter As Integer = 0 To backupTypes.Count - 1
                If backupTypes(backupTypeCounter).backupTypeName = newBackupType.backupTypeName Then
                    findIndex = backupTypeCounter
                    Exit For
                End If
            Next
        End If

        If findIndex <> -1 Then
            backupTypes.RemoveAt(findIndex)
            backupTypes.Insert(findIndex, newBackupType)
        Else
            backupTypes.Add(newBackupType)
        End If
    End Sub

    Friend Sub DeleteSNrule(ByVal existingSNRuleName As String)
        For counter As Integer = 0 To backupTypes.Count - 1
            If snRules(counter).snRuleName = existingSNRuleName Then
                snRules.RemoveAt(counter)
                Exit For
            End If
        Next
    End Sub

    Friend Sub DeleteBackupType(ByVal existingBackupTypeName As String)

        For counter As Integer = 0 To backupTypes.Count - 1
            If backupTypes(counter).backupTypeName = existingBackupTypeName Then
                backupTypes.RemoveAt(counter)
                Exit For
            End If
        Next
    End Sub

    Public Function AddTape(ByVal backupTypeName As String, ByVal backupDate As Date, _
ByVal SN As String) As Boolean

        If backupTypeName <> "" And SN <> "" Then
            '//determine backupType
            For counter As Integer = 0 To backupTypes.Count - 1
                If backupTypes(counter).backupTypeName = backupTypeName Then
                    'store tape data
                    tape.backupTypeName = backupTypeName
                    tape.backupDate = backupDate
                    tape.SN = SN
                    tapeList.Add(tape)
                    'increment tapeCounter variable
                    tapesAddedCounter += 1

                    'indicate as ready to send as soon as 1 valid tape is added
                    If tapesAddedCounter = 1 Then DetermineIfSendIsAllowed()

                    'tell other programs that function was successful
                    Return True

                    Exit For
                Else
                    'continue through loop
                End If
            Next
        Else '//function was called with Null input
            Throw New ArgumentNullException("backupTypeName or SN was an empty string.")
        End If

    End Function

    Public Function QueueForSend() As Boolean

        'determine if there is anything to send
        DetermineIfSendIsAllowed()

        Dim tapeListByBackupType(backupTypes.Count - 1, tapeList.Count - 1) As TapeStruct
        Dim arrayNavigatorCounter(backupTypes.Count - 1) As Integer

        'seperate tapeList by backupType
        For backupTypeCounter As Integer = 0 To backupTypes.Count - 1

            For tapeCounter As Integer = 0 To tapeList.Count - 1
                If tapeList(tapeCounter).backupTypeName = backupTypes(backupTypeCounter).backupTypeName Then
                    'make sure counter doesn't reference an array index that doesn't exist
                    If arrayNavigatorCounter(backupTypeCounter) <= tapeList.Count - 1 Then
                        'store tape info to a new corresponding backupType array
                        tapeListByBackupType(backupTypeCounter, _
                        arrayNavigatorCounter(backupTypeCounter)) = _
                        tapeList(tapeCounter)

                        'increment arrayNavigatorCounter
                        arrayNavigatorCounter(backupTypeCounter) += 1

                    Else 'too many tapes per backupType
                        Return False
                    End If

                Else 'backupType does not match...
                    'continue through loop
                End If
            Next
        Next

        SaveTapesToFile(tapeListByBackupType, arrayNavigatorCounter)

        SaveInventoryChanges()

    End Function

    Friend Sub DetermineIfScanIsAllowed()

        If snRules.Count >= 1 And backupTypes.Count >= 1 Then
            RaiseEvent IsAllowedToScan(True)
        Else
            RaiseEvent IsAllowedToScan(False)
        End If

    End Sub

    Friend Sub DetermineIfSendIsAllowed()
        Dim ok2Send As Boolean
        ''/* Debug Module
        'RaiseEvent IsAllowedToSend(True)
        ''*/ End Debug Module

        'check to see if is a valid time to send...
        If Date.Now.DayOfWeek = DayOfWeek.Saturday Or Date.Now.DayOfWeek = DayOfWeek.Sunday Then
            ok2Send = False
        ElseIf Date.Now.DayOfWeek = DayOfWeek.Friday And Date.Now.Hour >= 15 Then
            ok2Send = False
        Else
            ok2Send = True
        End If


        If ok2Send = True Then

            'check to see if any tapes are waiting to be sent
            Dim something2send As Boolean = IsThereSomethingToSend()

            'check to see if any tapes have been successfully entered
            If tapesAddedCounter >= 1 Then something2send = True

            If something2send = True Then
                RaiseEvent IsAllowedToSend(True)
            Else
                RaiseEvent IsAllowedToSend(False)
            End If
        Else
            Debug.WriteLine("Cannot Send Wrong Day")
            RaiseEvent IsAllowedToSend(False)
        End If
    End Sub

End Class
