Imports pbs.Helper
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports pbs.BO.DataAnnotations
Imports pbs.BO.Script
Imports pbs.BO.BusinessRules


Namespace SC

    <Serializable()> _
    Public Class WOE
        Inherits Csla.BusinessBase(Of WOE)
        Implements Interfaces.IGenPartObject
        Implements IComparable
        Implements IDocLink



#Region "Property Changed"
        Protected Overrides Sub OnDeserialized(context As Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            AddHandler Me.PropertyChanged, AddressOf BO_PropertyChanged
        End Sub

        Private Sub BO_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles Me.PropertyChanged
            'Select Case e.PropertyName

            '    Case "OrderType"
            '        If Not Me.GetOrderTypeInfo.ManualRef Then
            '            Me._orderNo = POH.AutoReference
            '        End If

            '    Case "OrderDate"
            '        If String.IsNullOrEmpty(Me.OrderPrd) Then Me._orderPrd.Text = Me._orderDate.Date.ToSunPeriod

            '    Case "SuppCode"
            '        For Each line In Lines
            '            line._suppCode = Me.SuppCode
            '        Next

            '    Case "ConvCode"
            '        If String.IsNullOrEmpty(Me.ConvCode) Then
            '            _convRate.Float = 0
            '        Else
            '            Dim conv = pbs.BO.LA.CVInfoList.GetConverter(Me.ConvCode, _orderPrd, String.Empty)
            '            If conv IsNot Nothing Then
            '                _convRate.Float = conv.DefaultRate
            '            End If
            '        End If

            '    Case Else

            'End Select

            pbs.BO.Rules.CalculationRules.Calculator(sender, e)
        End Sub
#End Region

#Region " Business Properties and Methods "
        Friend _DTB As String = String.Empty


        Friend _lineNo As Integer
        <System.ComponentModel.DataObjectField(True, True)> _
        <CellInfo(Hidden:=True)>
        Public ReadOnly Property LineNo() As String
            Get
                Return _lineNo
            End Get
        End Property

        Private _woId As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property WoId() As String
            Get
                Return _woId.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("WoId", True)
                If value Is Nothing Then value = String.Empty
                If Not _woId.Equals(value) Then
                    _woId.Text = value
                    PropertyHasChanged("WoId")
                End If
            End Set
        End Property

        Private _eventType As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property EventType() As String
            Get
                Return _eventType
            End Get
            Set(ByVal value As String)
                CanWriteProperty("EventType", True)
                If value Is Nothing Then value = String.Empty
                If Not _eventType.Equals(value) Then
                    _eventType = value
                    PropertyHasChanged("EventType")
                End If
            End Set
        End Property

        Private _eventDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="")>
        Public Property EventDate() As String
            Get
                Return _eventDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("EventDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _eventDate.Equals(value) Then
                    _eventDate.Text = value
                    PropertyHasChanged("EventDate")
                End If
            End Set
        End Property

        Private _eventTime As pbs.Helper.SmartTime = New pbs.Helper.SmartTime()
        <CellInfo("HOUR", GroupName:="", Tips:="")>
        Public Property EventTime() As String
            Get
                Return _eventTime.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("EventTime", True)
                If value Is Nothing Then value = String.Empty
                If Not _eventTime.Equals(value) Then
                    _eventTime.Text = value
                    PropertyHasChanged("EventTime")
                End If
            End Set
        End Property

        Private _emplCode As String = String.Empty
        <CellInfo(LinkCode.Employee, GroupName:="", Tips:="")>
        Public Property EmplCode() As String
            Get
                Return _emplCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("EmplCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _emplCode.Equals(value) Then
                    _emplCode = value
                    PropertyHasChanged("EmplCode")
                End If
            End Set
        End Property

        Private _descriptn1 As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Descriptn1() As String
            Get
                Return _descriptn1
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Descriptn1", True)
                If value Is Nothing Then value = String.Empty
                If Not _descriptn1.Equals(value) Then
                    _descriptn1 = value
                    PropertyHasChanged("Descriptn1")
                End If
            End Set
        End Property

        Private _descriptn2 As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Descriptn2() As String
            Get
                Return _descriptn2
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Descriptn2", True)
                If value Is Nothing Then value = String.Empty
                If Not _descriptn2.Equals(value) Then
                    _descriptn2 = value
                    PropertyHasChanged("Descriptn2")
                End If
            End Set
        End Property

        Private _descriptn3 As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Descriptn3() As String
            Get
                Return _descriptn3
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Descriptn3", True)
                If value Is Nothing Then value = String.Empty
                If Not _descriptn3.Equals(value) Then
                    _descriptn3 = value
                    PropertyHasChanged("Descriptn3")
                End If
            End Set
        End Property

        Private _descriptn4 As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Descriptn4() As String
            Get
                Return _descriptn4
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Descriptn4", True)
                If value Is Nothing Then value = String.Empty
                If Not _descriptn4.Equals(value) Then
                    _descriptn4 = value
                    PropertyHasChanged("Descriptn4")
                End If
            End Set
        End Property

        Private _descriptn5 As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Descriptn5() As String
            Get
                Return _descriptn5
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Descriptn5", True)
                If value Is Nothing Then value = String.Empty
                If Not _descriptn5.Equals(value) Then
                    _descriptn5 = value
                    PropertyHasChanged("Descriptn5")
                End If
            End Set
        End Property

        Private _notes As String = String.Empty
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Notes", True)
                If value Is Nothing Then value = String.Empty
                If Not _notes.Equals(value) Then
                    _notes = value
                    PropertyHasChanged("Notes")
                End If
            End Set
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(Hidden:=True)>
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.Text
            End Get
        End Property

        Private _updatedBy As String = String.Empty
        <CellInfo(Hidden:=True)>
        Public ReadOnly Property UpdatedBy() As String
            Get
                Return _updatedBy
            End Get
        End Property


        'Get ID
        Protected Overrides Function GetIdValue() As Object
            Return _lineNo
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            Dim pLineNo As String = ID.Trim.ToInteger
            If _lineNo < pLineNo Then Return -1
            If _lineNo > pLineNo Then Return 1
            Return 0
        End Function

#End Region 'Business Properties and Methods

#Region "Validation Rules"

        Sub CheckRules()
            ValidationRules.CheckRules()
        End Sub

        Private Sub AddSharedCommonRules()
            'Sample simple custom rule
            'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           

            'Sample dependent property. when check one , check the other as well
            'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
        End Sub

        Protected Overrides Sub AddBusinessRules()
            AddSharedCommonRules()

            For Each _field As ClassField In ClassSchema(Of WOE)._fieldList
                If _field.Required Then
                    ValidationRules.AddRule(AddressOf Csla.Validation.CommonRules.StringRequired, _field.FieldName, 0)
                End If
                If Not String.IsNullOrEmpty(_field.RegexPattern) Then
                    ValidationRules.AddRule(AddressOf Csla.Validation.CommonRules.RegExMatch, New RegExRuleArgs(_field.FieldName, _field.RegexPattern), 1)
                End If
                '----------using lookup, if no user lookup defined, fallback to predefined by developer----------------------------
                If CATMAPInfoList.ContainsCode(_field) Then
                    ValidationRules.AddRule(AddressOf LKUInfoList.ContainsLiveCode, _field.FieldName, 2)
                    'Else
                    '    Select Case _field.FieldName
                    '        Case "LocType"
                    '            ValidationRules.AddRule(Of LOC, AnalRuleArg)(AddressOf LOOKUPInfoList.ContainsSysCode, New AnalRuleArg(_field.FieldName, SysCats.LocationType))
                    '        Case "Status"
                    '            ValidationRules.AddRule(Of LOC, AnalRuleArg)(AddressOf LOOKUPInfoList.ContainsSysCode, New AnalRuleArg(_field.FieldName, SysCats.LocationStatus))
                    '    End Select
                End If
            Next
            Rules.BusinessRules.RegisterBusinessRules(Me)
            MyBase.AddBusinessRules()
        End Sub
#End Region ' Validation

#Region " Factory Methods "

        Private Sub New()
            _DTB = Context.CurrentBECode
        End Sub

        Public Shared Function BlankWOE() As WOE
            Return New WOE
        End Function

        Public Shared Function NewWOE(ByVal pLineNo As String) As WOE
            'If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("WOE")))
            Return DataPortal.Create(Of WOE)(New Criteria(pLineNo.ToInteger))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As WOE
            Dim pLineNo As String = ID.Trim

            Return NewWOE(pLineNo)
        End Function

        Public Shared Function GetWOE(ByVal pLineNo As String) As WOE
            Return DataPortal.Fetch(Of WOE)(New Criteria(pLineNo.ToInteger))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As WOE
            Dim pLineNo As String = ID.Trim

            Return GetWOE(pLineNo)
        End Function

        Public Shared Sub DeleteWOE(ByVal pLineNo As String)
            DataPortal.Delete(New Criteria(pLineNo.ToInteger))
        End Sub

        Public Overrides Function Save() As WOE
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("WOE")))

            Me.ApplyEdit()
            WOEInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneWOE(ByVal pLineNo As String) As WOE

            'If WOE.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningWOE As WOE = MyBase.Clone
            cloningWOE._lineNo = 0
            cloningWOE._DTB = Context.CurrentBECode

            'Todo:Remember to reset status of the new object here 
            cloningWOE.MarkNew()
            cloningWOE.ApplyEdit()

            cloningWOE.ValidationRules.CheckRules()

            Return cloningWOE
        End Function

