Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Imports Newtonsoft.Json

Namespace Spindle.Business.Library

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
            Dim libraryPaths As String() = Server.FetchObject(Of String())(Configuration.LibrariesUrl)
            If IsNothing(libraryPaths) Then Return Nothing

            Dim collection As New LibraryCollection()
            For Each libraryPath As String In libraryPaths
                Dim repository As Github.Repository = Server.FetchObject(Of Github.Repository)(libraryPath)
                If Not IsNothing(repository) Then
                    collection.Add(New Library(repository))
                End If
            Next
            Return collection
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