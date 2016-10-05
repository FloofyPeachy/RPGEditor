Imports System.IO

Public Class ModdedFiles
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        For Each file1 In File.ReadLines(IO.Path.Combine(MainUI.projectS, "modedfiles.txt"))
            listBox.Items.Add(file1)
        Next
    End Sub
End Class
