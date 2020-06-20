Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports AIMLbot
Module SystemConf

    'Función para quitar los saltos de línea de un texto 
    Public Function quitarSaltosLinea(ByVal texto As String, caracterReemplazar As String) As String
        quitarSaltosLinea = Replace(Replace(texto, Chr(10),
                caracterReemplazar), Chr(13), caracterReemplazar)
    End Function
    Public Function ConvertLine(text As String) As String
        Dim rchTxb As New RichTextBox
        rchTxb.Text = text

        Dim lineas() As String = rchTxb.Lines
        Dim countL As Integer = rchTxb.Lines.Count
        Dim linea As String = ""

        For I As Integer = 0 To countL - 1

            If countL >= 2 Then
                linea = linea & lineas(I)
                Try
                    If lineas(I + 1).Length > 0 Then linea = linea & " $ "
                Catch ex As Exception : End Try
            Else
                linea = linea & lineas(I)
            End If


        Next
        Return linea
    End Function

    Public Sub TakeScreenShot(FilePath As String)
        Dim BitmapScreenShot As Bitmap = New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb)
        Dim GraphicsScreenShot As Graphics = Graphics.FromImage(BitmapScreenShot)
        GraphicsScreenShot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy)
        BitmapScreenShot.Save(FilePath, ImageFormat.Png)
        BitmapScreenShot.Dispose()
    End Sub


    Sub getCBoxCity(ByVal cbCity As ComboBox)
        Dim objDic As New Dictionary(Of String, String)()

        For Each ObjCultureInfo As System.Globalization.CultureInfo In System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.SpecificCultures)
            Dim objRegionInfo As New System.Globalization.RegionInfo(ObjCultureInfo.Name)
            If Not objDic.ContainsKey(objRegionInfo.DisplayName) Then
                objDic.Add(objRegionInfo.DisplayName, objRegionInfo.TwoLetterISORegionName.ToLower())
            End If
        Next

        Dim obj = objDic.OrderBy(Function(p) p.Key)

        For Each val As KeyValuePair(Of String, String) In obj
            cbCity.Items.Add(val.Key)
        Next

        cbCity.SelectedIndex = 0

    End Sub
    Function getCityS(c As String) As String

        For Each ObjCultureInfo As System.Globalization.CultureInfo In System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.SpecificCultures)
            Dim objRegionInfo As New System.Globalization.RegionInfo(ObjCultureInfo.Name)
            If objRegionInfo.DisplayName = c Then
                Return objRegionInfo.CurrencySymbol
            End If
        Next

    End Function
End Module

