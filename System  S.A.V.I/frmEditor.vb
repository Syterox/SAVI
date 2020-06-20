Imports System.Threading
Imports ICSharpCode.TextEditor.Document
Imports ICSharpCode.TextEditor
Imports System.IO

Public Class frmEditor
    Dim CARACTER As Integer
    Dim curx As Integer
    Dim narchivo As String
    Dim lna_actual As Integer
    Dim _thread As Thread

    Private Sub frmEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fsmp As FileSyntaxModeProvider
        If My.Computer.FileSystem.DirectoryExists(frmCarga.StrApplication_Editor) Then


            fsmp = New FileSyntaxModeProvider(frmCarga.StrApplication_Editor)
            HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp)
            Dim cmd As String = txtTexto.Text

            If cmd.Substring(0, InStr(cmd, vbCrLf)).Contains("%vbscript%") = True Then
                txtTexto.SetHighlighting("VBNET")

            Else
                txtTexto.SetHighlighting("BAT")


            End If
            txtTexto.TextEditorProperties.Font = New Font("consolas", 11)
            txtTexto.Font = New Font("consolas", 11)

        End If
        ToolStripNameFile.Text = ""
        ubicación.Text = ""
        TmrLine.Start()
    End Sub
#Region "functions for editor"
    Private Function HaveSelection() As Boolean

        Return txtTexto.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected
    End Function

    Private Sub DoEditAction(editor As TextEditorControl, action As ICSharpCode.TextEditor.Actions.IEditAction)


        Dim area As TextArea = editor.ActiveTextAreaControl.TextArea
        editor.BeginUpdate()
        Try

            action.Execute(area)
            If (area.SelectionManager.HasSomethingSelected And area.AutoClearSelection) Then
                If (area.Document.TextEditorProperties.DocumentSelectionMode = DocumentSelectionMode.Normal) Then
                    area.SelectionManager.ClearSelection()
                End If
            End If

        Finally
            editor.EndUpdate()
            area.Caret.UpdateCaretPosition()
        End Try

    End Sub
