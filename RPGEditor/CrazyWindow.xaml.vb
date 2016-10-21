Public Class CrazyWindow
    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click

        For Each window As Window In Application.Current.Windows
            If window.[GetType]() = GetType(MainUI) Then
                Dim MainWindow1 = TryCast(window, MainUI)
                MainUI.projectS = "crazy"
                MainWindow1.LoadDirectories()
            End If
        Next

    End Sub

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
        For Each window As Window In Application.Current.Windows
            If window.[GetType]() = GetType(MainUI) Then
                Dim MainWindow1 = TryCast(window, MainUI)
                Dim tvi As New TreeViewItem
                tvi.Header = "DASAWQ"
                Dim tvi2 As New TreeViewItem
                tvi2.Header = "hello"
                tvi.Items.Add(tvi2)
                MainWindow1.treeView1.Items.Add(tvi)
            End If
        Next

    End Sub

    Private Sub button2_Click(sender As Object, e As RoutedEventArgs) Handles button2.Click
        Throw New Exception("Well? This is what you wanted.")
    End Sub

    Private Sub button3_Click(sender As Object, e As RoutedEventArgs) Handles button3.Click
        Dim mel As New MediaElement
        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
        Throw New Exception("Here you go.")
    End Sub
End Class
