Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.IO
Imports System.IO.Compression
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
    Dim strpath As String = New Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath
    Dim strpathlocal = New Uri(strpath).LocalPath
    Dim installdir = strpath
    Dim mountfolder As String
    Public process1 As Process
    Dim configfie As New IniFile
    Public WorkspaceExcetion As New Exception("The workspace cannot be loaded.")
    Public Sub New()

        InitializeComponent()


        'Loads config.
        configfie.Load(strpath & "\config.ini")

        'Loads colors.
        If configfie.GetKeyValue("user_settings", "usebackgroundimage") = "true" Then
            Me.Background = New ImageSourceConverter().ConvertFromString(configfie.GetKeyValue("user_settings", "backgroundimage"))
        Else
            Me.Background = New SolidColorBrush(ColorConverter.ConvertFromString(configfie.GetKeyValue("user_settings", "backgroundcolor")))
        End If
        'Checks if we should go into Normal mode or Editor mode.
        If configfie.GetKeyValue("user_settings", "editormode") = "true" Then

        End If

        'Loads Skins
        autosaveDispatcherTimer.Start()
        CreateWorkspace.warningiconpath = strpath + "/material/warning.png"
        StartPage.littlesquidicon = strpath + "/material/squidchibi.png"
        LoadWorkspace.LargeIcon = strpathlocal + "\material\create.png"
        CloseWorkspaceButton.LargeIcon = strpathlocal + "\material\close.png"
        WorkspaceSettingsButton.LargeIcon = strpathlocal + "\material\settings.png"
        WorkspaceCreateButton.LargeIcon = strpathlocal + "\material\add.png"
        SaveButton.LargeIcon = strpath + "\material\save.png"
        LaunchGame1.LargeIcon = strpath + "\material\play.png"
        AboutButton.LargeIcon = strpath + "\about.png"
        StopButton.LargeIcon = strpath + "\material\stop.png"
        ExportModButton.LargeIcon = strpath + "\material\build.png"
        MapEditorLoadButton.LargeIcon = strpath + "\material\load.png"
        LoadSkinButton.LargeIcon = strpath + "\material\brush.png"
        FileMenuItem.Icon = strpath + "\material\file.png"
        If Environment.GetCommandLineArgs(0).ToLower() = "\batch" Then

        End If
    End Sub

    Private Sub LoadWorkspace_Click(sender As Object, e As RoutedEventArgs)

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
                ExportModButton.IsEnabled = True
            End If

        Else



        End If

    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        Dim strPath As String = System.IO.Path.GetDirectoryName(
        System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

        dispatchertimer1.Interval = New TimeSpan(0, 0, 5)
        bw.WorkerReportsProgress = True
        AddHandler bw.DoWork, AddressOf backgroundWorker1_DoWork
        AddHandler bw.ProgressChanged, AddressOf backgroundWorker1_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf backgroundWorker1_RunWorkerCompleted

        AnimatePauseGame()
        Dim sp = New ClosableTab
        sp.Content = New StartPage
        tabControl.Items.Add(sp)
        sp.Focus()
        sp.Title = "Start Page"
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
        MsgBox("Done")
    End Sub
    Public Sub LoadDirectories()

        If Directory.Exists(projectS) Then
            Me.treeView1.Items.Add(Me.GetItem(New DirectoryInfo(projectS)))

            workspaceloaded = True
            LaunchGame1.IsEnabled = True
            Title = "RPGEditor UI Beta - " + New DirectoryInfo(projectS).Name
            Console.WriteLine("Workspace: " + New DirectoryInfo(projectS).Name)

        Else
            Throw New DirectoryNotFoundException("The workspace directory cannot be loaded.")

        End If
    End Sub
    Private Sub backgroundWorker1_DoWork(ByVal sender As System.Object,
   ByVal e As DoWorkEventArgs)

        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim i As Integer
        Console.WriteLine("A mod export has been started.")
        Dim exporttemp = projectS & "\exporttemp"
        MkDir(projectS & "\exporttemp")
        Console.WriteLine(exporttemp)
        For Each moddedfile In File.ReadAllLines(projectS + "\moddedfiles.txt")
            My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, moddedfile)(0), exporttemp & "\" & IO.Path.GetFileName(My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, moddedfile)(0)))
        Next





        ZipFile.CreateFromDirectory(projectS & "\exporttemp", projectS & "\ModExport.zip")

        My.Computer.FileSystem.DeleteDirectory(projectS & "\exporttemp", FileIO.DeleteDirectoryOption.DeleteAllContents)

    End Sub

    Public Function GetFiles(dir As String, Optional search As String = "")
        If search IsNot Nothing Then

        End If
        Dim output
        output = My.Computer.FileSystem.GetFiles(dir, FileIO.SearchOption.SearchAllSubDirectories)(0)
        Return output
    End Function
    ' This event handler updates the progress.
    Private Sub backgroundWorker1_ProgressChanged(ByVal sender As System.Object,
    ByVal e As ProgressChangedEventArgs)
        progressbar1.Value = e.ProgressPercentage
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
        If item.Header.ToString.Contains(".") Then

            If item.Header.ToString.Contains(".png") Then

                Dim sa = My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0)

                Dim converter = New ImageSourceConverter()

                SaveButton.IsEnabled = True




            ElseIf item.Header.ToString.Contains(".json") Then



                Dim fileName As String = My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0)
                Dim range As TextRange
                Dim fStream As FileStream
                If File.Exists(fileName) Then
                    Dim theTabItem As New ClosableTab()
                    Dim TextEditorInside1 = New TextEditorInside

                    theTabItem.Content = TextEditorInside1
                    theTabItem.Title = New FileInfo(My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0)).Name.ToString
                    tabControl.Items.Add(theTabItem)
                    theTabItem.Focus()
                    range = New TextRange(TextEditorInside1.textBox.Document.ContentStart, TextEditorInside1.textBox.Document.ContentEnd)
                    fStream = New FileStream(fileName, FileMode.Open)
                    range.Load(fStream, DataFormats.Text)
                    fStream.Close()
                    SaveButton.IsEnabled = False

                End If
            ElseIf item.Header.ToString.Contains(".exe") Then
                Process.Start(My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0))
            ElseIf item.Header.ToString.Contains(".zip") Then


                MkDir(projectS & "\" & item.Header.ToString.Split(".zip")(0))
                mountfolder = projectS & "\" & item.Header.ToString
                Dim mountfolderItem As New TreeViewItem

                ZipFile.ExtractToDirectory(My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0), projectS & "\" & item.Header.ToString.Split(".zip")(0))
                Me.treeView1.Items.Add(Me.GetItem(New DirectoryInfo(projectS & "\" & item.Header.ToString.Split(".zip")(0))))

                For Each treeviewitem1 In treeView1.Items
                    If treeviewitem1.Header.ToString = New DirectoryInfo(projectS & "\" & item.Header.ToString.Split(".zip")(0)).Name Then
                        treeviewitem1.Foreground = New SolidColorBrush(Colors.Purple)
                        treeviewitem1.tooltip = "This item has been mounted from a zip file."
                    End If
                Next
                ZipMountTabGroup1.Visibility = Visibility.Visible
                Dim unmountContextMenu As New MenuItem

                ZipMountTabGroup1.Visibility = Visibility.Visible
                UnMountTabItem.Group = ZipMountTabGroup1
                UnMountTabItem.Visibility = Visibility.Visible

                UnMountTabItem.Visibility = Visibility.Visible
                AddHandler UnMountButton.Click, Sub()

                                                    Try
                                                        For Each treeviewitem1 In treeView1.Items
                                                            If treeviewitem1.Header.ToString = New DirectoryInfo(projectS & "\" & item.Header.ToString.Split(".zip")(0)).Name Then
                                                                treeView1.Items.Remove(treeviewitem1)
                                                                Console.WriteLine(mountfolder)
                                                                Directory.Delete(projectS & "\" & item.Header.ToString.Split(".zip")(0), True)
                                                            End If
                                                        Next
                                                    Catch ex As Exception

                                                    End Try
                                                    mountfolder = ""
                                                    ZipMountTabGroup1.Visibility = Visibility.Hidden

                                                    ZipMountTabGroup1.Visibility = Visibility.Hidden
                                                    UnMountTabItem.Group = ZipMountTabGroup1
                                                    UnMountTabItem.Visibility = Visibility.Hidden

                                                    UnMountTabItem.Visibility = Visibility.Hidden
                                                    MsgBox("Unmounted.")
                                                End Sub

                Console.WriteLine("WorkspaceMounted:" + New DirectoryInfo(mountfolder).Name)

            Else
                Try
                    Dim fileName As String = My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0)
                    Dim range As TextRange
                    Dim fStream As FileStream
                    If File.Exists(fileName) Then
                        Dim theTabItem As New ClosableTab()
                        Dim TextEditorInside1 = New TextEditorInside

                        theTabItem.Content = TextEditorInside1
                        theTabItem.Title = New FileInfo(My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0)).Name.ToString
                        tabControl.Items.Add(theTabItem)
                        theTabItem.Focus()
                        range = New TextRange(TextEditorInside1.textBox.Document.ContentStart, TextEditorInside1.textBox.Document.ContentEnd)
                        fStream = New FileStream(fileName, FileMode.Open)
                        range.Load(fStream, DataFormats.Text)
                        fStream.Close()
                        SaveButton.IsEnabled = False

                    End If
                Catch ex As Exception

                End Try
            End If
        Else

        End If

    End Sub

    Public Sub RunPlugin(ByVal PluginName As String)

        Dim strPath As String = System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().CodeBase)

    End Sub

    'Create new Workspace Button



    Private myStoryboard As Storyboard
    Public Sub AnimatePauseGame()




    End Sub




    Private Sub eMod_Click(sender As Object, e As RoutedEventArgs)
        Dim exMod = New ExportMod
        exMod.Show()
    End Sub

    Private Sub mf_Click(sender As Object, e As RoutedEventArgs)



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
        Dim theTabItem As New ClosableTab()
        Dim TextEditorInside1 = New TextEditorInside

        theTabItem.Content = TextEditorInside1
        theTabItem.Title = New FileInfo(My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0)).Name.ToString
        tabControl.Items.Add(theTabItem)
        theTabItem.Focus()

        Dim RTBText As New TextRange(TextEditorInside1.textBox.Document.ContentStart, TextEditorInside1.textBox.Document.ContentEnd)
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


        LaunchGame1.IsEnabled = False
        StopButton.IsEnabled = True
        process1.EnableRaisingEvents = True
        AddHandler process1.Exited, Sub()



                                        Me.Dispatcher.Invoke(DispatcherPriority.SystemIdle, TimeSpan.FromSeconds(1), New Action(Sub() StopButton.IsEnabled = False))
                                        Me.Dispatcher.Invoke(DispatcherPriority.SystemIdle, TimeSpan.FromSeconds(1), New Action(Sub() LaunchGame1.IsEnabled = True))



                                    End Sub
    End Sub
    Private Sub SaveButton_Click(sender As Object, e As RoutedEventArgs)
        Dim item As TreeViewItem = TryCast(treeView1.SelectedItem, TreeViewItem)
        Dim sb = My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0)
        Dim theTabItem As New ClosableTab()
        Dim TextEditorInside1 = New TextEditorInside

        theTabItem.Content = TextEditorInside1
        theTabItem.Title = New FileInfo(My.Computer.FileSystem.GetFiles(projectS, FileIO.SearchOption.SearchAllSubDirectories, item.Header.ToString)(0)).Name.ToString
        tabControl.Items.Add(theTabItem)
        theTabItem.Focus()
        Dim t As New TextRange(TextEditorInside1.textBox.Document.ContentStart, TextEditorInside1.textBox.Document.ContentEnd)
        Dim file As New FileStream(sb.ToString, FileMode.Create)
        t.Save(file, System.Windows.DataFormats.Text)
        file.Close()




        item.Foreground = New SolidColorBrush(Colors.LightGreen)
        SaveButton.IsEnabled = False
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
            ExportModButton.IsEnabled = False
        End If
    End Sub

    Private Sub WorkspaceSettingsButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs)



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
        Dim dlg As New [OpenFileDialog]
        If dlg.ShowDialog = True Then
            My.Computer.FileSystem.CopyFile(dlg.FileName, projectS)
            treeView1.Items.Clear()
            LoadDirectories()
        Else

        End If


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

    Private Sub MarkAsMod_Click(sender As Object, e As RoutedEventArgs)
        Dim item As TreeViewItem = TryCast(treeView1.SelectedItem, TreeViewItem)
        Using addInfo = File.AppendText(projectS & "\moddedfiles.txt")
            addInfo.WriteLine(item.Header.ToString)

        End Using

        ' Append text to an existing file named "WriteLines.txt".


    End Sub

    Private Sub ExportModButton_Click(sender As Object, e As RoutedEventArgs)
        bw.RunWorkerAsync()
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As TextChangedEventArgs)

    End Sub

    Private Sub CrazyWindowButton_Click(sender As Object, e As RoutedEventArgs)
        Dim cw = New CrazyWindow
        cw.Show()
    End Sub

    Private Sub ModPatcherButton_Click(sender As Object, e As RoutedEventArgs)
        Try
            Console.WriteLine("Launching ModPatcher.")
            MsgBox(strpath & "\Plugins\ModPatcher\ModPatcher.exe")
            Process.Start(strpath & "Plugins\ModPatcher\ModPatcher.exe")
        Catch ex As Exception
            Console.WriteLine("Failed.")
            Console.WriteLine(ex.ToString)
        End Try


    End Sub

    Private Sub treeView1_MouseRightButtonDown_1(sender As Object, e As MouseButtonEventArgs)

    End Sub

    Private Sub MapEditorButton_Click(sender As Object, e As RoutedEventArgs)
        UnfinshedWindow.note = "Hello. This is unfinshed. 
What this feature is going to be is something I have been thinking about for a while.
A Map Editor. What this is going to use is .remap files as map files. "
        Dim UW = New UnfinshedWindow

        UW.ShowDialog()
    End Sub

    Private Sub AssetManagerButton_Click(sender As Object, e As RoutedEventArgs)
        Dim assetsmanager = New AssetsManager
        assetsmanager.Show()
    End Sub



    Private Sub RibbonWindow_KeyDown(sender As Object, e As Input.KeyEventArgs)

    End Sub

    Private Sub WorkspaceCreateButton_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub FileMenuItem_Click(sender As Object, e As RoutedEventArgs)


    End Sub
End Class