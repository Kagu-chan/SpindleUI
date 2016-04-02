Option Compare Binary
Option Explicit On
Option Strict On
Option Infer On

Imports System.Collections.ObjectModel
Imports System.Windows.Forms
Imports System.Drawing

Namespace Spindle.Business.Controls

    Public Class CFlexForm
        Inherits UserControl

        Private _flexStyle As FlexManageStyle = FlexManageStyle.None
        Private _arrangeStyle As FlexArrangeStyle = FlexArrangeStyle.Horizontal
        Private _displayType As Type = GetType(CGroupBox)
        Private _controls As New ObservableCollection(Of Control)()
        Private _tabMode As Boolean = False
        Private _lastTabMode As Boolean = False

        Public Event FlexStyleChanged As EventHandler
        Public Event ArrangeStyleChanged As EventHandler
        Public Event DisplayTypeChanged As EventHandler

        Public Sub New()
            AddHandler _controls.CollectionChanged, AddressOf OnControlsCollectionChanged
            AddHandler Me.SizeChanged, AddressOf OnParentFormSizeChanged
            AddHandler Me.FlexStyleChanged, AddressOf OnFlexStyleChanged
            AddHandler Me.ArrangeStyleChanged, AddressOf OnArrangeStyleChanged
            AddHandler Me.DisplayTypeChanged, AddressOf OnDisplayTypeChanged
        End Sub

        Public Property FlexStyle As FlexManageStyle
            Get
                Return _flexStyle
            End Get
            Set(value As FlexManageStyle)
                If value = _flexStyle Then Return
                _flexStyle = value
                RaiseEvent FlexStyleChanged(Me, EventArgs.Empty)
            End Set
        End Property

        Public Property ArrangeStyle As FlexArrangeStyle
            Get
                Return _arrangeStyle
            End Get
            Set(value As FlexArrangeStyle)
                If value = _arrangeStyle Then Return
                _arrangeStyle = value
                RaiseEvent ArrangeStyleChanged(Me, EventArgs.Empty)
            End Set
        End Property

        Public Property DisplayType As Type
            Get
                Return _displayType
            End Get
            Set(value As Type)
                If value = _displayType Then Return
                _displayType = value
                RaiseEvent DisplayTypeChanged(Me, EventArgs.Empty)
            End Set
        End Property

        Public Sub AddControl(newControl As Control)
            Me.AddControl(newControl, "")
        End Sub

        Public Sub AddControl(newControl As Control, text As String)
            newControl.Dock = DockStyle.Fill
            newControl.Text = text
            _controls.Add(newControl)
        End Sub

        Private Sub OnControlsCollectionChanged(sender As Object, e As EventArgs)
            ReCalculateControls()
        End Sub

        Private Sub OnParentFormSizeChanged(sender As Object, e As EventArgs)
            ReCalculateControls()
        End Sub

        Private Sub OnFlexStyleChanged(sender As Object, e As EventArgs)
            ReCalculateControls()
        End Sub

        Private Sub OnArrangeStyleChanged(sender As Object, e As EventArgs)
            ReCalculateControls()
        End Sub

        Private Sub OnDisplayTypeChanged(sender As Object, e As EventArgs)
            ReCalculateControls()
        End Sub

        Private Sub ReCalculateControls()
            SetTabMode()
            CreateArrangeControlsCall()
        End Sub

        Private Sub SetTabMode()
            _lastTabMode = _tabMode
            Select Case _flexStyle
                Case FlexManageStyle.Tabs
                    _tabMode = True
                Case FlexManageStyle.Both
                    If _arrangeStyle = FlexArrangeStyle.Horizontal Then
                        _tabMode = Me.Size.Width < Configuration.ControlMinimumWidth * _controls.Count
                    Else
                        _tabMode = Me.Size.Height < Configuration.ControlMinimumHeight * _controls.Count
                    End If
                Case Else
                    _tabMode = False
            End Select
        End Sub

        Private Sub CreateArrangeControlsCall()
            If _displayType Is GetType(CGroupBox) Then
                ArrangeControls(Of CGroupBox)()
            ElseIf _displayType Is GetType(CHeadlineBox) Then
                ArrangeControls(Of CHeadlineBox)()
            Else
                ArrangeControls(Of GroupBox)()
            End If
        End Sub

        Private Sub ArrangeControls(Of T As Control)()
            Dim lastIndex As Integer = 0
            Dim tabControl As TabControl = Nothing
            If _lastTabMode Then
                tabControl = TryCast(Me.Controls.Item(0), TabControl)
                If Not IsNothing(tabControl) Then
                    lastIndex = tabControl.SelectedIndex
                End If
            End If

            Me.Controls.Clear()
            If _tabMode Then
                tabControl = New TabControl()
                tabControl.Dock = DockStyle.Fill
                For Each currentControl As Control In _controls
                    Dim tab As New TabPage(currentControl.Text)
                    tab.Controls.Add(currentControl)
                    tabControl.TabPages.Add(tab)
                Next
                tabControl.SelectedIndex = If(lastIndex >= tabControl.TabCount, 0, lastIndex)
                Me.Controls.Add(tabControl)
            Else
                Dim i As Integer = 0
                For Each currentControl As Control In _controls
                    Dim container As T = Activator.CreateInstance(Of T)

                    container.Text = currentControl.Text
                    container.Controls.Add(currentControl)

                    If _arrangeStyle = FlexArrangeStyle.Horizontal Then
                        Dim singleSize As Integer = CInt(Math.Round(Me.Size.Width / _controls.Count))
                        container.Size = New Size(singleSize, Me.Size.Height)
                        container.Location = New Point(i * singleSize, 0)
                    Else
                        Dim singleSize As Integer = CInt(Math.Round(Me.Size.Height / _controls.Count))
                        container.Size = New Size(Me.Size.Width, singleSize)
                        container.Location = New Point(0, i * singleSize)
                    End If

                    Me.Controls.Add(container)
                    i += 1
                Next
            End If
        End Sub

    End Class

End Namespace