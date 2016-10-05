Imports System.Windows.Threading

Public Class MediaPlayer
    Dim dispatchertimer1 As New DispatcherTimer
    Friend Shared source1
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        AddHandler dispatchertimer1.Tick, AddressOf dispatchertimer1_Tick
        dispatchertimer1.Interval = New TimeSpan(0,0,0,0,1)
       mediaElement.LoadedBehavior = MediaState.Manual
        mediaElement.Source = new uri(source1)
        mediaElement.Volume = 50
        mediaElement.play
    End Sub
    Public Sub dispatchertimer1_Tick

    End Sub

    Private Sub toggleButton_Checked(sender As Object, e As RoutedEventArgs)
        mediaElement.play
        toggleButton.Content = "Pause"
    End Sub

    Private Sub toggleButton_Unchecked(sender As Object, e As RoutedEventArgs)
        mediaElement.pause
              toggleButton.Content = "Play"
    End Sub

End Class
