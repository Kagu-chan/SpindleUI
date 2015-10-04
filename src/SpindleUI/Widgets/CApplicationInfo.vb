Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.UI

    Public Class CApplicationInfo

        Public Sub New()
            InitializeComponent()
            RegisterEvents()
        End Sub

        Private Sub RegisterEvents()
            AddHandler Me.Load, AddressOf OnFormLoad
            AddHandler Me.SizeChanged, AddressOf OnSizeChanged
        End Sub

        Private Sub OnFormLoad(sender As Object, e As EventArgs)
            GBVersionInfo.Text = "Application-Info"
            GBMiscInformation.Text = "Additional Info"
        End Sub

        Private Shadows Sub OnSizeChanged(sender As Object, e As EventArgs)
            Dim halfSize As New Size(Me.Width, CInt(Math.Round(Me.Height / 2)))
            Dim halfPos As New Point(0, halfSize.Height)
            Me.GBVersionInfo.Size = halfSize
            Me.GBMiscInformation.Size = halfSize
            Me.GBMiscInformation.Location = halfPos
        End Sub

    End Class

End Namespace