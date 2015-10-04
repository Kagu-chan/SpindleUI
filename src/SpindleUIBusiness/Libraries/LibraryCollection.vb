Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Imports Newtonsoft.Json

Namespace Spindle.Business.Libraries

    Public Class LibraryCollection
        Inherits System.Collections.CollectionBase

        Public Sub New()
        End Sub

        Public Sub New(libraries As IEnumerable(Of Library))
            For Each library As Library In libraries
                Me.Add(library)
            Next
        End Sub

        Public Shared Function FindFromServer() As LibraryCollection
            Spindle.Business.Server.WebRequest.Request(Configuration.LibrariesUrl)
            If Spindle.Business.Server.WebRequest.LastRequestSuceed() Then
                Dim response As String = Spindle.Business.Server.LastContent()
                Dim libraries As IEnumerable(Of Library) = JsonConvert.DeserializeObject(Of IEnumerable(Of Library))(response)

                Return New LibraryCollection(libraries)
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(library As Library)
            Me.List.Add(library)
        End Sub

        Public Sub Remove(index As Integer)
            If index >= 0 And index < Count Then
                Me.List.Remove(index)
            End If
        End Sub

        Public Function Item(index As Integer) As Library
            If index >= 0 And index < Count Then
                Return DirectCast(Me.List(index), Library)
            Else
                Return Nothing
            End If
        End Function

    End Class
End Namespace