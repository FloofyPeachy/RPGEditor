Imports System.IO

Public Class AssetsManager
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        'Load BGM to listbox
        For Each bgm In My.Computer.FileSystem.GetFiles(MainUI.projectS & "\www\audio\bgm", FileIO.SearchOption.SearchAllSubDirectories)
            listBox.Items.Add(New FileInfo(bgm).Name)

        Next
    End Sub

    Private Sub listBox_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs)
        PlaySound(My.Computer.FileSystem.GetFiles(MainUI.projectS & "\www\audio\bgm", FileIO.SearchOption.SearchAllSubDirectories, listBox.SelectedItem.ToString)(0))
    End Sub
    Public Sub PlaySound(path As String)
        Dim mediaelement1 = New MediaElement
        mediaelement1.Source = New Uri(path)
        mediaelement1.LoadedBehavior = MediaState.Manual
        mediaelement1.Play()
        mediaelement1.Volume = 100
    End Sub
End Class
