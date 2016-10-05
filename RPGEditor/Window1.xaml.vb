
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Partial Public Class Window1
    Inherits Window

    Private _panel As System.Windows.Forms.Panel
    Friend Shared _process As New Process()
    Friend Shared gamepath As String


    Public Sub New()
        InitializeComponent()
        _panel = New System.Windows.Forms.Panel()
        windowsformshost1.Child = _panel
        If MainUI.projectS = Nothing Then

        Else
            MsgBox((IO.Path.Combine(MainUI.projectS, "Game.exe")))
            _process = Process.Start(IO.Path.Combine(MainUI.projectS, "Game.exe"))
            button1_Click()
        End If



    End Sub

    <DllImport("user32.dll")>
    Private Shared Function SetWindowLong(hWnd As IntPtr, nIndex As Integer, dwNewLong As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function GetWindowLong(hWnd As IntPtr, nIndex As Integer) As Integer
    End Function

    <DllImport("user32")>
    Private Shared Function SetParent(hWnd As IntPtr, hWndParent As IntPtr) As IntPtr
    End Function

    <DllImport("user32")>
    Private Shared Function SetWindowPos(hWnd As IntPtr, hWndInsertAfter As IntPtr, X As Integer, Y As Integer, cx As Integer, cy As Integer,
        uFlags As Integer) As Boolean
    End Function

    Private Const SWP_NOZORDER As Integer = &H4
    Private Const SWP_NOACTIVATE As Integer = &H10
    Private Const GWL_STYLE As Integer = -16
    Private Const WS_CAPTION As Integer = &HC00000
    Private Const WS_THICKFRAME As Integer = &H40000

    Private Sub button1_Click()


        _process.WaitForInputIdle()
        Threading.Thread.Sleep(1000)
        SetParent(_process.MainWindowHandle, _panel.Handle)
        AddHandler _panel.KeyPress, AddressOf pannal_KeyDown
        ' remove control box
        Dim style As Integer = GetWindowLong(_process.MainWindowHandle, GWL_STYLE)
        style = style And Not WS_CAPTION And Not WS_THICKFRAME
        SetWindowLong(_process.MainWindowHandle, GWL_STYLE, style)

        ' resize embedded application & refresh
        ResizeEmbeddedApp()
        AddHandler _panel.KeyPress, AddressOf pannal_KeyDown
        Dim mainWin = TryCast(Application.Current.Windows.Cast(Of Window)().FirstOrDefault(Function(window) TypeOf window Is MainUI), MainUI)
        AddHandler _process.Exited, AddressOf mainWin.ProcessExited
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)
        If _process IsNot Nothing Then
            _process.Refresh()
            _process.Close()
        End If
    End Sub

    Private Sub ResizeEmbeddedApp()
        If _process Is Nothing Then
            Return
        End If

        SetWindowPos(_process.MainWindowHandle, IntPtr.Zero, 0, 0, CInt(_panel.ClientSize.Width), CInt(_panel.ClientSize.Height),
            SWP_NOZORDER Or SWP_NOACTIVATE)
    End Sub

    Protected Overrides Function MeasureOverride(availableSize As Size) As Size
        Dim size As Size = MyBase.MeasureOverride(availableSize)
        ResizeEmbeddedApp()
        Return size
    End Function

    Private Sub closeProcess_Click(sender As Object, e As RoutedEventArgs)
        _process.Close()
        Dim mainWin = TryCast(Application.Current.Windows.Cast(Of Window)().FirstOrDefault(Function(window) TypeOf window Is MainWindow), MainWindow)

        Me.Close()


    End Sub

    Public Sub pannal_KeyDown(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar.ToString = "F5" Then
            Dim mainWin = TryCast(Application.Current.Windows.Cast(Of Window)().FirstOrDefault(Function(window) TypeOf window Is MainWindow), MainWindow)

        Else

        End If
    End Sub



    Private Sub PauseProcess_Checked(sender As Object, e As RoutedEventArgs)


        SuspendThread(_process.Threads(0).Id)
        Dim mainWin = TryCast(Application.Current.Windows.Cast(Of Window)().FirstOrDefault(Function(window) TypeOf window Is MainWindow), MainWindow)


    End Sub

    Private Sub PauseProcess_Unchecked(sender As Object, e As RoutedEventArgs)
        ResumeThread(_process.Threads(0).Id)
    End Sub


    Private Declare Function SuspendThread Lib "kernel32.dll" (ByVal hThread As Long) As Long



    Private Declare Function ResumeThread Lib "kernel32.dll" (ByVal hThread As Long) As Long

    Private Sub Window_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs)

        _process.Refresh()
            _process.Close()

    End Sub
End Class


