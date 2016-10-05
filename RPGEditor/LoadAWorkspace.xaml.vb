Public Class LoadAWorkspace
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        For each folder In My.Computer.FileSystem.GetDirectories(io.Path.Combine( My.Computer.FileSystem.SpecialDirectories.MyDocuments, "RPGWorkspaces"))
               Dim dirInfo As New System.IO.DirectoryInfo(folder)
            listbox.Items.Add(dirInfo.name)
            
        Next
    End Sub

    Private Sub listBox_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs)

        MainUI.projectS = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "RPGWorkspaces", listBox.SelectedValue)

        Me.close
        
    End Sub
End Class
