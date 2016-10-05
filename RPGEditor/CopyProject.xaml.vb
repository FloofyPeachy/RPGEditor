Imports System.ComponentModel

Public Class CopyProject

    Private bw As BackgroundWorker = New BackgroundWorker
    Friend Shared CopyDir As String
    Friend Shared DestDir As String
   
    Public Sub New()
        InitializeComponent()

        bw.WorkerReportsProgress = True
        bw.WorkerSupportsCancellation = True
        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

    End Sub
    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If Not bw.IsBusy = True Then
            bw.RunWorkerAsync()
        End If
    End Sub
    Private Sub buttonCancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If bw.WorkerSupportsCancellation = True Then
            bw.CancelAsync()
        End If
    End Sub
    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
     
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)

        For i = 1 To 100
            If bw.CancellationPending = True Then
                e.Cancel = True
                Exit For
            Else
                ' Perform a time consuming operation and report progress
          
        My.Computer.FileSystem.CopyDirectory(CopyDir, destDir, True)
                           bw.ReportProgress(i * 1)
              
            End If
        Next
          
    End Sub
    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        MsgBox("Done!")
    End Sub
    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
      textBlock1.Text = e.ProgressPercentage.ToString() & "%"
       progressbar1.value = e.ProgressPercentage
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
bw.RunWorkerAsync
    End Sub
End Class
