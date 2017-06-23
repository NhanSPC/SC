Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports pbs.BO.Script

Namespace SC

    Public Class WOStatus
        Implements IQueryBO
        Implements ISupportScripts

#Region "IQueryBO"

        Private _selectedStatus As String = String.Empty

        Public Sub AddQueryFilters(pDic As System.Collections.Generic.Dictionary(Of String, String)) Implements IQueryBO.AddQueryFilters

        End Sub

        Public ReadOnly Property ChildrenType As System.Type Implements IQueryBO.ChildrenType
            Get
                Return GetType(pbs.BO.SC.WOInfo)
            End Get
        End Property

        Public Function GetBOList() As System.Collections.IList Implements IQueryBO.GetBOList
            Dim ret = (From itm As WOInfo In WOInfoList.GetWOInfoList Where itm.WoStatus = _selectedStatus).ToList

            Return ret
        End Function

        Public Function GetBOListStatus() As String Implements IQueryBO.GetBOListStatus
            Return "Work order no: {WoId}"
        End Function

        Public Function GetDoubleClickCommand() As String Implements IQueryBO.GetDoubleClickCommand
            Return "pbs.BO.SC.WO?WoId=[WoId]&$Action=View"
        End Function

        Public Function GetMyQD() As SQLBuilder.QD Implements IQueryBO.GetMyQD

        End Function

        Public Function GetMyTitle() As String Implements IQueryBO.GetMyTitle
            Return String.Format("Work order status: {0}.", _selectedStatus)
        End Function

        Public Function GetSelectCommand() As String Implements IQueryBO.GetSelectCommand

        End Function

        Public Function GetSelectionChangedCommand() As String Implements IQueryBO.GetSelectionChangedCommand

        End Function

        Public Function GetVariables() As System.Collections.Generic.Dictionary(Of String, String) Implements IQueryBO.GetVariables

        End Function

        Public Sub InvalidateCacheList() Implements IQueryBO.InvalidateCacheList

        End Sub

        Public Sub SetParameters(pDic As System.Collections.Generic.Dictionary(Of String, String)) Implements IQueryBO.SetParameters

        End Sub

        Public Function Syntax() As String Implements IQueryBO.Syntax
            Return <Syntax>
                        This Inquiry return Work Order that match selected status.
                        Syntax: pbs.BO.SC.WOStatus
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

#Region "ISupportScripts"

        'Filter button
        Private Function SelectedStatus_Imp() As UITasks
            Dim ret As New UITasks(Me)
            ret.IconName = "Find/Find"
            ret.AddCallMethod(1, "SelectedStatus")
            ret.RefreshUIWhenFinish = True

            Return ret
        End Function
        Private Sub SelectedStatus()
            Dim newSelectedStatus = pbs.Helper.UIServices.ValueSelectorService.SelectValue("STATUS", ResStrConst.SelectItemText("Status"))

            'If Not String.IsNullOrEmpty(newSelectedStatus) Then
            _selectedStatus = newSelectedStatus
            'End If

        End Sub

        Public Function GetScriptDictionary() As System.Collections.Generic.Dictionary(Of String, UITasks) Implements ISupportScripts.GetScriptDictionary
            Dim ret = New Dictionary(Of String, UITasks)

            ret.Add("Filter", SelectedStatus_Imp)

            Return ret
        End Function

#End Region

    End Class
End Namespace
