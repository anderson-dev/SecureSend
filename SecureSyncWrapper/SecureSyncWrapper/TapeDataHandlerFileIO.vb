Imports System.IO
Imports System.Xml
Imports SecureSyncWrapper.TapeDataTypes

' Note: When building this code, you must reference the
' System.Runtime.Serialization.Formatters.Soap.dll assembly.
Imports System.Runtime.Serialization.Formatters.Soap

Partial Public Class TapeDataHandlerClass

    Protected centralFilePath As String = "I:\Common\Applications\SecureSyncWrapper\"
    Protected fileQueuePath As String = "I:\Common\Applications\SecureSyncWrapper\Queue\"
    Protected fileLogPath As String = "I:\Common\Applications\SecureSyncWrapper\Log\"

    Protected Shared tapeInventory As New ArrayList
    Protected tapeInventoryBuilder As New TapeInventoryStruct

    Protected Sub FilePathChecker()

        ' /* Make sure directories are specified without trailing "\"

        If centralFilePath.EndsWith("\") Then centralFilePath = centralFilePath.Remove(centralFilePath.Length - 1, 1)

        'set fileQueuePath and fileLogPath
        fileQueuePath = centralFilePath & "\Queue"
        fileLogPath = centralFilePath & "\Log"
        'check to make sure that all directories exist, if not create them
        With My.Computer.FileSystem

            'find out if drive is available

            'parse the centralFilePath string to determine which drive was selected
            Dim driveLetterFromString(0) As Char
            driveLetterFromString = centralFilePath.ToCharArray(0, 1)

            If Char.IsLetter(Char.Parse(driveLetterFromString(0))) = True Then

                Dim driveInfo As DriveInfo
                driveInfo = My.Computer.FileSystem.GetDriveInfo(driveLetterFromString)
                If driveInfo.IsReady = True Then
                    Try
                        'if fileQueuePath does not exist, create it
                        If Not .DirectoryExists(fileQueuePath) Then _
                        .CreateDirectory(fileQueuePath)
                    Catch
                        ApplicationEventLog.WriteEntry("Unable To Create Directory at:  " & ControlChars.Quote _
                        & fileQueuePath & ControlChars.Quote, EventLogEntryType.Error)
                    End Try
                    Try
                        'if fileLogPath does not exist, create it
                        If Not .DirectoryExists(fileLogPath) Then _
                        .CreateDirectory(fileLogPath)
                    Catch
                        ApplicationEventLog.WriteEntry("Unable To Create Directory at:  " & ControlChars.Quote _
                        & fileLogPath & ControlChars.Quote, EventLogEntryType.Error)
                    End Try

                Else 'drive is unavailable
                    ApplicationEventLog.WriteEntry("Drive " & ControlChars.Quote & driveLetterFromString _
                    & ControlChars.Quote & " is unavailable.", EventLogEntryType.Warning)
                End If
            End If

        End With
    End Sub

    Protected Function ReadInExistingSNrules() As Boolean
        'attempts to read in exisiting backupTypes from a file stored in sharedNetPath called:
        'BackupTypes.xml

        Try
            Dim snRulesFileStream As New FileStream(centralFilePath & "\snRules.xml", FileMode.Open)
            Dim snRulesDeSerializer As New SoapFormatter
            Dim conversionArray() As snRuleStruct

            conversionArray = CType(snRulesDeSerializer.Deserialize(snRulesFileStream), snRuleStruct())
            snRulesFileStream.Close()

            'convert static array to dynamic list
            For counter As Integer = 0 To conversionArray.Length - 1
                snRules.Add(conversionArray(counter))
            Next
        Catch serializationError As Runtime.Serialization.SerializationException
            ApplicationEventLog.WriteEntry("snRules.xml was not in an expected format", EventLogEntryType.Error)
        Catch fileNotFoundError As FileNotFoundException
            ApplicationEventLog.WriteEntry("snRules.xml could not be found in the directory of " & ControlChars.Quote _
            & centralFilePath & ControlChars.Quote, EventLogEntryType.Warning)
        End Try

    End Function

    Friend Sub SaveSNRules()

        'convert dynamic list to static array
        Dim conversionArray(snRules.Count - 1) As snRuleStruct
        For counter As Integer = 0 To conversionArray.Length - 1
            conversionArray(counter) = snRules(counter)
        Next

        Dim snRulesFileStream As New FileStream(centralFilePath & "\snRules.xml", FileMode.Create)
        Dim snRulesSerializer As New SoapFormatter
        snRulesSerializer.Serialize(snRulesFileStream, conversionArray)
        snRulesFileStream.Close()
    End Sub

    Protected Sub ReadInExistingBackupTypes()
        'attempts to read in exisiting backupTypes from a file stored in sharedNetPath called:
        'BackupTypes.xml

        Try
            Dim backupTypesFileStream As New FileStream(centralFilePath & "\BackupTypes.xml", FileMode.Open)
            Dim backupTypesDeSerializer As New SoapFormatter
            Dim tempArray() As BackupTypeStruct

            tempArray = CType(backupTypesDeSerializer.Deserialize(backupTypesFileStream), BackupTypeStruct())
            backupTypesFileStream.Close()

            For Each backupTypeItem As BackupTypeStruct In tempArray
                backupTypes.Add(backupTypeItem)
            Next

        Catch serializationError As Runtime.Serialization.SerializationException
            ApplicationEventLog.WriteEntry("BackupTypes.xml was not in an expected format", EventLogEntryType.Error)
        Catch fileNotFoundError As FileNotFoundException
            ApplicationEventLog.WriteEntry("BackupTypes.xml could not be found in the directory of " & ControlChars.Quote _
            & centralFilePath & ControlChars.Quote, EventLogEntryType.Warning)
        End Try

    End Sub

    Friend Sub SaveBackupTypes()

        'convert dynamic list to static array
        Dim conversionArray(backupTypes.Count - 1) As BackupTypeStruct
        For counter As Integer = 0 To conversionArray.Length - 1
            conversionArray(counter) = backupTypes(counter)
        Next

        Dim backupTypesFileStream As New FileStream(centralFilePath & "\BackupTypes.xml", FileMode.Create)
        Dim backupTypesSerializer As New SoapFormatter
        backupTypesSerializer.Serialize(backupTypesFileStream, conversionArray)
        backupTypesFileStream.Close()
    End Sub

    Protected Function IsThereSomethingToSend() As Boolean

        'check to see if any tapes are waiting to be sent in the queue
        With My.Computer.FileSystem
            If .DirectoryExists(fileQueuePath) = True Then
                Dim fileCounter As Collections.ObjectModel.ReadOnlyCollection(Of String)

                fileCounter = .GetFiles(fileQueuePath) '//get number of files in directory
                Debug.WriteLine(fileCounter.Count, "Pending Files in Queue")
                If fileCounter.Count >= 1 Then
                    Return True
                Else
                    Return False
                End If
            Else 'directory not found
                'Error Log Needed
            End If
        End With
    End Function

    Protected Function SaveTapesToFile(ByRef tapeListByBackupType(,) As TapeStruct, ByRef arrayNavigatorCounter() As Integer) As Boolean

        Dim fileName As String

        For backupTypeCounter As Integer = 0 To backupTypes.Count - 1
            For tapeCounter As Integer = 0 To arrayNavigatorCounter(backupTypeCounter) - 1

                With tapeListByBackupType(backupTypeCounter, tapeCounter)

                    If .SN <> "" Then

                        Select Case .backupTypeName
                            Case "Primary Audits"
                                Dim fridaysDate As Date = .backupDate

                                While fridaysDate.DayOfWeek <> DayOfWeek.Friday

                                    fridaysDate = DateAdd(DateInterval.Day, 1, fridaysDate)
                                End While
                                fileName = _
                                .backupTypeName & " - " & "week ending " & fridaysDate.ToString("MMddyy") & ".txt"

                                Dim queueFilePrimaryAudits As New StreamWriter(fileQueuePath & "\" & fileName, True)
                                queueFilePrimaryAudits.WriteLine(.SN.ToString())
                                queueFilePrimaryAudits.Close()

                                'record to log file
                                Dim logFilePrimaryAudits As New StreamWriter(fileLogPath & "\" & .backupTypeName & ".txt", True)
                                logFilePrimaryAudits.Write(.SN.ToString())
                                logFilePrimaryAudits.Write(", ")
                                logFilePrimaryAudits.WriteLine(.backupDate.ToString("d"))
                                logFilePrimaryAudits.Close()

                                'record in inventory
                                If tapeInventory IsNot Nothing Then
                                    Dim found As Boolean
                                    For Each tapeInventoryItem As TapeInventoryStruct In tapeInventory
                                        If tapeInventoryItem.SN = .SN Then
                                            found = True
                                            tapeInventoryItem.checkedOut = True
                                            'tapeInventoryItem.returnDate = Next
                                        End If
                                    Next
                                    If found = False Then
                                        tapeInventoryBuilder.SN = .SN
                                        tapeInventoryBuilder.checkedOut = True
                                        'tapeInventoryBuilder.returnDate = 
                                        tapeInventory.Add(tapeInventoryBuilder)
                                    End If
                                Else 'first entry
                                    tapeInventoryBuilder.SN = .SN
                                    tapeInventoryBuilder.checkedOut = True
                                    'tapeInventoryBuilder.returnDate = 
                                    tapeInventory.Add(tapeInventoryBuilder)
                                End If

                            Case "Secondary Audits"
                                Dim fridaysDate As Date = .backupDate

                                While fridaysDate.DayOfWeek <> DayOfWeek.Friday

                                    fridaysDate = DateAdd(DateInterval.Day, 1, fridaysDate)

                                End While
                                fileName = .backupTypeName & _
                                " - " & "week ending " & fridaysDate.ToString("MMddyy") & ".txt"

                                Dim queueFileSecondaryAudits As New StreamWriter(fileQueuePath & "\" & fileName, True)
                                queueFileSecondaryAudits.WriteLine(.SN.ToString())
                                queueFileSecondaryAudits.Close()

                                'record to log file
                                Dim logFileSecondaryAudits As New StreamWriter(fileLogPath & "\" & .backupTypeName & ".txt", True)
                                logFileSecondaryAudits.Write(.SN.ToString())
                                logFileSecondaryAudits.Write(", ")
                                logFileSecondaryAudits.WriteLine(.backupDate.ToString("d"))
                                logFileSecondaryAudits.Close()

                                'record in inventory
                                If tapeInventory IsNot Nothing Then
                                    Dim found As Boolean
                                    For Each tapeInventoryItem As TapeInventoryStruct In tapeInventory
                                        If tapeInventoryItem.SN = .SN Then
                                            found = True
                                            tapeInventoryItem.checkedOut = True
                                            'tapeInventoryItem.returnDate = Next
                                        End If
                                    Next
                                    If found = False Then
                                        tapeInventoryBuilder.SN = .SN
                                        tapeInventoryBuilder.checkedOut = True
                                        'tapeInventoryBuilder.returnDate = 
                                        tapeInventory.Add(tapeInventoryBuilder)
                                    End If
                                Else 'first entry
                                    tapeInventoryBuilder.SN = .SN
                                    tapeInventoryBuilder.checkedOut = True
                                    'tapeInventoryBuilder.returnDate = 
                                    tapeInventory.Add(tapeInventoryBuilder)
                                End If

                            Case Else

                                fileName = .backupTypeName & " - " & .backupDate.ToString("MMddyy") & ".txt"

                                Dim queueFileOther As New StreamWriter(fileQueuePath & "\" & fileName, True)
                                queueFileOther.WriteLine(.SN.ToString())
                                queueFileOther.Close()

                                Dim logFileOther As New StreamWriter(fileLogPath & "\" & .backupTypeName & ".txt", True)
                                logFileOther.Write(.SN.ToString())
                                logFileOther.Write(", ")
                                logFileOther.WriteLine(.backupDate.ToString("d"))
                                logFileOther.Close()

                                'record in inventory
                                If tapeInventory IsNot Nothing Then
                                    Dim found As Boolean
                                    For Each tapeInventoryItem As TapeInventoryStruct In tapeInventory
                                        If tapeInventoryItem.SN = .SN Then
                                            found = True
                                            tapeInventoryItem.checkedOut = True
                                            'tapeInventoryItem.returnDate = Next
                                        End If
                                    Next
                                    If found = False Then
                                        tapeInventoryBuilder.SN = .SN
                                        tapeInventoryBuilder.checkedOut = True
                                        'tapeInventoryBuilder.returnDate = 
                                        tapeInventory.Add(tapeInventoryBuilder)
                                    End If
                                Else 'first entry
                                    tapeInventoryBuilder.SN = .SN
                                    tapeInventoryBuilder.checkedOut = True
                                    'tapeInventoryBuilder.returnDate = 
                                    tapeInventory.Add(tapeInventoryBuilder)
                                End If

                        End Select

                    Else 'no tape was entered
                        Exit For 'skip to next backupType
                    End If
                End With

            Next
        Next

    End Function

    Protected Sub SaveInventoryChanges()

        Dim inventoryFileStream As New FileStream(centralFilePath & "\inventory.xml", FileMode.Create)
        Dim inventorySerializer As New SoapFormatter
        inventorySerializer.Serialize(inventoryFileStream, tapeInventory)
        inventoryFileStream.Close()

    End Sub

    'Friend Function GetListOfTapesToSend() As List(Of TapeFileStruct)

    '    Dim stringManip() As String
    '    Dim stringManipHelper() As String

    '    With My.Computer.FileSystem
    '        Dim fileList As Collections.ObjectModel.ReadOnlyCollection(Of String)
    '        'get list of all files pending
    '        fileList = .GetFiles(fileQueuePath)

    '        'store appropriate tape information into tapeFileList
    '        For Counter As Integer = 0 To fileList.Count - 1
    '            Dim tapeFile As TapeFileStruct
    '            tapeFile.fileName = fileList(Counter).ToString
    '            stringManip = fileList(Counter).Split("-"c)
    '            stringManip(0) = stringManip(0).Trim()
    '            stringManip(1) = stringManip(1).Trim()
    '            stringManipHelper = stringManip(0).Split("\"c)
    '            stringManip(0) = stringManipHelper(stringManipHelper.Length - 1)
    '            tapeFile.backupTypeName = stringManip(0)
    '            ReDim stringManipHelper(1)

    '            If stringManip(1).Contains("week ending") Then
    '                stringManipHelper(0) = "week ending"
    '            Else
    '                stringManipHelper(0) = ""
    '            End If

    '            stringManipHelper(1) = stringManip(1).Substring(stringManip(1).Length - 10, 10)
    '            stringManipHelper(1) = stringManipHelper(1).Remove(stringManipHelper(1).Length - 4, 4)
    '            stringManipHelper(1) = stringManipHelper(1).Insert(2, "/")
    '            stringManipHelper(1) = stringManipHelper(1).Insert(5, "/")
    '            tapeFile.backupDate = stringManipHelper(1)
    '            tapeFile.backupDescription = stringManip(0) & " - " & stringManipHelper(0) & " " & stringManipHelper(1)

    '            tapeFileList.Add(tapeFile)

    '        Next
    '    End With
    '    Return tapeFileList
    'End Function
End Class
