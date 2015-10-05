Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.Business.Github

    Public Structure Repository
        Public owner As User
        Public id As UInteger
        Public name As String
        Public full_name As String
        Public [private] As Boolean
        Public html_url As String
        Public description As String
        Public fork As Boolean
        Public url As String
        Public forks_url As String
        Public keys_url As String
        Public collaborators_url As String
        Public teams_url As String
        Public hooks_url As String
        Public issue_events_url As String
        Public events_url As String
        Public assignees_url As String
        Public branches_url As String
        Public tags_url As String
        Public blobs_url As String
        Public git_tags_url As String
        Public git_refs_url As String
        Public trees_url As String
        Public statuses_url As String
        Public languages_url As String
        Public stargazers_url As String
        Public contributors_url As String
        Public subscribers_url As String
        Public subscription_url As String
        Public commits_url As String
        Public git_commits_url As String
        Public comments_url As String
        Public issue_comment_url As String
        Public contents_url As String
        Public compare_url As String
        Public merges_url As String
        Public archive_url As String
        Public downloads_url As String
        Public issues_url As String
        Public pulls_url As String
        Public milestones_url As String
        Public notifications_url As String
        Public labels_url As String
        Public releases_url As String
        Public created_at As String
        Public updated_at As String
        Public pushed_at As String
        Public git_url As String
        Public ssh_url As String
        Public clone_url As String
        Public svn_url As String
        Public homepage As String
        Public size As UInteger
        Public stargazers_count As UInteger
        Public watchers_count As UInteger
        Public language As String
        Public default_branch As String
        Public has_issues As Boolean
        Public has_downloads As Boolean
        Public has_wiki As Boolean
        Public has_pages As Boolean
        Public mirror_url As String
        Public forks_count As UInteger
        Public open_issues_count As UInteger
        Public forks As UInteger
        Public open_issues As UInteger
        Public watchers As UInteger
        Public network_count As UInteger
        Public subscribers_count As UInteger
    End Structure

End Namespace