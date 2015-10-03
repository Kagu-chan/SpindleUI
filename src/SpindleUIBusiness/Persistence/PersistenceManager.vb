Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.Business.Persistence

    ''' <summary>
    ''' Save and Load Data
    ''' </summary>
    Public Class PersistenceManager

        Private _PathHandler As New PathHandler()

        Public Sub New()
            CreateStorage()
        End Sub

        ''' <summary>
        ''' Creates a default persistence storage for Spindle
        ''' </summary>
        Private Sub CreateStorage()
            _PathHandler.CreateDirectory(_PathHandler.ConcatenatePaths(_PathHandler.GetAppPath(), Configuration.SavePath))
        End Sub

    End Class

End Namespace