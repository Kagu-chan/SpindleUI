Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.UI.Controls

    Public Class CLibraryInfo

        Private _library As Business.Library.Library = New Business.Library.Library

        Public Sub New()
            Initialize(Nothing)
        End Sub

        Public Sub New(library As Business.Library.Library)
            Initialize(library)
        End Sub

        Private Sub Initialize(library As Business.Library.Library)
            InitializeComponent()
            _library = library

            'AddTextLabel("Version", _library.VersionString)
            'AddTextLabel("Author", _library.Creator)
            'AddTextLabel("Description", _library.Description)
            'AddTextLabel("Web", _library.PublicDomain)
            'AddTextLabel("Last Change", _library.LastCommit)
            'AddTextLabel("", _library.LastCommitDate)
            'AddTextLabel("", _library.LastCommitMessage)
            'AddTextLabel("", _library.LastCommitPublicDomain)

            AddHandler Me.SizeChanged, AddressOf OnSizeChanged
        End Sub

        Private Sub AddTextLabel(title As String, content As String)
            Dim leftLabel As New Label() With {.Text = title}
            Dim rightLabel As New Label() With {.Text = content}
            Me.Controls.AddRange({leftLabel, rightLabel})
        End Sub

        Private Shadows Sub OnSizeChanged(sender As Object, e As EventArgs)
            Dim i As Integer = 0
            Dim topIndex As Integer = 0
            Dim leftBase As Integer = CInt(Math.Round(Me.Size.Width * 0.25F))

            For Each ctrl As Control In Me.Controls
                Dim left = (i Mod 2) * leftBase
                Dim height As Integer = ctrl.Size.Height

                Dim size As New Size(If(left = 0, leftBase, Me.Size.Width - leftBase), height)
                Dim location As New Point(left, height * topIndex)

                ctrl.Size = size
                ctrl.Location = location

                i += 1
                If left <> 0 Then topIndex += 1
            Next
        End Sub

    End Class

End Namespace