Public Class CreateWorkspace
    Friend Shared warningiconpath As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        image.Source = New ImageSourceConverter().ConvertFromString(warningiconpath)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
