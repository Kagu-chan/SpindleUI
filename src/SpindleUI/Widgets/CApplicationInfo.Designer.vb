Namespace Spindle.UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CApplicationInfo
        Inherits System.Windows.Forms.UserControl

        'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Wird vom Windows Form-Designer benötigt.
        Private components As System.ComponentModel.IContainer

        'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
        'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.GBVersionInfo = New System.Windows.Forms.GroupBox()
            Me.GBMiscInformation = New System.Windows.Forms.GroupBox()
            Me.SuspendLayout()
            '
            'GBVersionInfo
            '
            Me.GBVersionInfo.Dock = System.Windows.Forms.DockStyle.Top
            Me.GBVersionInfo.Location = New System.Drawing.Point(0, 0)
            Me.GBVersionInfo.Name = "GBVersionInfo"
            Me.GBVersionInfo.Size = New System.Drawing.Size(150, 64)
            Me.GBVersionInfo.TabIndex = 0
            Me.GBVersionInfo.TabStop = False
            Me.GBVersionInfo.Text = "GroupBox1"
            '
            'GBMiscInformation
            '
            Me.GBMiscInformation.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.GBMiscInformation.Location = New System.Drawing.Point(0, 70)
            Me.GBMiscInformation.Name = "GBMiscInformation"
            Me.GBMiscInformation.Size = New System.Drawing.Size(150, 80)
            Me.GBMiscInformation.TabIndex = 1
            Me.GBMiscInformation.TabStop = False
            Me.GBMiscInformation.Text = "GroupBox1"
            '
            'CApplicationInfo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.GBMiscInformation)
            Me.Controls.Add(Me.GBVersionInfo)
            Me.Name = "CApplicationInfo"
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GBVersionInfo As GroupBox
        Friend WithEvents GBMiscInformation As GroupBox
    End Class
End Namespace