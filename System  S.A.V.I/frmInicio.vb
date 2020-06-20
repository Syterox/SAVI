
Imports Emgu.CV
Imports Emgu.CV.Structure

Public Class frmInicio
    Public capturez As Capture


    Dim imagen As Bitmap
    Dim currentFrame As Image(Of Bgr, Byte)
    Dim face As HaarCascade
    Dim eye As HaarCascade
    Dim result As Image(Of Gray, Byte)
    Dim TrainedFace As Image(Of Gray, Byte)
    Dim gray As Image(Of Gray, Byte)
    Dim NamePersons As List(Of String) = New List(Of String)()
    Dim ContTrain As Integer
    Dim NumLabels As Integer
    Dim t As Integer
    Dim names As String
    Dim prsn_name As String

    'DEFINICIONES ROSTRO
    Dim haar_h As Integer
    Dim haar_w As Integer
    Dim haar_x As Integer
    Dim haar_y As Integer
    Dim greet As Boolean = False

    Public Event vid_frame As EventHandler
    Public rostro As Bitmap

    Sub LoadLenguaje()
        LblNPers.Text = My.Resources.N_Personas + " :"
        LblPers.Text = My.Resources.Personas + " :"
        LblRegPers.Text = My.Resources.Reg_Persona

    End Sub
    Private Sub Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

        Try
            LoadBot()
            LoadFaceData()
            frmMemory.LoadConfig()
            LoadSpeechConfig()
            My.Application.ChangeCulture(strCulture)
            My.Application.ChangeUICulture(strCulture)
            LoadLenguaje()
        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        'carga la interfaz de usuario
        btn_text.Text = Me.Text
        Me.MaximumSize = New Size(My.Computer.Screen.WorkingArea.Width, My.Computer.Screen.WorkingArea.Height)
        pic_ico.Image = Me.Icon.ToBitmap
        Me.Size = New Size(856, 423)

    End Sub

    Private Sub Inicio_Close(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        tmr_deteccion.Stop()
        frmRecoVoz.tmrEvents.Stop()
        frmRecoVoz.Close()
        frmRecoVoz.tmrRecieveMsg.Stop()
        If Not capturez Is Nothing Then capturez.Dispose()

        StopReconize()

    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If SaviBot.Graphmaster.NumberOfChildNodes > 0 Then
            SaviBot.saveToBinaryFile(frmCarga.StrSystem_botbrain_file)

        End If
        
        Me.Close()

        Application.Exit()
        Application.ExitThread()
        For i As Integer = 0 To ListThread.Count - 1
            ListThread(i).Abort()
        Next
    End Sub

    
    Private Sub btnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    ''
    '' MOVIMIENTO DEL FORMULARIO
    ''
#Region "Move form"


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
    <System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint:="ReleaseCapture")> _
    Private Shared Sub ReleaseCapture()

    End Sub
    '
    <System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint:="SendMessage")> _
    Private Shared Sub SendMessage( _
            ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, _
            ByVal wParam As Integer, ByVal lParam As Integer _
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
                    Handles btn_text.MouseMove
        moverForm()
    End Sub
#End Region
    ''
    '' PROCEDIMIENTOS DE EL SISTEMA
    ''

    Private Sub tmr_deteccion_Tick(sender As Object, e As EventArgs) Handles tmr_deteccion.Tick
        Dim arg As EventArgs = New EventArgs
        
        If Not capturez Is Nothing Then _
        RaiseEvent vid_frame(capturez, arg)
    End Sub
    Function reconocer(image As Bitmap) As String

        Return FaceReconize.faceReconize(image)
    End Function

    Private Sub FrameGrabber(sender As Object, e As EventArgs) Handles Me.vid_frame

        lbl_npersv.Text = "0"

        NamePersons.Add("")
        currentFrame = Me.capturez.QueryFrame().Resize(320, 240, CvEnum.INTER.CV_INTER_CUBIC)
        gray = Me.currentFrame.Convert(Of Gray, Byte)()
        Dim facesDetected As MCvAvgComp()() = gray.DetectHaarCascade(Me.face, 1.2, 10, CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, New Size(10, 10))
        Dim array As MCvAvgComp() = facesDetected(0)

        For i As Integer = 0 To array.Length - 1
            Dim f As MCvAvgComp = array(i)
            t += 1
            result = Me.currentFrame.Copy(f.rect).Convert(Of Gray, Byte)().Resize(100, 100, CvEnum.INTER.CV_INTER_CUBIC)
            currentFrame.Draw(f.rect, New Bgr(Color.AliceBlue), 1)
            rostro = result.Bitmap
            If FaceReconize.imagelist.ToArray().Length <> 0 Then


                prsn_name = FaceReconize.faceReconize(result.Bitmap)
                Try
                    Dim arg_192_1 As String = prsn_name
                    Dim rect2 As Rectangle = f.rect
                    Dim grap As Graphics = Graphics.FromImage(currentFrame.Bitmap)
                    If arg_192_1 = "" Then
                        arg_192_1 = "desconocido"
                    End If
                    grap.DrawString(arg_192_1, New Font("lucida console", 9), Brushes.AliceBlue, New Point(rect2.X, rect2.Y - 11))
                    grap.DrawString("X:" & rect2.X & " Y:" & rect2.Y, New Font("Lucida console", 9), Brushes.AliceBlue, New PointF(rect2.X, rect2.Y))

                Catch ex As Exception

                End Try

            End If

            NamePersons(t - 1) = prsn_name
            NamePersons.Add("")
            lbl_npersv.Text = facesDetected(0).Length.ToString()

        Next
        t = 0
        For nnn As Integer = 0 To facesDetected(0).Length - 1
            names = names + Me.NamePersons(nnn) + ", "
        Next

        pic_visor.Image = currentFrame.Bitmap
        lbl_persv.Text = names
        names = ""
        NamePersons.Clear()
        lbl_upersv.Text = prsn_name '' carga la ultima persona vista
        '' si es el usuario , lo saluda inicialmente
        If prsn_name = strUserName And greet = False Then
            strPerson = strUserNickname
            comandos_def("hola")
            greet = True
        End If
    End Sub


    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If tbx_nombre.Text = "" Then Return
        saveNewFace(tbx_nombre.Text, rostro)
        debugText += ">>Rostro guardado" & vbCrLf
        'exeCommand("DOS", tbx_nombre.Text)
    End Sub



    Private Sub BtnConfig_Click(sender As Object, e As EventArgs) Handles btnConfig.Click
        frmMemory.ShowDialog()

    End Sub

    Private Sub BtnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click

        'carga del sistema
        ''reconocimiento facial
        ''carga las imagenes de la base de datos
        Try
            If SaviUser.Predicates.grabSetting("facereconize") = True Then
                capturez = New Capture()
                capturez.QueryFrame()
                init_reco_facial()

            End If
        Catch ex As Exception
            MsgBox("no se encuentra ninguna camara!, S.A.V.I. funcionará sin el reconocimiento facial", MsgBoxStyle.Critical)

        End Try
        ''
        ''reconocimiento de voz
        ''
        Try
            initSpeech()
            frmRecoVoz.Show()
        Catch ex As Exception
            MsgBox(ex.Message & ", revise su reconocedor de voz o cambie la cultura del sistema, el reconocimiento de voz no iniciará", MsgBoxStyle.Critical)
        End Try

        ''video.OpenPreviewWindow(pic_imagen)
        ''carga del detector
        If Not capturez Is Nothing Then

            face = New HaarCascade(My.Application.Info.DirectoryPath & "\haarcascade_frontalface_default.xml")
            tmr_deteccion.Interval = 50
            tmr_deteccion.Start()
        Else
            Dim graf_vs As Graphics = Graphics.FromImage(pic_visor.Image)
            graf_vs.DrawString("Sin señal, actíve la opción 'Activar reconocimiento facial' en opciones o conecte un dispositivo de video", New Font("Lucida console", 10), Brushes.DarkRed, New PointF(10, 10))
        End If

        If SaviUser.Predicates.grabSetting("minimizewin") = True Then
            Me.btnMin.PerformClick()
        End If
        silencio = False
        tmResponse = 0
        btnIniciar.Enabled = False
    End Sub

    Private Sub btnIniciar_MouseHover(sender As Object, e As EventArgs) Handles btnIniciar.MouseHover
        lblHover.Location = New Point(btnIniciar.Location.X + 2 + btnIniciar.Size.Width, btnIniciar.Location.Y)
        lblHover.Text = "Iniciar"
    End Sub


    Private Sub btnGuardar_MouseHover(sender As Object, e As EventArgs) Handles btnGuardar.MouseHover
        lblHover.Location = New Point(btnGuardar.Location.X, btnGuardar.Location.Y + 2 + btnGuardar.Size.Height)
        lblHover.Text = "Guardar"
    End Sub

    Private Sub btnConfig_MouseHover(sender As Object, e As EventArgs) Handles btnConfig.MouseHover
        lblHover.Text = "Configuración"
        lblHover.Location = New Point(btnConfig.Location.X - lblHover.Width - 3, btnConfig.Location.Y)
    End Sub
    Private Sub btnIniciar_MouseLeave(sender As Object, e As EventArgs) Handles btnIniciar.MouseLeave
        lblHover.Text = ""
    End Sub


    Private Sub btnGuardar_MouseLeave(sender As Object, e As EventArgs) Handles btnGuardar.MouseLeave
        lblHover.Text = ""
    End Sub

    Private Sub btnConfig_MouseLeave(sender As Object, e As EventArgs) Handles btnConfig.MouseLeave
        lblHover.Text = ""
    End Sub

    Private Sub TbxDebug_TextChanged(sender As Object, e As EventArgs) Handles tbxDebug.TextChanged
        tbxDebug.Select(tbxDebug.TextLength, tbxDebug.TextLength)
        tbxDebug.ScrollToCaret()
    End Sub
End Class
