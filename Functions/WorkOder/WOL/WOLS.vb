﻿Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports pbs.Helper

Namespace SC

    <Serializable()> _
    Public Class WOLs
        Inherits Csla.BusinessListBase(Of WOLs, WOL)

#Region " Business Methods"
        Friend _parent As WO = Nothing

        Protected Overrides Function AddNewCore() As Object
            If _parent IsNot Nothing Then
                Dim theNewLine = WOL.NewWOL(_parent.WoId)
                AddNewLine(theNewLine)
                theNewLine.CheckRules()
                Return theNewLine
            Else
                Return MyBase.AddNewCore
            End If
        End Function

        Friend Sub AddNewLine(ByVal pLine As WOL)
            If pLine Is Nothing Then Exit Sub

            'get the next line number
            Dim nextnumber As Integer = 1
            If Me.Count > 0 Then
                Dim allNumbers = (From line In Me Select line.LineNo).ToList
                nextnumber = allNumbers.Max + 1
            End If

            pLine._LineNo = nextnumber

            'Populate _line with info from parent here

            Me.Add(pLine)

        End Sub

#End Region
#Region " Factory Methods "

        Friend Shared Function NewWOLs(ByVal pParent As WO) As WOLs
            Return New WOLs(pParent)
        End Function

        Friend Shared Function GetWOLs(ByVal dr As SafeDataReader, ByVal parent As WO) As WOLs
            Dim ret = New WOLs(dr, parent)
            ret.MarkAsChild()
            Return ret
        End Function

        Private Sub New(ByVal parent As WO)
            _parent = parent
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As SafeDataReader, ByVal parent As WO)
            _parent = parent
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region ' Factory Methods
#Region " Data Access "

        Private Sub Fetch(ByVal dr As SafeDataReader)
            RaiseListChangedEvents = False

            Dim suppressChildValidation = True
            While dr.Read()
                Dim Line = WOL.GetChildWOL(dr)
                Me.Add(Line)
            End While

            RaiseListChangedEvents = True
        End Sub

        Friend Sub Update(ByVal cn As SqlConnection, ByVal parent As WO)
            RaiseListChangedEvents = False

            ' loop through each deleted child object
            For Each deletedChild As WOL In DeletedList
                deletedChild._DTB = parent._DTB
                deletedChild.DeleteSelf(cn)
            Next
            DeletedList.Clear()

            ' loop through each non-deleted child object
            For Each child As WOL In Me
                child._DTB = parent._DTB
                'child.OrderNo = parent.OrderNo
                child.WoId = parent.WoId

                If child.IsNew Then
                    child.Insert(cn)
                Else
                    child.Update(cn)
                End If
            Next

            RaiseListChangedEvents = True
        End Sub

#End Region ' Data Access                   
    End Class

End Namespace