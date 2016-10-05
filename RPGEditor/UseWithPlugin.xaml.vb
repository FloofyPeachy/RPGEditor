Public Class UseWithPlugin
    Private Sub rec1_MouseUp(sender As Object, e As MouseButtonEventArgs)
MsgBox("Use " & textBlock1.Text & "to open this file?")
        If MsgBoxResult.Yes
            Me.Close
            RunPlugin("MainTextEditor", new MainTextEditor)
        End If
    End Sub
    Public Sub RunPlugin(byval plugin As String,gwindow As window)

    End Sub
End Class
