Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.Business.API

    Public Structure Commit
        Public sha As String
        Public commit As InnerCommit
        Public url As String
        Public html_url As String
        Public comments_url As String
        Public author As User
        Public committer As User
        Public parents() As Parent
    End Structure

End Namespace