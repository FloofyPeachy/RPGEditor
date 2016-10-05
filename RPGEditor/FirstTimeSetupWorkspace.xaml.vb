Imports System.Windows.forms
Public Class FirstTimeSetupWorkspace
            Dim fbd As new FolderBrowserDialog
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
textBox.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim fbd As new FolderBrowserDialog
        fbd.ShowDialog
   
     End Sub

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
        Dim ini As New IniFile
     ini.AddSection("USER")
        ini.AddSection("USER").AddKey("firsttimesetup").Value = "true"
        ini.AddSection("USER").AddKey("WorkspaceDir").Value = fbd.SelectedPath
        
Dim strPath As String = System.IO.Path.GetDirectoryName( _
    System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

        ini.Save(io.path.Combine(strPath, "\settings.ini"))
   My.Computer.FileSystem.CreateDirectory(io.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "RPGWorkspaces"))
        Process.Start(IO.Path.Combine(strPath, "\settings.ini"))
        Dim mWindow = New MainWindow
        mWindow.show
        Me.close
    End Sub
End Class
