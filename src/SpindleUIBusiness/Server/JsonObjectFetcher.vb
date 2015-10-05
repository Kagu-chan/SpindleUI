Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Imports Newtonsoft.Json

Namespace Spindle.Business.Server

    Module JsonObjectFetcher

        Public Function FetchObject(Of T)(uri As String) As T
            WebRequest.Request(uri)
            If WebRequest.LastRequestSuceed Then
                Dim response As String = WebRequest.LastContent
                Try
                    Return JsonConvert.DeserializeObject(Of T)(response)
                Catch ex As Newtonsoft.Json.JsonSerializationException
                    Return Nothing
                End Try
            Else
                Return Nothing
            End If
        End Function

    End Module
End Namespace