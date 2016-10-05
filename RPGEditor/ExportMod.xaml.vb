Imports System.IO
Imports System.IO.Compression
Imports System.Windows.Forms

Public Class ExportMod
     Dim saveFileDialog1 As New SaveFileDialog()

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click

        MkDir(IO.Path.Combine(MainUI.projectS, "ExportTemp_" & textBox1.Text))
        MkDir(IO.Path.Combine(MainUI.projectS, "ExportTemp_" & textBox1.Text, textBox1.Text))
        textBox1.IsEnabled = false
        textBox.IsEnabled = False
        Dim moddedFiles = IO.Path.Combine(MainUI.projectS, "modedfiles.txt")
        Dim moddedFilesText = File.ReadAllLines(moddedFiles)
        Dim ExportTemp = IO.Path.Combine(MainUI.projectS, "ExportTemp_" & textBox1.Text, textBox1.Text)

        FileIO.FileSystem.CopyFile(IO.Path.Combine(moddedFiles), Path.Combine(ExportTemp, "moddedfiles.txt"))
        Dim readtext = File.ReadAllLines(moddedFiles)

        For Each line As String In readtext

            Dim gotfiles = FileIO.FileSystem.GetFiles(MainUI.projectS, FileIO.SearchOption.SearchAllSubDirectories, line)
            FileIO.FileSystem.CopyFile(gotfiles(0), Path.Combine(ExportTemp, line))
        Next
        ZipFile.CreateFromDirectory(IO.Path.Combine(MainUI.projectS, "ExportTemp_" & textBox1.Text), saveFileDialog1.FileName)

        textBox1.IsEnabled = true
        textBox.IsEnabled = true
    End Sub

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
       
       
        saveFileDialog1.Filter = "Zip Files (*.zip)|*.zip|All files (*.*)|*.*"
        saveFileDialog1.ShowDialog
        If saveFileDialog1.FileName = Nothing

            Else
            textBox.Text = saveFileDialog1.FileName
        End If

    End Sub
End Class
