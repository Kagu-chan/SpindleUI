Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.UI

    Public Class FMain

        Private _AppStatus As New Business.AppStatus()

        Public Sub New()
            InitializeComponent()
            RegisterEvents()
        End Sub

        Private Sub RegisterEvents()
            AddHandler Me.Load, AddressOf OnFormLoad
            AddHandler _AppStatus.FormTitleChanged, AddressOf OnFormTitleChanged
            AddHandler _AppStatus.CurrentContextChanged, AddressOf OnCurrentContextChanged
        End Sub

        Private Sub OnFormLoad(sender As Object, e As EventArgs)
            _AppStatus.FormTitle = "Welcome"
            _AppStatus.CurrentContext = New FlexForms.FWelcome()

            Me.MinimumSize = New Size(Spindle.Business.Configuration.FormMinimumWidth, Spindle.Business.Configuration.FormMinimumHeight)
        End Sub

        Private Sub OnFormTitleChanged(sender As Object, e As EventArgs)
            Me.Text = _AppStatus.FormTitle
        End Sub

        Private Sub OnCurrentContextChanged(sender As Object, e As EventArgs)
            Me.Controls.Clear()
            Me.Controls.Add(_AppStatus.CurrentContext)
        End Sub

    End Class

End Namespace