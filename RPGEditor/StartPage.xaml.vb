Imports System.IO
Imports Discord
Imports Microsoft.Win32

Public Class StartPage
    Friend Shared littlesquidicon As String
    Private Sub Hyperlink_Click(sender As Object, e As RoutedEventArgs)
        Dim CreateNW = New CreateWorkspace
        CreateNW.ShowDialog()
    End Sub

    Private Sub Hyperlink_Click_1(sender As Object, e As RoutedEventArgs)
        Dim ofd = New OpenFileDialog
        If ofd.ShowDialog = True Then


            For Each window As Window In Application.Current.Windows
                If window.[GetType]() = GetType(MainUI) Then
                    Dim MainWindow1 = TryCast(window, MainUI)
                    MainUI.projectS = File.ReadLines(ofd.FileName)(0)
                    MainWindow1.LoadDirectories()
                End If
            Next

        Else

        End If
    End Sub

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        image.Source = New ImageSourceConverter().ConvertFromString(littlesquidicon)
    End Sub


End Class
