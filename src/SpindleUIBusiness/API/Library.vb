Option Infer On
Imports System.Text
Imports Newtonsoft.Json

Namespace Spindle.Business.API

    Public Structure Library

        Public name As String
        Public nicename As String
        Public streams As IEnumerable(Of String)

    End Structure

End Namespace