#End Region ' Factory Methods

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public _lineNo As Integer

            Public Sub New(ByVal pLineNo As String)
                _lineNo = pLineNo.ToInteger

            End Sub
        End Class

        <RunLocal()> _
        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            _lineNo = criteria._lineNo

            ValidationRules.CheckRules()
        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()
                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>
                                         SELECT * FROM pbs_SC_WO_EVENT_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %>
                                     </SqlText>.Value.Trim

                    Using dr As New SafeDataReader(cm.ExecuteReader)
                        If dr.Read Then
                            FetchObject(dr)
                            MarkOld()
                        End If
                    End Using

                End Using
            End Using
        End Sub

        Private Sub FetchObject(ByVal dr As SafeDataReader)
            _lineNo = dr.GetInt32("LINE_NO")
            _woId.Text = dr.GetInt32("WO_ID")
            _eventType = dr.GetString("EVENT_TYPE").TrimEnd
            _eventDate.Text = dr.GetInt32("EVENT_DATE")
            _eventTime.Text = dr.GetInt32("EVENT_TIME")
            _emplCode = dr.GetString("EMPL_CODE").TrimEnd
            _descriptn1 = dr.GetString("DESCRIPTN1").TrimEnd
            _descriptn2 = dr.GetString("DESCRIPTN2").TrimEnd
            _descriptn3 = dr.GetString("DESCRIPTN3").TrimEnd
            _descriptn4 = dr.GetString("DESCRIPTN4").TrimEnd
            _descriptn5 = dr.GetString("DESCRIPTN5").TrimEnd
            _notes = dr.GetString("NOTES").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    'Using cm = ctx.Connection.CreateCommand()

                    '    cm.CommandType = CommandType.StoredProcedure
                    '    cm.CommandText = String.Format("pbs_SC_WO_EVENT_{0}_Insert", _DTB)

                    '    cm.Parameters.AddWithValue("@LINE_NO", _lineNo).Direction = ParameterDirection.Output
                    '    AddInsertParameters(cm)
                    '    cm.ExecuteNonQuery()

                    '    _lineNo = CInt(cm.Parameters("@LINE_NO").Value)
                    'End Using

                    Insert(ctx.Connection)
                End Using
            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As SqlCommand)
            cm.Parameters.AddWithValue("@WO_ID", _woId.DBValue)
            cm.Parameters.AddWithValue("@EVENT_TYPE", _eventType.Trim)
            cm.Parameters.AddWithValue("@EVENT_DATE", _eventDate.DBValue)
            cm.Parameters.AddWithValue("@EVENT_TIME", _eventTime.DBValue)
            cm.Parameters.AddWithValue("@EMPL_CODE", _emplCode.Trim)
            cm.Parameters.AddWithValue("@DESCRIPTN1", _descriptn1.Trim)
            cm.Parameters.AddWithValue("@DESCRIPTN2", _descriptn2.Trim)
            cm.Parameters.AddWithValue("@DESCRIPTN3", _descriptn3.Trim)
            cm.Parameters.AddWithValue("@DESCRIPTN4", _descriptn4.Trim)
            cm.Parameters.AddWithValue("@DESCRIPTN5", _descriptn5.Trim)
            cm.Parameters.AddWithValue("@NOTES", _notes.Trim)
            cm.Parameters.AddWithValue("@UPDATED", _updated.DBValue)
            cm.Parameters.AddWithValue("@UPDATED_BY", _updatedBy.Trim)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    '    Using cm = ctx.Connection.CreateCommand()

                    '        cm.CommandType = CommandType.StoredProcedure
                    '        cm.CommandText = String.Format("pbs_SC_WO_EVENT_{0}_Update", _DTB)

                    '        cm.Parameters.AddWithValue("@LINE_NO", _lineNo)
                    '        AddInsertParameters(cm)
                    '        cm.ExecuteNonQuery()

                    '    End Using

                    Update(ctx.Connection)
                End Using
            End SyncLock
        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_lineNo))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>DELETE pbs_SC_WO_EVENT_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
        '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
        '        WOEInfoList.InvalidateCache()
        '    End If
        'End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pLineNo As String) As Boolean
            Return WOEInfoList.ContainsCode(pLineNo)
        End Function

        'Public Shared Function KeyDuplicated(ByVal pLineNo As SmartInt32) As Boolean
        '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_SC_WO_EVENT_DEM WHERE DTB='<%= Context.CurrentBECode %>'  AND LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
        '    Return SQLCommander.GetScalarInteger(SqlText) > 0
        'End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return CloneWOE(id)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(WOE).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(WOE).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return WOEInfoList.GetWOEInfoList
        End Function
