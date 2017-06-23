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
    <DB(TableName:="pbs_SC_WO_{XXX}")>
    Public Class WO
        Inherits Csla.BusinessBase(Of WO)
        Implements Interfaces.IGenPartObject
        Implements IComparable
        Implements IDocLink



#Region "Property Changed"
        Protected Overrides Sub OnDeserialized(context As Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            AddHandler Me.PropertyChanged, AddressOf BO_PropertyChanged
        End Sub

        Private Sub BO_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles Me.PropertyChanged
            Select e.PropertyName

                Case "ClientId"
                    For Each itm In CRM.CUSInfoList.GetCUSInfoList
                        If _clientId = itm.CustomerCode Then
                            _clientName = itm.Name
                        End If
                    Next

                Case "EquCode"
                    For Each itm In EAM.EQUInfoList.GetEQUInfoList
                        If _equCode = itm.EquNo Then
                            _equDesc = itm.Descriptn
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

        Private _woId As Integer
        <System.ComponentModel.DataObjectField(True, True)> _
        <CellInfo(Hidden:=True)>
        Public ReadOnly Property WoId() As String
            Get
                Return _woId
            End Get
        End Property

        Private _woType As String = String.Empty
        <CellInfo(GroupName:="Work Order Info", Tips:="Type of Work Order")>
        Public Property WoType() As String
            Get
                Return _woType
            End Get
            Set(ByVal value As String)
                CanWriteProperty("WoType", True)
                If value Is Nothing Then value = String.Empty
                If Not _woType.Equals(value) Then
                    _woType = value
                    PropertyHasChanged("WoType")
                End If
            End Set
        End Property

        Private _woStatus As String = String.Empty
        <CellInfo(GroupName:="Work Order Info", Tips:="Status of work order")>
        Public Property WoStatus() As String
            Get
                Return _woStatus
            End Get
            Set(ByVal value As String)
                CanWriteProperty("WoStatus", True)
                If value Is Nothing Then value = String.Empty
                If Not _woStatus.Equals(value) Then
                    _woStatus = value
                    PropertyHasChanged("WoStatus")
                End If
            End Set
        End Property

        Private _referenceNo As String = String.Empty
        <CellInfo(GroupName:="Work Order Info", Tips:="Refenrence number")>
        Public Property ReferenceNo() As String
            Get
                Return _referenceNo
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ReferenceNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _referenceNo.Equals(value) Then
                    _referenceNo = value
                    PropertyHasChanged("ReferenceNo")
                End If
            End Set
        End Property

        Private _clientId As String = String.Empty
        <CellInfo(LinkCode.Customer, GroupName:="Customer Info", Tips:="Choose Client ID from list")>
        Public Property ClientId() As String
            Get
                Return _clientId
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ClientId", True)
                If value Is Nothing Then value = String.Empty
                If Not _clientId.Equals(value) Then
                    _clientId = value
                    PropertyHasChanged("ClientId")
                End If
            End Set
        End Property

        Private _contactId As String = String.Empty
        <CellInfo(GroupName:="Customer Info", Tips:="Choose Contact ID from list")>
        Public Property ContactId() As String
            Get
                Return _contactId
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ContactId", True)
                If value Is Nothing Then value = String.Empty
                If Not _contactId.Equals(value) Then
                    _contactId = value
                    PropertyHasChanged("ContactId")
                End If
            End Set
        End Property

        Private _clientName As String = String.Empty
        <CellInfo(GroupName:="Customer Info", Tips:="Client name")>
        Public Property ClientName() As String
            Get
                Return _clientName
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ClientName", True)
                If value Is Nothing Then value = String.Empty
                If Not _clientName.Equals(value) Then
                    _clientName = value
                    PropertyHasChanged("ClientName")
                End If
            End Set
        End Property

        Private _contactName As String = String.Empty
        <CellInfo(GroupName:="Customer Info", Tips:="Contact name")>
        Public Property ContactName() As String
            Get
                Return _contactName
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ContactName", True)
                If value Is Nothing Then value = String.Empty
                If Not _contactName.Equals(value) Then
                    _contactName = value
                    PropertyHasChanged("ContactName")
                End If
            End Set
        End Property

        Private _address As String = String.Empty
        <CellInfo(GroupName:="Customer Info", Tips:="Enter client's address")>
        Public Property Address() As String
            Get
                Return _address
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Address", True)
                If value Is Nothing Then value = String.Empty
                If Not _address.Equals(value) Then
                    _address = value
                    PropertyHasChanged("Address")
                End If
            End Set
        End Property

        Private _mobile As String = String.Empty
        <CellInfo(GroupName:="Customer Info", Tips:="Mobile")>
        Public Property Mobile() As String
            Get
                Return _mobile
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Mobile", True)
                If value Is Nothing Then value = String.Empty
                If Not _mobile.Equals(value) Then
                    _mobile = value
                    PropertyHasChanged("Mobile")
                End If
            End Set
        End Property

        Private _phone As String = String.Empty
        <CellInfo(GroupName:="Customer Info", Tips:="Phone")>
        Public Property Phone() As String
            Get
                Return _phone
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Phone", True)
                If value Is Nothing Then value = String.Empty
                If Not _phone.Equals(value) Then
                    _phone = value
                    PropertyHasChanged("Phone")
                End If
            End Set
        End Property

        Private _email As String = String.Empty
        <CellInfo(GroupName:="Customer Info", Tips:="Email")>
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Email", True)
                If value Is Nothing Then value = String.Empty
                If Not _email.Equals(value) Then
                    _email = value
                    PropertyHasChanged("Email")
                End If
            End Set
        End Property

        Private _woDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Work Order Info", Tips:="Work Order Date")>
        <Rule(Required:=True)>
        Public Property WoDate() As String
            Get
                Return _woDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("WoDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _woDate.Equals(value) Then
                    _woDate.Text = value
                    PropertyHasChanged("WoDate")
                End If
            End Set
        End Property

        Private _woTime As pbs.Helper.SmartTime = New pbs.Helper.SmartTime()
        <CellInfo("HOUR", GroupName:="Work Order Info", Tips:="Work Order Time")>
        Public Property WoTime() As String
            Get
                Return _woTime.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("WoTime", True)
                If value Is Nothing Then value = String.Empty
                If Not _woTime.Equals(value) Then
                    _woTime.Text = value
                    PropertyHasChanged("WoTime")
                End If
            End Set
        End Property

        Private _woDueDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Work Order Info", Tips:="Work Order due date")>
        Public Property WoDueDate() As String
            Get
                Return _woDueDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("WoDueDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _woDueDate.Equals(value) Then
                    _woDueDate.Text = value
                    PropertyHasChanged("WoDueDate")
                End If
            End Set
        End Property

        Private _woDueTime As pbs.Helper.SmartTime = New pbs.Helper.SmartTime()
        <CellInfo("HOUR", GroupName:="Work Order Info", Tips:="Work Order due time")>
        Public Property WoDueTime() As String
            Get
                Return _woDueTime.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("WoDueTime", True)
                If value Is Nothing Then value = String.Empty
                If Not _woDueTime.Equals(value) Then
                    _woDueTime.Text = value
                    PropertyHasChanged("WoDueTime")
                End If
            End Set
        End Property

        Private _locCode As String = String.Empty
        <CellInfo(GroupName:="Equipment Info", Tips:="Enter code of current location")>
        Public Property LocCode() As String
            Get
                Return _locCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("LocCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _locCode.Equals(value) Then
                    _locCode = value
                    PropertyHasChanged("LocCode")
                End If
            End Set
        End Property

        Private _equCode As String = String.Empty
        <CellInfo(LinkCode.Equipment, GroupName:="Equipment Info", Tips:="Enter equipment code")>
        Public Property EquCode() As String
            Get
                Return _equCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("EquCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _equCode.Equals(value) Then
                    _equCode = value
                    PropertyHasChanged("EquCode")
                End If
            End Set
        End Property

        Private _partNo As String = String.Empty
        <CellInfo(GroupName:="Equipment Info", Tips:="Part number")>
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

        Private _serialNo As String = String.Empty
        <CellInfo(GroupName:="Equipment Info", Tips:="Serial")>
        Public Property SerialNo() As String
            Get
                Return _serialNo
            End Get
            Set(ByVal value As String)
                CanWriteProperty("SerialNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _serialNo.Equals(value) Then
                    _serialNo = value
                    PropertyHasChanged("SerialNo")
                End If
            End Set
        End Property

        Private _barCode As String = String.Empty
        <CellInfo(GroupName:="Equipment Info", Tips:="Barcode")>
        Public Property BarCode() As String
            Get
                Return _barCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("BarCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _barCode.Equals(value) Then
                    _barCode = value
                    PropertyHasChanged("BarCode")
                End If
            End Set
        End Property

        Private _equDesc As String = String.Empty
        <CellInfo(GroupName:="Equipment Info", Tips:="Equipment description")>
        Public Property EquDesc() As String
            Get
                Return _equDesc
            End Get
            Set(ByVal value As String)
                CanWriteProperty("EquDesc", True)
                If value Is Nothing Then value = String.Empty
                If Not _equDesc.Equals(value) Then
                    _equDesc = value
                    PropertyHasChanged("EquDesc")
                End If
            End Set
        End Property

        Private _problem As String = String.Empty
        <CellInfo(GroupName:="Issue", Tips:="Enter problem of device", ControlType:=Forms.CtrlType.MemoEdit)>
        <Rule(Required:=True)>
        Public Property Problem() As String
            Get
                Return _problem
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Problem", True)
                If value Is Nothing Then value = String.Empty
                If Not _problem.Equals(value) Then
                    _problem = value
                    PropertyHasChanged("Problem")
                End If
            End Set
        End Property

        Private _remedy As String = String.Empty
        <CellInfo(GroupName:="Issue", Tips:="Remedy for the problem", ControlType:=Forms.CtrlType.MemoEdit)>
        Public Property Remedy() As String
            Get
                Return _remedy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Remedy", True)
                If value Is Nothing Then value = String.Empty
                If Not _remedy.Equals(value) Then
                    _remedy = value
                    PropertyHasChanged("Remedy")
                End If
            End Set
        End Property

        Private _worNotes As String = String.Empty
        <CellInfo(GroupName:="Issue", Tips:="Work Order Notes", ControlType:=Forms.CtrlType.MemoEdit)>
        Public Property WorNotes() As String
            Get
                Return _worNotes
            End Get
            Set(ByVal value As String)
                CanWriteProperty("WorNotes", True)
                If value Is Nothing Then value = String.Empty
                If Not _worNotes.Equals(value) Then
                    _worNotes = value
                    PropertyHasChanged("WorNotes")
                End If
            End Set
        End Property

        Private _receivedBy As String = String.Empty
        <CellInfo(GroupName:="Work Order Info", Tips:="Enter employee code of reciever")>
        Public Property ReceivedBy() As String
            Get
                Return _receivedBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ReceivedBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _receivedBy.Equals(value) Then
                    _receivedBy = value
                    PropertyHasChanged("ReceivedBy")
                End If
            End Set
        End Property

        Private _processBy As String = String.Empty
        <CellInfo(GroupName:="Work Order Info", Tips:="Process by")>
        Public Property ProcessBy() As String
            Get
                Return _processBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ProcessBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _processBy.Equals(value) Then
                    _processBy = value
                    PropertyHasChanged("ProcessBy")
                End If
            End Set
        End Property

        Private _extDate1 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Extended Date", Tips:="")>
        Public Property ExtDate1() As String
            Get
                Return _extDate1.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDate1", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDate1.Equals(value) Then
                    _extDate1.Text = value
                    PropertyHasChanged("ExtDate1")
                End If
            End Set
        End Property

        Private _extDate2 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Extended Date", Tips:="")>
        Public Property ExtDate2() As String
            Get
                Return _extDate2.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDate2", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDate2.Equals(value) Then
                    _extDate2.Text = value
                    PropertyHasChanged("ExtDate2")
                End If
            End Set
        End Property

        Private _extDate3 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Extended Date", Tips:="")>
        Public Property ExtDate3() As String
            Get
                Return _extDate3.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDate3", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDate3.Equals(value) Then
                    _extDate3.Text = value
                    PropertyHasChanged("ExtDate3")
                End If
            End Set
        End Property

        Private _extDate4 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Extended Date", Tips:="")>
        Public Property ExtDate4() As String
            Get
                Return _extDate4.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDate4", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDate4.Equals(value) Then
                    _extDate4.Text = value
                    PropertyHasChanged("ExtDate4")
                End If
            End Set
        End Property

        Private _extDate5 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Extended Date", Tips:="")>
        Public Property ExtDate5() As String
            Get
                Return _extDate5.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtDate5", True)
                If value Is Nothing Then value = String.Empty
                If Not _extDate5.Equals(value) Then
                    _extDate5.Text = value
                    PropertyHasChanged("ExtDate5")
                End If
            End Set
        End Property

        Private _extValue1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended Value", Tips:="")>
        Public Property ExtValue1() As String
            Get
                Return _extValue1.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtValue1", True)
                If value Is Nothing Then value = String.Empty
                If Not _extValue1.Equals(value) Then
                    _extValue1.Text = value
                    PropertyHasChanged("ExtValue1")
                End If
            End Set
        End Property

        Private _extValue2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended Value", Tips:="")>
        Public Property ExtValue2() As String
            Get
                Return _extValue2.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtValue2", True)
                If value Is Nothing Then value = String.Empty
                If Not _extValue2.Equals(value) Then
                    _extValue2.Text = value
                    PropertyHasChanged("ExtValue2")
                End If
            End Set
        End Property

        Private _extValue3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended Value", Tips:="")>
        Public Property ExtValue3() As String
            Get
                Return _extValue3.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtValue3", True)
                If value Is Nothing Then value = String.Empty
                If Not _extValue3.Equals(value) Then
                    _extValue3.Text = value
                    PropertyHasChanged("ExtValue3")
                End If
            End Set
        End Property

        Private _extValue4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended Value", Tips:="")>
        Public Property ExtValue4() As String
            Get
                Return _extValue4.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtValue4", True)
                If value Is Nothing Then value = String.Empty
                If Not _extValue4.Equals(value) Then
                    _extValue4.Text = value
                    PropertyHasChanged("ExtValue4")
                End If
            End Set
        End Property

        Private _extValue5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Extended Value", Tips:="")>
        Public Property ExtValue5() As String
            Get
                Return _extValue5.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ExtValue5", True)
                If value Is Nothing Then value = String.Empty
                If Not _extValue5.Equals(value) Then
                    _extValue5.Text = value
                    PropertyHasChanged("ExtValue5")
                End If
            End Set
        End Property

        Private _ncWo0 As String = String.Empty
        <CellInfo(GroupName:="Analysis", Tips:="")>
        Public Property NcWo0() As String
            Get
                Return _ncWo0
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcWo0", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncWo0.Equals(value) Then
                    _ncWo0 = value
                    PropertyHasChanged("NcWo0")
                End If
            End Set
        End Property

        Private _ncWo1 As String = String.Empty
        <CellInfo(GroupName:="Analysis", Tips:="")>
        Public Property NcWo1() As String
            Get
                Return _ncWo1
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcWo1", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncWo1.Equals(value) Then
                    _ncWo1 = value
                    PropertyHasChanged("NcWo1")
                End If
            End Set
        End Property

        Private _ncWo2 As String = String.Empty
        <CellInfo(GroupName:="Analysis", Tips:="")>
        Public Property NcWo2() As String
            Get
                Return _ncWo2
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcWo2", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncWo2.Equals(value) Then
                    _ncWo2 = value
                    PropertyHasChanged("NcWo2")
                End If
            End Set
        End Property

        Private _ncWo3 As String = String.Empty
        <CellInfo(GroupName:="Analysis", Tips:="")>
        Public Property NcWo3() As String
            Get
                Return _ncWo3
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcWo3", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncWo3.Equals(value) Then
                    _ncWo3 = value
                    PropertyHasChanged("NcWo3")
                End If
            End Set
        End Property

        Private _ncWo4 As String = String.Empty
        <CellInfo(GroupName:="Analysis", Tips:="")>
        Public Property NcWo4() As String
            Get
                Return _ncWo4
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcWo4", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncWo4.Equals(value) Then
                    _ncWo4 = value
                    PropertyHasChanged("NcWo4")
                End If
            End Set
        End Property

        Private _ncWo5 As String = String.Empty
        <CellInfo(GroupName:="Analysis", Tips:="")>
        Public Property NcWo5() As String
            Get
                Return _ncWo5
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcWo5", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncWo5.Equals(value) Then
                    _ncWo5 = value
                    PropertyHasChanged("NcWo5")
                End If
            End Set
        End Property

        Private _ncWo6 As String = String.Empty
        <CellInfo(GroupName:="Analysis", Tips:="")>
        Public Property NcWo6() As String
            Get
                Return _ncWo6
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcWo6", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncWo6.Equals(value) Then
                    _ncWo6 = value
                    PropertyHasChanged("NcWo6")
                End If
            End Set
        End Property

        Private _ncWo7 As String = String.Empty
        <CellInfo(GroupName:="Analysis", Tips:="")>
        Public Property NcWo7() As String
            Get
                Return _ncWo7
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcWo7", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncWo7.Equals(value) Then
                    _ncWo7 = value
                    PropertyHasChanged("NcWo7")
                End If
            End Set
        End Property

        Private _ncWo8 As String = String.Empty
        <CellInfo(GroupName:="Analysis", Tips:="")>
        Public Property NcWo8() As String
            Get
                Return _ncWo8
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcWo8", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncWo8.Equals(value) Then
                    _ncWo8 = value
                    PropertyHasChanged("NcWo8")
                End If
            End Set
        End Property

        Private _ncWo9 As String = String.Empty
        <CellInfo(GroupName:="Analysis", Tips:="")>
        Public Property NcWo9() As String
            Get
                Return _ncWo9
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcWo9", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncWo9.Equals(value) Then
                    _ncWo9 = value
                    PropertyHasChanged("NcWo9")
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
            Return _woId
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            Dim pWoId As Integer = ID.Trim.ToInteger
            If _woId < pWoId Then Return -1
            If _woId > pWoId Then Return 1
            Return 0
        End Function

#End Region 'Business Properties and Methods

#Region "Validation Rules"
        'Check rule: Client code or client name is null
        Private Shared Function CheckClient(target As Object, e As RuleArgs) As Boolean
            Dim workOrder As WO = target
            If String.IsNullOrEmpty(workOrder.ClientId) AndAlso String.IsNullOrEmpty(workOrder.ClientName) Then
                e.Description = ResStr("You must enter value for Client ID or Client Name")
                Return False
            End If
            Return True
        End Function

        'Check rule: Client code or client name is null
        Private Shared Function CheckEquipment(target As Object, e As RuleArgs) As Boolean
            Dim workOrder As WO = target
            If String.IsNullOrEmpty(workOrder.EquCode) AndAlso String.IsNullOrEmpty(workOrder.EquDesc) Then
                e.Description = ResStr("You must enter value for Equipment Code or Equipment Description")
                Return False
            End If
            Return True
        End Function


        Private Sub AddSharedCommonRules()
            'Sample simple custom rule
            'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           
            ValidationRules.AddRule(AddressOf CheckClient, "ClientId", 1)
            ValidationRules.AddRule(AddressOf CheckClient, "ClientName", 1)
            ValidationRules.AddRule(AddressOf CheckEquipment, "EquCode", 1)
            ValidationRules.AddRule(AddressOf CheckEquipment, "EquDesc", 1)

            'Sample dependent property. when check one , check the other as well
            'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
            ValidationRules.AddDependantProperty("ClientId", "ClientName", True)
            ValidationRules.AddDependantProperty("EquCode", "EquDesc", True)

        End Sub

        Protected Overrides Sub AddBusinessRules()
            AddSharedCommonRules()

            For Each _field As ClassField In ClassSchema(Of WO)._fieldList
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

        Public Shared Function BlankWO() As WO
            Return New WO
        End Function

        Public Shared Function NewWO(ByVal pWoId As String) As WO
            'If KeyDuplicated(pWoId) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("WO")))
            Return DataPortal.Create(Of WO)(New Criteria(pWoId.ToInteger))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As WO
            Dim pWoId As String = ID.Trim.ToInteger

            Return NewWO(pWoId)
        End Function

        Public Shared Function GetWO(ByVal pWoId As String) As WO
            Return DataPortal.Fetch(Of WO)(New Criteria(pWoId.ToInteger))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As WO
            Dim pWoId As String = ID.Trim.ToInteger

            Return GetWO(pWoId)
        End Function

        Public Shared Sub DeleteWO(ByVal pWoId As String)
            DataPortal.Delete(New Criteria(pWoId.ToInteger))
        End Sub

        Public Overrides Function Save() As WO
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("WO")))

            Me.ApplyEdit()
            WOInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneWO(ByVal pWoId As String) As WO

            'If WO.KeyDuplicated(pWoId) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningWO As WO = MyBase.Clone
            cloningWO._woId = 0
            cloningWO._DTB = Context.CurrentBECode

            'Todo:Remember to reset status of the new object here 
            cloningWO.MarkNew()

            'mark all child in WOE, WOL and WOP are new
            For Each itm In cloningWO._woeDetails
                itm.MarkAsNewChild()
            Next

            For Each itm In cloningWO._wolDetails
                itm.MarkAsNewChild()
            Next

            For Each itm In cloningWO._wopDetails
                itm.MarkAsNewChild()
            Next

            cloningWO.ApplyEdit()

            cloningWO.ValidationRules.CheckRules()

            Return cloningWO
        End Function

#End Region ' Factory Methods

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public _woId As Integer

            Public Sub New(ByVal pWoId As String)
                _woId = pWoId.ToInteger

            End Sub
        End Class

        <RunLocal()> _
        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            _woId = criteria._woId

            ValidationRules.CheckRules()
        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()
                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>
                                         SELECT * FROM pbs_SC_WO_<%= _DTB %> WHERE WO_ID= <%= criteria._woId %>
                                         SELECT * FROM pbs_SC_WO_EVENT_<%= _DTB %> WHERE WO_ID= <%= criteria._woId %>


                                     </SqlText>.Value.Trim

                    Using dr As New SafeDataReader(cm.ExecuteReader)
                        If dr.Read Then
                            FetchObject(dr)
                            MarkOld()
                        End If

                        'If dr.NextResult Then
                        '    _woeDetails = WOEs.GetWOEs(dr, Me)
                        'End If
                    End Using

                    'fetch data from WOE, WOL and WOD
                    cm.CommandText = <SqlText>SELECT * FROM pbs_SC_WO_EVENT_<%= _DTB %> WHERE WO_ID= <%= criteria._woId %></SqlText>.Value.Trim
                    Using dr As New SafeDataReader(cm.ExecuteReader)
                        _woeDetails = WOEs.GetWOEs(dr, Me)
                    End Using

                    cm.CommandText = <SqlText>SELECT * FROM pbs_SC_WO_LABOR_<%= _DTB %> WHERE WO_ID= <%= criteria._woId %></SqlText>.Value.Trim
                    Using dr As New SafeDataReader(cm.ExecuteReader)
                        _wolDetails = WOLs.GetWOLs(dr, Me)
                    End Using

                    cm.CommandText = <SqlText>SELECT * FROM pbs_SC_WO_PARTS_<%= _DTB %> WHERE WO_ID= <%= criteria._woId %></SqlText>.Value.Trim
                    Using dr As New SafeDataReader(cm.ExecuteReader)
                        _wopDetails = WOPs.GetWOPs(dr, Me)
                    End Using
                End Using
            End Using
        End Sub

        Private Sub FetchObject(ByVal dr As SafeDataReader)
            _woId = dr.GetInt32("WO_ID")
            _woType = dr.GetString("WO_TYPE").TrimEnd
            _woStatus = dr.GetString("WO_STATUS").TrimEnd
            _referenceNo = dr.GetString("REFERENCE_NO").TrimEnd
            _clientId = dr.GetString("CLIENT_ID").TrimEnd
            _contactId = dr.GetString("CONTACT_ID").TrimEnd
            _clientName = dr.GetString("CLIENT_NAME").TrimEnd
            _contactName = dr.GetString("CONTACT_NAME").TrimEnd
            _address = dr.GetString("ADDRESS").TrimEnd
            _mobile = dr.GetString("MOBILE").TrimEnd
            _phone = dr.GetString("PHONE").TrimEnd
            _email = dr.GetString("EMAIL").TrimEnd
            _woDate.Text = dr.GetInt32("WO_DATE")
            _woTime.Text = dr.GetInt32("WO_TIME")
            _woDueDate.Text = dr.GetInt32("WO_DUE_DATE")
            _woDueTime.Text = dr.GetInt32("WO_DUE_TIME")
            _locCode = dr.GetString("LOC_CODE").TrimEnd
            _equCode = dr.GetString("EQU_CODE").TrimEnd
            _partNo = dr.GetString("PART_NO").TrimEnd
            _serialNo = dr.GetString("SERIAL_NO").TrimEnd
            _barCode = dr.GetString("BAR_CODE").TrimEnd
            _equDesc = dr.GetString("EQU_DESC").TrimEnd
            _problem = dr.GetString("PROBLEM").TrimEnd
            _remedy = dr.GetString("REMEDY").TrimEnd
            _worNotes = dr.GetString("WOR_NOTES").TrimEnd
            _receivedBy = dr.GetString("RECEIVED_BY").TrimEnd
            _processBy = dr.GetString("PROCESS_BY").TrimEnd
            _extDate1.Text = dr.GetInt32("EXT_DATE1")
            _extDate2.Text = dr.GetInt32("EXT_DATE2")
            _extDate3.Text = dr.GetInt32("EXT_DATE3")
            _extDate4.Text = dr.GetInt32("EXT_DATE4")
            _extDate5.Text = dr.GetInt32("EXT_DATE5")
            _extValue1.Text = dr.GetDecimal("EXT_VALUE1")
            _extValue2.Text = dr.GetDecimal("EXT_VALUE2")
            _extValue3.Text = dr.GetDecimal("EXT_VALUE3")
            _extValue4.Text = dr.GetDecimal("EXT_VALUE4")
            _extValue5.Text = dr.GetDecimal("EXT_VALUE5")
            _ncWo0 = dr.GetString("NC_WO0").TrimEnd
            _ncWo1 = dr.GetString("NC_WO1").TrimEnd
            _ncWo2 = dr.GetString("NC_WO2").TrimEnd
            _ncWo3 = dr.GetString("NC_WO3").TrimEnd
            _ncWo4 = dr.GetString("NC_WO4").TrimEnd
            _ncWo5 = dr.GetString("NC_WO5").TrimEnd
            _ncWo6 = dr.GetString("NC_WO6").TrimEnd
            _ncWo7 = dr.GetString("NC_WO7").TrimEnd
            _ncWo8 = dr.GetString("NC_WO8").TrimEnd
            _ncWo9 = dr.GetString("NC_WO9").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_SC_WO_{0}_Insert", _DTB)

                        cm.Parameters.AddWithValue("@WO_ID", _woId).Direction = ParameterDirection.Output
                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()

                        _woId = CInt(cm.Parameters("@WO_ID").Value)
                    End Using

                    Me.WoeDetails.Update(ctx.Connection, Me)
                    Me.WolDetails.Update(ctx.Connection, Me)
                    Me.WopDetails.Update(ctx.Connection, Me)
                End Using
            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As SqlCommand)
            cm.Parameters.AddWithValue("@WO_TYPE", _woType.Trim)
            cm.Parameters.AddWithValue("@WO_STATUS", _woStatus.Trim)
            cm.Parameters.AddWithValue("@REFERENCE_NO", _referenceNo.Trim)
            cm.Parameters.AddWithValue("@CLIENT_ID", _clientId.Trim)
            cm.Parameters.AddWithValue("@CONTACT_ID", _contactId.Trim)
            cm.Parameters.AddWithValue("@CLIENT_NAME", _clientName.Trim)
            cm.Parameters.AddWithValue("@CONTACT_NAME", _contactName.Trim)
            cm.Parameters.AddWithValue("@ADDRESS", _address.Trim)
            cm.Parameters.AddWithValue("@MOBILE", _mobile.Trim)
            cm.Parameters.AddWithValue("@PHONE", _phone.Trim)
            cm.Parameters.AddWithValue("@EMAIL", _email.Trim)
            cm.Parameters.AddWithValue("@WO_DATE", _woDate.DBValue)
            cm.Parameters.AddWithValue("@WO_TIME", _woTime.DBValue)
            cm.Parameters.AddWithValue("@WO_DUE_DATE", _woDueDate.DBValue)
            cm.Parameters.AddWithValue("@WO_DUE_TIME", _woDueTime.DBValue)
            cm.Parameters.AddWithValue("@LOC_CODE", _locCode.Trim)
            cm.Parameters.AddWithValue("@EQU_CODE", _equCode.Trim)
            cm.Parameters.AddWithValue("@PART_NO", _partNo.Trim)
            cm.Parameters.AddWithValue("@SERIAL_NO", _serialNo.Trim)
            cm.Parameters.AddWithValue("@BAR_CODE", _barCode.Trim)
            cm.Parameters.AddWithValue("@EQU_DESC", _equDesc.Trim)
            cm.Parameters.AddWithValue("@PROBLEM", _problem.Trim)
            cm.Parameters.AddWithValue("@REMEDY", _remedy.Trim)
            cm.Parameters.AddWithValue("@WOR_NOTES", _worNotes.Trim)
            cm.Parameters.AddWithValue("@RECEIVED_BY", _receivedBy.Trim)
            cm.Parameters.AddWithValue("@PROCESS_BY", _processBy.Trim)
            cm.Parameters.AddWithValue("@EXT_DATE1", _extDate1.DBValue)
            cm.Parameters.AddWithValue("@EXT_DATE2", _extDate2.DBValue)
            cm.Parameters.AddWithValue("@EXT_DATE3", _extDate3.DBValue)
            cm.Parameters.AddWithValue("@EXT_DATE4", _extDate4.DBValue)
            cm.Parameters.AddWithValue("@EXT_DATE5", _extDate5.DBValue)
            cm.Parameters.AddWithValue("@EXT_VALUE1", _extValue1.DBValue)
            cm.Parameters.AddWithValue("@EXT_VALUE2", _extValue2.DBValue)
            cm.Parameters.AddWithValue("@EXT_VALUE3", _extValue3.DBValue)
            cm.Parameters.AddWithValue("@EXT_VALUE4", _extValue4.DBValue)
            cm.Parameters.AddWithValue("@EXT_VALUE5", _extValue5.DBValue)
            cm.Parameters.AddWithValue("@NC_WO0", _ncWo0.Trim)
            cm.Parameters.AddWithValue("@NC_WO1", _ncWo1.Trim)
            cm.Parameters.AddWithValue("@NC_WO2", _ncWo2.Trim)
            cm.Parameters.AddWithValue("@NC_WO3", _ncWo3.Trim)
            cm.Parameters.AddWithValue("@NC_WO4", _ncWo4.Trim)
            cm.Parameters.AddWithValue("@NC_WO5", _ncWo5.Trim)
            cm.Parameters.AddWithValue("@NC_WO6", _ncWo6.Trim)
            cm.Parameters.AddWithValue("@NC_WO7", _ncWo7.Trim)
            cm.Parameters.AddWithValue("@NC_WO8", _ncWo8.Trim)
            cm.Parameters.AddWithValue("@NC_WO9", _ncWo9.Trim)
            cm.Parameters.AddWithValue("@UPDATED", ToDay.ToSunDate)
            cm.Parameters.AddWithValue("@UPDATED_BY", Context.CurrentUserCode)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_SC_WO_{0}_Update", _DTB)

                        cm.Parameters.AddWithValue("@WO_ID", _woId)
                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()
                    End Using

                    Me.WoeDetails.Update(ctx.Connection, Me)
                    Me.WolDetails.Update(ctx.Connection, Me)
                    Me.WopDetails.Update(ctx.Connection, Me)
                End Using
            End SyncLock
        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_woId))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>
                                         DELETE pbs_SC_WO_<%= _DTB %> WHERE WO_ID= <%= criteria._woId %>
                                         DELETE pbs_SC_WO_EVENT_<%= _DTB %> WHERE WO_ID= <%= criteria._woId %>
                                         DELETE pbs_SC_WO_LABOR_<%= _DTB %> WHERE WO_ID= <%= criteria._woId %>
                                         DELETE pbs_SC_WO_PARTS_<%= _DTB %> WHERE WO_ID= <%= criteria._woId %>

                                     </SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
        '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
        '        WOInfoList.InvalidateCache()
        '    End If
        'End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pWoId As String) As Boolean
            Return WOInfoList.ContainsCode(pWoId)
        End Function

        'Public Shared Function KeyDuplicated(ByVal pWoId As String) As Boolean
        '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_SC_WO_<%= Context.CurrentBECode %> WHERE WO_ID= <%= pWoId %></SqlText>.Value.Trim
        '    Return SQLCommander.GetScalarInteger(SqlText) > 0
        'End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return CloneWO(id)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(WO).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(WO).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return WOInfoList.GetWOInfoList
        End Function
#End Region

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _woId)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region

    End Class

End Namespace