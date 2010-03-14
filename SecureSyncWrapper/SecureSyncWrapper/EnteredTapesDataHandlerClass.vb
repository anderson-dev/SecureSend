Imports System.IO
Imports SecureSyncWrapper.TapeDataTypes

Public Class EnteredTapesDataHandlerClass

    Public Event IsAllowedToSend(ByVal allowed2send As Boolean)

    Protected tape As TapeStruct
    Protected tapeList As New List(Of TapeStruct)
    Protected tapeListByBackupType(,) As TapeStruct

    Protected tapesAddedCounter As Integer

    Protected backupTypes() As String
    Protected arrayNavigatorCounter() As Integer

    Protected tapeFileList As New List(Of TapeFileStruct)
    Protected fileQueuePath As String = "I:\Common\Applications\SecureSyncWrapper\Queue\"
    Protected fileLogPath As String = "I:\Common\Applications\SecureSyncWrapper\Log\"

    Public Sub New(ByVal typesOfBackups() As String)

        'store backupTypes for reference, only initially declared backupTypes
        'can be used in AddTape method
        backupTypes = typesOfBackups

        'make sure filepaths are ready and available for use
        FilePathChecker()

    End Sub

    Public Sub New(ByVal typesOfBackups() As String, ByVal setFileQueuePath As String, ByVal setFileLogPath As String)

        backupTypes = typesOfBackups

        fileQueuePath = setFileQueuePath
        fileLogPath = setFileLogPath

        'make sure filepaths are ready and available for use
        FilePathChecker()

    End Sub

    Protected Function FilePathChecker() As Boolean

        ' /* Make sure directories are specified with trailing "\"
        If Not fileQueuePath.EndsWith("\") Then fileQueuePath &= "\"

        If Not fileLogPath.EndsWith("\") Then fileLogPath &= "\"
        '*/ End Make sure directories end with trailing "\"

        'check to make sure that all directories exist, if not create them
        With My.Computer.FileSystem

            Dim driveLetterFromString As String
            driveLetterFromString = fileQueuePath.Substring(0, 1) 'extract drive from filepath string

            'find out if drive is available
            Dim driveInfo As DriveInfo
            driveInfo = My.Computer.FileSystem.GetDriveInfo(driveLetterFromString)
            If driveInfo.IsReady = True Then
                'if fileQueuePath does not exist, create it
                If Not .DirectoryExists(fileQueuePath) Then _
                .CreateDirectory(fileQueuePath)
                'if fileLogPath does not exist, create it
                If Not .DirectoryExists(fileLogPath) Then _
                .CreateDirectory(fileLogPath)
            Else 'drive is unavailable
                Debug.WriteLine("Drive is unavailable")
            End If

        End With
    End Function

    Public Function AddTape(ByVal backupType As String, ByVal backupDate As Date, _
    ByVal SN As String) As Boolean

        If backupType <> "" And SN <> "" Then
            '//determine backupType
            For counter As Integer = 0 To backupTypes.Length - 1
                If backupTypes(counter) = backupType Then
                    'store tape data
                    tape.backupType = backupType
                    tape.backupDate = backupDate
                    tape.SN = SN
                    tapeList.Add(tape)
                    'increment tapeCounter variable
                    tapesAddedCounter += 1

                    'indicate as ready to send as soon as 1 valid tape is added
                    If tapesAddedCounter = 1 Then IsSendAllowed()

                    'tell other programs that function was successful
                    Return True

                    Exit For
                Else
                    'continue through loop
                End If
            Next
        Else '//function was called with Null input
            Return False
        End If

    End Function

    Public Function QueueForSend() As Boolean

        'determine if there is anything to send
        IsSendAllowed()

        ReDim tapeListByBackupType(backupTypes.Length - 1, tapeList.Count - 1)
        ReDim arrayNavigatorCounter(backupTypes.Length - 1)

        'seperate tapeList by backupType
        For backupTypeCounter As Integer = 0 To backupTypes.Length - 1

            For tapeCounter As Integer = 0 To tapeList.Count - 1
                If tapeList(tapeCounter).backupType = backupTypes(backupTypeCounter) Then
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

        SaveTapes()

        'using default setFileQueuePath and fileLogPath locations
    End Function

    Protected Function SaveTapes() As Boolean

        Dim fileName As String

        For backupTypeCounter As Integer = 0 To backupTypes.Length - 1
            For tapeCounter As Integer = 0 To arrayNavigatorCounter(backupTypeCounter) - 1

                With tapeListByBackupType(backupTypeCounter, tapeCounter)

                    If .SN <> "" Then

                        Select Case .backupType
                            Case "Primary Audits"
                                Dim fridaysDate As Date = .backupDate

                                While fridaysDate.DayOfWeek <> DayOfWeek.Friday

                                    fridaysDate = DateAdd(DateInterval.Day, 1, fridaysDate)

                                End While
                                fileName = _
                                .backupType & " - " & "week ending " & fridaysDate.ToString("MMddyy") & ".txt"

                                Dim queueFilePrimaryAudits As New StreamWriter(fileQueuePath & fileName, True)
                                queueFilePrimaryAudits.WriteLine(.SN.ToString())
                                queueFilePrimaryAudits.Close()

                                'record to log file
                                Dim logFilePrimaryAudits As New StreamWriter(fileLogPath & .backupType.ToString() & ".txt", True)
                                logFilePrimaryAudits.Write(.SN.ToString())
                                logFilePrimaryAudits.Write(", ")
                                logFilePrimaryAudits.WriteLine(.backupDate.ToString("d"))
                                logFilePrimaryAudits.Close()

                            Case "Secondary Audits"
                                Dim fridaysDate As Date = .backupDate

                                While fridaysDate.DayOfWeek <> DayOfWeek.Friday

                                    fridaysDate = DateAdd(DateInterval.Day, 1, fridaysDate)

                                End While
                                fileName = .backupType & _
                                " - " & "week ending " & fridaysDate.ToString("MMddyy") & ".txt"

                                Dim queueFileSecondaryAudits As New StreamWriter(fileQueuePath & fileName, True)
                                queueFileSecondaryAudits.WriteLine(.SN.ToString())
                                queueFileSecondaryAudits.Close()

                                'record to log file
                                Dim logFileSecondaryAudits As New StreamWriter(fileLogPath & .backupType.ToString() & ".txt", True)
                                logFileSecondaryAudits.Write(.SN.ToString())
                                logFileSecondaryAudits.Write(", ")
                                logFileSecondaryAudits.WriteLine(.backupDate.ToString("d"))
                                logFileSecondaryAudits.Close()

                            Case Else

                                fileName = .backupType & " - " & .backupDate.ToString("MMddyy") & ".txt"

                                Dim queueFileOther As New StreamWriter(fileQueuePath & fileName, True)
                                queueFileOther.WriteLine(.SN.ToString())
                                queueFileOther.Close()

                                Dim logFileOther As New StreamWriter(fileLogPath & .backupType.ToString() & ".txt", True)
                                logFileOther.Write(.SN.ToString())
                                logFileOther.Write(", ")
                                logFileOther.WriteLine(.backupDate.ToString("d"))
                                logFileOther.Close()

                        End Select

                    Else 'no tape was entered
                        Exit For 'skip to next backupType
                    End If
                End With

            Next
        Next

    End Function

    Friend Function GetListOfTapesToSend() As List(Of TapeFileStruct)

        Dim stringManip() As String
        Dim stringManipHelper() As String

        With My.Computer.FileSystem
            Dim fileList As Collections.ObjectModel.ReadOnlyCollection(Of String)
            'get list of all files pending
            fileList = .GetFiles(fileQueuePath)

            'store appropriate tape information into tapeFileList
            For Counter As Integer = 0 To fileList.Count - 1
                Dim tapeFile As TapeFileStruct
                tapeFile.fileName = fileList(Counter).ToString
                stringManip = fileList(Counter).Split("-"c)
                stringManip(0) = stringManip(0).Trim()
                stringManip(1) = stringManip(1).Trim()
                stringManipHelper = stringManip(0).Split("\"c)
                stringManip(0) = stringManipHelper(stringManipHelper.Length - 1)
                tapeFile.backupType = stringManip(0)
                ReDim stringManipHelper(1)

                If stringManip(1).Contains("week ending") Then
                    stringManipHelper(0) = "week ending"
                Else
                    stringManipHelper(0) = ""
                End If

                stringManipHelper(1) = stringManip(1).Substring(stringManip(1).Length - 10, 10)
                stringManipHelper(1) = stringManipHelper(1).Remove(stringManipHelper(1).Length - 4, 4)
                stringManipHelper(1) = stringManipHelper(1).Insert(2, "/")
                stringManipHelper(1) = stringManipHelper(1).Insert(5, "/")
                tapeFile.backupDate = stringManipHelper(1)
                tapeFile.backupDescription = stringManip(0) & " - " & stringManipHelper(0) & " " & stringManipHelper(1)

                tapeFileList.Add(tapeFile)

            Next
        End With
        Return tapeFileList
    End Function

    Friend Sub IsSendAllowed()
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

            Dim something2send As Boolean

            'check to see if any tapes have been successfully entered
            If tapesAddedCounter >= 1 Then something2send = True

            'check to see if any tapes are waiting to be sent in the queue
            With My.Computer.FileSystem
                Dim fileCounter As Collections.ObjectModel.ReadOnlyCollection(Of String)

                fileCounter = .GetFiles(fileQueuePath) '//get number of files in directory
                Debug.WriteLine(fileCounter.Count, "Pending Files in Queue")
                If fileCounter.Count >= 1 Then
                    something2send = True
                End If

            End With

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
