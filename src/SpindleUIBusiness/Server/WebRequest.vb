Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.Business.Server

    Module WebRequest

        Private _lastResponse As Net.WebResponse

        Public Sub Request(uri As String)
            Dim request As Net.HttpWebRequest = DirectCast(System.Net.WebRequest.Create(uri), Net.HttpWebRequest)
            request.Timeout = 1000
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;.NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; InfoPath.2;.NET CLR 3.5.21022; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)"
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