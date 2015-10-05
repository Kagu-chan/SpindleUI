Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On
Imports System.Text
Imports Newtonsoft.Json

Namespace Spindle.Business.Library

    Public Class Library

        Private _repository As API.Repository
        Private _branch As API.Branch

        Public Initialized As Boolean = False
        Public Name As String = String.Empty
        Public NiceName As String = String.Empty
        Public Streams As IEnumerable(Of String) = {}
        Public Creator As String = String.Empty
        Public PublicDomain As String = String.Empty
        Public LastCommit As String = String.Empty
        Public LastCommitDate As String = String.Empty
        Public LastCommitMessage As String = String.Empty
        Public LastCommitPublicDomain As String = String.Empty
        Public Description As String = String.Empty
        Public VersionString As String = String.Empty

        Public Sub New()
        End Sub

        Public Sub New(name As String)
            Me.Name = name
        End Sub

        Public Sub New(library As API.Library)
            Me.Initialized = False
            Me.Name = library.name
            Me.NiceName = library.nicename
            Me.Streams = library.streams
        End Sub

        Public Sub New(repository As API.Repository)
            _repository = repository
            _branch = Server.FetchObject(Of API.Branch)(_repository.branches_url.Replace("{/branch}", "/master"))

            If Not IsNothing(_repository.name) Then Me.Name = _repository.name
            If Not IsNothing(_repository.owner.login) Then Me.Creator = _repository.owner.login
            If Not IsNothing(_repository.html_url) Then Me.PublicDomain = _repository.html_url
            If Not IsNothing(_branch.commit.sha) Then Me.LastCommit = _branch.commit.sha
            If Not IsNothing(_branch.commit.commit.author.date) Then Me.LastCommitDate = _branch.commit.commit.author.date
            If Not IsNothing(_branch.commit.commit.message) Then Me.LastCommitMessage = _branch.commit.commit.message
            If Not IsNothing(_branch.commit.html_url) Then Me.LastCommitPublicDomain = _branch.commit.html_url
            If Not IsNothing(_repository.description) Then Me.Description = _repository.description
            If Not String.IsNullOrEmpty(Me.LastCommitDate) Then Me.VersionString = "b" & RegularExpressions.Regex.Replace(Me.LastCommitDate, "-|T|:|Z", "")
        End Sub

    End Class
End Namespace
