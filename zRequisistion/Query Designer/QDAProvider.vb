Imports pbs.Helper
Imports pbs.Helper.Interfaces

Namespace SQLBuilder

    Public Class QDAProvider
        Implements IQDSchemaProvider

        Private Function GetSchemaDic() As Dictionary(Of String, String) Implements IQDSchemaProvider.GetSchemaDic
            Dim ret = New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)

            For Each itm In GetTableInfoDic()
                Try

                    If Not ret.ContainsKey(itm.Key) Then
                        Dim QDSchema = My.Resources.ResourceManager.GetString(itm.Key)

                        ret.Add(itm.Key, QDSchema)
                    End If

                Catch ex As Exception
                    TextLogger.Log(ex)
                End Try
            Next

            Return ret
        End Function

        Private _tableInfos As Dictionary(Of String, String) = Nothing
        Private Function GetTableInfoDic() As Dictionary(Of String, String) Implements IQDSchemaProvider.GetTableInfoDic

            If _tableInfos Is Nothing Then

                _tableInfos = New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
                Try
                    Dim schema = My.Resources.SCHEMALIST_SC
                    Dim ele = XElement.Parse(schema)

                    For Each node In ele...<row>
                        Dim thekey = DNz(node.@table, String.Empty)
                        If Not _tableInfos.ContainsKey(thekey) Then
                            _tableInfos.Add(thekey, node.ToString)
                        End If
                    Next

                Catch ex As Exception
                    TextLogger.Log(ex)
                End Try
            End If

            Return _tableInfos
        End Function
    End Class

End Namespace