#End Region

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _lineNo)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region

#Region "Child"
        Shared Function NewChildWOE(pParentId As String) As WOE
            Dim ret = New WOE
            ret._woId.Text = pParentId
            ret.MarkAsChild()
            Return ret
        End Function

        Shared Function GetChildWOE(dr As SafeDataReader)
            Dim child = New WOE
            child.FetchObject(dr)
            child.MarkAsChild()
            child.MarkOld()
            Return child
        End Function

        Sub DeleteSelf(cn As SqlConnection)
            Using cm = cn.CreateCommand
                cm.CommandType = CommandType.Text
                cm.CommandText = <sqltext>DELETE pbs_SC_WO_EVENT_<%= _DTB %> WHERE LINE_NO= <%= _lineNo %></sqltext>
                cm.ExecuteNonQuery()
            End Using
        End Sub

        Sub Insert(cn As SqlConnection)
            Using cm = cn.CreateCommand()

                cm.CommandType = CommandType.StoredProcedure
                cm.CommandText = String.Format("pbs_SC_WO_EVENT_{0}_Insert", _DTB)

                cm.Parameters.AddWithValue("@LINE_NO", _lineNo).Direction = ParameterDirection.Output
                AddInsertParameters(cm)
                cm.ExecuteNonQuery()

                _lineNo = CInt(cm.Parameters("@LINE_NO").Value)
            End Using
        End Sub

        Sub Update(cn As SqlConnection)

            Using cm = cn.CreateCommand()

                cm.CommandType = CommandType.StoredProcedure
                cm.CommandText = String.Format("pbs_SC_WO_EVENT_{0}_Update", _DTB)

                cm.Parameters.AddWithValue("@LINE_NO", _lineNo)
                AddInsertParameters(cm)
                cm.ExecuteNonQuery()

            End Using

        End Sub

        Sub MarkAsNewChild()
            MarkNew()
        End Sub
#End Region



    End Class

End Namespace