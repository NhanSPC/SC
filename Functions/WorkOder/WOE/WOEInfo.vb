
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

Namespace SC

    <Serializable()> _
    Public Class WOEInfo
        Inherits Csla.ReadOnlyBase(Of WOEInfo)
        Implements IComparable
        Implements IInfo
        Implements IDocLink
        'Implements IInfoStatus


#Region " Business Properties and Methods "


        Private _lineNo As Integer
        Public ReadOnly Property LineNo() As String
            Get
                Return _lineNo
            End Get
        End Property

        Private _woId As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        Public ReadOnly Property WoId() As String
            Get
                Return _woId.Text
            End Get
        End Property

        Private _eventType As String = String.Empty
        Public ReadOnly Property EventType() As String
            Get
                Return _eventType
            End Get
        End Property

        Private _eventDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property EventDate() As String
            Get
                Return _eventDate.DateViewFormat
            End Get
        End Property

        Private _eventTime As pbs.Helper.SmartTime = New pbs.Helper.SmartTime()
        Public ReadOnly Property EventTime() As String
            Get
                Return _eventTime.Text
            End Get
        End Property

        Private _emplCode As String = String.Empty
        Public ReadOnly Property EmplCode() As String
            Get
                Return _emplCode
            End Get
        End Property

        Private _descriptn1 As String = String.Empty
        Public ReadOnly Property Descriptn1() As String
            Get
                Return _descriptn1
            End Get
        End Property

        Private _descriptn2 As String = String.Empty
        Public ReadOnly Property Descriptn2() As String
            Get
                Return _descriptn2
            End Get
        End Property

        Private _descriptn3 As String = String.Empty
        Public ReadOnly Property Descriptn3() As String
            Get
                Return _descriptn3
            End Get
        End Property

        Private _descriptn4 As String = String.Empty
        Public ReadOnly Property Descriptn4() As String
            Get
                Return _descriptn4
            End Get
        End Property

        Private _descriptn5 As String = String.Empty
        Public ReadOnly Property Descriptn5() As String
            Get
                Return _descriptn5
            End Get
        End Property

        Private _notes As String = String.Empty
        Public ReadOnly Property Notes() As String
            Get
                Return _notes
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

        Public ReadOnly Property Code As String Implements IInfo.Code
            Get
                Return _lineNo
            End Get
        End Property

        Public ReadOnly Property LookUp As String Implements IInfo.LookUp
            Get
                Return _lineNo
            End Get
        End Property

        Public ReadOnly Property Description As String Implements IInfo.Description
            Get
                Return _descriptn1
            End Get
        End Property


        Public Sub InvalidateCache() Implements IInfo.InvalidateCache
            WOEInfoList.InvalidateCache()
        End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Friend Shared Function GetWOEInfo(ByVal dr As SafeDataReader) As WOEInfo
            Return New WOEInfo(dr)
        End Function

        Friend Shared Function EmptyWOEInfo(Optional ByVal pLineNo As String = "") As WOEInfo
            Dim info As WOEInfo = New WOEInfo
            With info
                ._lineNo = pLineNo.ToInteger

            End With
            Return info
        End Function

        Private Sub New(ByVal dr As SafeDataReader)
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

        Private Sub New()
        End Sub

#End Region ' Factory Methods

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _lineNo)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region

    End Class

End Namespace