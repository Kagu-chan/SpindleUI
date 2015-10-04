Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.UI.Widgets

    Public Class CLibrariesWidget
        Inherits Spindle.Business.Controls.CFlexForm

        Public Sub New()
            InitializeComponent()
            RegisterEvents()
            Me.FlexStyle = Spindle.Business.Controls.FlexStyle.Both
            Me.ArrangeStyle = Spindle.Business.Controls.ArrangeStyle.Vertical
        End Sub

        Public Sub RegisterEvents()
            AddHandler Me.Load, AddressOf OnFormLoad
        End Sub

        Private Sub OnFormLoad(sender As Object, e As EventArgs)
            Dim libraries As Spindle.Business.Libraries.LibraryCollection = Spindle.Business.Libraries.LibraryCollection.FindFromServer()
            If IsNothing(libraries) Then
                Me.AddControl(New Controls.CLibraryNetException())
            Else
                For Each library As Spindle.Business.Libraries.Library In libraries
                    Me.AddControl(New Controls.CLibraryInfo(), library.Name)
                Next
            End If
        End Sub

    End Class

End Namespace