
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

Namespace SC

    <Serializable()> _
    Public Class WOInfo
        Inherits Csla.ReadOnlyBase(Of WOInfo)
        Implements IComparable
        Implements IInfo
        Implements IDocLink
        'Implements IInfoStatus


#Region " Business Properties and Methods "


        Private _woId As Integer
        Public ReadOnly Property WoId() As String
            Get
                Return _woId
            End Get
        End Property

        Private _woType As String = String.Empty
        Public ReadOnly Property WoType() As String
            Get
                Return _woType
            End Get
        End Property

        Private _woStatus As String = String.Empty
        Public ReadOnly Property WoStatus() As String
            Get
                Return _woStatus
            End Get
        End Property

        Private _referenceNo As String = String.Empty
        Public ReadOnly Property ReferenceNo() As String
            Get
                Return _referenceNo
            End Get
        End Property

        Private _clientId As String = String.Empty
        Public ReadOnly Property ClientId() As String
            Get
                Return _clientId
            End Get
        End Property

        Private _contactId As String = String.Empty
        Public ReadOnly Property ContactId() As String
            Get
                Return _contactId
            End Get
        End Property

        Private _clientName As String = String.Empty
        Public ReadOnly Property ClientName() As String
            Get
                Return _clientName
            End Get
        End Property

        Private _contactName As String = String.Empty
        Public ReadOnly Property ContactName() As String
            Get
                Return _contactName
            End Get
        End Property

        Private _address As String = String.Empty
        Public ReadOnly Property Address() As String
            Get
                Return _address
            End Get
        End Property

        Private _mobile As String = String.Empty
        Public ReadOnly Property Mobile() As String
            Get
                Return _mobile
            End Get
        End Property

        Private _phone As String = String.Empty
        Public ReadOnly Property Phone() As String
            Get
                Return _phone
            End Get
        End Property

        Private _email As String = String.Empty
        Public ReadOnly Property Email() As String
            Get
                Return _email
            End Get
        End Property

        Friend _woDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property WoDate() As String
            Get
                Return _woDate.DateViewFormat
            End Get
        End Property

        Private _woTime As pbs.Helper.SmartTime = New pbs.Helper.SmartTime()
        Public ReadOnly Property WoTime() As String
            Get
                Return _woTime.Text
            End Get
        End Property

        Friend _woDueDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property WoDueDate() As String
            Get
                Return _woDueDate.DateViewFormat
            End Get
        End Property

        Private _woDueTime As pbs.Helper.SmartTime = New pbs.Helper.SmartTime()
        Public ReadOnly Property WoDueTime() As String
            Get
                Return _woDueTime.Text
            End Get
        End Property

        Private _locCode As String = String.Empty
        Public ReadOnly Property LocCode() As String
            Get
                Return _locCode
            End Get
        End Property

        Private _equCode As String = String.Empty
        Public ReadOnly Property EquCode() As String
            Get
                Return _equCode
            End Get
        End Property

        Private _partNo As String = String.Empty
        Public ReadOnly Property PartNo() As String
            Get
                Return _partNo
            End Get
        End Property

        Private _serialNo As String = String.Empty
        Public ReadOnly Property SerialNo() As String
            Get
                Return _serialNo
            End Get
        End Property

        Private _barCode As String = String.Empty
        Public ReadOnly Property BarCode() As String
            Get
                Return _barCode
            End Get
        End Property

        Private _equDesc As String = String.Empty
        Public ReadOnly Property EquDesc() As String
            Get
                Return _equDesc
            End Get
        End Property

        Private _problem As String = String.Empty
        Public ReadOnly Property Problem() As String
            Get
                Return _problem
            End Get
        End Property

        Private _remedy As String = String.Empty
        Public ReadOnly Property Remedy() As String
            Get
                Return _remedy
            End Get
        End Property

        Private _worNotes As String = String.Empty
        Public ReadOnly Property WorNotes() As String
            Get
                Return _worNotes
            End Get
        End Property

        Private _receivedBy As String = String.Empty
        Public ReadOnly Property ReceivedBy() As String
            Get
                Return _receivedBy
            End Get
        End Property

        Private _processBy As String = String.Empty
        Public ReadOnly Property ProcessBy() As String
            Get
                Return _processBy
            End Get
        End Property

        Private _extDate1 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExtDate1() As String
            Get
                Return _extDate1.DateViewFormat
            End Get
        End Property

        Private _extDate2 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExtDate2() As String
            Get
                Return _extDate2.DateViewFormat
            End Get
        End Property

        Private _extDate3 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExtDate3() As String
            Get
                Return _extDate3.DateViewFormat
            End Get
        End Property

        Private _extDate4 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExtDate4() As String
            Get
                Return _extDate4.DateViewFormat
            End Get
        End Property

        Private _extDate5 As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property ExtDate5() As String
            Get
                Return _extDate5.DateViewFormat
            End Get
        End Property

        Private _extValue1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExtValue1() As String
            Get
                Return _extValue1.Text
            End Get
        End Property

        Private _extValue2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExtValue2() As String
            Get
                Return _extValue2.Text
            End Get
        End Property

        Private _extValue3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExtValue3() As String
            Get
                Return _extValue3.Text
            End Get
        End Property

        Private _extValue4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExtValue4() As String
            Get
                Return _extValue4.Text
            End Get
        End Property

        Private _extValue5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ExtValue5() As String
            Get
                Return _extValue5.Text
            End Get
        End Property

        Private _ncWo0 As String = String.Empty
        Public ReadOnly Property NcWo0() As String
            Get
                Return _ncWo0
            End Get
        End Property

        Private _ncWo1 As String = String.Empty
        Public ReadOnly Property NcWo1() As String
            Get
                Return _ncWo1
            End Get
        End Property

        Private _ncWo2 As String = String.Empty
        Public ReadOnly Property NcWo2() As String
            Get
                Return _ncWo2
            End Get
        End Property

        Private _ncWo3 As String = String.Empty
        Public ReadOnly Property NcWo3() As String
            Get
                Return _ncWo3
            End Get
        End Property

        Private _ncWo4 As String = String.Empty
        Public ReadOnly Property NcWo4() As String
            Get
                Return _ncWo4
            End Get
        End Property

        Private _ncWo5 As String = String.Empty
        Public ReadOnly Property NcWo5() As String
            Get
                Return _ncWo5
            End Get
        End Property

        Private _ncWo6 As String = String.Empty
        Public ReadOnly Property NcWo6() As String
            Get
                Return _ncWo6
            End Get
        End Property

        Private _ncWo7 As String = String.Empty
        Public ReadOnly Property NcWo7() As String
            Get
                Return _ncWo7
            End Get
        End Property

        Private _ncWo8 As String = String.Empty
        Public ReadOnly Property NcWo8() As String
            Get
                Return _ncWo8
            End Get
        End Property

        Private _ncWo9 As String = String.Empty
        Public ReadOnly Property NcWo9() As String
            Get
                Return _ncWo9
            End Get
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.DateViewFormat
            End Get
        End Property

        Private _updatedBy As String = String.Empty
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

        Public ReadOnly Property Code As String Implements IInfo.Code
            Get
                Return _woId
            End Get
        End Property

        Public ReadOnly Property LookUp As String Implements IInfo.LookUp
            Get
                Return _woId
            End Get
        End Property

        Public ReadOnly Property Description As String Implements IInfo.Description
            Get
                Return String.Format("Word oder no: {0}", _woId)
            End Get
        End Property


        Public Sub InvalidateCache() Implements IInfo.InvalidateCache
            WOInfoList.InvalidateCache()
        End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Friend Shared Function GetWOInfo(ByVal dr As SafeDataReader) As WOInfo
            Return New WOInfo(dr)
        End Function

        Friend Shared Function EmptyWOInfo(Optional ByVal pWoId As String = "") As WOInfo
            Dim info As WOInfo = New WOInfo
            With info
                ._woId = pWoId.ToInteger

            End With
            Return info
        End Function

        Private Sub New(ByVal dr As SafeDataReader)
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

        Private Sub New()
        End Sub


#End Region ' Factory Methods

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