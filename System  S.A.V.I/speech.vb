Imports System.Runtime.InteropServices
Imports System.Speech
Imports System.Speech.Recognition
Imports System.Speech.Synthesis
Imports WindowsInput
Imports System.Threading
Imports System.IO
Imports AIMLbot
Imports AIMLbot.Utils
Imports System__SAVI.savi.ControlRemote
Imports System.Reflection

Module speech
    ''
    Public strCommandRec As String
    Public strAvName As String = "savi"
    Public strSaviVoiceName As String = ""
    Public strCulture As String = "es-es"

    Public silencio As Boolean = False
    Public comandoEjec As Boolean

    Public tmResponse As Integer = 0
    Public MinWaitTime As Integer = 100

    Public ListThread As List(Of Thread) = New List(Of Thread)

    Public strUserName As String = "default"
    Public strUserNickname As String = "señor"
    Public strPerson As String = ""
    Public strIpServer As String = ""
    Public LogText As String = ""
    '' bot
    Public SaviBot As Bot
    Public SaviUser As User
    Public commands_social() As String = {strAvName, strAvName + " estas hay",
                                          strAvName + " me escuchas", "me escuchas",
                                          "no me llamo asi",
                                          "quien soy",
                                          "hola", "como estas", "que tal",
                                          "como te llamas", "quien eres", "cual es tu nombre",
                                          "cual es tu edad", "que edad tienes",
                                          "cuentame un chiste", "dime un chiste", "cuenta un chiste",
                                          "gracias",
                                          "conversemos", "activar conversación", "quieres conversar?", "hablemos", "quieres hablar?",
                                          "silencio", "alto", "callate", "no hables", "para"
                                         }

    Public Commands_Default() As String = {"cierra el asistente virtual", "cerrar asistente",
                                            "ruido",
                                           "apaga la camara", "apagar camara",
                                           "activa la camara", "activar camara",
                                            "qué día es", "qué día es hoy", "dime que día es",
                                            "qué fecha es", "qué fecha es hoy", "cuál es la fecha", "cuál es la fecha para hoy", "dime la fecha",
                                            "qué hora es", "qué hora es ahora", "dime la hora",
                                            "vaciar papelera", "vaciar papelera de reciclaje", "limpiar la papelera", "limpiar la papelera de reciclaje", "limpiar papelera", "vaciar papelera",
                                            "copiar", "copiar eso", "copiar esto",
                                            "cortar", "cortar eso", "cortar esto",
                                            "eliminar", "eliminar eso", "eliminar esto",
                                            "guardar", "guardar eso", "guardar esto",
                                            "pegar", "pegar eso", "pegar esto",
                                            "mostrar escritorio", "minimizar todas las ventanas",
                                            "apagar sistema", "apagar la computadora", "apagar el ordenador", "apagar el sistema",
                                            "reiniciar sistema", "reiniciar la computadora", "reiniciar el ordenador", "reiniciar el sistema",
                                            "cerrar sesión", "cambiar de sesión", "cambiar la sesión",
                                            "abortar", "cancelar",
                                            "si",
                                            "no",
                                            "cancelar apagado", "cancelar reinicio",
                                            "activar dictado",
                                            "desactivar dictado",
                                            "abrir bandeja", "abrir la lectora", "abrir unidad de dvd", "abrir unidad de cd", "abrir unidad de cd rom",
                                            "apagar monitor", "dapagar la pantalla", "apagar monitor",
                                            "cambiar ventana", "siguiente ventana", "cambiar de ventana",
                                            "capturar pantalla", "capturar la pantalla", "capturar monitor",
                                            "cerrar eso", "cerrar ventana", "cerrar", "cerrar la aplicacion", "cerrar el programa", "cerrar programa",
                                            "cuál es el clima", "el clima", "cuál es el pronóstico", "el pronóstico",
                                            "cuál es el clima para mañana", "el clima para mañana", "cuál es el pronostico para mañana", "el pronóstico para mañana",
                                            "cuál es la temperatura", "a que temperatura estamos", "la temperatura",
                                            "leer esto", "leer esto", "leer el texto", "leer el siguiente texto", "leer texto seleccionado",
                                            "buscar esto", "buscar esto", "buscar el texto", "buscar el siguiente texto", "buscar texto seleccionado",
                                            "minimizar asistente", "minimizar el asistente",
                                            "minimizar ventana", "minimizar eso", "minimizar esto",
                                            "mostrar asistente", "mostrar el asistente", "ver asistente",
                                            "abrir configuración", "mostrar configuración", "ver configuración",
                                             "agregar comandos", "agregar comandos", "insertar comandos", "ingresar comandos",
                                            "mostrar comandos", "ver comandos", "ver los comandos", "mostrar comandos del sistema", "mostrar los comandos del sistema", "ver los comandos del sistema", "mostrar comandos por defecto", "ver comandos por defecto", "mostrar los comandos por defecto",
                                            "mostrar comandos de carpetas", "ver comandos de carpetas",
                                            "mostrar comandos de aplicaciones", "ver comandos de aplicaciones",
                                            "mostrar comandos paginas webs", "ver comandos paginas webs",
                                            "mostrar comandos sociales", "ver comandos sociales",
                                            "abrir nueva ventana", "nueva ventana", "ventana nueva",
                                            "abrir nueva pestaña", "nueva pestaña", "pestaña nueva",
                                            "abrir nueva ventana en modo incognito", "modo incognito", "nueva ventana en modo incognito",
                                            "abrir pestaña cerrada", "última pestaña cerrada", "pestaña cerrada", "abrir última pestaña cerrada", "abrir última pestaña",
                                            "siguiente pestaña", "cambiar pestaña", "cambiar de pestaña",
                                            "anterior pestaña", "pestaña anterior",
                                            "cerrar pestaña", "cerrar pestaña actual", "cerrar esta pestaña", "cerrar la pestaña",
                                            "subir", "subir página", "subir página web", "arriba",
                                            "bajar", "bajar página", "bajar página web", "abajo",
                                            "imprimir página", "imprimir esta página", "imprimir la página",
                                            "página de descargas", "ver página de descargas", "mostrar mis descargas", "mis descargas", "abrir mis descargar", "ver mis descargas",
                                            "actualizar", "refrescar", "actualizar pagina",
                                            "reproducir música", "reproducir canción", "reproducir pista", "reproducir", "iniciar música", "iniciar canción", "iniciar pista", "reproducir video", "reproducir pelicula", "iniciar video", "iniciar pelicula", "reanudar",
                                            "detener música", "detener", "cancelar musica", "cancelar reproducción", "detener pista", "detener canción",
                                            "pausar música",
                                            "siguiente música", "siguiente pista", "siguiente canción", "siguiente reproduccion",
                                            "anterior música", "anterior pista", "anterior canción", "música anterior", "pista anterior", "canción anterior",
                                            "activar aleatorio", "iniciar aleatorio", "activar random", "activar música aleatoria", "activar pista aleatoria", "activar canción aleatior", "música aleatoria", "desactivar aleatorio", "desactivar música aleatoria",
                                            "repetir música", "repetir pista", "repetir canción", "desactivar repetir",
                                            "subir volumen", "aumentar volumen", "inclementar volumen", "subir el volumen",
                                            "bajar volumen", "desminuir volumen", "decrementar volumen",
                                            "silenciar música", "sienciar", "desactivar volumen", "mute",
                                            "cerrar reproductor", "cerrar reproductor de windows", "cerrar el reproductor",
                                            "pantalla completa", "maximizar pantalla"}

    '"abrir alarma", "aconfigurar alarma", "ver la alarma", "mostrar la alarma",
    '"estado de alarma", "estado de la alarma", "cúal es el estado de la alarma", "saber el estado de la alarma", "dime el estado de la alarma", "el estado de la alarma",
    '"activar alarma", "activar la alarma", "iniciar la alarma", "comenzar la alarma",
    '"desactivar alarma", "parar la alarma", "detener la alarma", "desactivar la alarma",
    '"abrir recordatorio", "agregar recordatorio", "insertar recordatorio", "ver recordatorio",
    '"revisar recordatorios",
    '"revisar facebook", "revisar el facebook",
    '"leer notificación", "leer la notificación",
    '"abrir notificación", "abrir la notificacion", "ver la notificación", "ver notificacón",
    '"leer siguiente notificación", "siguiente notificación",
    '"leer anterior notificación", "anterior notificación",
    '"revisar correo", "revisar el correo",
    '"leer correo", "leer el correo",
    '"leer siguiente correo", "leer el siguiente correo", "leer el correo siguiente", "leer correo siguiente", "siguiente correo",
    '"leer anterior correo", "leer el correo anterior", "leer el anterior correo", "leer correo anterior", "anterior correo",
    '"abrir correo", "abrir el correo", "ver el correo", "ver correo",

    ''
    Private CultureInfo As System.Globalization.CultureInfo = New System.Globalization.CultureInfo(strCulture)
    Private _reco As SpeechRecognitionEngine = New SpeechRecognitionEngine(CultureInfo)
    Private _savi As SpeechSynthesizer = New SpeechSynthesizer()
    Private SpeechResult As RecognitionResult
    Private countCommand As Integer = 0
    Private PCMonitor As Monitor = New Monitor
    Private Capture As String = frmCarga.StrApplication_images + "/capture.png"
    Private Pross As Process
    Private CommandThread As Thread
    Private minimize As savi.ProcessFunction.SaviProcFunc = New savi.ProcessFunction.SaviProcFunc
    Private iHandleR As Integer = 0
    Private EnableDictation As Boolean = False
    ''
    Dim lastResult As Result
    Dim lastRequest As Request
    Dim CONTADOR As Integer = 0
    Dim MIARRAY(CONTADOR) As String
    Dim buffer() As Byte
    Dim StopRec As Boolean = False

    Public _isWeb As Boolean = False

    Sub InitSpeechRec()
        Try
            _reco.SetInputToDefaultAudioDevice()
            _reco.RequestRecognizerUpdate()
            _reco.BabbleTimeout = System.TimeSpan.FromSeconds(0.4)
            _reco.EndSilenceTimeout = System.TimeSpan.FromSeconds(0.4)
            _reco.MaxAlternates = 10
            _reco.RecognizeAsync(RecognizeMode.Multiple)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
        AddHandler _savi.SpeakStarted, AddressOf _savi_SpeakStarted
        AddHandler _savi.SpeakCompleted, AddressOf savi_SpeakCompleted
        AddHandler _savi.SpeakProgress, AddressOf _savi_SpeakProgress

        AddHandler _reco.SpeechRecognized, AddressOf savi_SpeechReconize
        AddHandler _reco.SpeechRecognitionRejected, AddressOf savi_SpeechReconitionR
        AddHandler _reco.SpeechDetected, AddressOf savi_SpeechDetected
        AddHandler _reco.SpeechHypothesized, AddressOf savi_SpeechHypothesized

        AddHandler _reco.RecognizeCompleted, AddressOf RecognizeCompletedHandler
        AddHandler _reco.EmulateRecognizeCompleted, AddressOf EmulateRecognizeCompletedHandler

        AddHandler _reco.AudioLevelUpdated, AddressOf _reco_audioLevelUpdate
        AddHandler _reco.AudioStateChanged, AddressOf _reco_audioStateChanged
    End Sub
    ''
    ''
    ''
    Sub _reco_audioLevelUpdate(ByVal sender As Object, ByVal e As AudioLevelUpdatedEventArgs)
        frmRecoVoz.cpbMicVol.Value = e.AudioLevel

    End Sub
    Sub _reco_audioStateChanged(ByVal sender As Object, ByVal e As AudioStateChangedEventArgs)
        ''por desarrollar , agregar colores
    End Sub
    ''
    ''
    Sub savi_SpeechHypothesized(ByVal sender As Object, e As SpeechHypothesizedEventArgs)

    End Sub

    Sub savi_SpeechDetected(ByVal sender As Object, ByVal e As SpeechDetectedEventArgs)
        frmRecoVoz.cpbSpkVol.InnerColor = Color.Indigo

    End Sub

    Sub savi_SpeechReconitionR(ByVal sender As Object, ByVal e As SpeechRecognitionRejectedEventArgs)

    End Sub

    Sub savi_SpeechReconize(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)
        Dim RecResult As RecognitionResult = e.Result
        Dim id As Integer = GetIdPerson(frmInicio.lbl_upersv.Text)
        recFunc(RecResult, RecResult.Text, id)
    End Sub
    ''
    Private Sub EmulateRecognizeCompletedHandler(sender As Object, e As EmulateRecognizeCompletedEventArgs)

        comandoEjec = False
    End Sub

    Private Sub RecognizeCompletedHandler(sender As Object, e As RecognizeCompletedEventArgs)

        comandoEjec = False
    End Sub
    ''
    ''
    Sub _savi_SpeakProgress(ByVal sender As Object, ByVal e As SpeakProgressEventArgs)
        ''obtener el volumen del audio reproducido por speak
        frmRecoVoz.cpbSpkVol.OuterWidth = e.AudioPosition.Milliseconds / 100 + 3
    End Sub

    Sub _savi_SpeakStarted(ByVal sender As Object, ByVal e As SpeakStartedEventArgs)
        frmRecoVoz.cpbSpkVol.OuterWidth = 7

    End Sub
    Sub savi_SpeakCompleted(ByVal sender As Object, ByVal e As SpeakCompletedEventArgs)
        frmRecoVoz.cpbSpkVol.OuterWidth = 7


    End Sub

    ''
    ''
    ''

    Public Sub selectVoice(name As String)
        Try
            If name <> "" Then
                _savi.SelectVoice(name)
                strSaviVoiceName = name
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Sub StopReconize()
        If Not _reco Is Nothing Then
            _reco.RecognizeAsyncStop()
            frmInicio.btnIniciar.Enabled = True
            silencio = True
            StopRec = True
        End If

    End Sub

    Public Sub SpeakAsyncCancell(Stext As String)
        If silencio = False Or _isWeb = True Then
            _savi.SpeakAsyncCancelAll()
            _speak(Stext)
        End If
    End Sub

    Public Sub SpeakAsync(Stext As String)
        If silencio = False Or _isWeb = True Then
            _speak(Stext)
        End If
    End Sub

    Public Sub SpeakSync(Stext As String)
        Try
            If silencio = False Or _isWeb = True Then
                _speak(Stext)
            End If
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub recFunc(recResult As RecognitionResult, command As String, idPerson As Integer)
        '' si es diferente que el anterior quitar silencio

        strCommandRec = command

        If frmInicio.lbl_upersv.Text = strUserName Then
            strPerson = strUserNickname

        ElseIf frmInicio.lbl_upersv.Text <> "" Then
            strPerson = frmInicio.lbl_upersv.Text

        End If
        '' voz de cada persona al decir "hola"
        If idPerson >= 0 And command = "hola" Then
            frmMemory.Memory.PsrnMemory.Rows(idPerson).Item(3) = recResult.Confidence +
                Val(recResult.Audio.Duration.ToString) * recResult.Semantics.Confidence
        End If

        ''escribe en el log
        LogText += strPerson + ": " + command + Environment.NewLine()

        If strPerson <> "" Then SaviUser.Predicates.addSetting("name", strPerson)


        If comandoEjec = False And EnableDictation = False Then
            Try
                If strPerson = strUserNickname And SaviUser.Predicates.grabSetting("userresponse") = True Then
                    comandos_def(command)
                ElseIf SaviUser.Predicates.grabSetting("userresponse") = True Then
                    '' si llaman al asistente responder 
                    If command = strAvName Then : comandos_def(command) : Return : End If
                    ''si pide un comando que no esta autorizado
                    If Commands_Default.Contains(command) Then
                        _speak("No puedo realizar lo que me pide&no tengo autorización para realizar eso&disculpe, pero no puedo hacerlo&lo siento " + strPerson + " pero no puedo responder a sus ordenes")
                    Else
                        SpeakAsync(GetRBot(command))
                    End If
                Else
                    comandos_def(command)
                End If
            Catch ex As Exception

            End Try
        ElseIf EnableDictation = True Then
            silencio = False
            DictationMode(command)
        End If


        comandoEjec = False
    End Sub

    Sub SimulateRec(person As String, text As String)
        Dim rec As RecognitionResult
        _isWeb = True
        'asigna el nombre de la persona en la app
        strPerson = "App " + person
        recFunc(rec, text, -1)
        ''devuelve el nombre de usuario
        strPerson = strUserNickname
        _isWeb = False

    End Sub

    Function RandText(str As String) As String

        If str.Contains("&") Then
            Dim Phrases() As String = str.Split(New Char() {"&"})
            Dim intR As Integer = 0
            Dim rand As New Random
            intR = rand.Next(0, Phrases.Count())
            str = Phrases(intR)

        End If

        Return str
    End Function

    Sub _speak(str As String)
        If str.Contains("%") Then str = GetScriptVal(str)

        str = RandText(str)

        If (_isWeb = True) Then
            WebWrite(str)

            LogText += "Server " + strAvName + ": " + str + Environment.NewLine()
            Return
        End If

        If silencio = True Then Return

        LogText += strAvName + ": " + str + Environment.NewLine()

        exeCommand("speak", str)



    End Sub

    Public Sub clear_greetings() ''limpiar saludos
        For I As Integer = 0 To frmMemory.Memory.PsrnMemory.Rows.Count - 1
            frmMemory.Memory.PsrnMemory.Rows(I).Item(4) = False
        Next
        SaveFaceData()

    End Sub


    Public Function getlistVoice() As Array

        Dim arr(0 To _savi.GetInstalledVoices.Count - 1) As String
        Dim I As Integer = 0

        ''carga las voces del sistema windows
        For I = 0 To _savi.GetInstalledVoices.Count - 1
            arr(I) = _savi.GetInstalledVoices.Item(I).VoiceInfo.Name
        Next

        Return arr
    End Function

    Public Function GetIdCommand(name As String) As Integer
        Dim count As Integer = 0
        Dim split() As String
        count = frmMemory.Commands.Comands.Rows.Count

        For b As Integer = 0 To count - 1
            split = frmMemory.Commands.Comands.Rows(b).Item(0).ToString.Split(New Char() {"&"})

            If split.Count > 0 Then
                If split.Contains(name) Then

                    Return b

                End If

            ElseIf frmMemory.Commands.Comands.Rows(b).Item(0) = name Then

                Return b

            End If
        Next


        Return -1
    End Function

    Sub LoadSpeechConfig()
        '' Voz
        selectVoice(SaviBot.GlobalSettings.grabSetting("voice"))
        ''nombre del asistente
        strAvName = SaviBot.GlobalSettings.grabSetting("name")
        ''usuario pricipal
        strUserName = SaviUser.Predicates.grabSetting("user")
        ''ip servidor web
        strIpServer = SaviUser.Predicates.grabSetting("ipserver")
        ''nombre o apodo del usuario
        strUserNickname = SaviUser.Predicates.grabSetting("nickname")
        ''cultura del sistema
        strCulture = SaviUser.Predicates.grabSetting("culture")
        ''tiempo de espera
        MinWaitTime = Val(SaviBot.GlobalSettings.grabSetting("waittime"))

    End Sub

    Sub LoadGrammar()
        ''
        Dim VOCABULARIO As New GrammarBuilder
        Dim _choices As New Choices

        CultureInfo = New System.Globalization.CultureInfo(strCulture)
        VOCABULARIO.Culture = CultureInfo

        countCommand = Commands_Default.Count + commands_social.Count
        Dim Commands(countCommand - 1) As String
        Dim i As Integer = 0
        For x As Integer = 0 To Commands_Default.Count - 1
            Dim Comm As Object = Commands_Default(x)
            Commands(i) = Comm
            i += 1
        Next
        ''carga comando sociales
        For x As Integer = 0 To commands_social.Count - 1
            Dim Comm As Object = commands_social(x)
            Commands(i) = Comm
            i += 1
        Next
        Dim split() As String

        '' carga de comandos de la base de datos
        For x As Integer = 0 To frmMemory.Commands.Comands.Rows.Count - 1
            Try
                If frmMemory.Commands.Comands.Rows(x).Item(0).ToString.Contains("&") Then _
                    split = frmMemory.Commands.Comands.Rows(x).Item(0).ToString.Split(New Char() {"&"})

                If Not split Is Nothing Then
                    _choices.Add(split)
                Else
                    _choices.Add(New String() {frmMemory.Commands.Comands.Rows(x).Item(0)})
                End If

            Catch ex As Exception

            End Try
        Next
        _reco.UnloadAllGrammars()

        _choices.Add(Commands)

        'carga los comandos del bot AIML
        For x As Integer = 0 To SaviBot.PatternsList.Count - 1

            _choices.Add(New String() {SaviBot.PatternsList.Item(x)})

        Next

        VOCABULARIO.Append(_choices)
        _reco.LoadGrammar(New Grammar(VOCABULARIO))

    End Sub

    Public Sub LoadCommand()
        frmMemory.Commands.Clear()
        frmMemory.Commands.ReadXml(frmCarga.StrSystem_file)
        frmMemory.ViewComands.Update()

    End Sub

    Public Sub SaveCommands()
        frmMemory.ComandsBindingSource.EndEdit()
        frmMemory.Commands.WriteXml(frmCarga.StrSystem_file)
        LoadCommand()
    End Sub

    ''bot
    Sub LoadBot()
        SaviBot = New Bot()
        SaviBot.isAcceptingUserInput = True
        SaviBot.loadSettings("application\Config\Settings.xml")
        SaviBot.GlobalSettings.loadSettings("application\Config\Settings.xml")
        SaviBot.DefaultPredicates.loadSettings("application\Config\DefaultPredicates.xml")
        SaviBot.GenderSubstitutions.loadSettings("application\Config\GenderSubstitutions.xml")
        SaviBot.loadCustomTagHandlers(Assembly.LoadFrom(Application.StartupPath + "\" + Process.GetCurrentProcess.ProcessName + ".exe"))
        SaviUser = New User(strUserName, SaviBot)
        AddHandler SaviBot.WrittenToLog, New AIMLbot.Bot.LogMessageDelegate(AddressOf saviBot_WrittenToLog)
        SaviBot.loadFromBinaryFile(frmCarga.StrSystem_botbrain_file)
        'SaviBot.loadAIMLFromFiles()

    End Sub

    Private Sub saviBot_WrittenToLog()
        Dim expr_06 As TextBox = frmRecoVoz.tbxLog
        expr_06.Text = expr_06.Text() + SaviBot.LastLogMessage + Environment.NewLine()
        frmRecoVoz.tbxLog.ScrollToCaret()
    End Sub

    Function ChatBot(rawInput As String) As String
        Dim myRequest As Request = New Request(UCase(rawInput), SaviUser, SaviBot)
        Dim myResult As Result = SaviBot.Chat(myRequest)
        lastRequest = myRequest
        lastResult = myResult

        Return LCase(myResult.RawOutput.ToUpper())
    End Function

    ''load

    Sub initSpeech()
        Try
            LoadBot()
            LoadCommand()
            LoadSpeechConfig()
            ''
            ''carga el grammar
            LoadGrammar()

            If StopRec = True Then : _reco.RecognizeAsync(RecognizeMode.Multiple)
                StopRec = False : Return : End If

            InitSpeechRec()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ''////////////////////////////////////////////
    ''
    ''------------------------------------------
    ''          ejecucion de comandos
    ''------------------------------------------
    ''
    ''////////////////////////////////////////////

    ''' <summary>
    ''' ejecuta una thread para los scripts
    ''' </summary>
    ''' <param name="func">funcion a ejecutar</param>
    ''' <param name="cmd">comandos scripts</param>
    ''' <remarks></remarks>
    Function exeCommand(func As String, cmd As String)
        Dim threadExec As Thread
        Select Case LCase(func)
            Case "dos"
                threadExec = New Thread(AddressOf DOS)
                threadExec.Start(cmd)
                comandoEjec = True

            Case "vbscript"
                threadExec = New Thread(AddressOf VBScript)
                threadExec.Start(cmd)
                comandoEjec = True

            Case "weather"
                threadExec = New Thread(AddressOf _Weather)
                threadExec.Start()
                comandoEjec = True

            Case "temperature"
                threadExec = New Thread(AddressOf _temperature)
                threadExec.Start()
                comandoEjec = True

            Case "fweather"
                threadExec = New Thread(AddressOf _FWeather)
                threadExec.Start()
                comandoEjec = True

            Case "shutdown"
                threadExec = New Thread(AddressOf shutdown)
                threadExec.Start(cmd)
                comandoEjec = True
            Case "speak"
                threadExec = New Thread(AddressOf cmdSpeak)
                threadExec.Start(cmd)
                comandoEjec = True

            Case Else
                Return vbNull
        End Select

        ListThread.Add(threadExec)
        Return threadExec
    End Function

    Sub cmdSpeak(str As String)

        _savi.SpeakAsync(str)
    End Sub

    ''' <summary>
    ''' obtiene el clima actual
    ''' </summary>
    ''' <remarks></remarks>
    Sub _Weather()
        Dim wControl As savi.WebControl.Weather = New savi.WebControl.Weather
        Dim Ret As String = wControl.GetWeather()

        If Ret.Contains("error") = False Then
            _speak(String.Concat(New String() {"Para hoy, el clima en ", wControl.getTown, " es ", wControl.getCondition, ", con una temperatura de ", wControl.getTemperature, " grados, con una humedad del ", wControl.getHumidity, " % y con vientos de ", wControl.getWinSpeed, " Kilometros por hora"}))

        ElseIf Ret.Contains("error") Then
            SpeakAsyncCancell(Ret)
        End If
    End Sub

    ''' <summary>
    ''' obtiene la temperatura para mañana
    ''' </summary>
    ''' <remarks></remarks>
    Sub _FWeather()
        Dim wControl As savi.WebControl.Weather = New savi.WebControl.Weather
        Dim Ret As String = wControl.GetWeather()

        If Ret.Contains("error") = False Then
            SpeakAsyncCancell("El CLima para mañana en " + wControl.getTown + " es")
            _speak(String.Concat(New String() {wControl.getTFCond, " con una temperatura maxima de ", wControl.getTFHigh, " y una minima de ", wControl.getTFLow, " grados"}))
        ElseIf Ret.Contains("error") Then
            SpeakAsyncCancell(Ret)
        End If
    End Sub
    ''' <summary>
    ''' obtiene la temperatura actual
    ''' </summary>
    ''' <remarks></remarks>
    Sub _temperature()
        Dim wControl As savi.WebControl.Weather = New savi.WebControl.Weather
        Dim Ret As String = wControl.GetWeather()

        If Ret.Contains("error") = False Then
            SpeakAsyncCancell("estamos con una temperatura de " + wControl.getTemperature + " grados")
        ElseIf Ret.Contains("error") Then
            SpeakAsyncCancell("No hay acceso al sistema, verifique su codigo o su acceso a internet")
        End If
    End Sub
    ''' <summary>
    ''' funciones para el apagado del sistema
    ''' </summary>
    ''' <param name="params">parametros para el apagado del sistema</param>
    ''' <remarks></remarks>
    Sub shutdown(params As String)
        Select Case params
            Case "r"
                _speak("Desea reiniciar el PC?&Debe confirmar el reinicio&Confirme el reinicio")
                If MsgBox("Desea reiniciar el PC?", MsgBoxStyle.YesNo, "Confirme el proceso") = MsgBoxResult.Yes Then
                    DOS("shutdown -r -t 20")
                    SpeakAsyncCancell("el computador se reiniciará en 20 segundos")
                    Thread.Sleep(1000)
                    comandos_def("cerrar asistente")
                Else
                    _speak("Reinicio cancelado&se cancelo el reinicio&cancelado")
                End If
            Case "s"
                _speak("Desea apagar el PC?&Debe confirmar el apagado del sistema&Confirme el apagado")
                If MsgBox("Desea apagar el PC?", MsgBoxStyle.YesNo, "Confirme el proceso") = MsgBoxResult.Yes Then
                    DOS("shutdown -s -t 30")
                    SpeakAsyncCancell("el computador se apagará en 30 segundos")
                    Thread.Sleep(1000)
                    comandos_def("cerrar asistente")
                Else
                    _speak("Apagado cancelado&se cancelo el apagado&cancelado")
                End If
            Case "l"
                _speak("Desea cerrar sesión?&Debe confirmar cerrado de sesión&Confirme el proceso")
                If MsgBox("Desea cerrar sesión?", MsgBoxStyle.YesNo, "Confirme el proceso") = MsgBoxResult.Yes Then
                    DOS("shutdown -l -t 10")
                    SpeakAsyncCancell("Cerrando sesión")
                    comandos_def("cerrar asistente")
                Else
                    _speak("se canceló el cerrado de sesión&cancelado")
                End If
        End Select
    End Sub

    ''' <summary>
    ''' obtiene una respuesta desde el bot de charla
    ''' </summary>
    ''' <param name="Input"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetRBot(Input As String) As String
        Return ChatBot(Input)
    End Function
    ''' <summary>
    ''' evia datos a app por udp
    ''' </summary>
    ''' <param name="text">texto a enviar</param>
    Public Sub WebWrite(text As String)

        'frmRecoVoz.enviar(strPerson & "|" & text)



    End Sub
    Function CToU(text) As String
        text = text.ToString.Replace("á", "a")

        text = text.ToString.Replace("é", "e")

        text = text.ToString.Replace("í", "i")

        text = text.ToString.Replace("ó", "o")

        text = text.ToString.Replace("ú", "u")

        Return text
    End Function
    ''' <summary>
    ''' modo dictado
    ''' </summary>
    ''' <param name="cmd">palabra recibida desde speech</param>
    ''' <remarks></remarks>
    Private Sub DictationMode(cmd As String)
        Dim enableCaracter As Boolean = False
        Dim enableSpace As Boolean = True
        Dim colection As Object
        Clipboard.SetText(cmd)
        Dim expr_15 As String = cmd
        Dim key As String = expr_15

        If expr_15 IsNot Nothing Then
            Dim num As Integer
            If colection Is Nothing Then
                colection = New System.Collections.Generic.Dictionary(Of String, Integer)(10) From {{"punto aparte", 0}, {"espacio", 1}, {"nuevo parrafo", 2}, {"nueva linea", 3}, {",", 4}, {".", 5}, {":", 6}, {";", 7}, {"¿", 8}, {"¡", 9}, {"desactivar dictado", 10}}
            End If

            If colection.TryGetValue(key, num) Then
                Select Case num
                    Case 0
                        InputSimulator.SimulateTextEntry(".")
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.ACCEPT)
                        enableCaracter = True
                    Case 1
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.SPACE)
                        enableCaracter = True
                    Case 2
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.[RETURN])
                        System.Threading.Thread.Sleep(25)
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.[RETURN])
                        enableCaracter = True
                    Case 3
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.[RETURN])
                        enableCaracter = True
                    Case 4
                        enableSpace = False
                    Case 5
                        enableSpace = False
                    Case 6
                        enableSpace = False
                    Case 7
                        enableSpace = False
                    Case 8
                        enableSpace = False
                    Case 9
                        enableSpace = False
                    Case 10
                        comandos_def("desactivar dictado")
                End Select
            End If
        End If
        If Not enableCaracter Then
            If enableSpace Then
                InputSimulator.SimulateKeyPress(VirtualKeyCode.SPACE)
            End If
            InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V)
        End If
        tmResponse = 0
    End Sub


    ''' <summary>
    ''' ejecucion de comandos
    ''' </summary>
    ''' <param name="cmd">comando</param>
    ''' <remarks></remarks>
    Sub comandos_def(cmd As String)
        Dim id As Integer = GetIdPerson(frmInicio.lbl_upersv.Text)


        If silencio = False Or _isWeb = True Then

            tmResponse = 0
            Select Case cmd.ToLower
                Case strAvName, strAvName + " estas hay"
                    SpeakAsync(GetRBot("avname"))
                    comandoEjec = True
                    Return
                Case "me escuchas", strAvName + " me escuchas"
                    SpeakAsync(GetRBot("me escuchas"))
                    comandoEjec = True
                    Return
                Case "silencio", "alto", "callate", "no hables", "para"
                    _speak("Disculpe," & strPerson & "&Lo siento " & strPerson & "&ok, disculpe")
                    frmRecoVoz.cpbSpkVol.InnerColor = Color.Red
                    tmResponse = MinWaitTime + 1
                    silencio = True
                    comandoEjec = True
                    Return

                Case "hola"
                    If id < 0 Then
                        SpeakAsync(GetRBot("hola"))
                        Return
                    End If

                    If frmMemory.Memory.PsrnMemory.Rows(id).Item(4) = False Then

                        If Hour(TimeOfDay) >= 12 And Hour(TimeOfDay) <= 18 Then
                            SpeakAsync("buenas tardes " & strPerson)


                        ElseIf Hour(TimeOfDay) >= 6 And Hour(TimeOfDay) <= 11 Then
                            SpeakAsync("buenos días " & strPerson)
                        ElseIf Hour(TimeOfDay) >= 19 And Hour(TimeOfDay) <= 24 Then
                            SpeakAsync("buenas nóches " & strPerson)
                        Else
                            SpeakAsync("buen dia " & strPerson)
                        End If
                        If strPerson = "ninguna" Or
                            strPerson = "" Then Return

                        frmMemory.Memory.PsrnMemory.Rows(id).Item(4) = True
                        SaveFaceData()
                    End If
                    comandoEjec = True
                    Return

                Case "quien soy"
                    If Val(frmInicio.lbl_npersv.Text) > 1 Then
                        SpeakAsync("las personas que puedo identificar ahora son  " & frmInicio.lbl_persv.Text)
                    ElseIf strPerson.Count > 1 Then
                        _speak("Según puedo identificar&Al parecer&Según veo")
                        _speak(IIf(strPerson = strUserNickname, "Usted es " & strPerson & " " & strUserName, "Usted es " & strPerson) + RandText(",Verdad?&,No?&,Estoy en lo correcto?"))

                    Else
                        SpeakAsync("no puedo identificar su rostro")
                    End If
                    comandoEjec = True
                    Return

                Case "apaga la camara", "apagar camara"
                    SpeakAsyncCancell("si, " + strPerson)
                    If SaviUser.Predicates.grabSetting("userresponse") = True Then _
                        SpeakAsync("debo recordar " + strPerson + " que no podre reconocer su rostro, debe desactivar la opcion 'responder comandos solo a usuario' para poder ejecutar comandos")

                    If Not frmInicio.capturez Is Nothing Then
                        frmInicio.tmr_deteccion.Stop()
                        frmInicio.capturez.Dispose()
                    Else
                        SpeakAsync("la camara no esta activada.")
                    End If
                    comandoEjec = True
                    Return

                Case "activa la camara", "activar camara"
                    SpeakAsyncCancell("enseguida, " + strPerson)
                    frmInicio.btnIniciar.PerformClick()
                    comandoEjec = True
                    Return

                Case "cierra el asistente virtual", "cerrar asistente"
                    If _isWeb = True Then : _speak("No puedo realizar esa tarea desde aquí") : Return : End If
                    _savi.SpeakAsync(RandText("que tenga un buen día, " + strPerson + "&Hasta pronto " + strPerson + "&Hasta la proxima " + strPerson))

                    frmInicio.btnExit.PerformClick()
                    Application.Exit()
                    comandoEjec = True
                    Return

                Case "minimizar asistente", "minimizar el asistente"

                    If frmRecoVoz.WindowState = FormWindowState.Normal OrElse frmRecoVoz.WindowState = FormWindowState.Maximized Then
                        frmRecoVoz.WindowState = FormWindowState.Minimized
                        SpeakAsyncCancell("Asistente Minimizado")
                    End If
                    comandoEjec = True
                    Return

                Case "mostrar asistente", "mostrar el asistente", "ver asistente"
                    If frmRecoVoz.WindowState = FormWindowState.Minimized Then
                        frmRecoVoz.Show()
                        SpeakAsyncCancell("Barra de estado activada")
                        frmRecoVoz.WindowState = FormWindowState.Normal
                    End If
                    comandoEjec = True
                    Return

                Case "no me llamo asi"
                    Dim nam As String
                    SpeakAsyncCancell("entonces como se llama?")
                    nam = InputBox("escribe tu nombre", "S.A.V.I.", "", 10, 10)

                    If nam.Length > 0 Then
                        saveNewFace(nam, frmInicio.rostro)
                        SpeakAsyncCancell("mucho gusto en conocerle, " & nam)
                    End If
                    comandoEjec = True
                    Return

                Case "qué día es", "qué día es hoy", "dime que día es"
                    Dim day As String = System.DateTime.Today.ToString("dddd")
                    SpeakAsyncCancell(day)
                    comandoEjec = True
                    Return

                Case "qué fecha es", "qué fecha es hoy", "cuál es la fecha", "cuál es la fecha para hoy", "dime la fecha"
                    Dim dateTd As String = System.DateTime.Today.ToString("dd-MM-yyyy")
                    SpeakAsyncCancell(dateTd)
                    comandoEjec = True
                    Return
                Case "qué hora es", "qué hora es ahora", "dime la hora"
                    Dim time As String = System.DateTime.Now.GetDateTimeFormats("t"c)(0)
                    SpeakAsyncCancell(time)
                    comandoEjec = True
                    Return
                Case "vaciar papelera", "vaciar papelera de reciclaje", "limpiar la papelera", "limpiar la papelera de reciclaje", "limpiar papelera", "vaciar papelera"
                    PCMonitor.vaciarPapelera()
                    _speak("papelera limpia&limpia&listo&ok")
                    comandoEjec = True
                    Return
                Case "copiar", "copiar eso", "copiar esto"
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C)
                    SpeakAsyncCancell("copiado")
                    comandoEjec = True
                    Return
                Case "cortar", "cortar eso", "cortar esto"
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_X)
                    SpeakAsyncCancell("cortado")
                    comandoEjec = True
                    Return

                Case "eliminar", "eliminar eso", "eliminar esto"
                    InputSimulator.SimulateKeyDown(VirtualKeyCode.DELETE)
                    SpeakAsyncCancell("eliminando")
                    comandoEjec = True
                    Return

                Case "reiniciar sistema", "reiniciar la computadora", "reiniciar el ordenador", "reiniciar el sistema"
                    exeCommand("shutdown", "r")

                    Return

                Case "apagar sistema", "apagar la computadora", "apagar el ordenador", "apagar el sistema"
                    exeCommand("shutdown", "s")

                    Return

                Case "cerrar sesión", "cambiar de sesión", "cambiar la sesión"

                    exeCommand("shutdown", "l")
                    Return

                Case "abortar", "cancelar"
                    InputSimulator.SimulateKeyDown(VirtualKeyCode.ESCAPE)
                    SpeakAsyncCancell("cancelado")
                    comandoEjec = True
                    Return

                Case "cancelar apagado", "cancelar reinicio"
                    DOS("shutdown -a")
                    SpeakAsyncCancell("cancelado")
                    comandoEjec = True
                    Return

                Case "si"
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_S)
                    comandoEjec = True
                    Return

                Case "no"
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_N)
                    comandoEjec = True
                    Return

                Case "guardar", "guardar eso", "guardar esto"

                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_G)
                    SpeakAsyncCancell("guardando")
                    comandoEjec = True
                    Return
                Case "pegar", "pegar eso", "pegar esto"

                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V)
                    SpeakAsyncCancell("pegado")
                    comandoEjec = True
                    Return
                Case "mostrar escritorio", "minimizar todas las ventanas"
                    Dim typeShell As System.Type = System.Type.GetTypeFromProgID("Shell.Application")
                    Dim objShell As Object = System.Activator.CreateInstance(typeShell)
                    typeShell.InvokeMember("MinimizeAll", System.Reflection.BindingFlags.InvokeMethod, Nothing, objShell, Nothing)
                    SpeakAsyncCancell("el escritorio")
                    comandoEjec = True
                    Return

                Case "activar dictado"
                    SpeakAsyncCancell("dictado activado")
                    _reco.LoadGrammar(New DictationGrammar())
                    EnableDictation = True
                    comandoEjec = True
                    Return

                Case "desactivar dictado"
                    SpeakAsyncCancell("dictado desactivado")
                    _reco.UnloadAllGrammars()
                    LoadCommand()
                    LoadGrammar()
                    EnableDictation = False
                    comandoEjec = True
                    Return

                Case "conversemos", "activar conversación", "quieres conversar?", "hablemos", "quieres hablar?"
                    SpeakAsyncCancell("ok")
                    _reco.LoadGrammar(New DictationGrammar())
                    comandoEjec = True
                    Return

                Case "abrir bandeja", "abrir la lectora", "abrir unidad de dvd", "abrir unidad de cd", "abrir unidad de cd rom"
                    PCMonitor.abrirBandeja()
                    SpeakAsyncCancell("bandeja abierta")
                    comandoEjec = True
                    Return
                Case "apagar monitor", "dapagar la pantalla", "apagar monitor"
                    PCMonitor.SetMonitorOFF()
                    comandoEjec = True
                    Return
                Case "cambiar ventana", "siguiente ventana", "cambiar de ventana"

                    SpeakAsyncCancell("cambiada")
                    comandoEjec = True
                    Return
                Case "capturar pantalla", "capturar la pantalla", "capturar monitor"
                    TakeScreenShot(Capture)
                    Process.Start(Capture)
                    SpeakAsyncCancell("pantalla capturada")
                    comandoEjec = True
                    Return
                Case "cerrar eso", "cerrar ventana", "cerrar", "cerrar la aplicacion", "cerrar el programa", "cerrar programa"
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.F4)
                    SpeakAsyncCancell("cerrando")
                    comandoEjec = True
                    Return
                Case "cuál es el clima", "el clima", "cuál es el pronóstico", "el pronóstico"
                    SpeakAsync("Conectando con el servidor")
                    exeCommand("weather", "")
                Case "cuál es el clima para mañana", "el clima para mañana", "cuál es el pronostico para mañana", "el pronóstico para mañana"
                    SpeakAsync("Conectando con el servidor")
                    exeCommand("fweather", "")
                Case "cuál es la temperatura", "a que temperatura estamos", "la temperatura"
                    SpeakAsync("Conectando con el servidor")
                    exeCommand("temperature", "")
                Case "revisar correo", "revisar el correo"
                Case "leer correo", "leer el correo"
                Case "leer siguiente correo", "leer el siguiente correo", "leer el correo siguiente", "leer correo siguiente", "siguiente correo"
                Case "leer anterior correo", "leer el correo anterior", "leer el anterior correo", "leer correo anterior", "anterior correo"
                Case "abrir correo", "abrir el correo", "ver el correo", "ver correo"
                Case "leer esto", "leer el texto", "leer el siguiente texto", "leer texto seleccionado"
                    Try
                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C)

                        SpeakAsyncCancell(Clipboard.GetText())
                    Catch ex_BE4 As System.Exception
                        '' cargar en el bot para obtener varias respuestas
                        SpeakAsyncCancell("debe seleccionar el texto a leer")
                    End Try
                    comandoEjec = True
                    Return
                Case "buscar esto", "buscar esto", "buscar el texto", "buscar el siguiente texto", "buscar texto seleccionado"
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C)
                    System.Threading.Thread.Sleep(100)
                    Process.Start("https://www.google.com.ec/search?q=" + Clipboard.GetText())
                    SpeakAsyncCancell("Buscando " + Clipboard.GetText())
                    comandoEjec = True
                    Return
                Case "revisar facebook", "revisar el facebook"
                Case "leer notificación", "leer la notificación"
                Case "abrir notificación", "abrir la notificacion", "ver la notificación", "ver notificacón"
                Case "leer siguiente notificación", "siguiente notificación"
                Case "leer anterior notificación", "anterior notificación"

                Case "minimizar ventana", "minimizar eso", "minimizar esto"
                    minimize.MinimizeNameWindow()
                    SpeakAsyncCancell("minimizado")
                    comandoEjec = True
                    Return

                Case "Comprimir ventana"
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.RWIN, VirtualKeyCode.DOWN)
                    SpeakAsyncCancell("comprimido")
                    comandoEjec = True
                    Return
                Case "pantalla completa", "maximizar pantalla"
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.RWIN, VirtualKeyCode.UP)
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.RWIN, VirtualKeyCode.UP)
                    SpeakAsyncCancell("Maximizado")
                    comandoEjec = True
                    Return
                Case "abrir configuración", "mostrar configuración", "ver configuración"
                    frmMemory.Show()
                    comandoEjec = True
                    Return
                Case "abrir alarma", "aconfigurar alarma", "ver la alarma", "mostrar la alarma"
                Case "estado de alarma", "estado de la alarma", "cúal es el estado de la alarma", "saber el estado de la alarma", "dime el estado de la alarma", "el estado de la alarma"
                Case "activar alarma", "activar la alarma", "iniciar la alarma", "comenzar la alarma"
                Case "desactivar alarma", "parar la alarma", "detener la alarma", "desactivar la alarma"
                Case "abrir recordatorio", "agregar recordatorio", "insertar recordatorio", "ver recordatorio"
                Case "revisar recordatorios"

                Case "agregar comandos", "agregar comandos", "insertar comandos", "ingresar comandos"
                    frmMemory.TCConfig.SelectedTab = frmMemory.TpComandos
                    frmMemory.BackgroundImage.Dispose()
                    frmMemory.BackgroundImage = My.Resources.Options2
                    frmMemory.btn_text.Text = frmMemory.lblComandos.Text
                    frmMemory.Show()
                    SpeakAsync("Los comandos programables")
                    comandoEjec = True
                    Return

                Case "mostrar comandos", "ver comandos", "ver los comandos", "mostrar comandos del sistema", "mostrar los comandos del sistema", "ver los comandos del sistema", "mostrar comandos por defecto", "ver comandos por defecto", "mostrar los comandos por defecto"
                    frmMemory.TCConfig.SelectedTab = frmMemory.TpComandos
                    frmMemory.BackgroundImage.Dispose()
                    frmMemory.BackgroundImage = My.Resources.Options2
                    frmMemory.btn_text.Text = frmMemory.lblComandos.Text
                    frmMemory.btnCmdSystem.PerformClick()
                    frmMemory.Show()
                    SpeakAsync("Los comandos del sistema")
                    comandoEjec = True
                    Return

                Case "abrir nueva ventana", "nueva ventana", "ventana nueva"
                    If minimize.GetNameCurrentProcess = "iexplore" OrElse minimize.GetNameCurrentProcess = "MicrosoftEdge" _
                        OrElse minimize.GetNameCurrentProcess = "chrome" OrElse minimize.GetNameCurrentProcess = "firefox" Then

                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_N)
                        SpeakAsyncCancell("nueva ventana")
                    End If
                    comandoEjec = True
                    Return
                Case "abrir nueva pestaña", "nueva pestaña", "pestaña nueva"
                    If minimize.GetNameCurrentProcess = "iexplore" OrElse minimize.GetNameCurrentProcess = "MicrosoftEdge" _
                        OrElse minimize.GetNameCurrentProcess = "chrome" OrElse minimize.GetNameCurrentProcess = "firefox" Then

                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_T)
                        SpeakAsyncCancell("nueva pestaña")
                    End If
                    comandoEjec = True
                    Return
                Case "abrir nueva ventana en modo incognito", "modo incognito", "nueva ventana en modo incognito"

                    If minimize.GetNameCurrentProcess = "iexplore" OrElse minimize.GetNameCurrentProcess = "MicrosoftEdge" _
                         OrElse minimize.GetNameCurrentProcess = "chrome" OrElse minimize.GetNameCurrentProcess = "firefox" Then
                        InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL)
                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_N)
                        System.Threading.Thread.Sleep(50)
                        InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL)
                        SpeakAsyncCancell("nueva ventana modo incognito")
                    End If
                    comandoEjec = True
                    Return
                Case "abrir pestaña cerrada", "última pestaña cerrada", "pestaña cerrada", "abrir última pestaña cerrada", "abrir última pestaña"
                    If minimize.GetNameCurrentProcess = "iexplore" OrElse minimize.GetNameCurrentProcess = "MicrosoftEdge" _
                         OrElse minimize.GetNameCurrentProcess = "chrome" OrElse minimize.GetNameCurrentProcess = "firefox" Then
                        InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL)
                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_T)
                        System.Threading.Thread.Sleep(50)
                        InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL)
                        SpeakAsyncCancell("ultima pestaña cerrada")
                        comandoEjec = True
                        Return
                    End If
                Case "siguiente pestaña", "cambiar pestaña", "cambiar de pestaña"

                    If minimize.GetNameCurrentProcess = "iexplore" OrElse minimize.GetNameCurrentProcess = "MicrosoftEdge" _
                         OrElse minimize.GetNameCurrentProcess = "chrome" OrElse minimize.GetNameCurrentProcess = "firefox" Then
                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.TAB)
                        SpeakAsyncCancell("siguiente")
                        comandoEjec = True
                        Return
                    End If
                Case "anterior pestaña", "pestaña anterior"

                    If minimize.GetNameCurrentProcess = "iexplore" OrElse minimize.GetNameCurrentProcess = "MicrosoftEdge" _
                         OrElse minimize.GetNameCurrentProcess = "chrome" OrElse minimize.GetNameCurrentProcess = "firefox" Then
                        InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL)
                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LSHIFT, VirtualKeyCode.TAB)
                        System.Threading.Thread.Sleep(50)
                        InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL)
                        SpeakAsyncCancell("anterior")
                        comandoEjec = True
                        Return
                    End If
                Case "cerrar pestaña", "cerrar pestaña actual", "cerrar esta pestaña", "cerrar la pestaña"
                    If minimize.GetNameCurrentProcess = "iexplore" OrElse minimize.GetNameCurrentProcess = "MicrosoftEdge" _
                         OrElse minimize.GetNameCurrentProcess = "chrome" OrElse minimize.GetNameCurrentProcess = "firefox" Then
                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_W)
                        System.Threading.Thread.Sleep(50)
                        SpeakAsyncCancell("cerrado")
                        comandoEjec = True
                        Return
                    End If
                Case "subir", "subir página", "subir página web", "arriba"
                    If minimize.GetNameCurrentProcess = "iexplore" OrElse minimize.GetNameCurrentProcess = "MicrosoftEdge" _
                         OrElse minimize.GetNameCurrentProcess = "chrome" OrElse minimize.GetNameCurrentProcess = "firefox" Then
                        For i As Integer = 0 To 10
                            InputSimulator.SimulateKeyPress(VirtualKeyCode.UP)
                            System.Threading.Thread.Sleep(50)
                        Next
                        comandoEjec = True
                        Return
                    End If
                Case "bajar", "bajar página", "bajar página web", "abajo"
                    If minimize.GetNameCurrentProcess = "iexplore" OrElse minimize.GetNameCurrentProcess = "MicrosoftEdge" _
                         OrElse minimize.GetNameCurrentProcess = "chrome" OrElse minimize.GetNameCurrentProcess = "firefox" Then
                        For i As Integer = 0 To 10
                            InputSimulator.SimulateKeyPress(VirtualKeyCode.DOWN)
                            System.Threading.Thread.Sleep(50)
                        Next
                        comandoEjec = True
                        Return
                    End If
                Case "imprimir página", "imprimir esta página", "imprimir la página"
                    If minimize.GetNameCurrentProcess = "iexplore" OrElse minimize.GetNameCurrentProcess = "MicrosoftEdge" _
                         OrElse minimize.GetNameCurrentProcess = "chrome" OrElse minimize.GetNameCurrentProcess = "firefox" Then
                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_P)
                        SpeakAsyncCancell("configuracion de impresion")
                        comandoEjec = True
                        Return
                    End If
                Case "página de descargas", "ver página de descargas", "mostrar mis descargas", "mis descargas", "abrir mis descargar", "ver mis descargas"
                    If minimize.GetNameCurrentProcess = "iexplore" OrElse minimize.GetNameCurrentProcess = "MicrosoftEdge" _
                         OrElse minimize.GetNameCurrentProcess = "chrome" OrElse minimize.GetNameCurrentProcess = "firefox" Then
                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_J)
                        SpeakAsyncCancell("sus descargas")
                        comandoEjec = True
                        Return
                    End If
                Case "actualizar", "refrescar", "actualizar pagina"
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.F5)
                    comandoEjec = True
                    Return
                Case "reproducir música", "reproducir canción", "reproducir pista", "reproducir", "iniciar música", "iniciar canción", "iniciar pista", "reproducir video", "reproducir pelicula", "iniciar video", "iniciar pelicula", "reanudar"
                    While Process.Start(SaviUser.Predicates.grabSetting("appmusic")).Start = False : End While
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE)

                    Return
                Case "detener música", "detener", "cancelar musica", "cancelar reproducción", "detener pista", "detener canción"
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE)

                    Return
                Case "pausar música"
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE)

                    Return
                Case "siguiente música", "siguiente pista", "siguiente canción", "siguiente reproduccion"
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_NEXT_TRACK)

                    Return
                Case "anterior música", "anterior pista", "anterior canción", "música anterior", "pista anterior", "canción anterior"
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PREV_TRACK)

                    Return
                Case "activar aleatorio", "iniciar aleatorio", "activar random", "activar música aleatoria", "activar pista aleatoria", "activar canción aleatior", "música aleatoria", "desactivar aleatorio", "desactivar música aleatoria"
                    While Process.Start(SaviUser.Predicates.grabSetting("appmusic")).Start = False : End While
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE)

                    Return
                Case "repetir música", "repetir pista", "repetir canción", "desactivar repetir"
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PREV_TRACK)

                    Return
                Case "subir volumen", "aumentar volumen", "inclementar volumen", "subir el volumen"
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_UP)

                    Return
                Case "bajar volumen", "desminuir volumen", "decrementar volumen"
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_DOWN)

                    Return
                Case "silenciar música", "sienciar", "desactivar volumen", "mute"
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_MUTE)

                    Return
                Case Else
                    Try
                        Dim IdC As Integer = GetIdCommand(cmd) '' id del comando
                        Dim Comm As String
                        If IdC < 0 Then
                            SpeakAsyncCancell(GetRBot(CToU(cmd)))
                            Return
                        End If
                        Comm = LCase(frmMemory.Commands.Comands.Rows(IdC).Item(2))
                        _speak(frmMemory.Commands.Comands.Rows(IdC).Item(1))
                        If Comm <> "" Then
                            If Comm.Substring(0, InStr(Comm, "$")).Contains("%vbscript%") = True Then
                                exeCommand("VBScript", Comm)
                            Else

                                exeCommand("DOS", Comm)

                            End If

                        End If

                    Catch ex As Exception
                        SpeakAsyncCancell("Error:" & ex.Message)
                    End Try


            End Select
        ElseIf cmd = strAvName Then
            silencio = False
            tmResponse = 0
            frmRecoVoz.cpbSpkVol.InnerColor = Color.Transparent
            frmRecoVoz.cpbSpkVol.Refresh()
            _speak(ChatBot("avname"))
        End If

    End Sub



End Module



