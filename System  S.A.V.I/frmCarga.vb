Imports System.IO
Imports System.Runtime

Public Class frmCarga

    Public StrSystem As String = Application.StartupPath & "\System"
    Public StrSystem_memory As String = Application.StartupPath & "\System\Memmory"
    Public StrSystem_faces As String = Application.StartupPath & "\System\Faces"
    Public StrSystem_commands As String = Application.StartupPath & "\System\Commands"
    Public StrSystem_commands_file As String = Application.StartupPath & "\System\Commands\CommandTemp.vbs"
    Public StrSystem_memory_file As String = Application.StartupPath & "\System\Memmory\Memmory.xml"
    Public StrSystem_botbrain_file As String = Application.StartupPath & "\System\Memmory\SaviBotDefault.bin"
    Public StrSystem_botbrain_files As String = Application.StartupPath & "\System\Memmory\"
    Public StrSystem_file As String = Application.StartupPath & "\System\SystemCommands.xml"
    Public StrApplication As String = Application.StartupPath & "\Application\"
    Public StrApplication_config As String = Application.StartupPath & "\Application\Config"
    Public StrApplication_images As String = Application.StartupPath & "\Application\Images"
    Public StrApplication_Editor As String = Application.StartupPath & "\Application\Editor"


    Sub form_load(ByVal o As Object, e As EventArgs) Handles Me.Load
        ProgressBar1.Value += 2
        '' verifica si los directorios existen
        If Directory.Exists(StrSystem) = False Then
            '' crea el directorio
            Directory.CreateDirectory(StrSystem)
        End If
        ProgressBar1.Value += 2 '' aumenta la barra de progreso con cada proceso realizado

        If Directory.Exists(StrSystem_memory) = False Then
            Directory.CreateDirectory(StrSystem_memory)
        End If
        ProgressBar1.Value += 2 '' aumenta la barra de progreso con cada proceso realizado

        If Directory.Exists(StrSystem_commands) = False Then
            Directory.CreateDirectory(StrSystem_commands)
        End If
        ProgressBar1.Value += 2 '' aumenta la barra de progreso con cada proceso realizado

        If Directory.Exists(StrSystem_faces) = False Then
            Directory.CreateDirectory(StrSystem_faces)
        End If
        ProgressBar1.Value += 2 '' aumenta la barra de progreso con cada proceso realizado

        '' 
        '' Aplication
        '' 
        If Directory.Exists(StrApplication) = False Then
            Directory.CreateDirectory(StrApplication)
        End If

        ProgressBar1.Value += 2
        If Directory.Exists(StrApplication_config) = False Then
            Directory.CreateDirectory(StrApplication_config)
        End If

        ProgressBar1.Value += 2
        If Directory.Exists(StrApplication_images) = False Then
            Directory.CreateDirectory(StrApplication_images)
        End If

        ProgressBar1.Value += 2

        If Directory.Exists(StrApplication_Editor) = False Then
            Directory.CreateDirectory(StrApplication_Editor)
        End If

        ProgressBar1.Value += 2
        
        ''
        '' MEMORY FILE , ARCHIVOS DE MEMORIA
        ''

        If File.Exists(StrSystem_memory_file) = False Then
            File.Create(StrSystem_memory_file).Close()
            frmMemory.Memory.WriteXml(StrSystem_memory_file)

        End If
        ProgressBar1.Value += 2

        If File.Exists(StrSystem_file) = False Then
            File.Create(StrSystem_file).Close()
            frmMemory.Commands.WriteXml(StrSystem_file)

        End If
        ProgressBar1.Value += 2




        '' filalice
        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value += (100 - ProgressBar1.Value)
        End If
    End Sub


End Class