Imports System.Environment
Imports System.IO.Path

Namespace Spindle.Business.Persistence

    ''' <summary>
    ''' Gets and Sets Paths
    ''' </summary>
    Friend Class PathHandler

        ''' <summary>
        ''' Returns the Application Data Path
        ''' </summary>
        ''' <returns>%appdata% path</returns>
        Public Function GetAppPath() As String
            Return GetFolderPath(SpecialFolder.ApplicationData)
        End Function

        ''' <summary>
        ''' Concatenate multiple path partials to a full qualified path element
        ''' </summary>
        ''' <param name="partials">Path partials</param>
        ''' <returns>Path</returns>
        Public Function ConcatenatePaths(ParamArray ByVal partials() As String) As String
            Return Combine(partials)
        End Function

        ''' <summary>
        ''' Creates a directory if not exist
        ''' </summary>
        ''' <param name="path">Directories path</param>
        Public Sub CreateDirectory(path As String)
            If Not My.Computer.FileSystem.DirectoryExists(path) Then My.Computer.FileSystem.CreateDirectory(path)
        End Sub

    End Class

End Namespace