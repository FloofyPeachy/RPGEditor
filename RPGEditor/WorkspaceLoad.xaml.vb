Public Class WorkspaceLoad
    Friend Shared projectfolder
    Public Sub button_Click() Handles button.Click
        projectfolder = textBox.Text
        Dim mainscreen = New MainWindow
        mainscreen.Show()
    End Sub
End Class
