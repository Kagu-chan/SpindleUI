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
        End Sub

        Public Sub OnFormLoad()
            _AppStatus.FormTitle = "Welcome"
        End Sub

        Public Sub OnFormTitleChanged()
            Me.Text = _AppStatus.FormTitle
        End Sub

    End Class

End Namespace