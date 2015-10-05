Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Imports System.Windows.Forms
Imports System.Drawing

Namespace Spindle.Business.Controls

    Public Class CException
        Inherits System.Windows.Forms.UserControl

        Private _infoMargin As Integer = 12
        Private _exceptionText As String = String.Empty
        Private _exceptionDescriptionText As String = String.Empty

        Public Event InfoMarginChanged As EventHandler
        Public Event ExceptionTextChanged As EventHandler
        Public Event ExceptionDescriptionTextChanged As EventHandler

        Public Property InfoMargin As Integer
            Get
                Return _infoMargin
            End Get
            Set(value As Integer)
                If _infoMargin = value Then Return
                _infoMargin = value
                RaiseEvent InfoMarginChanged(Me, EventArgs.Empty)
            End Set
        End Property

        Public Property ExceptionText As String
            Get
                Return _exceptionText
            End Get
            Set(value As String)
                If value = _exceptionText Then Return
                _exceptionText = value
                RaiseEvent ExceptionTextChanged(Me, New EventArgs)
            End Set
        End Property

        Public Property ExceptionDescriptionText As String
            Get
                Return _exceptionDescriptionText
            End Get
            Set(value As String)
                If value = _exceptionDescriptionText Then Return
                _exceptionDescriptionText = value
                RaiseEvent ExceptionDescriptionTextChanged(Me, New EventArgs)
            End Set
        End Property

        Public Sub New()
            Initialize("", "")
        End Sub

        Public Sub New(exceptionText As String, exceptionDescriptionText As String)
            Initialize(exceptionText, exceptionDescriptionText)
        End Sub

        Private Sub Initialize(exceptionText As String, exceptionDescriptionText As String)
            _exceptionText = exceptionText
            _exceptionDescriptionText = exceptionDescriptionText
            InitializeComponent()
            RegisterHandlers()
        End Sub

        Private Sub RegisterHandlers()
            AddHandler Me.SizeChanged, AddressOf OnSizeChanged
            AddHandler Me.InfoMarginChanged, AddressOf OnInfoMarginChanged
            AddHandler Me.ExceptionTextChanged, AddressOf OnExceptionTextChanged
            AddHandler Me.ExceptionDescriptionTextChanged, AddressOf OnExceptionDescriptionTextChanged
        End Sub

        Private Shadows Sub OnSizeChanged(sender As Object, e As EventArgs)
            Redraw()
        End Sub

        Private Sub OnInfoMarginChanged(sender As Object, e As EventArgs)
            Redraw()
        End Sub

        Private Sub OnExceptionDescriptionTextChanged(sender As Object, e As EventArgs)
            Redraw()
        End Sub

        Private Sub OnExceptionTextChanged(sender As Object, e As EventArgs)
            Redraw()
        End Sub

        Private Sub Redraw()
            Me.Controls.Clear()
            Dim exceptionTextLabel As New Label With {
                .Text = Me.ExceptionText,
                .ForeColor = Color.DarkRed,
                .BackColor = Color.Orange,
                .TextAlign = ContentAlignment.MiddleCenter
            }
            exceptionTextLabel.Size = New Size(Me.Width, exceptionTextLabel.Height)
            Dim exceptionDescriptionTextLabel As New Label With {
                .Text = Me.ExceptionDescriptionText,
                .Location = New Point(0, exceptionTextLabel.Height + Me._infoMargin),
                .AutoSize = False,
                .Size = New Size(Me.Width, Me.Height - exceptionTextLabel.Height)
            }

            Me.Controls.AddRange({exceptionTextLabel, exceptionDescriptionTextLabel})
        End Sub

    End Class

End Namespace