#End Region


    Private Sub inicio_Close(sender As Object, e As EventArgs) Handles MyBase.FormClosed

        TmrLine.Stop()
    End Sub



    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        TmrLine.Stop()

        Me.Close()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButtonEjecutar.Click
        Dim cmd As String = txtTexto.Text

        If cmd.Substring(0, InStr(cmd, vbCrLf)).Contains("%vbscript%") = True Then
            _thread = exeCommand("VBScript", cmd)
        Else

            _thread = exeCommand("DOS", cmd)

        End If

    End Sub

    Private Sub ToolStripButtonPausar_Click(sender As Object, e As EventArgs) Handles ToolStripButtonPausar.Click
        _thread.Abort()
    End Sub



    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click

        ' configurar el cuadro de diálogo por código
        Me.dlgAbrir.Title = "Seleccionar archivo a leer"
        Me.dlgAbrir.Filter = "Archivos de código script (*.bat,*.vbs,*.txt)|*.bat;*.vbs;*.txt|Archivo Batch (*.bat)|*.bat|Visual Basic Script (*.vbs)|*.vbs|Texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        ' abrir el diálogo
        If dlgAbrir.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' si se han seleccionado varios archivos
            ' mostrar su nombre
            If Me.dlgAbrir.FileNames.Length > 1 Then
                Dim sArchivo As String
                For Each sArchivo In Me.dlgAbrir.FileNames
                    MessageBox.Show("Archivo seleccionado: " & sArchivo)
                Next
            End If
            ' abrir el primer archivo con un Stream
            ' y volcarlo al TextBox
            Dim srLector As New IO.StreamReader(Me.dlgAbrir.FileName)
            NuevoToolStripMenuItem.PerformClick()
            txtTexto.Text = srLector.ReadToEnd()
            srLector.Close()
            narchivo = dlgAbrir.SafeFileName
            ToolStripNameFile.Text = narchivo
            TSlblFile.Text = dlgAbrir.FileName

            Try
                Dim file As New FileInfo(TSlblFile.Text)
                If file.Extension = UCase(".vbs") Then
                    lbl_tipo.Text = "Archivo Visual Basic Script"
                    txtTexto.SetHighlighting("VBNET")
                ElseIf file.Extension = UCase(".bat") Then
                    lbl_tipo.Text = "Archivo Batch"
                    txtTexto.SetHighlighting("BAT")
                Else

                    lbl_tipo.Text = "Archivo de texto"
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub GuardarComoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarComoToolStripMenuItem.Click
        ' configurar por código el diálogo de grabación de archivos
        Me.dlggrabar.Filter = "Archivo Batch (*.bat)|*.bat|Visual Basic Script (*.vbs)|*.vbs|Texto (*.txt)|*.txt"
        Me.dlggrabar.FilterIndex = 1
        Me.dlggrabar.ValidateNames = True
        If dlggrabar.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' si todo es correcto, escribir mediante un objeto Stream
            ' el contenido del TextBox en el archivo indicado por
            ' las propiedades del cuadro de diálogo
            Dim swEscritor As IO.StreamWriter
            swEscritor = New IO.StreamWriter(Me.dlggrabar.FileName)
            swEscritor.Write(ToolStripNameFile.Text)
            swEscritor.Close()
            TSlblFile.Text = dlggrabar.FileName
            Dim file As New FileInfo(dlggrabar.FileName)
            ToolStripNameFile.Text = file.Name
            GuardarToolStripMenuItem.PerformClick()

        End If
    End Sub

    Private Sub SalirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub CerrarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CerrarToolStripMenuItem.Click
        txtTexto.Visible = False
    End Sub



    Private Sub FuentesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuentesToolStripMenuItem.Click
        Me.dlgfuente.ShowApply = True
        Me.dlgfuente.ShowDialog()
        Me.AplicarFuente()
    End Sub
    ' este método cambia el fuente del TextBox
    Private Sub AplicarFuente()
        txtTexto.Font = Me.dlgfuente.Font
        txtTexto.TextEditorProperties.Font = Me.dlgfuente.Font

    End Sub
    ' al pulsar el botón Aplicar del diálogo de
    ' selección de fuente, se produce este evento
    Private Sub dlgFuente_Apply(ByVal sender As Object, ByVal e As System.EventArgs) Handles dlgfuente.Apply
        Me.AplicarFuente()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click

    End Sub

    Private Sub ArchivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchivoToolStripMenuItem.Click

    End Sub

    Private Sub txtTexto_Load(sender As Object, e As EventArgs) Handles txtTexto.Load
        lbl_pos.Text = "Lin: " & txtTexto.AutoScrollPosition.X & _
                        " Col: " & txtTexto.AutoScrollPosition.Y
    End Sub

    Private Sub NumeroDeLineaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NumeroDeLineaToolStripMenuItem.Click
        If NumeroDeLineaToolStripMenuItem.Checked = True Then
            txtTexto.ShowLineNumbers = True
        Else
            txtTexto.ShowLineNumbers = False
        End If
    End Sub

    Private Sub CompilarF9ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompilarF9ToolStripMenuItem.Click
        ToolStripButtonEjecutar.PerformClick()
    End Sub

    Private Sub btn_abrir_Click(sender As Object, e As EventArgs) Handles btn_abrir.Click
        AbrirToolStripMenuItem.PerformClick()
    End Sub

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        GuardarToolStripMenuItem.PerformClick()
    End Sub

    Private Sub btn_gcomo_Click(sender As Object, e As EventArgs) Handles btn_gcomo.Click
        GuardarComoToolStripMenuItem.PerformClick()
    End Sub

    Private Sub DesacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesacerToolStripMenuItem.Click
        txtTexto.Undo()
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox1.Click
        txtTexto.Redo()
    End Sub

    Private Sub CortarCtrlXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CortarCtrlXToolStripMenuItem.Click
        If (HaveSelection()) Then _
            DoEditAction(txtTexto, New ICSharpCode.TextEditor.Actions.Cut())
    End Sub

    Private Sub CopiarCtrlCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarCtrlCToolStripMenuItem.Click
        If (HaveSelection()) Then _
                DoEditAction(txtTexto, New ICSharpCode.TextEditor.Actions.Copy())
    End Sub

    Private Sub PegarCtrlVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PegarCtrlVToolStripMenuItem.Click
        If (HaveSelection()) Then _
                DoEditAction(txtTexto, New ICSharpCode.TextEditor.Actions.Paste)
    End Sub

    Private Sub SeleccionarTodoCtrlAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarTodoCtrlAToolStripMenuItem.Click
        
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        txtTexto.Text = ""
    End Sub

    Private Sub RecientesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        If ubicación.Text.Length > 1 Then
            txtTexto.SaveFile(ubicación.Text)
        End If
    End Sub

    Private Sub TmrLine_Tick(sender As Object, e As EventArgs) Handles TmrLine.Tick
        If tbxDebug.Text <> debugText Then tbxDebug.Text = debugText
    End Sub
End Class