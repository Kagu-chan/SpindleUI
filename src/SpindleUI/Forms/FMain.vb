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

        Public Sub OnFormLoad()
            _AppStatus.FormTitle = "Welcome"
            _AppStatus.CurrentContext = New FlexForms.FWelcome()
        End Sub

        Public Sub OnFormTitleChanged()
            Me.Text = _AppStatus.FormTitle
        End Sub

        Public Sub OnCurrentContextChanged()
            Me.Controls.Clear()
            Me.Controls.Add(_AppStatus.CurrentContext)
        End Sub

    End Class

End Namespace