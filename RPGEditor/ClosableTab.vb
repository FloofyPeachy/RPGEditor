
Imports System.Windows.Controls
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Media



Class ClosableTab
    Inherits TabItem


    ' Constructor
    Public Sub New()
        ' Create an instance of the usercontrol
        Dim closableTabHeader As New CloseableHeader()

        ' Assign the usercontrol to the tab header
        Me.Header = closableTabHeader

        ' Attach to the CloseableHeader events (Mouse Enter/Leave, Button Click, and Label resize)
        AddHandler closableTabHeader.button_close.MouseEnter, New MouseEventHandler(AddressOf button_close_MouseEnter)
        AddHandler closableTabHeader.button_close.MouseLeave, New MouseEventHandler(AddressOf button_close_MouseLeave)
        AddHandler closableTabHeader.button_close.Click, New RoutedEventHandler(AddressOf button_close_Click)
        AddHandler closableTabHeader.label_TabTitle.SizeChanged, New SizeChangedEventHandler(AddressOf label_TabTitle_SizeChanged)
    End Sub



    ''' <summary>
    ''' Property - Set the Title of the Tab
    ''' </summary>
    Public WriteOnly Property Title() As String
        Set
            DirectCast(Me.Header, CloseableHeader).label_TabTitle.Content = Value
        End Set
    End Property




    '
    ' - - - Overrides  - - -
    '


    ' Override OnSelected - Show the Close Button
    Protected Overrides Sub OnSelected(e As RoutedEventArgs)
        MyBase.OnSelected(e)
        DirectCast(Me.Header, CloseableHeader).button_close.Visibility = Visibility.Visible
    End Sub

    ' Override OnUnSelected - Hide the Close Button
    Protected Overrides Sub OnUnselected(e As RoutedEventArgs)
        MyBase.OnUnselected(e)
        DirectCast(Me.Header, CloseableHeader).button_close.Visibility = Visibility.Hidden
    End Sub

    ' Override OnMouseEnter - Show the Close Button
    Protected Overrides Sub OnMouseEnter(e As MouseEventArgs)
        MyBase.OnMouseEnter(e)
        DirectCast(Me.Header, CloseableHeader).button_close.Visibility = Visibility.Visible
    End Sub

    ' Override OnMouseLeave - Hide the Close Button (If it is NOT selected)
    Protected Overrides Sub OnMouseLeave(e As MouseEventArgs)
        MyBase.OnMouseLeave(e)
        If Not Me.IsSelected Then
            DirectCast(Me.Header, CloseableHeader).button_close.Visibility = Visibility.Hidden
        End If
    End Sub





    '
    ' - - - Event Handlers  - - -
    '


    ' Button MouseEnter - When the mouse is over the button - change color to Red
    Private Sub button_close_MouseEnter(sender As Object, e As MouseEventArgs)
        DirectCast(Me.Header, CloseableHeader).button_close.Foreground = Brushes.Red
    End Sub

    ' Button MouseLeave - When mouse is no longer over button - change color back to black
    Private Sub button_close_MouseLeave(sender As Object, e As MouseEventArgs)
        DirectCast(Me.Header, CloseableHeader).button_close.Foreground = Brushes.Black
    End Sub


    ' Button Close Click - Remove the Tab - (or raise an event indicating a "CloseTab" event has occurred)
    Private Sub button_close_Click(sender As Object, e As RoutedEventArgs)
        DirectCast(Me.Parent, TabControl).Items.Remove(Me)
    End Sub


    ' Label SizeChanged - When the Size of the Label changes (due to setting the Title) set position of button properly
    Private Sub label_TabTitle_SizeChanged(sender As Object, e As SizeChangedEventArgs)
        DirectCast(Me.Header, CloseableHeader).button_close.Margin = New Thickness(DirectCast(Me.Header, CloseableHeader).label_TabTitle.ActualWidth + 5, 3, 4, 0)
    End Sub





End Class