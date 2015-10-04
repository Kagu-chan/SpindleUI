Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Namespace Spindle.Business

    ''' <summary>
    ''' Configuration Module (Data Storage)
    ''' </summary>
    Module Configuration

        Public SavePath As String = "SpindleUI"
        Public AppDataFileName As String = "SpindleUI.xml"
        Public FormTitlePrefix As String = " | SpindleUI"
        Public ApplicationVersion As String = "0.1-a1-1.0"
        Public ControlMinimumWidth As Integer = 256
        Public ControlMinimumHeight As Integer = 128

    End Module

End Namespace