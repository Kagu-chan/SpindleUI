Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.Business.API

    Public Structure User
        Public login As String
        Public id As UInteger
        Public avatar_url As String
        Public gravatar_id As String
        Public url As String
        Public html_url As String
        Public follower_urls As String
        Public following_url As String
        Public gists_url As String
        Public starred_url As String
        Public subscriptions_url As String
        Public organizations_url As String
        Public repos_url As String
        Public events_url As String
        Public received_events_url As String
        Public type As String
        Public site_admin As Boolean
    End Structure

End Namespace