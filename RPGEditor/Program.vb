Public Class Program
    Private Sub New()
    End Sub
    Private Declare Auto Function FreeConsole Lib "kernel32.dll" () As Boolean

    <STAThread>
    Public Shared Function Main1(args As String()) As Integer
        If args IsNot Nothing AndAlso args.Length > 0 Then
            ' TODO: Add your code to run in command line mode
            Console.WriteLine("Hello world. ")
            Console.ReadLine()
            Return 0
        Else
            FreeConsole()
            Dim app = New Class1
            app.D()
        End If
    End Function
End Class
