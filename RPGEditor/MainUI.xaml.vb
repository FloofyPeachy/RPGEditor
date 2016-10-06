Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms
Imports System.Windows.Media.Animation
Imports System.Windows.Threading

Public Class MainUI
    Dim dispatchertimer1 As New DispatcherTimer
    Dim autosaveDispatcherTimer As New DispatcherTimer
    Friend Shared projectS As String = ""
    Public bw As New BackgroundWorker
    Dim a As StringCollection
    Dim pluginCount As Integer = 0
    Dim selectedPlugin
    Dim workspaceloaded As Boolean
    Dim rootElementBrush As SolidColorBrush
    Dim animation As ColorAnimation
    Dim OpenFileDialog1 As New OpenFileDialog
    Dim strpath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
    Dim strpathlocal = New Uri(strpath).LocalPath
    Dim installdir = strpath
    Public process1 As Process
    Public Sub New()

        ' This call is required by the designer.

        InitializeComponent()
        autosaveDispatcherTimer.Interval = New TimeSpan(0, 0, 20)
        AddHandler autosaveDispatcherTimer.Tick, AddressOf autosaveDispatcherTimer_Click
        ' Add any initialization after the InitializeComponent() call.
        autosaveDispatcherTimer.Start()
        ' Add any initialization after the InitializeComponent() call.
        LoadWorkspace.LargeIcon = strpathlocal + "\load.png"
        CloseWorkspaceButton.LargeIcon = strpathlocal + "\closeworkspace.png"
        WorkspaceSettingsButton.LargeIcon = strpathlocal + "\settings.png"
        WorkspaceCreateButton.LargeIcon = strpathlocal + "\createnewworkspace.png"
        SaveButton.LargeIcon = strpath + "\save.png"
        LaunchGame1.LargeIcon = strpath + "\run.png"
        AboutButton.LargeIcon = strpath + "\about.png"
        StopButton.LargeIcon = strpath + "\stop.png"
    End Sub
    Public Sub autosaveDispatcherTimer_Click()
        textBlock.Text = "Saved workspace."
    End Sub


    Private Sub LoadWorkspace_Click(sender As Object, e As RoutedEventArgs)

        ' This event handler was created by double-clicking the window in the designer.
        ' It runs on the program's startup routine.
        '
        OpenFileDialog1.Title = "Load a workspace file"
        OpenFileDialog1.Filter = "Workspace Files (*.rpgwork)|*.rpgwork|All files (*.*)|*.*"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = Forms.DialogResult.OK Then

            projectS = File.ReadLines(OpenFileDialog1.FileName)(0)
            LoadDirectories()

        ElseIf result = Forms.DialogResult.Cancel Then


        End If
        If OpenFileDialog1.FileName IsNot Nothing Then

            If OpenFileDialog1.FileName = Nothing Then

            Else
                SetupWorkspaceGUI(True)
                projectS = File.ReadLines(OpenFileDialog1.FileName)(0)
                CloseWorkspaceButton.IsEnabled = True
                LoadWorkspace.IsEnabled = False
            End If

        Else



        End If

    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        Dim strPath As String = System.IO.Path.GetDirectoryName(
        System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

        AddHandler Window1._process.Exited, AddressOf ProcessExited
        e.Handled = True
        dispatchertimer1.Interval = New TimeSpan(0, 0, 5)
        bw.WorkerReportsProgress = True
        AddHandler bw.DoWork, AddressOf backgroundWorker1_DoWork
        AddHandler bw.ProgressChanged, AddressOf backgroundWorker1_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf backgroundWorker1_RunWorkerCompleted

        AnimatePauseGame()
    End Sub
    Public Sub PluginItem_Click()

    End Sub
    Public Sub RefreshPlugins()
        Dim strPath As String = System.IO.Path.GetDirectoryName(
          System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        Dim pluginItem As New System.Windows.Controls.MenuItem


        For Each plugin In My.Computer.FileSystem.GetDirectories(New Uri(IO.Path.Combine(strPath, "Plugins")).LocalPath)
            Dim dirInfo As DirectoryInfo = New System.IO.DirectoryInfo(New Uri(plugin).LocalPath)

            pluginItem.Header = dirInfo.Name




        Next
    End Sub
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object,
  ByVal e As RunWorkerCompletedEventArgs)

    End Sub
    Public Sub LoadDirectories()


        Me.treeView1.Items.Add(Me.GetItem(New DirectoryInfo(projectS)))

        workspaceloaded = True
        LaunchGame1.IsEnabled = True
        Title = "RPGEditor UI Beta - " + New DirectoryInfo(projectS).Name
    End Sub
    Private Sub backgroundWorker1_DoWork(ByVal sender As System.Object,
   ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim i As Integer

        For i = 1 To 100
            If (worker.CancellationPending = True) Then
                e.Cancel = True
                Exit For
            Else
                ' Perform a time consuming operation and report progress.

                worker.ReportProgress(i * 1)
            End If
        Next
    End Sub

    ' This event handler updates the progress.
    Private Sub backgroundWorker1_ProgressChanged(ByVal sender As System.Object,
    ByVal e As ProgressChangedEventArgs)

    End Sub

    Private Sub item_Expanded(sender As Object, e As RoutedEventArgs)
        Dim item = DirectCast(sender, TreeViewItem)
        If Me.HasDummy(item) Then

            Me.RemoveDummy(item)
            Me.ExploreDirectories(item)
            Me.ExploreFiles(item)

        End If

    End Sub

    Private Sub button1_Click()
        Dim nodeToFind As String = "Evil.png"

        For Each item As TreeViewItem In treeView1.Items
            If item.Name = nodeToFind Then
                item.IsSelected = True
                item.Background = Brushes.Red
                Exit For
            End If
            If item.HasItems Then
                findNode(item, nodeToFind)
            End If
        Next
    End Sub

    Public Sub findNode(parent As TreeViewItem, name As String)
        For Each item As TreeViewItem In parent.Items
            If item.Name = name Then
                item.IsSelected = True
                Exit For
            End If
            If item.HasItems Then
                findNode(item, name)
            End If
        Next
    End Sub
    Private Sub ExploreDirectories(item As TreeViewItem)
        Dim directoryInfo = DirectCast(Nothing, DirectoryInfo)
        If TypeOf item.Tag Is DriveInfo Then
            directoryInfo = DirectCast(item.Tag, DriveInfo).RootDirectory
        ElseIf TypeOf item.Tag Is DirectoryInfo Then
            directoryInfo = DirectCast(item.Tag, DirectoryInfo)
        ElseIf TypeOf item.Tag Is FileInfo Then
            directoryInfo = DirectCast(item.Tag, FileInfo).Directory
        End If
        If Object.ReferenceEquals(directoryInfo, Nothing) Then
            Return
        End If
        For Each directory In directoryInfo.GetDirectories()
            Dim isHidden = (directory.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden
            Dim isSystem = (directory.Attributes And FileAttributes.System) = FileAttributes.System
            If Not isHidden AndAlso Not isSystem Then
                item.Items.Add(Me.GetItem(directory))
            End If
        Next
    End Sub

    Private Sub ExploreFiles(item As TreeViewItem)
        Dim directoryInfo = DirectCast(Nothing, DirectoryInfo)
        If TypeOf item.Tag Is DriveInfo Then
            directoryInfo = DirectCast(item.Tag, DriveInfo).RootDirectory
        ElseIf TypeOf item.Tag Is DirectoryInfo Then
            directoryInfo = DirectCast(item.Tag, DirectoryInfo)
        ElseIf TypeOf item.Tag Is FileInfo Then
            directoryInfo = DirectCast(item.Tag, FileInfo).Directory
        End If
        If Object.ReferenceEquals(directoryInfo, Nothing) Then
            Return
        End If
        For Each file In directoryInfo.GetFiles()
            Dim isHidden = (file.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden
            Dim isSystem = (file.Attributes And FileAttributes.System) = FileAttributes.System
            If Not isHidden AndAlso Not isSystem Then
                item.Items.Add(Me.GetItem(file))
            End If
        Next

    End Sub
    Private Sub LoadProject()

    End Sub
    Private Function GetItem(directory As DirectoryInfo) As TreeViewItem
        Dim item = New TreeViewItem() With {
             .Header = directory.Name,
            .DataContext = directory,
            .Tag = directory
        }
        Me.AddDummy(item)
        AddHandler item.Expanded, AddressOf item_Expanded
        Return item
    End Function

    Private Sub AddDummy(item As TreeViewItem)
        item.Items.Add(New DummyTreeViewItem())
    End Sub

    Private Function HasDummy(item As TreeViewItem) As Boolean
        Return item.HasItems AndAlso (item.Items.OfType(Of TreeViewItem)().ToList().FindAll(Function(tvi) TypeOf tvi Is DummyTreeViewItem).Count > 0)
    End Function

    Private Sub RemoveDummy(item As TreeViewItem)
        Dim dummies = item.Items.OfType(Of TreeViewItem)().ToList().FindAll(Function(tvi) TypeOf tvi Is DummyTreeViewItem)
        For Each dummy In dummies
            item.Items.Remove(dummy)
        Next
    End Sub
    Private Function GetItem(file As FileInfo) As TreeViewItem
        Dim item = New TreeViewItem() With {
             .Header = file.Name,
             .DataContext = file,
             .Tag = file
        }
        Return item
    End Function
    Public Sub ExportMod()

        bw.RunWorkerAsync()
    End Sub
    Private Sub treeView1_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs)

        Dim item As TreeViewItem = TryCast(treeView1.SelectedItem, TreeViewItem)

        If item.Header.ToString.Contains(".png") Then

            Dim sa = My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0)

            Dim converter = New ImageSourceConverter()
            Image.Source = DirectCast(converter.ConvertFromString(sa), ImageSource)




        ElseIf item.Header.ToString.Contains(".json") Then
            Dim fileName As String = My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0)
            Dim range As TextRange
            Dim fStream As FileStream
            If File.Exists(fileName) Then
                range = New TextRange(RichTextBox1.Document.ContentStart, RichTextBox1.Document.ContentEnd)
                fStream = New FileStream(fileName, FileMode.Open)
                range.Load(fStream, DataFormats.Text)
                fStream.Close()

            End If
        ElseIf item.Header.ToString.Contains(".exe") Then
            RunGame()
        Else
            Dim fileName As String = My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0)
            Dim range As TextRange
            Dim fStream As FileStream
            If File.Exists(fileName) Then
                range = New TextRange(RichTextBox1.Document.ContentStart, RichTextBox1.Document.ContentEnd)
                fStream = New FileStream(fileName, FileMode.Open)
                range.Load(fStream, DataFormats.Text)
                fStream.Close()

            End If
        End If


    End Sub
    Dim window12 = New Window1
    Public Sub RunPlugin(ByVal PluginName As String)

        Dim strPath As String = System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

    End Sub


    Private Sub cWorkspace_Click(sender As Object, e As RoutedEventArgs)
        Dim cWorkspace1 = New CreateWorkspace
        cWorkspace1.Show()
    End Sub

    Private Sub oWorkspace_Click(sender As Object, e As RoutedEventArgs)
        Dim lWorkspace1 = New LoadAWorkspace
        lWorkspace1.Show()
    End Sub

    Private myStoryboard As Storyboard
    Public Sub AnimatePauseGame()




    End Sub


    Private Sub MarkAsM_Click(sender As Object, e As RoutedEventArgs)
        Dim item As TreeViewItem = TryCast(treeView1.SelectedItem, TreeViewItem)


        Dim w As StreamWriter = File.AppendText(IO.Path.Combine(projectS, "modedfiles.txt"
                                                ))
        w.WriteLine(item.Header.ToString)
        w.Close()
    End Sub

    Private Sub eMod_Click(sender As Object, e As RoutedEventArgs)
        Dim exMod = New ExportMod
        exMod.Show()
    End Sub

    Private Sub mf_Click(sender As Object, e As RoutedEventArgs)
        Dim mFiles = New ModdedFiles
        mFiles.Show()


    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        RefreshPlugins()
    End Sub

    Private Sub DelFile_Click(sender As Object, e As RoutedEventArgs)
        Dim item As TreeViewItem = TryCast(treeView1.SelectedItem, TreeViewItem)
        DeleteFile(My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0), True)
    End Sub
    Public Sub DeleteFile(ByVal file As String, ByVal comfirmDelete As Boolean)
        If comfirmDelete = True Then
            MsgBox("Delete file" + file + "?", MsgBoxStyle.YesNo)
            If MsgBoxResult.Yes Then

                My.Computer.FileSystem.DeleteFile(file)
                treeView1.Items.Clear()
                LoadDirectories()
            End If
        Else
            My.Computer.FileSystem.DeleteFile(file)
        End If
    End Sub
    Public Sub ProcessExited()

    End Sub

    Private Sub CloseWorkspace_Click(sender As Object, e As RoutedEventArgs)
        treeView1.Items.Clear()
        workspaceloaded = False

    End Sub

    Private Sub SaveFile_Click(sender As Object, e As RoutedEventArgs)
        Dim item As TreeViewItem = TryCast(treeView1.SelectedItem, TreeViewItem)

        Dim fs As IO.FileStream = IO.File.OpenWrite(My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0))
        Dim RTBText As New TextRange(RichTextBox1.Document.ContentStart, RichTextBox1.Document.ContentEnd)
        RTBText.Save(fs, DataFormats.Text)
        fs.Close()
        fs.Dispose()

    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub LaunchGame1_Click(sender As Object, e As RoutedEventArgs)
        RunGame()
    End Sub
    Public Sub RunGame()
        process1 = Process.Start(projectS + "\Game.exe")

        toolBar.Background = New SolidColorBrush(Color.FromRgb(255, 108, 0))
        LaunchGame1.IsEnabled = False
        StopButton.IsEnabled = True
        process1.EnableRaisingEvents = True
        AddHandler process1.Exited, Sub()

                                        Me.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle, TimeSpan.FromSeconds(1), New Action(Sub() toolBar.Background = New SolidColorBrush(ColorConverter.ConvertFromString("#FF4283CD"))))

                                        Me.Dispatcher.Invoke(DispatcherPriority.SystemIdle, TimeSpan.FromSeconds(1), New Action(Sub() StopButton.IsEnabled = False))
                                        Me.Dispatcher.Invoke(DispatcherPriority.SystemIdle, TimeSpan.FromSeconds(1), New Action(Sub() LaunchGame1.IsEnabled = True))



                                    End Sub
    End Sub
    Private Sub SaveButton_Click(sender As Object, e As RoutedEventArgs)
        Dim item As TreeViewItem = TryCast(treeView1.SelectedItem, TreeViewItem)
        Dim sb = My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0)
        Dim t As New TextRange(RichTextBox1.Document.ContentStart, RichTextBox1.Document.ContentEnd)
        Dim file As New FileStream(sb.ToString, FileMode.Create)
        t.Save(file, System.Windows.DataFormats.Text)
        file.Close()
    End Sub

    Private Sub CloseWorkspaceButton_Click(sender As Object, e As RoutedEventArgs)
        SetupWorkspaceGUI(False)
        CloseWorkspaceButton.IsEnabled = False
        LoadWorkspace.IsEnabled = True
    End Sub
    Public Sub SetupWorkspaceGUI(ByVal show As Boolean)
        If show = True Then

        Else

            treeView1.Items.Clear()
            projectS = ""
            Title = "RPGEditor UI Beta"
            LaunchGame1.IsEnabled = False
        End If
    End Sub

    Private Sub WorkspaceSettingsButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs)

        WorkspaceSettingsTab.Visibility = Visibility.Hidden
        WorkspaceSettingsTab.IsSelected = False

    End Sub



    Private Sub WorkspaceSettingsGrid_Loaded(sender As Object, e As RoutedEventArgs)
        If OpenFileDialog1.FileName Is Nothing Then

        Else

        End If

    End Sub

    Private Sub AboutButton_Click(sender As Object, e As RoutedEventArgs)
        Dim about = New About
        about.ShowDialog()
    End Sub

    Private Sub treeView1_SelectedItemChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Object))
        Dim item As TreeViewItem = TryCast(treeView1.SelectedItem, TreeViewItem)
        Try
            If item.Header = "System.json" Then
                tabGroup1.Visibility = Visibility.Visible
                GameTabItem.Group = tabGroup1
                GameTabItem.Visibility = Visibility.Visible
                LaunchGame1.IsEnabled = True
                GameTabItem.Visibility = Visibility.Visible

            Else
                tabGroup1.Visibility = Visibility.Hidden
                GameTabItem.Group = tabGroup1
                GameTabItem.Visibility = Visibility.Hidden
                GameTabItem.Visibility = Visibility.Hidden
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub treeView1_MouseRightButtonDown(sender As Object, e As MouseButtonEventArgs)

    End Sub

    Private Sub DeleteItemButton_Click(sender As Object, e As RoutedEventArgs)
        Dim item As TreeViewItem = TryCast(treeView1.SelectedItem, TreeViewItem)
        DeleteFile(My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0), True)
        treeView1.Items.Clear()
        LoadDirectories()

    End Sub

    Private Sub AddFileButton_Click(sender As Object, e As RoutedEventArgs)


    End Sub

    Private Sub StopButton_Click(sender As Object, e As RoutedEventArgs)

        For Each p As Process In System.Diagnostics.Process.GetProcessesByName("Game")
            Try
                p.Kill()
                ' possibly with a timeout
                p.WaitForExit()
                ' process was terminating or can't be terminated - deal with it
            Catch winException As Win32Exception
                ' process has already exited - might be able to let this one go
            Catch invalidException As InvalidOperationException
            End Try
        Next
        ProcessExited()
    End Sub
End Class
