Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Imports System.Windows.Forms

Namespace Spindle.Business.Controls

    Public Class ManagableControl
        Inherits UserControl

        Private _manageStyle As ManageStyle = ManageStyle.None

        Public Property ManageStyle As ManageStyle
            Get
                Return _manageStyle
            End Get
            Set(value As ManageStyle)
                _manageStyle = value
            End Set
        End Property

        Public Sub AddControl(newControl As Control, docking As DockStyle, text As String)
            newControl.Dock = docking
            newControl.Text = text
            Me.Controls.Add(newControl)
        End Sub

    End Class

End Namespace