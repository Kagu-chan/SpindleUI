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
            Me.FlexStyle = Spindle.Business.Controls.FlexManageStyle.Both
            Me.ArrangeStyle = Spindle.Business.Controls.FlexArrangeStyle.Vertical
            Me.DisplayType = GetType(Spindle.Business.Controls.CHeadlineBox)
        End Sub

        Public Sub RegisterEvents()
            AddHandler Me.Load, AddressOf OnFormLoad
        End Sub

        Private Sub OnFormLoad(sender As Object, e As EventArgs)
            Dim libraries As Spindle.Business.Library.LibraryCollection = Spindle.Business.Library.LibraryCollection.FindFromServer()
            If libraries.Count = 0 Then
                Me.AddControl(New Business.Controls.CException("No Libraries available", "This can be due to connection issues or that the Update Server is not reachable for any other reason. Please check your internet connection!"))
            Else
                For Each library As Spindle.Business.Library.Library In libraries
                    Me.AddControl(New Controls.CLibraryInfo(library), library.NiceName)
                Next
            End If
        End Sub

    End Class

End Namespace