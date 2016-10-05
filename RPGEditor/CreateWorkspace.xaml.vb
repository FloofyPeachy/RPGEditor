Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Public Class CreateWorkspace
    Dim fdl As New FolderBrowserDialog

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        If checkBox.IsChecked = True
            My.Computer.FileSystem.CreateDirectory(IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "RPGWorkspaces", textBox.Text))
            Dim CopyProject1 = New CopyProject
            CopyProject.CopyDir = fdl.SelectedPath
            CopyProject.DestDir = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "RPGWorkspaces", textBox.Text)
            Dim docs = My.Computer.FileSystem.SpecialDirectories.MyDocuments

            CopyProject1.Show
        Else
            My.Computer.FileSystem.CreateDirectory(IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "RPGWorkspaces", textBox.Text))

            Dim ini As New IniFile
            ini.AddSection("PROJECT")



        End If

    End Sub

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
        fdl.ShowDialog

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim strPath As String = System.IO.Path.GetDirectoryName( _
    System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        Dim stringPath As [String] = IO.Path.Combine(strPath, "blank.png")
        Dim imageUri As New Uri(stringPath.Substring(6), UriKind.Relative)
        Dim imageBitmap As New BitmapImage(imageUri)
        Dim myImage As New Image()
        image.Source = imageBitmap

    End Sub
End Class
