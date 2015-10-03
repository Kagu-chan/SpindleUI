Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Imports System.Windows.Forms

Namespace Spindle.Business

    Public Class AppStatus

        Private PersistenceManager As New Persistence.PersistenceManager()
        Private _formTitle As String = String.Empty
        Private _currentContext As ContainerControl = Nothing

        Public Event FormTitleChanged As EventHandler
        Public Event CurrentContextChanged As EventHandler

        Public Property FormTitle As String
            Get
                Return _formTitle & Configuration.FormTitlePrefix
            End Get
            Set(value As String)
                _formTitle = value
                RaiseEvent FormTitleChanged(Me, EventArgs.Empty)
            End Set
        End Property

        Public Property CurrentContext As ContainerControl
            Get
                Return _currentContext
            End Get
            Set(value As ContainerControl)
                _currentContext = value
                _currentContext.Dock = DockStyle.Fill
                RaiseEvent CurrentContextChanged(Me, EventArgs.Empty)
            End Set
        End Property

        Public Sub New()

        End Sub

    End Class

End Namespace