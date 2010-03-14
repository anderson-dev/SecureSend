Imports System.Text.RegularExpressions

Public Class TapeDataTypes

    <Serializable()> Structure BackupTypeStruct
        Private m_defaultReturnDateType As BackupTypeStruct.ReturnDateType
        Friend backupTypeName As String
        Friend validSNformats() As String
        Private defaultReturnDateInterval As DateInterval
        Private defaultReturnDateMultiplier As Integer
        Private defaultReturnDateDayOfWeek As DayOfWeek

        Private Enum ReturnDateType
            NumberOfDays
            NextOccuringSpecifiedDayOfWeek
        End Enum

        ''' <summary>
        ''' Gets or Sets the Default Return Date Type
        ''' </summary>
        ''' <value>ReturnDateType Constant</value>
        ''' <returns>
        ''' ReturnDateType Constant representing type of Return Date</returns>
        ''' <remarks></remarks>
        Private Property DefaultReturnDateType() As BackupTypeStruct.ReturnDateType
            Get
                Return m_defaultReturnDateType
            End Get
            Set(ByVal value As BackupTypeStruct.ReturnDateType)
                m_defaultReturnDateType = value
            End Set
        End Property

        Friend ReadOnly Property DefaultReturnDate() As Date
            Get
                Select Case DefaultReturnDateType
                    Case ReturnDateType.NumberOfDays
                        Return DateAdd(defaultReturnDateInterval, defaultReturnDateMultiplier, Date.Now)
                    Case ReturnDateType.NextOccuringSpecifiedDayOfWeek
                        Dim nextOccuringSpecifiedDayOfWeek As Date = Date.Now
                        While nextOccuringSpecifiedDayOfWeek.DayOfWeek <> defaultReturnDateDayOfWeek
                            nextOccuringSpecifiedDayOfWeek = DateAdd(DateInterval.Day, 1, nextOccuringSpecifiedDayOfWeek)
                        End While
                        Return nextOccuringSpecifiedDayOfWeek
                End Select
            End Get
        End Property

        Friend Sub SetDefaultReturnDateRule(ByVal ReturnDateInterval As DateInterval, ByVal NumberOfDateIntervals As Integer)
            DefaultReturnDateType = ReturnDateType.NumberOfDays
            defaultReturnDateInterval = ReturnDateInterval
            defaultReturnDateMultiplier = NumberOfDateIntervals
        End Sub

        Friend Sub SetDefaultReturnDateRule(ByVal NextOccuringDayOfWeek As DayOfWeek, ByVal InclusiveOfCurrentWeek As Boolean)
            DefaultReturnDateType = ReturnDateType.NextOccuringSpecifiedDayOfWeek
            defaultReturnDateDayOfWeek = NextOccuringDayOfWeek
        End Sub

        Friend Sub SetDefaultReturnDateRule(ByVal NextOccuringDayOfWeek As DayOfWeek, ByVal InclusiveOfCurrentWeek As Boolean, ByVal NumberOfNextOccuringDayOfWeek As Integer)
            Dim dayOfWeekMatchCounter As Integer
            Dim daysuntilReturnDate As Integer
            Dim dayCounter As Date = Date.Now

            DefaultReturnDateType = ReturnDateType.NumberOfDays

            While dayOfWeekMatchCounter <> NumberOfNextOccuringDayOfWeek

                dayCounter = DateAdd(DateInterval.Day, 1, dayCounter)
                daysuntilReturnDate += 1
                If dayCounter.DayOfWeek = NextOccuringDayOfWeek Then
                    dayOfWeekMatchCounter += 1
                End If
            End While

            defaultReturnDateInterval = DateInterval.Day
            defaultReturnDateMultiplier = daysuntilReturnDate
        End Sub

    End Structure

    <Serializable()> Structure snRuleStruct
        Dim snRuleName As String
        Dim snRuleTextLength As Integer
        Dim snRegExPattern As Regex
    End Structure

    <Serializable()> Structure TapeStruct
        Dim backupTypeName As String
        Dim backupDate As Date
        Dim SN As String
    End Structure

    <Serializable()> Structure TapeFileStruct
        Dim fileName As String
        Dim backupDescription As String
        Dim backupTypeName As String
        Dim backupDate As String
    End Structure

    <Serializable()> Structure TapeInventoryStruct
        Dim SN As String
        Dim checkedOut As Boolean
        Dim returnDate As Date
    End Structure

End Class