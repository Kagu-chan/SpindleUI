Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.UI.FlexForms

    Public Class FWelcome
        Inherits Spindle.Business.Controls.CFlexForm

        Public Sub New()
            InitializeComponent()
            RegisterEvents()
            Me.FlexStyle = Spindle.Business.Controls.FlexManageStyle.Both
            Me.ArrangeStyle = Spindle.Business.Controls.FlexArrangeStyle.Horizontal
        End Sub

        Private Sub RegisterEvents()
            AddHandler Me.Load, AddressOf OnFormLoad
        End Sub

        Private Sub OnFormLoad(sender As Object, e As EventArgs)
            Me.AddControl(New Widgets.CProjectsWidget(), "Projects")
            Me.AddControl(New Widgets.CLibrariesWidget(), "Libraries")
            Me.AddControl(New Widgets.CApplicationInfoWidget(), "Info")
        End Sub

    End Class

End Namespace