Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.Business.Server

    Module WebRequest

        Private _lastResponse As Net.WebResponse

        Public Sub Request(uri As String)
            Dim request As Net.WebRequest = System.Net.WebRequest.Create(uri)
            _lastResponse = request.GetResponse()
        End Sub

        Public Function LastRequestSuceed() As Boolean
            Dim response As Net.HttpWebResponse = DirectCast(_lastResponse, Net.HttpWebResponse)
            Return response.StatusCode = Net.HttpStatusCode.OK
        End Function

        Public Function LastContent() As String
            Dim dataStream As IO.Stream = _lastResponse.GetResponseStream()
            Dim streamReader As New IO.StreamReader(dataStream)
            Return streamReader.ReadToEnd()
        End Function

    End Module
End Namespace