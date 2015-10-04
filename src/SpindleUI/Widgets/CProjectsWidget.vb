Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.UI.Widgets

    Public Class CProjectsWidget
        Inherits Spindle.Business.Controls.CFlexForm

        Public Sub New()
            InitializeComponent()
            RegisterEvents()
            Me.FlexStyle = Spindle.Business.Controls.FlexStyle.Both
            Me.ArrangeStyle = Spindle.Business.Controls.ArrangeStyle.Vertical
        End Sub

        Private Sub RegisterEvents()
            AddHandler Me.Load, AddressOf OnFormLoad
        End Sub

        Private Sub OnFormLoad(sender As Object, e As EventArgs)
            ' no controls yet
        End Sub

    End Class

End Namespace