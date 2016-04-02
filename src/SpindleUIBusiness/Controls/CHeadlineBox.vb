Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Imports System.Windows.Forms
Imports System.Drawing

Namespace Spindle.Business.Controls

    Public Class CHeadlineBox
        Inherits GroupBox

        Private _underlineColor As Color = Color.LightGray
        Private _headerBackColor As Color = Color.Green 'Color.FromName("Control")
        Private _headerForeColor As Color = Color.Black
        Private _underlineWidth As Integer = 1

        Public Event UnderlineColorChanged As EventHandler
        Public Event UnderlineWidthChanged As EventHandler
        Public Event HeaderBackColorChanged As EventHandler
        Public Event HeaderForeColorChanged As EventHandler

        Public Property UnderlineColor As Color
            Get
                Return _underlineColor
            End Get
            Set(value As Color)
                If value = _underlineColor Then Return
                _underlineColor = value
                RaiseEvent UnderlineColorChanged(Me, EventArgs.Empty)
            End Set
        End Property

        Public Property HeaderBackColor As Color
            Get
                Return _headerBackColor
            End Get
            Set(value As Color)
                If value = _headerBackColor Then Return
                _headerBackColor = value
                RaiseEvent HeaderBackColorChanged(Me, EventArgs.Empty)
            End Set
        End Property

        Public Property HeaderForeColor As Color
            Get
                Return _headerForeColor
            End Get
            Set(value As Color)
                If value = _headerForeColor Then Return
                _headerForeColor = value
                RaiseEvent HeaderForeColorChanged(Me, EventArgs.Empty)
            End Set
        End Property

        Public Property UnderlineWidth As Integer
            Get
                Return _underlineWidth
            End Get
            Set(value As Integer)
                If value = _underlineWidth Then Return
                _underlineWidth = value
                RaiseEvent UnderlineWidthChanged(Me, EventArgs.Empty)
            End Set
        End Property

        Public Sub New()
            MyBase.New
            AddHandler Me.UnderlineColorChanged, AddressOf OnUnderlineColorChanged
            AddHandler Me.UnderlineWidthChanged, AddressOf OnUnderlineWidthChanged
            AddHandler Me.HeaderBackColorChanged, AddressOf OnHeaderBackColorChanged
            AddHandler Me.HeaderForeColorChanged, AddressOf OnHeaderForeColorChanged
        End Sub

        Private Sub OnUnderlineWidthChanged(sender As Object, e As EventArgs)
            Refresh()
        End Sub

        Private Sub OnUnderlineColorChanged(sender As Object, e As EventArgs)
            Refresh()
        End Sub

        Private Sub OnHeaderBackColorChanged(sender As Object, e As EventArgs)
            Refresh()
        End Sub

        Private Sub OnHeaderForeColorChanged(sender As Object, e As EventArgs)
            Refresh()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim textSize As Size = TextRenderer.MeasureText(Me.Text & " ", Me.Font)

            e.Graphics.FillRectangle(New SolidBrush(Me._headerBackColor), 0, 0, Me.Width, textSize.Height * 2)
            e.Graphics.FillRectangle(New SolidBrush(Me._underlineColor), 0, textSize.Height * 2, Me.Width, _underlineWidth)
            e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me._headerForeColor), CInt((Me.Width - textSize.Width) * 0.5F), CInt(textSize.Height * 0.5F))

        End Sub

    End Class

End Namespace