Friend Class Monitor
    Private Enum RecycleFlags As UInteger
        SHERB_NOCONFIRMATION = 1UI
        SHERB_NOPROGRESSUI
        SHERB_NOSOUND = 4UI
    End Enum

    Private Enum MonitorState
        [ON] = -1
        OFF = 2
        STANDBY = 1
    End Enum

    Private Const SW_SHOWMINNOACTIVE As Integer = 7

    Private SC_MONITORPOWER As Integer = 61808

    Private WM_SYSCOMMAND As Integer = 274

    Private HWND_BROADCAST As Integer = 65535

    Private Declare Function ShowWindow Lib "user32.dll" (hWnd As System.IntPtr, nCmdShow As Integer) As Boolean

    Private Shared Sub MinimizeWindow(handle As System.IntPtr)
        Monitor.ShowWindow(handle, 7)
    End Sub

    Private Declare Unicode Function SHEmptyRecycleBin Lib "Shell32.dll" (hwnd As System.IntPtr, pszRootPath As String, dwFlags As Monitor.RecycleFlags) As UInteger

    Public Sub vaciarPapelera()
        Try
            Monitor.SHEmptyRecycleBin(System.IntPtr.Zero, Nothing, CType(0UI, Monitor.RecycleFlags))
        Catch ex_0F As Exception
        End Try
    End Sub

    Public Sub abrirBandeja()
        VBScript("Set objPlayer = CreateObject(" & Chr(34) & "WMPlayer.OCX.7" & Chr(34) & ")" + vbCrLf +
                "collCDROM = objPlayer.cdromCollection" + vbCrLf +
                 "If collCDROM.Count >= 1 Then" + vbCrLf +
                    "For I = 0 To collCDROM.Count - 1" + vbCrLf +
                       "collCDROM.Item(I).Eject()" + vbCrLf +
                    "Next" + vbCrLf +
                "End If")
    End Sub

    Public Sub cerrarBandeja()
        VBScript("Set objPlayer = CreateObject(" & Chr(34) & "WMPlayer.OCX.7" & Chr(34) & ")" + vbCrLf +
               "collCDROM = objPlayer.cdromCollection" + vbCrLf +
                "If collCDROM.Count >= 1 Then" + vbCrLf +
                   "For I = 0 To collCDROM.Count - 1" + vbCrLf +
                      "collCDROM.Item(I).Eject()" + vbCrLf +
                   "Next" + vbCrLf +
               "End If")
    End Sub

    Private Declare Function SendMessage Lib "user32.dll" (hWnd As Integer, Msg As Integer, wParam As Integer, lParam As Integer) As System.IntPtr

    Private Declare Function GetForegroundWindow Lib "user32.dll" () As System.IntPtr

    Private Declare Function GetWindowTextLength Lib "user32.dll" (hWnd As System.IntPtr) As Integer

    Private Declare Function GetWindowText Lib "user32.dll" (hWnd As System.IntPtr, lpString As System.Text.StringBuilder, nMaxCount As Integer) As Integer

    Private Declare Function GetWindowThreadProcessId Lib "user32.dll" (hWnd As System.IntPtr, <Out()> ByRef lpdwProcessId As UInteger) As UInteger

    Private Declare Function OpenProcess Lib "kernel32.dll" (dwDesiredAccess As UInteger, bInheritHandle As Boolean, dwProcessId As UInteger) As System.IntPtr

    Private Declare Function CloseHandle Lib "kernel32.dll" (handle As System.IntPtr) As Boolean

    Private Declare Function GetModuleBaseName Lib "psapi.dll" (hWnd As System.IntPtr, hModule As System.IntPtr, lpFileName As System.Text.StringBuilder, nSize As Integer) As UInteger

    Public Function GetTopWindowText() As String
        Dim hWnd As System.IntPtr = Monitor.GetForegroundWindow()
        Dim length As Integer = Monitor.GetWindowTextLength(hWnd)
        Dim text As System.Text.StringBuilder = New System.Text.StringBuilder(length + 1)
        Monitor.GetWindowText(hWnd, text, text.Capacity)
        Return text.ToString()
    End Function

    Public Function GetTopWindowName() As String
        Dim hWnd As System.IntPtr = Monitor.GetForegroundWindow()
        Dim lpdwProcessId As UInteger
        Monitor.GetWindowThreadProcessId(hWnd, lpdwProcessId)
        Dim hProcess As System.IntPtr = Monitor.OpenProcess(1040UI, False, lpdwProcessId)
        Dim text As System.Text.StringBuilder = New System.Text.StringBuilder(1000)
        Monitor.GetModuleBaseName(hProcess, System.IntPtr.Zero, text, text.Capacity)
        Monitor.CloseHandle(hProcess)
        MessageBox.Show(text.ToString())
        Return text.ToString()
    End Function

    Public Sub SetMonitorOFF()
        Monitor.SendMessage(Me.HWND_BROADCAST, Me.WM_SYSCOMMAND, Me.SC_MONITORPOWER, 2)
    End Sub

    Public Sub SetMonitorON()
        Monitor.SendMessage(Me.HWND_BROADCAST, Me.WM_SYSCOMMAND, Me.SC_MONITORPOWER, 1)
    End Sub
End Class

