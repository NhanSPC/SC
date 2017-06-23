Imports pbs.BO.DataAnnotations

Namespace SC

    Partial Class WO



        <ComponentModel.Browsable(False)>
        Public Overrides ReadOnly Property IsDirty As Boolean
            Get
                Return MyBase.IsDirty OrElse WoeDetails.IsDirty OrElse WolDetails.IsDirty OrElse WopDetails.IsDirty
            End Get
        End Property

        <ComponentModel.Browsable(False)>
        Public Overrides ReadOnly Property IsValid As Boolean
            Get
                Return MyBase.IsValid AndAlso WoeDetails.IsValid AndAlso WolDetails.IsValid AndAlso WopDetails.IsValid
            End Get
        End Property

        Private _woeDetails As WOEs = Nothing
        <TableRangeInfo()>
        ReadOnly Property WoeDetails As WOEs
            Get
                If _woeDetails Is Nothing Then
                    _woeDetails = WOEs.NewWOEs(Me)
                End If
                Return _woeDetails
            End Get
        End Property

        Private _wolDetails As WOLs = Nothing
        <TableRangeInfo()>
        ReadOnly Property WolDetails As WOLs
            Get
                If _wolDetails Is Nothing Then
                    _wolDetails = WOLs.NewWOLs(Me)
                End If
                Return _wolDetails
            End Get
        End Property

        Private _wopDetails As WOps = Nothing
        <TableRangeInfo()>
        ReadOnly Property WopDetails As WOps
            Get
                If _wopDetails Is Nothing Then
                    _wopDetails = WOps.NewWOps(Me)
                End If
                Return _wopDetails
            End Get
        End Property
    End Class

End Namespace
