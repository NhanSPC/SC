Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports pbs.BO.Script

Namespace SC

    Public Class WOAgingOverdue
        Implements IQueryBO
        Implements ISupportScripts


#Region "IInfo"
        Class WorkOrderAging

            Implements IInfo

            Property WoId() As String
            Property WoType() As String
            Property WoStatus() As String
            Property ReferenceNo() As String
            Property ClientName() As String
            Property WoDate() As SmartDate
            Property WoDueDate() As SmartDate
            Property Band_01 As Decimal
            Property Band_02 As Decimal
            Property Band_03 As Decimal
            Property Band_04 As Decimal
            Property Band_05 As Decimal

            Public _overdueDay As Integer
            ReadOnly Property OverdueDay As Decimal
                Get
                    Return _overdueDay
                End Get
            End Property

            Public ReadOnly Property Code As String Implements IInfo.Code
                Get
                    Return WoId
                End Get
            End Property

            Public ReadOnly Property Description As String Implements IInfo.Description
                Get
                    Return WoId
                End Get
            End Property

            Public Sub InvalidateCache() Implements IInfo.InvalidateCache

            End Sub

            Public ReadOnly Property LookUp As String Implements IInfo.LookUp
                Get
                    Return WoId
                End Get
            End Property
        End Class

        Public _band01 As Integer = 30
        Public _band02 As Integer = 60
        Public _band03 As Integer = 90
        Public _band04 As Integer = 120

        Public _calculationDate As New SmartDate("T")



#End Region

#Region "IQueryBO"

        Public Sub AddQueryFilters(pDic As System.Collections.Generic.Dictionary(Of String, String)) Implements IQueryBO.AddQueryFilters
            Dim settings = pbs.BO.SC.Settings.GetSettings

            _band01 = pDic.GetValueByKey("Band01", Nz(settings.AgingBand01, 30)).ToInteger
            _band02 = pDic.GetValueByKey("Band02", Nz(settings.AgingBand02, 60)).ToInteger
            _band03 = pDic.GetValueByKey("Band03", Nz(settings.AgingBand03, 90)).ToInteger
            _band04 = pDic.GetValueByKey("Band04", Nz(settings.AgingBand04, 120)).ToInteger
        End Sub

        Public ReadOnly Property ChildrenType As System.Type Implements IQueryBO.ChildrenType
            Get
                Return GetType(WorkOrderAging)
            End Get
        End Property

        Public Function GetBOList() As System.Collections.IList Implements IQueryBO.GetBOList
            'Dim ret = (From itm As WOInfo In WOInfoList.GetWOInfoList Where DateDiff(DateInterval.Day, itm._woDueDate.Date, pbs.Helper.ToDay) >= _selectedAging).ToList
            Dim agingQD = CreateWOAgingQD()
            Dim theList = New Dictionary(Of String, WorkOrderAging)
            FillToBand(agingQD.Extract, theList)

            Return theList.Values.ToList
        End Function

        Public Function GetBOListStatus() As String Implements IQueryBO.GetBOListStatus
            Return "Work order no: {WoId}"
        End Function

        Public Function GetDoubleClickCommand() As String Implements IQueryBO.GetDoubleClickCommand
            Return "pbs.BO.SC.WO?WoId=[WoId]&$Action=View"
        End Function

        Public Function GetMyQD() As SQLBuilder.QD Implements IQueryBO.GetMyQD
            Return Nothing
        End Function

        Public Function GetMyTitle() As String Implements IQueryBO.GetMyTitle
            Return String.Format("Work order Overdue at date: {0}", _calculationDate)
        End Function

        Public Function GetSelectCommand() As String Implements IQueryBO.GetSelectCommand
            Return String.Empty
        End Function

        Public Function GetSelectionChangedCommand() As String Implements IQueryBO.GetSelectionChangedCommand
            Return String.Empty
        End Function

        Public Function GetVariables() As System.Collections.Generic.Dictionary(Of String, String) Implements IQueryBO.GetVariables

        End Function

        Public Sub InvalidateCacheList() Implements IQueryBO.InvalidateCacheList

        End Sub

        Public Sub SetParameters(pDic As System.Collections.Generic.Dictionary(Of String, String)) Implements IQueryBO.SetParameters

        End Sub

        Public Function Syntax() As String Implements IQueryBO.Syntax
            Return <Syntax>
                        This Inquiry return Work Order that late 30, 60, 90 or 120 days.
                        Syntax: pbs.BO.SC.WOAgingOverdue
                   </Syntax>
        End Function

        Public Sub UpdateCurrentLine(pLine As Object) Implements IQueryBO.UpdateCurrentLine

        End Sub

        Public Sub UpdateQD(pQD As SQLBuilder.QD) Implements IQueryBO.UpdateQD

        End Sub

        Public Sub UpdateSelectedLines(pLines As System.Collections.IEnumerable) Implements IQueryBO.UpdateSelectedLines

        End Sub

        Public Sub ZReset() Implements IQueryBO.ZReset

        End Sub

        Public Function CanExecute(cmd As String) As Boolean? Implements ISupportCommandAuthorization.CanExecute

        End Function

#End Region

