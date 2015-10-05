Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Imports System.Windows.Forms

Namespace Spindle.Business.Controls

    Public Class CGroupBox
        Inherits GroupBox

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            If Not String.IsNullOrEmpty(Me.Text) Then MyBase.OnPaint(e)
        End Sub
    End Class

End Namespace