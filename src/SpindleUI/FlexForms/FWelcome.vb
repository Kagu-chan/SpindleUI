Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.UI.FlexForms

    Public Class FWelcome

        Public Sub New()
            InitializeComponent()
            RegisterEvents()
        End Sub

        Private Sub RegisterEvents()
            AddHandler Me.Load, AddressOf OnFormLoad
        End Sub

        Private Sub OnFormLoad(sender As Object, e As EventArgs)

        End Sub

    End Class

End Namespace