#Region "Build the list"

        ''' <summary>
        ''' Create WOAging QD with selected column: WO_ID, WO_TYPE, WO_STATUS, REFERENCE_NO, CLIENT_NO, WO_DATE, WO_DUE_DATE.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateWOAgingQD() As pbs.BO.SQLBuilder.QD
            Dim WOAgingQD = SQLBuilder.QD.NewQD("WOAging")
            WOAgingQD.Descriptn = "Work order aging"
            WOAgingQD.AnalQ0 = "SC_WO"

            WOAgingQD.AddSelectedField(New pbs.BO.SQLBuilder.Field("", "WO_ID", "", ""))
            WOAgingQD.AddSelectedField(New pbs.BO.SQLBuilder.Field("", "WO_TYPE", "", ""))
            WOAgingQD.AddSelectedField(New pbs.BO.SQLBuilder.Field("", "WO_STATUS", "", ""))
            WOAgingQD.AddSelectedField(New pbs.BO.SQLBuilder.Field("", "REFERENCE_NO", "", ""))
            WOAgingQD.AddSelectedField(New pbs.BO.SQLBuilder.Field("", "CLIENT_NAME", "", ""))
            WOAgingQD.AddSelectedField(New pbs.BO.SQLBuilder.Field("", "WO_DATE", "", ""))
            WOAgingQD.AddSelectedField(New pbs.BO.SQLBuilder.Field("", "WO_DUE_DATE", "", ""))

            Return WOAgingQD
        End Function

        ''' <summary>
        ''' Fill data from DataTable to properties and Bands
        ''' </summary>
        ''' <param name="dt">Source DataTable. It can be result of QD.</param>
        ''' <remarks></remarks>
        Private Sub FillToBand(ByVal dt As DataTable, ByVal pDic As Dictionary(Of String, WorkOrderAging))

            If pDic Is Nothing Then pDic = New Dictionary(Of String, WorkOrderAging)

            'get value from QD reusult and fill it to pDic
            For Each row In dt.Rows
                Dim aging As New WorkOrderAging

                Dim theWOId = DNz(row("WO_ID"), String.Empty)

                If pDic.ContainsKey(theWOId) Then
                    aging = pDic(theWOId)
                Else
                    Dim theWOType = DNz(row("WO_TYPE"), String.Empty)
                    Dim theWOStatus = DNz(row("WO_STATUS"), String.Empty)
                    Dim theReferenceNo = DNz(row("REFERENCE_NO"), String.Empty)
                    Dim theClientId = DNz(row("CLIENT_NAME"), String.Empty)
                    Dim theWODate = New Helper.SmartDate(DNz(row("WO_DATE"), String.Empty))
                    Dim theDueDate = New Helper.SmartDate(DNz(row("WO_DUE_DATE"), String.Empty))

                    aging.WoId = theWOId
                    aging.WoType = theWOType
                    aging.WoStatus = theWOStatus
                    aging.ReferenceNo = theReferenceNo
                    aging.ClientName = theClientId
                    aging.WoDate = theWODate
                    aging.WoDueDate = theDueDate

                    pDic.Add(aging.WoId, aging)
                End If

                'fill value to bands
                Dim dayDiff = (_calculationDate - aging.WoDueDate).TotalDays
                If dayDiff > 0 Then
                    Select Case dayDiff
                        Case Is <= (New TimeSpan(_band01, 0, 0, 0)).TotalDays
                            aging.Band_01 = 1
                            aging.Band_02 = 0
                            aging.Band_03 = 0
                            aging.Band_04 = 0
                            aging._overdueDay = dayDiff
                        Case Is <= (New TimeSpan(_band02, 0, 0, 0)).TotalDays
                            aging.Band_01 = 0
                            aging.Band_02 = 1
                            aging.Band_03 = 0
                            aging.Band_04 = 0
                            aging._overdueDay = dayDiff
                        Case Is <= (New TimeSpan(_band03, 0, 0, 0)).TotalDays
                            aging.Band_01 = 0
                            aging.Band_02 = 0
                            aging.Band_03 = 1
                            aging.Band_04 = 0
                            aging._overdueDay = dayDiff
                        Case Is <= (New TimeSpan(_band04, 0, 0, 0)).TotalDays
                            aging.Band_01 = 0
                            aging.Band_02 = 0
                            aging.Band_03 = 0
                            aging.Band_04 = 1
                            aging._overdueDay = dayDiff
                        Case Else
                            aging.Band_01 = 0
                            aging.Band_02 = 0
                            aging.Band_03 = 0
                            aging.Band_04 = 0
                            aging._overdueDay = dayDiff
                    End Select
                End If
            Next

        End Sub


#End Region

#Region "ISupportScripts"

        'Filter button
        Private Function SelectDate_Imp() As UITasks
            Dim ret As New UITasks(Me)
            ret.IconName = "Find/Find"
            ret.AddCallMethod(1, "SelectDate")
            ret.RefreshUIWhenFinish = True

            Return ret
        End Function
        Private Sub SelectDate()
            Dim newSelectedDate = pbs.Helper.UIServices.ValueSelectorService.SelectValue(LinkCode.Calendar, ResStrConst.SelectItemText("Date"))

            If Not String.IsNullOrEmpty(newSelectedDate) Then
                _calculationDate.Text = newSelectedDate
            End If

        End Sub

        Public Function GetScriptDictionary() As System.Collections.Generic.Dictionary(Of String, UITasks) Implements ISupportScripts.GetScriptDictionary
            Dim ret = New Dictionary(Of String, UITasks)

            ret.Add("Filter", SelectDate_Imp)

            Return ret
        End Function

#End Region

    End Class
End Namespace
