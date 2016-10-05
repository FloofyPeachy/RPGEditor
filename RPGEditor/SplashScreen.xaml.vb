Imports System.Windows.Threading

Public Class SplashScreen
    Dim dispatchertimer1 As New DispatcherTimer
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        dispatchertimer1.Interval = New TimeSpan(0, 0, 3)
        AddHandler dispatchertimer1.Tick, Sub()
                                              Dim mainwindow1 = New MainWindow
                                              mainwindow1.Show()
                                              dispatchertimer1.Stop()
                                              Me.Close()


                                          End Sub
        dispatchertimer1.Start()
    End Sub
End Class
