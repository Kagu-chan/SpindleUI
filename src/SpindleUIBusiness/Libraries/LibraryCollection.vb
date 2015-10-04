Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.Business.Libraries

    Public Class LibraryCollection
        Inherits System.Collections.CollectionBase

        Public Shared Function FindFromServer() As LibraryCollection
            Dim collection As New LibraryCollection()

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