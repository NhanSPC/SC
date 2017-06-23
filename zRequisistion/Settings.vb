Imports pbs.Helper
Imports pbs.Helper.Extensions
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports pbs.BO.DataAnnotations
Imports System.Xml.Linq
Imports pbs.BO.BusinessRules
Imports pbs.BO.Script

Namespace SC

    <Serializable>
    <PhoebusCommand(Desc:="Project Management Settings")>
    Public Class Settings
        Inherits Csla.BusinessBase(Of Settings)
        Implements Interfaces.IGenPartObject
        Implements IComparable
        Implements ISingleton
        Implements ILookupProvider
        Implements ISupportScripts

        Public Shared Sub RegisterModule()
            'do nothing .called from Phoebus system
        End Sub

#Region " Business Properties and Methods "
        Private _DTB As String = String.Empty

        Public Const STR_Settings = "SC_Settings"

        Friend Function GetConnectionString() As String
            Return pbs.Helper.ConfigService.DBConnectionService.GetConnectionString(_connectionID)
        End Function

#Region "Open Date / Period"

        Private _connectionID As String = String.Empty
        <CellInfo(ControlType:=Forms.CtrlType.Lookup, GroupName:="Service", Tips:="Select the connection from the list. Create new connection with pbs.BO.DB.DBC")>
        Public Property ConnectionID() As String
            Get
                CanReadProperty("ConnectionID", True)
                Return _connectionID
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ConnectionID", True)
                If value Is Nothing Then value = String.Empty
                If Not _connectionID.Equals(value) Then
                    _connectionID = value
                    PropertyHasChanged("ConnectionID")
                End If
            End Set
        End Property


#End Region

#Region "Aging"

        Private _agingBand01 As String = String.Empty
        <CellInfo(GroupName:="Aging", Tips:="Band 1 of the aging analysis (default = 30 days)")>
        Public Property AgingBand01() As String
            Get
                Return _agingBand01
            End Get
            Set(ByVal value As String)
                value = Nz(value, String.Empty)
                If Not _agingBand01.Equals(value) Then
                    _agingBand01 = value
                    PropertyHasChanged("AgingBand01")
                End If
            End Set
        End Property

        Private _agingBand02 As String = String.Empty
        <CellInfo(GroupName:="Aging", Tips:="Band 2 of the aging analysis (default = 60 days)")>
        Public Property AgingBand02() As String
            Get
                Return _agingBand02
            End Get
            Set(ByVal value As String)
                value = Nz(value, String.Empty)
                If Not _agingBand02.Equals(value) Then
                    _agingBand02 = value
                    PropertyHasChanged("AgingBand02")
                End If
            End Set
        End Property

        Private _agingBand03 As String = String.Empty
        <CellInfo(GroupName:="Aging", Tips:="Band 3 of the aging analysis (default = 90 days)")>
        Public Property AgingBand03() As String
            Get
                Return _agingBand03
            End Get
            Set(ByVal value As String)
                value = Nz(value, String.Empty)
                If Not _agingBand03.Equals(value) Then
                    _agingBand03 = value
                    PropertyHasChanged("AgingBand03")
                End If
            End Set
        End Property

        Private _agingBand04 As String = String.Empty
        <CellInfo(GroupName:="Aging", Tips:="Band 4 of the aging analysis (default = 120 days)")>
        Public Property AgingBand04() As String
            Get
                Return _agingBand04
            End Get
            Set(ByVal value As String)
                value = Nz(value, String.Empty)
                If Not _agingBand04.Equals(value) Then
                    _agingBand04 = value
                    PropertyHasChanged("AgingBand04")
                End If
            End Set
        End Property

        'Private _agingBand05 As String = String.Empty
        '<CellInfo(GroupName:="Aging", Tips:="Band 5 of the aging analysis (default = 150 days)")>
        'Public Property AgingBand05() As String
        '    Get
        '        Return _agingBand05
        '    End Get
        '    Set(ByVal value As String)
        '        value = Nz(value, String.Empty)
        '        If Not _agingBand05.Equals(value) Then
        '            _agingBand05 = value
        '            PropertyHasChanged("AgingBand05")
        '        End If
        '    End Set
        'End Property

#End Region

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.Text
            End Get
        End Property

        'Get ID
        Protected Overrides Function GetIdValue() As Object
            Return pbs.Helper.Context.ServerName
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Return 0
        End Function

#End Region 'Business Properties and Methods

#Region "Validation Rules"

        Private Sub AddSharedCommonRules()

            'Sample simple custom rule
            'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           

            'Sample dependent property. when check one , check the other as well
            'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
        End Sub

        Protected Overrides Sub AddBusinessRules()
            AddSharedCommonRules()

            For Each _field As ClassField In ClassSchema(Of SM.Settings)._fieldList
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
            pbs.BO.Rules.BusinessRules.RegisterBusinessRules(Me)
            MyBase.AddBusinessRules()
        End Sub
#End Region ' Validation

