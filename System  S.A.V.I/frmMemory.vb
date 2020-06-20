Imports System.Xml
Imports System.Net
Imports System.Net.Mail



Public Class frmMemory

    Dim descriprion As String = "Gracias por descargar System SAVI. " +
                       vbCrLf + "el sistema SAVI es un Sistema de Asistente Virtual Inteligente desarrollado para asistir al usuario en su dispositivo. SAVI cuenta con un sistema de reconocimiento y síntesis de voz y con un sistema de reconocimiento facial incluido. " +
                       vbCrLf + "SAVI tiene la capacidad de ejecutar comando con scripts, lo cual mejora las capacidades de ejecución de comandos, los scripts que puede ejecutar son VBScript y Batch. los scripts se ejecutan de manera externa de software así que no se podrán acceder a las variables del script, esta función está en desarrollo. SAVI también cuenta con un Bot de inteligencia artificial lo cual mejora la fluidez de conversación, esta función también está mejorándose, ahora está en su primera fase." +
                       vbCrLf + " Si deseas contribuir al proyecto puedes hacer una donacion voluntaria para que el proyecto siga creciendo. Puedes contribuir por el tiempo invertido en el software y para que siga siendo gratuito." +
                       vbCrLf + "Puedes enviarnos tus sugerencias y comentarios(no se conservará ninguno de los datos que ingreses de tu correo)"


    Private Sub frmMemory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.SetDesktopLocation(0, 0)
        Me.Size = New Size(643, 717)

        pic_ico.Image = Me.Icon.ToBitmap

        cbxAvVoice.Items.Clear()
        cbxUsuario.Items.Clear()

        Try
            LoadFaceData()
            LoadConfig()
            LoadCommand() : Catch ex As Exception
            MsgBox(ex.Message & ", revise la configuración.", MsgBoxStyle.Critical)
        End Try

        ' Establezca el título del formulario.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("Acerca de {0}", ApplicationTitle)
        ' Inicialice todo el texto mostrado en el cuadro Acerca de.
        ' TODO: personalice la información del ensamblado de la aplicación en el panel "Aplicación" del 
        '    cuadro de diálogo propiedades del proyecto (bajo el menú "Proyecto").
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Versión {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = "Descripción:" & vbCrLf & vbCrLf & descriprion

    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btn_min_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Sub LoadConfig()
        SaviBot.loadSettings("application\Config\Settings.xml")
        SaviBot.DefaultPredicates.loadSettings("application\Config\DefaultPredicates.xml")
        SaviBot.GenderSubstitutions.loadSettings("application\Config\GenderSubstitutions.xml")

        '' añade las personas
        For I As Integer = 0 To Memory.PsrnMemory.Rows.Count - 1
            If cbxUsuario.Items.Contains(Memory.PsrnMemory.Rows(I).Item(1)) = False Then cbxUsuario.Items.Add(Memory.PsrnMemory.Rows(I).Item(1))
        Next

        ''añade las voces
        cbxAvVoice.Items.AddRange(getlistVoice)
        ''añade paises
        getCBoxCity(cbxCity)
        ''config
        cbxAvVoice.SelectedItem = SaviBot.GlobalSettings.grabSetting("voice")
        TbxAvName.Text = SaviBot.GlobalSettings.grabSetting("name")
        tbxWaitTime.Text = SaviBot.GlobalSettings.grabSetting("waittime")
        'chkInterfaceType.SelectedItem = SaviBot.GlobalSettings.grabSetting("interfacetype") 
        cbxUsuario.SelectedItem = SaviUser.Predicates.grabSetting("user")
        tbxNickname.Text = SaviUser.Predicates.grabSetting("nickname")
        tbxCultureInfo.Text = SaviUser.Predicates.grabSetting("culture")
        cbxCity.Text = SaviUser.Predicates.grabSetting("city")
        tbxCoutry.Text = SaviUser.Predicates.grabSetting("coutry")

        ''check box
        chbxUserResponse.Checked = SaviUser.Predicates.grabSetting("userresponse")
        chbxMinimize.Checked = SaviUser.Predicates.grabSetting("minimizewin")
        chbxFaceReco.Checked = SaviUser.Predicates.grabSetting("facereconize")

    End Sub

    Sub SaveConfig()
        Try
            If cbxAvVoice.Text <> "" Then SaviBot.GlobalSettings.addSetting("voice", cbxAvVoice.Text)
            If TbxAvName.Text <> "" Then SaviBot.GlobalSettings.addSetting("name", TbxAvName.Text)
            If tbxWaitTime.Text <> "" Then SaviBot.GlobalSettings.addSetting("waittime", tbxWaitTime.Text)
            'If ChkInterfaceType.Text <> ""  Then Config .SystemConfig .Rows (0).Item (2) = chkInterfaceType.Text
            If cbxUsuario.Text <> "" Then SaviUser.Predicates.addSetting("user", cbxUsuario.Text)
            If cbxCity.Text <> "" Then SaviUser.Predicates.addSetting("city", cbxCity.Text)
            If tbxNickname.Text <> "" Then SaviUser.Predicates.addSetting("nickname", tbxNickname.Text)
            If tbxCultureInfo.Text <> "" Then SaviUser.Predicates.addSetting("culture", tbxCultureInfo.Text)
            If tbxCoutry.Text <> "" Then SaviUser.Predicates.addSetting("coutry", tbxCoutry.Text)


            SaviUser.Predicates.addSetting("userresponse", chbxUserResponse.Checked)
            SaviUser.Predicates.addSetting("minimizewin", chbxMinimize.Checked)
            SaviUser.Predicates.addSetting("facereconize", chbxFaceReco.Checked)



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
        SaviUser.Predicates.DictionaryAsXML.Save("application\Config\DefaultPredicates.xml")
        SaviBot.GlobalSettings.DictionaryAsXML.Save("application\Config\Settings.xml")
        SaviBot.loadSettings("application\Config\Settings.xml")
        SaviBot.GenderSubstitutions.DictionaryAsXML.Save("application\Config\GenderSubstitutions.xml")

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
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_text.MouseMove

        moverForm()
    End Sub




    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            SaveConfig()
            SaveFaceData()
            LoadSpeechConfig()
            SaveCommands()

            MsgBox("Datos Guardados", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message & ", verifique la configuración.", MsgBoxStyle.Exclamation)

        End Try
    End Sub


    Private Sub ViewComands_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ViewComands.CellClick
        If e.ColumnIndex = 2 And e.RowIndex >= 0 Then
            If ViewComands.AllowUserToAddRows = False Then Return
            frmEditor.txtTexto.Text = ViewComands.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Replace(" $ ", vbCrLf)
            frmEditor.ShowDialog()
            ViewComands.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ConvertLine(frmEditor.txtTexto.Text)
        End If
    End Sub


    Private Sub btnBorrarComando_Click(sender As Object, e As EventArgs) Handles btnBorrarComando.Click
        Try
            Commands.Comands.Rows(ViewComands.CurrentCellAddress.Y).Delete()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub LblConfig_Click(sender As Object, e As EventArgs) Handles LblConfig.Click
        TCConfig.SelectedTab = TpOpciones
        Me.BackgroundImage = My.Resources.Options1
        btn_text.Text = LblConfig.Text
    End Sub



    Private Sub LblComados_Click(sender As Object, e As EventArgs) Handles lblComandos.Click
        TCConfig.SelectedTab = TpComandos
        Me.BackgroundImage.Dispose()
        Me.BackgroundImage = My.Resources.Options2
        btn_text.Text = lblComandos.Text
    End Sub

    Private Sub LblPersonas_Click(sender As Object, e As EventArgs) Handles LblPersonas.Click
        TCConfig.SelectedTab = TpPersonas
        Me.BackgroundImage.Dispose()
        Me.BackgroundImage = My.Resources.Options3
        btn_text.Text = LblPersonas.Text
        ''
    End Sub

    Private Sub LblAcercaDe_Click(sender As Object, e As EventArgs) Handles LblAcercaDe.Click
        TCConfig.SelectedTab = TpAcercaDe
        Me.BackgroundImage.Dispose()
        Me.BackgroundImage = My.Resources.Options4
        btn_text.Text = LblAcercaDe.Text
    End Sub



    Private Sub BtnProbar_Click(sender As Object, e As EventArgs) Handles BtnProbar.Click
        If cbxAvVoice.Text <> "" Then
            silencio = False
            selectVoice(cbxAvVoice.Text)
            _speak("usted a elegido a " & cbxAvVoice.Text)
            silencio = True
        End If
    End Sub

    Private Sub BtnProbar_MouseHover(sender As Object, e As EventArgs) Handles BtnProbar.MouseHover
        Label13.Visible = True
    End Sub

    Private Sub BtnProbar_MouseLeave(sender As Object, e As EventArgs) Handles BtnProbar.MouseLeave
        Label13.Visible = False
    End Sub

    Private Sub btnCmdDefault_Click(sender As Object, e As EventArgs) Handles btnCmdDefault.Click
        ViewComands.DataSource = ComandsBindingSource
        ViewComands.AllowUserToAddRows = True
        ViewComands.AllowUserToDeleteRows = True
        ViewComands.ReadOnly = False

        lblComandAC.Text = "Comandos que puedes programar"
    End Sub

    Private Sub btnCmdSystem_Click(sender As Object, e As EventArgs) Handles btnCmdSystem.Click
        Dim Table As New DataTable
        Table.Columns.Add("Comando")
        For I As Integer = 0 To Commands_Default.Count - 1

            Table.Rows.Add(Commands_Default(I))
        Next
        ViewComands.DataSource = Table
        ViewComands.AllowUserToAddRows = False
        ViewComands.AllowUserToDeleteRows = False
        ViewComands.ReadOnly = True

        lblComandAC.Text = "Comandos basicos del sistema"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCmdSocial.Click
        Dim Table As New DataTable
        Table.Columns.Add("Comando")
        For I As Integer = 0 To commands_social.Count - 1

            Table.Rows.Add(commands_social(I))
        Next
        ViewComands.DataSource = Table
        ViewComands.AllowUserToAddRows = False
        ViewComands.AllowUserToDeleteRows = False
        ViewComands.ReadOnly = True

        lblComandAC.Text = "Comandos que puedes decir"
    End Sub

    Private Sub btnGuardar_MouseHover(sender As Object, e As EventArgs) Handles btnGuardar.MouseHover
        lblHover.Text = "Guardar"
        lblHover.Location = New Point(btnGuardar.Location.X - lblHover.Width - 2, btnGuardar.Location.Y)
    End Sub


    Private Sub btnGuardar_MouseLeave(sender As Object, e As EventArgs) Handles btnGuardar.MouseLeave
        lblHover.Text = ""
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnDonate.Click
        Process.Start("https://paypal.me/RonnyVillamar")
    End Sub


    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim MailSend As Mail.MailMessage
        Try
            MailSend = New Mail.MailMessage(tbxMail.Text, "syterox@gmail.com")
            MailSend.Subject = tbxSubject.Text
            MailSend.Body = tbxBody.Text
            MailSend.BodyEncoding = System.Text.Encoding.UTF8
            MailSend.IsBodyHtml = False
            MailSend.Priority = MailPriority.High

        Catch ex As Exception
            MsgBox("Error: Revise los datos de su correo," + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        Try

            If MailSend.To.Count > 0 Then

                Dim client As SmtpClient = New SmtpClient
                client.Credentials = New System.Net.NetworkCredential(tbxMail.Text, tbxPassword.Text)
                client.Port = 587
                client.EnableSsl = True
                client.Host = "smtp.live.com"
                client.Send(MailSend)
                MsgBox("Tu comentario ha sido enviado, gracias por tu colaboración.", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub tbxPassword_TextChanged(sender As Object, e As KeyEventArgs) Handles tbxPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSend.PerformClick()
        End If
    End Sub

    Private Sub btn_text_Click(sender As Object, e As EventArgs) Handles btn_text.Click

    End Sub
End Class