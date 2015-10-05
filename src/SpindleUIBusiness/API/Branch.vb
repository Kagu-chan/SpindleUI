Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.Business.API

    Public Structure Branch
        Public name As String
        Public commit As Commit
    End Structure
End Namespace
