Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Text

Namespace savi.ProcessFunction
    Friend Class SaviProcFunc
        Private Delegate Function EnumThreadDelegate(hWnd As System.IntPtr, lParam As System.IntPtr) As Boolean

        Private Const SW_HIDE As Integer = 0

        Private Const SW_SHOWNORMAL As Integer = 1

        Private Const SW_NORMAL As Integer = 1

        Private Const SW_SHOWMINIMIZED As Integer = 2

        Private Const SW_SHOWMAXIMIZED As Integer = 3

        Private Const SW_MAXIMIZE As Integer = 3

        Private Const SW_SHOWNOACTIVATE As Integer = 4

        Private Const SW_SHOW As Integer = 5

        Private Const SW_MINIMIZE As Integer = 6

        Private Const SW_SHOWMINNOACTIVE As Integer = 7

        Private Const SW_SHOWNA As Integer = 8

        Private Const SW_RESTORE As Integer = 9

        Private Const SW_SHOWDEFAULT As Integer = 10

        Private Const WM_SYSCOMMAND As Integer = 274

        Private Const SC_MINIMIZE As Integer = 61472

        Public nombreP As String

        Public nombrePG As String

        Private hWnd As Integer

        Private ProcWindow As String = "itunes"

        Private Declare Function ShowWindow Lib "User32" (hwnd As Integer, nCmdShow As Integer) As Integer

        Public Sub minimizeWindow()
            Dim processRunning As Process() = Process.GetProcesses()
            Dim array As Process() = processRunning
            For i As Integer = 0 To array.Length - 1
                Dim pr As Process = array(i)
                If pr.ProcessName = Me.nombreP Then
                    Me.hWnd = pr.MainWindowHandle.ToInt32()
                    SaviProcFunc.ShowWindow(Me.hWnd, 6)
                End If
            Next
        End Sub

        Private Declare Function GetForegroundWindow Lib "user32.dll" () As System.IntPtr

        Private Declare Function GetWindowThreadProcessId Lib "user32.dll" (hWnd As System.IntPtr, <Out()> ByRef lpdwProcessId As UInteger) As Integer

        Private Shared Function GetActiveProcess() As Process
            Dim hwnd As System.IntPtr = SaviProcFunc.GetForegroundWindow()
            Return SaviProcFunc.GetProcessByHandle(hwnd)
        End Function

        Private Shared Function GetProcessByHandle(hwnd As System.IntPtr) As Process
            Dim result As Process
            Try
                Dim processID As UInteger
                SaviProcFunc.GetWindowThreadProcessId(hwnd, processID)
                result = Process.GetProcessById(CInt(processID))
            Catch ex_12 As Exception
                result = Nothing
            End Try
            Return result
        End Function

        Public Function GetNameCurrentProcess() As String
            Dim currentProcess As Process = SaviProcFunc.GetActiveProcess()
            If currentProcess IsNot Nothing Then
                Me.nombrePG = currentProcess.ProcessName
            End If
            Return Me.nombrePG
        End Function

        Public Sub MinimizeNameWindow()
            Dim currentProcess As Process = SaviProcFunc.GetActiveProcess()
            If currentProcess IsNot Nothing Then
                Me.nombreP = currentProcess.ProcessName
            End If
            If Me.nombreP = "explorer" Then
                Me.minimizeExplorer()
                Return
            End If
            Me.minimizeWindow()
        End Sub

        <System.STAThread()>
        Public Sub minimizeExplorer()
            For Each handle As System.IntPtr In SaviProcFunc.EnumerateProcessWindowHandles(Process.GetProcessesByName("explorer")(0).Id)
                SaviProcFunc.SendMessage(handle, WM_SYSCOMMAND, SC_MINIMIZE, 0)
            Next
        End Sub

        Private Declare Auto Function GetClassName Lib "user32.dll" (hWnd As System.IntPtr, lpClassName As System.Text.StringBuilder, nMaxCount As Integer) As Integer

        Private Shared Function GetDaClassName(hWnd As System.IntPtr) As String
            Dim ClassName As System.Text.StringBuilder = New System.Text.StringBuilder(100)
            Dim nRet As Integer = SaviProcFunc.GetClassName(hWnd, ClassName, ClassName.Capacity)
            If nRet <> 0 Then
                Return ClassName.ToString()
            End If
            Return Nothing
        End Function

        Private Declare Function EnumThreadWindows Lib "user32.dll" (dwThreadId As Integer, lpfn As SaviProcFunc.EnumThreadDelegate, lParam As System.IntPtr) As Boolean

        Private Shared Function EnumerateProcessWindowHandles(processID As Integer) As System.Collections.Generic.IEnumerable(Of System.IntPtr)
            Dim [handles] As System.Collections.Generic.List(Of System.IntPtr) = New System.Collections.Generic.List(Of System.IntPtr)()
            Dim addWindowHandle As SaviProcFunc.EnumThreadDelegate = Function(hWnd As System.IntPtr, param As System.IntPtr) As Boolean
                                                                         Dim className As String = SaviProcFunc.GetDaClassName(hWnd)
                                                                         Dim expr_08 As String = className
                                                                         Dim a As String = expr_08
                                                                         If expr_08 IsNot Nothing Then
                                                                             If Not (a = "ExploreWClass") Then
                                                                                 If a = "CabinetWClass" Then
                                                                                     [handles].Add(hWnd)
                                                                                 End If
                                                                             Else
                                                                                 [handles].Add(hWnd)
                                                                             End If
                                                                         End If
                                                                         Return True
                                                                     End Function
            For Each thread As ProcessThread In Process.GetProcessById(processID).Threads
                SaviProcFunc.EnumThreadWindows(thread.Id, addWindowHandle, System.IntPtr.Zero)
            Next
            Return [handles]
        End Function


        Private Declare Auto Function SendMessage Lib "user32.dll" (hWnd As System.IntPtr, Msg As UInteger, wParam As Integer, lParam As Integer) As System.IntPtr

        Public Declare Sub SwitchToThisWindow Lib "user32.dll" (hWnd As System.IntPtr, turnon As Boolean)

        Private Sub switchWindow()
            Dim procs As Process() = Process.GetProcessesByName(Me.ProcWindow)
            Dim array As Process() = procs
            For i As Integer = 0 To array.Length - 1
                Dim proc As Process = array(i)
                SaviProcFunc.SwitchToThisWindow(proc.MainWindowHandle, False)
            Next
        End Sub
    End Class
