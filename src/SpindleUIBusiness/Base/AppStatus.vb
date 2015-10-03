Namespace Spindle.Business

    Public Class AppStatus

        Private PersistenceManager As New Persistence.PersistenceManager()
        Private _formTitle = String.Empty

        Public Event FormTitleChanged As EventHandler

        Public Property FormTitle As String
            Get
                Return _formTitle & Configuration.FormTitlePrefix
            End Get
            Set(value As String)
                _formTitle = value
                RaiseEvent FormTitleChanged(Me, EventArgs.Empty)
            End Set
        End Property

        Public Sub New()

        End Sub

    End Class

End Namespace