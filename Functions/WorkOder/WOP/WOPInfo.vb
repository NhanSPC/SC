﻿
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

Namespace SC

    <Serializable()> _
    Public Class WOPInfo
        Inherits Csla.ReadOnlyBase(Of WOPInfo)
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

        Private _itemCode As String = String.Empty
        Public ReadOnly Property ItemCode() As String
            Get
                Return _itemCode
            End Get
        End Property

        Private _location As String = String.Empty
        Public ReadOnly Property Location() As String
            Get
                Return _location
            End Get
        End Property

        Private _issueDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property IssueDate() As String
            Get
                Return _issueDate.DateViewFormat
            End Get
        End Property

        Private _issueBy As String = String.Empty
        Public ReadOnly Property IssueBy() As String
            Get
                Return _issueBy
            End Get
        End Property

        Private _partNo As String = String.Empty
        Public ReadOnly Property PartNo() As String
            Get
                Return _partNo
            End Get
        End Property

        Private _descriptn As String = String.Empty
        Public ReadOnly Property Descriptn() As String
            Get
                Return _descriptn
            End Get
        End Property

        Private _unit As String = String.Empty
        Public ReadOnly Property Unit() As String
            Get
                Return _unit
            End Get
        End Property

        Private _qty As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Qty() As String
            Get
                Return _qty.Text
            End Get
        End Property

        Private _convCode As String = String.Empty
        Public ReadOnly Property ConvCode() As String
            Get
                Return _convCode
            End Get
        End Property

        Private _convRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ConvRate() As String
            Get
                Return _convRate.Text
            End Get
        End Property

        Private _transAmt As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property TransAmt() As String
            Get
                Return _transAmt.Text
            End Get
        End Property

        Private _amount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Amount() As String
            Get
                Return _amount.Text
            End Get
        End Property

        Private _value1 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value1() As String
            Get
                Return _value1.Text
            End Get
        End Property

        Private _value2 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value2() As String
            Get
                Return _value2.Text
            End Get
        End Property

        Private _value3 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value3() As String
            Get
                Return _value3.Text
            End Get
        End Property

        Private _value4 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value4() As String
            Get
                Return _value4.Text
            End Get
        End Property

        Private _value5 As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Value5() As String
            Get
                Return _value5.Text
            End Get
        End Property

        Private _charge As String = String.Empty
        Public ReadOnly Property Charge() As String
            Get
                Return _charge
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

        Private _updateBy As String = String.Empty
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
                Return _descriptn
            End Get
        End Property


        Public Sub InvalidateCache() Implements IInfo.InvalidateCache
            WOPInfoList.InvalidateCache()
        End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Friend Shared Function GetWOPInfo(ByVal dr As SafeDataReader) As WOPInfo
            Return New WOPInfo(dr)
        End Function

        Friend Shared Function EmptyWOPInfo(Optional ByVal pLineNo As String = "") As WOPInfo
            Dim info As WOPInfo = New WOPInfo
            With info
                ._lineNo = pLineNo.ToInteger

            End With
            Return info
        End Function

        Private Sub New(ByVal dr As SafeDataReader)
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