End Namespace

Namespace savi.Window

    Friend Class ChangeWindow
        Private Enum GetWindow_Cmd As UInteger
            GW_HWNDFIRST
            GW_HWNDLAST
            GW_HWNDNEXT
            GW_HWNDPREV
            GW_OWNER
            GW_CHILD
            GW_ENABLEDPOPUP
        End Enum

        Private Declare Function GetWindow Lib "user32.dll" (hWnd As System.IntPtr, uCmd As UInteger) As System.IntPtr

        Public Declare Auto Function GetParent Lib "user32.dll" (hWnd As System.IntPtr) As System.IntPtr

        Private Declare Function SetForegroundWindow Lib "user32.dll" (hWnd As System.IntPtr) As <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)>
        Boolean

        Public Sub ChangeWindow()
            Dim targetHwnd As System.IntPtr = Window.ChangeWindow.GetWindow(Process.GetCurrentProcess().MainWindowHandle, 2UI)
            While True
                Dim temp As System.IntPtr = Window.ChangeWindow.GetParent(targetHwnd)
                If temp.Equals(System.IntPtr.Zero) Then
                    Exit While
                End If
                targetHwnd = temp
            End While
            Window.ChangeWindow.SetForegroundWindow(targetHwnd)
        End Sub
    End Class

End Namespace


Namespace savi.ControlRemote
    Public Class Win32
        Public Const WM_COMMAND As Integer = 273

        Public Const WM_COMMAND_PROTEUS As Integer = 273

        Public Declare Function FindWindow Lib "User32.dll" (strClassName As String, strWindowName As String) As Integer

        Public Declare Function FindWindowEx Lib "User32.dll" (hwndParent As Integer, hwndChildAfter As Integer, strClassName As String, strWindowName As String) As Integer

        Public Declare Function SendMessage Lib "User32.dll" (hWnd As Integer, Msg As Integer, wParam As Integer, <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)> lParam As String) As Integer

        Public Declare Function SendMessage Lib "User32.dll" (hWnd As Integer, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Class
End Namespace