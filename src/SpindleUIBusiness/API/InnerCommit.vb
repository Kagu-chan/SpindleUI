Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.Business.API

    Public Structure InnerCommit
        Public author As UserThin
        Public committer As UserThin
        Public message As String
        Public tree As Tree
        Public url As String
        Public comment_count As UInteger
    End Structure
End Namespace
