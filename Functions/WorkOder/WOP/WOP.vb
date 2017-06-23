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
    Public Class WOP
        Inherits Csla.BusinessBase(Of WOP)
        Implements Interfaces.IGenPartObject
        Implements IComparable
        Implements IDocLink



#Region "Property Changed"
        Protected Overrides Sub OnDeserialized(context As Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            AddHandler Me.PropertyChanged, AddressOf BO_PropertyChanged
        End Sub

        Private Sub BO_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles Me.PropertyChanged
            Select Case e.PropertyName

                Case "ConvCode"

                    For Each itm In pbs.BO.LA.DCInfoList.GetDCInfoList
                        If _convCode = itm.Code Then
                            _convRate.Float = itm.Rate
                        End If
                    Next

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

            End Select

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
        <CellInfo(GroupName:="", Tips:="Work order Id - used to link this table to WO")>
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

        Private _itemCode As String = String.Empty
        <CellInfo(GroupName:="", Tips:="Item code")>
        Public Property ItemCode() As String
            Get
                Return _itemCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ItemCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _itemCode.Equals(value) Then
                    _itemCode = value
                    PropertyHasChanged("ItemCode")
                End If
            End Set
        End Property

        Private _location As String = String.Empty
        <CellInfo(GroupName:="", Tips:="Location")>
        Public Property Location() As String
            Get
                Return _location
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Location", True)
                If value Is Nothing Then value = String.Empty
                If Not _location.Equals(value) Then
                    _location = value
                    PropertyHasChanged("Location")
                End If
            End Set
        End Property

        Private _issueDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="", Tips:="Issue date")>
        Public Property IssueDate() As String
            Get
                Return _issueDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("IssueDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _issueDate.Equals(value) Then
                    _issueDate.Text = value
                    PropertyHasChanged("IssueDate")
                End If
            End Set
        End Property

        Private _issueBy As String = String.Empty
        <CellInfo(LinkCode.Employee, GroupName:="", Tips:="Employee code the person who issue this work order")>
        Public Property IssueBy() As String
            Get
                Return _issueBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("IssueBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _issueBy.Equals(value) Then
                    _issueBy = value
                    PropertyHasChanged("IssueBy")
                End If
            End Set
        End Property

        Private _partNo As String = String.Empty
        <CellInfo(GroupName:="", Tips:="Part no")>
        Public Property PartNo() As String
            Get
                Return _partNo
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PartNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _partNo.Equals(value) Then
                    _partNo = value
                    PropertyHasChanged("PartNo")
                End If
            End Set
        End Property

        Private _descriptn As String = String.Empty
        <CellInfo(GroupName:="", Tips:="Description")>
        Public Property Descriptn() As String
            Get
                Return _descriptn
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Descriptn", True)
                If value Is Nothing Then value = String.Empty
                If Not _descriptn.Equals(value) Then
                    _descriptn = value
                    PropertyHasChanged("Descriptn")
                End If
            End Set
        End Property

        Private _unit As String = String.Empty
        <CellInfo(GroupName:="", Tips:="Unit of item")>
        Public Property Unit() As String
            Get
                Return _unit
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Unit", True)
                If value Is Nothing Then value = String.Empty
                If Not _unit.Equals(value) Then
                    _unit = value
                    PropertyHasChanged("Unit")
                End If
            End Set
        End Property

        Private _qty As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="quantity")>
        Public Property Qty() As String
            Get
                Return _qty.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Qty", True)
                If value Is Nothing Then value = String.Empty
                If Not _qty.Equals(value) Then
                    _qty.Text = value
                    PropertyHasChanged("Qty")
                End If
            End Set
        End Property

        Private _convCode As String = String.Empty
        <CellInfo(LinkCode.ConvDailyRate, GroupName:="", Tips:="Daily Conversion code")>
        Public Property ConvCode() As String
            Get
                Return _convCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ConvCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _convCode.Equals(value) Then
                    _convCode = value
                    PropertyHasChanged("ConvCode")
                End If
            End Set
        End Property

        Private _convRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="Daily conversion rate")>
        Public Property ConvRate() As String
            Get
                Return _convRate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ConvRate", True)
                If value Is Nothing Then value = String.Empty
                If Not _convRate.Equals(value) Then
                    _convRate.Text = value
                    PropertyHasChanged("ConvRate")
                End If
            End Set
        End Property

        Private _transAmt As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="Transaction amount")>
        Public Property TransAmt() As String
            Get
                Return _transAmt.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("TransAmt", True)
                If value Is Nothing Then value = String.Empty
                If Not _transAmt.Equals(value) Then
                    _transAmt.Text = value
                    PropertyHasChanged("TransAmt")
                End If
            End Set
        End Property

        Private _amount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="Amount")>
        Public Property Amount() As String
            Get
                Return _amount.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Amount", True)
                If value Is Nothing Then value = String.Empty
                If Not _amount.Equals(value) Then
                    _amount.Text = value
                    PropertyHasChanged("Amount")
                End If
            End Set
        End Property

        Private _value1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value1() As String
            Get
                Return _value1.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value1", True)
                If value Is Nothing Then value = String.Empty
                If Not _value1.Equals(value) Then
                    _value1.Text = value
                    PropertyHasChanged("Value1")
                End If
            End Set
        End Property

        Private _value2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value2() As String
            Get
                Return _value2.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value2", True)
                If value Is Nothing Then value = String.Empty
                If Not _value2.Equals(value) Then
                    _value2.Text = value
                    PropertyHasChanged("Value2")
                End If
            End Set
        End Property

        Private _value3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value3() As String
            Get
                Return _value3.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value3", True)
                If value Is Nothing Then value = String.Empty
                If Not _value3.Equals(value) Then
                    _value3.Text = value
                    PropertyHasChanged("Value3")
                End If
            End Set
        End Property

        Private _value4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value4() As String
            Get
                Return _value4.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value4", True)
                If value Is Nothing Then value = String.Empty
                If Not _value4.Equals(value) Then
                    _value4.Text = value
                    PropertyHasChanged("Value4")
                End If
            End Set
        End Property

        Private _value5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="", Tips:="")>
        Public Property Value5() As String
            Get
                Return _value5.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Value5", True)
                If value Is Nothing Then value = String.Empty
                If Not _value5.Equals(value) Then
                    _value5.Text = value
                    PropertyHasChanged("Value5")
                End If
            End Set
        End Property

        Private _charge As String = String.Empty
        <CellInfo(GroupName:="", Tips:="Charge")>
        Public Property Charge() As String
            Get
                Return _charge
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Charge", True)
                If value Is Nothing Then value = String.Empty
                If Not _charge.Equals(value) Then
                    _charge = value
                    PropertyHasChanged("Charge")
                End If
            End Set
        End Property

        Private _notes As String = String.Empty
        <CellInfo(GroupName:="", Tips:="Notes")>
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

        Private _updateBy As String = String.Empty
        <CellInfo(Hidden:=True)>
        Public ReadOnly Property UpdateBy() As String
            Get
                Return _updateBy
            End Get
        End Property

        'Get ID
        Protected Overrides Function GetIdValue() As Object
            Return _lineNo
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            Dim pLineNo As Integer = ID.Trim.ToInteger
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

            For Each _field As ClassField In ClassSchema(Of WOP)._fieldList
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

        Public Shared Function BlankWOP() As WOP
            Return New WOP
        End Function

        Public Shared Function NewWOP(ByVal pLineNo As String) As WOP
            'If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("WOP")))
            Return DataPortal.Create(Of WOP)(New Criteria(pLineNo.ToInteger))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As WOP
            Dim pLineNo As String = ID.Trim

            Return NewWOP(pLineNo)
        End Function

        Public Shared Function GetWOP(ByVal pLineNo As String) As WOP
            Return DataPortal.Fetch(Of WOP)(New Criteria(pLineNo.ToInteger))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As WOP
            Dim pLineNo As String = ID.Trim

            Return GetWOP(pLineNo)
        End Function

        Public Shared Sub DeleteWOP(ByVal pLineNo As String)
            DataPortal.Delete(New Criteria(pLineNo.ToInteger))
        End Sub

        Public Overrides Function Save() As WOP
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("WOP")))

            Me.ApplyEdit()
            WOPInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneWOP(ByVal pLineNo As String) As WOP

            'If WOP.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningWOP As WOP = MyBase.Clone
            cloningWOP._lineNo = 0
            cloningWOP._DTB = Context.CurrentBECode

            'Todo:Remember to reset status of the new object here 
            cloningWOP.MarkNew()
            cloningWOP.ApplyEdit()

            cloningWOP.ValidationRules.CheckRules()

            Return cloningWOP
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
                    cm.CommandText = <SqlText>SELECT * FROM pbs_SC_WO_PARTS_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim

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
            _itemCode = dr.GetString("ITEM_CODE").TrimEnd
            _location = dr.GetString("LOCATION").TrimEnd
            _issueDate.Text = dr.GetInt32("ISSUE_DATE")
            _issueBy = dr.GetString("ISSUE_BY").TrimEnd
            _partNo = dr.GetString("PART_NO").TrimEnd
            _descriptn = dr.GetString("DESCRIPTN").TrimEnd
            _unit = dr.GetString("UNIT").TrimEnd
            _qty.Text = dr.GetDecimal("QTY")
            _convCode = dr.GetString("CONV_CODE").TrimEnd
            _convRate.Text = dr.GetDecimal("CONV_RATE")
            _transAmt.Text = dr.GetDecimal("TRANS_AMT")
            _amount.Text = dr.GetDecimal("AMOUNT")
            _value1.Text = dr.GetDecimal("VALUE1")
            _value2.Text = dr.GetDecimal("VALUE2")
            _value3.Text = dr.GetDecimal("VALUE3")
            _value4.Text = dr.GetDecimal("VALUE4")
            _value5.Text = dr.GetDecimal("VALUE5")
            _charge = dr.GetString("CHARGE").TrimEnd
            _notes = dr.GetString("NOTES").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")
            _updateBy = dr.GetString("UPDATE_BY").TrimEnd

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    'Using cm = ctx.Connection.CreateCommand()

                    '    cm.CommandType = CommandType.StoredProcedure
                    '    cm.CommandText = String.Format("pbs_SC_WO_Parts_{0}_Insert", _DTB)

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
            cm.Parameters.AddWithValue("@ITEM_CODE", _itemCode.Trim)
            cm.Parameters.AddWithValue("@LOCATION", _location.Trim)
            cm.Parameters.AddWithValue("@ISSUE_DATE", _issueDate.DBValue)
            cm.Parameters.AddWithValue("@ISSUE_BY", _issueBy.Trim)
            cm.Parameters.AddWithValue("@PART_NO", _partNo.Trim)
            cm.Parameters.AddWithValue("@DESCRIPTN", _descriptn.Trim)
            cm.Parameters.AddWithValue("@UNIT", _unit.Trim)
            cm.Parameters.AddWithValue("@QTY", _qty.DBValue)
            cm.Parameters.AddWithValue("@CONV_CODE", _convCode.Trim)
            cm.Parameters.AddWithValue("@CONV_RATE", _convRate.DBValue)
            cm.Parameters.AddWithValue("@TRANS_AMT", _transAmt.DBValue)
            cm.Parameters.AddWithValue("@AMOUNT", _amount.DBValue)
            cm.Parameters.AddWithValue("@VALUE1", _value1.DBValue)
            cm.Parameters.AddWithValue("@VALUE2", _value2.DBValue)
            cm.Parameters.AddWithValue("@VALUE3", _value3.DBValue)
            cm.Parameters.AddWithValue("@VALUE4", _value4.DBValue)
            cm.Parameters.AddWithValue("@VALUE5", _value5.DBValue)
            cm.Parameters.AddWithValue("@CHARGE", _charge.Trim)
            cm.Parameters.AddWithValue("@NOTES", _notes.Trim)
            cm.Parameters.AddWithValue("@UPDATED", ToDay.ToSunDate)
            cm.Parameters.AddWithValue("@UPDATE_BY", Context.CurrentBECode)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    'Using cm = ctx.Connection.CreateCommand()

                    '    cm.CommandType = CommandType.StoredProcedure
                    '    cm.CommandText = String.Format("pbs_SC_WO_Parts_{0}_Update", _DTB)

                    '    cm.Parameters.AddWithValue("@LINE_NO", _lineNo)
                    '    AddInsertParameters(cm)
                    '    cm.ExecuteNonQuery()

                    'End Using

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
                    cm.CommandText = <SqlText>DELETE pbs_SC_WO_PARTS_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
        '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
        '        WOPInfoList.InvalidateCache()
        '    End If
        'End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pLineNo As String) As Boolean
            Return WOPInfoList.ContainsCode(pLineNo)
        End Function

        'Public Shared Function KeyDuplicated(ByVal pLineNo As SmartInt32) As Boolean
        '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_SC_WO_PARTS_DEM WHERE DTB='<%= Context.CurrentBECode %>'  AND LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
        '    Return SQLCommander.GetScalarInteger(SqlText) > 0
        'End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return CloneWOP(id)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(WOP).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(WOP).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return WOPInfoList.GetWOPInfoList
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
        Shared Function NewChildWOP(pParentId As String) As WOP
            Dim ret = New WOP
            ret._woId.Text = pParentId
            ret.MarkAsChild()
            Return ret
        End Function

        Shared Function GetChildWOP(dr As SafeDataReader)
            Dim child = New WOP
            child.FetchObject(dr)
            child.MarkAsChild()
            child.MarkOld()
            Return child
        End Function

        Sub DeleteSelf(cn As SqlConnection)
            Using cm = cn.CreateCommand
                cm.CommandType = CommandType.Text
                cm.CommandText = <sqltext>DELETE pbs_SC_WO_PARTS_<%= _DTB %> WHERE LINE_NO= <%= _lineNo %></sqltext>
                cm.ExecuteNonQuery()
            End Using
        End Sub

        Sub Insert(cn As SqlConnection)
            Using cm = cn.CreateCommand()

                cm.CommandType = CommandType.StoredProcedure
                cm.CommandText = String.Format("pbs_SC_WO_Parts_{0}_Insert", _DTB)

                cm.Parameters.AddWithValue("@LINE_NO", _lineNo).Direction = ParameterDirection.Output
                AddInsertParameters(cm)
                cm.ExecuteNonQuery()

                _lineNo = CInt(cm.Parameters("@LINE_NO").Value)
            End Using
        End Sub

        Sub Update(cn As SqlConnection)

            Using cm = cn.CreateCommand()

                cm.CommandType = CommandType.StoredProcedure
                cm.CommandText = String.Format("pbs_SC_WO_Parts_{0}_Update", _DTB)

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