#Region " Factory Methods "

        Private Sub New()
            _DTB = String.Empty
        End Sub

        Public Shared Function NewSettings() As Settings
            Dim ret = GetSettings()
            If ret Is Nothing Then ret = New Settings()
            Return ret
        End Function

        Public Shared Function NewBO(ByVal ID As String) As Settings
            Return NewSettings()
        End Function

        Private Shared _settings As Settings = Nothing

        Private Shared lockobj As New Object
        Public Shared Function GetSettings() As Settings
            SyncLock _lockObj
                If _settings Is Nothing Then _settings = DataPortal.Fetch(Of Settings)(New Criteria())
                Return _settings
            End SyncLock
        End Function

        Public Shared Function GetBO(ByVal ID As String) As Settings
            Dim theOldClone = GetSettings().Clone
            theOldClone.MarkOld() 'without this. editing form always treat editing object as new. and ask for saving everytime
            Return theOldClone

        End Function

        Public Shared Sub DeleteSettings(ByVal pServer As String)
            'nodeletion 
        End Sub

        Public Overrides Function Save() As Settings
            If Not IsDirty Then Throw New Csla.Validation.ValidationException(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("ValidationRules")))

            Me.ApplyEdit()
            _settings = MyBase.Save()

            Return _settings
        End Function

        Public Shared Sub InvalidateCache()
            _settings = Nothing
        End Sub

#End Region ' Factory Methods

#Region "Data Access"

        <Serializable()> _
        Private Class Criteria

            Public Sub New()
            End Sub
        End Class

        <RunLocal()> _
        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Using cn = ConnectionFactory.GetDBConnection(True)

                Using cm = cn.CreateSQLCommand
                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>SELECT * FROM pbs_RFMSC WHERE PBS_DB='<%= _DTB %>' AND PBS_TB='<%= RFMSC_TB.Repository %>' AND KEY_FIELDS= '<%= STR_Settings %>' </SqlText>.Value.Trim

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

            Dim data = dr.GetString("PSM_DATA").TrimEnd

            data = data.Decompress

            Try
                Dim xdr = XElement.Parse(data)

                _connectionID = Nz(xdr.GetString("_connectionID"), String.Empty).Trim

            Catch ex As Exception
            End Try

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj

                Using cn = ConnectionFactory.GetDBConnection(True)

                    Using cm = cn.CreateSQLCommand

                        cm.SetDBCommand(CommandType.StoredProcedure, "pbs_RFMSC_InsertUpdate")

                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()

                    End Using
                End Using

            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As IDbCommand)

            Dim _key As String = STR_Settings
            Dim _data = <ss>
                            <_connectionID><%= _connectionID %></_connectionID>

                        </ss>.ToString
            cm.Parameters.AddWithValue("@PBS_DB", String.Empty)
            cm.Parameters.AddWithValue("@PBS_TB", RFMSC_TB.Repository)
            cm.Parameters.AddWithValue("@KEY_FIELDS", _key.Trim)
            cm.Parameters.AddWithValue("@LOOKUP", String.Format("{0:HHmmss}", Now))
            cm.Parameters.AddWithValue("@UPDATED", ToDay().ToSunDate)
            cm.Parameters.AddWithValue("@PSM_DATA", _data.Compress)
        End Sub

        Protected Overrides Sub DataPortal_Update()
            DataPortal_Insert()
        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            'not delete a singleton
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)
            'not delete a singleton
        End Sub

#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pDummy As String) As Boolean
            Return KeyDuplicated(pDummy)
        End Function

        Public Shared Function KeyDuplicated(ByVal pClassName As String) As Boolean
            Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_RFMSC WHERE  PBS_DB='' AND PBS_TB='<%= RFMSC_TB.Repository %>' AND  KEY_FIELDS= '<%= STR_Settings %>'</SqlText>.Value.Trim
            Return SQLCommander.GetScalarInteger(SqlText) > 0
        End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return Me
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return New String() {Action._Amend}
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(Settings).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return "Project Management Settings"
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return Nothing
        End Function
#End Region

#Region "ILookupProvider"
        Public Function GetLookupListForProperty(pName As String) As IEnumerable Implements ILookupProvider.GetLookupListForProperty
            Select Case pName
                Case "ConnectionID"
                    Return pbs.BO.DB.DBCInfoList.GetDBCInfoList
            End Select
        End Function

        Public Function GetLookupURL(pName As String) As String Implements ILookupProvider.GetLookupURL
            Return Nothing
        End Function
#End Region

#Region "Script"

        Private Sub SetupDatabase()
            Dim cmd = New pbs.BO.SC.DB.ScriptInstaller
            Dim msg = New List(Of String)
            cmd.Install(msg)
            If msg.Count > 0 Then
                pbs.Helper.UIServices.ConfirmService.Confirm(String.Join(Environment.NewLine, msg.ToArray))
            End If
        End Sub

        Private Function SetupDatabase_Imp() As UITasks

            Dim scripts = New Script.UITasks(Me)

            scripts.IconName = "Setup"
            scripts.CaptionKey = "Setup Database"

            scripts.AddCallMethod(10, "SetupDatabase")
            scripts.RefreshUIWhenFinish = True

            Return scripts

        End Function

        Public Function GetScriptDictionary() As Dictionary(Of String, Script.UITasks) Implements ISupportScripts.GetScriptDictionary
            Dim _scripts = New Dictionary(Of String, UITasks)(StringComparer.OrdinalIgnoreCase)

            _scripts.Add(pbs.Helper.Action._Setup, SetupDatabase_Imp)

            Return _scripts
        End Function
#End Region

    End Class

End Namespace




