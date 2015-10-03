Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.UI.FlexForms

    Public Class FWelcome
        Inherits Spindle.Business.Controls.ManagebleControl

        Public Sub New()
            InitializeComponent()
            RegisterEvents()
            Me.ManageStyle = Business.Controls.ManageStyle.Both
        End Sub

        Private Sub RegisterEvents()
            AddHandler Me.Load, AddressOf OnFormLoad
        End Sub

        Private Sub OnFormLoad(sender As Object, e As EventArgs)
            Me.AddControl(New CProjectsWidget(), DockStyle.Left, "Projects")
            Me.AddControl(New CApplicationInfo(), DockStyle.Right, "Info")
        End Sub

    End Class

End Namespace