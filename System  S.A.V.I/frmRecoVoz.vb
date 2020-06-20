Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class frmRecoVoz
    Const SERVERPORT = 2000

    Dim SERVERIP As String = ""
    Dim smscount As Integer = 0

    Dim deviceSearch As ssavilib.Network.DeviceSearch

    Dim clientSender As UdpClient
    Dim serverRecieve As UdpClient

    Dim sender As IPEndPoint

    Private Sub frmRecoVoz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFaceData()
        clear_greetings() 'limpia los saludos realizados

        tmrEvents.Start()


    End Sub

    Private Sub tmr_recvoz_Tick(sender As Object, e As EventArgs) Handles tmrEvents.Tick
        If tmResponse > MinWaitTime Then
            silencio = True
            cpbSpkVol.InnerColor = Color.Red
        Else
            cpbSpkVol.InnerColor = Color.Transparent

            tmResponse += 1
        End If
        cpbSpkVol.Refresh()
        If frmInicio.tbxDebug.Text <> debugText Then frmInicio.tbxDebug.Text = debugText

        If tbxLog.Text <> LogText Then tbxLog.Text = LogText


    End Sub

    ''
    '' MOVIMIENTO DEL FORMULARIO
    ''

#Region " Código generado por el Diseñador de Windows Forms "
    ' ... código del diseñador de Windows (no mostrado)
#End Region
    '
    ' Declaraciones del API de Windows (y constantes usadas para mover el form)
    '
    Private Const WM_SYSCOMMAND As Integer = &H112&
    Private Const MOUSE_MOVE As Integer = &HF012&
    '
    '' Declaraciones "clásicas" de VB6
    'Private Declare Function ReleaseCapture Lib "user32" () As Integer
    'Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
    '        (ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, _
    '        ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    '
    ' Declaraciones del API al estilo .NET
    <System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()

    End Sub
    '
    <System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(
            ByVal hWnd As System.IntPtr, ByVal wMsg As Integer,
            ByVal wParam As Integer, ByVal lParam As Integer
            )
    End Sub
    '
    ' función privada usada para mover el formulario actual
    Private Sub moverForm()
        ReleaseCapture()
        SendMessage(Me.Handle, WM_SYSCOMMAND, MOUSE_MOVE, 0)
    End Sub


    '
    ' evento mover formulario
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
                    Handles MyBase.MouseMove, cpbSpkVol.MouseMove, cpbMicVol.MouseMove
        moverForm()
    End Sub


    Private Sub Btn_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btn_min.Click
        frmMemory.ShowDialog()
    End Sub

    Private Sub frmRecoVoz_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmInicio.tmr_deteccion.Stop()

        If Not frmInicio.capturez Is Nothing Then frmInicio.capturez.Dispose()
        StopReconize()
    End Sub

    Private Sub Button1_Click(sender As Object, e As MouseEventArgs) Handles btnSalir.Click
        If e.Clicks Then
            Me.Close()
        End If

    End Sub

    Private Sub tbxLog_TextChanged(sender As Object, e As EventArgs) Handles tbxLog.TextChanged
        tbxLog.Select(tbxLog.TextLength, tbxLog.TextLength)
        tbxLog.ScrollToCaret()
    End Sub

    Private Sub cpbLogo_Click(sender As Object, e As EventArgs)

    End Sub


End Class