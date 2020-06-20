Imports System.IO
Imports System.Runtime

Module ScriptSavi
    Dim prcDOS As New Process
    Dim siDOS As New ProcessStartInfo
    Dim srInput As StreamWriter
    Dim srOutput As StreamReader
    Dim tbx As New TextBox
    Dim vbsBasicScript As String = "'basic function for S.A.V.I. Project (c)Ronny Villamar 2017" & vbCrLf &
                                    "Set objVoice = CreateObject(" & Chr(34) & "SAPI.SpVoice" & Chr(34) & ")" & vbCrLf &
                                    "for each i in objVoice.getvoices" & vbCrLf &
                                    "   if instr(i.getdescription," & Chr(34) & "%voice%" & Chr(34) & ")<> 0 then" & vbCrLf &
                                    "       set objvoice.voice = i" & vbCrLf &
                                    "   end if" & vbCrLf &
                                    "Next" & vbCrLf &
                                    "Sub speak(str)" & vbCrLf &
                                    "   objvoice.speak(Str)" & vbCrLf &
                                    "End Sub" & vbCrLf

    '' comandos variables 
    Dim strFuncs() As String = {"speak", "math", "dim", "msgbox", "set", "port.read", "port.write"}
    Dim strTypes() As String = {"integer", "string", "double", "long"}
    Dim strAssing() As String = {"=", "+=", "*=", "-=", "/="}
    Dim strBasicOperator() As Char = {"+", "*", "-", "/", "^"}
    Dim strAdvancedOperators() As String = {"cos", "sen", "tan", "mod"}
    Dim strNums() As Char = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}

    Dim portHandler As Ports.SerialPort = New Ports.SerialPort

    Public types As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public variables As Dictionary(Of String, Object) = New Dictionary(Of String, Object)

    Public debugText As String

#Region "Execute DOS Scripts"
    Private Sub initDOSProcess()

        siDOS.FileName = "cmd"

        siDOS.UseShellExecute = False
        siDOS.CreateNoWindow = True
        siDOS.Arguments = " /k @echo off"
        siDOS.RedirectStandardInput = True
        siDOS.RedirectStandardOutput = True

        prcDOS.StartInfo = siDOS
        prcDOS.Start()

        srInput = prcDOS.StandardInput
        srOutput = prcDOS.StandardOutput

    End Sub
    Public Function DOS(strC As String) As String
        Dim ret As String
        Dim comando As String = strC

        comando = LCase(comando)

        ''cargar las variabes 
        LoadVar()

        initDOSProcess()

        tbx.Text = comando.Replace(" $ ", vbCrLf)
        Dim lineas() As String = tbx.Lines
        Dim countL As Integer = lineas.Count
        Dim linea As String = ""

        ''lee cada linea y la ejecuta
        For I As Integer = 0 To countL - 1
            Dim linecmd() As String = {""} '' array para almacear cada palabra 
            linea = lineas(I) ''linea actual
            linecmd = linea.Split(New Char() {" "}) ''  separa cada palabra para ejcutar
            Try
                '' ejecucion de comandos
                If linea = "" Then Continue For

                srInput.WriteLine(DefaultSaviScript(linecmd(0), linea)) '' ejecuta los scripts basicos

            Catch ex As Exception
                '' imprime el error
                writeDebug("Error:" & ex.Message & vbCrLf &
                                  "lin:" & I + 1)

                MsgBox("Error:" & ex.Message & vbCrLf &
                                  "lin:" & I + 1) '' s

                Exit For
            End Try

        Next
        ''lee todo el buffer de retorno
        srInput.WriteLine("exit")
        ret = srOutput.ReadToEnd
        ''finaliza el proceso
        endDOSRead()
        ''ingresa los datos en el textbox
        writeDebug(ret)

        Return vbCrLf & ret & vbCrLf
    End Function

    Private Sub endDOSRead()
        srInput.Close()
        srOutput.Close()
    End Sub

    Sub writeDebug(ret As String)
        debugText = debugText & ">" & strCommandRec & vbCrLf & ret & vbCrLf

    End Sub

    Private Function DefaultSaviScript(Comm As String, params As String) As String

        params = GetScriptVal(params)
        params = params.Replace("'", "")
        params = params.Replace(Chr(34), "")

        Dim strVar As String() = params.Split(New Char() {" ", "="})
        Dim strVal As String() = params.Split(New Char() {"="})
        Dim variable As String = strVar(0).TrimEnd(" ")
        Dim value As String = ""

        If strVal.Count > 1 Then value = strVal(1)

        If strFuncs.Contains(strVar(1)) Then Comm = strVar(1)


        '' verifica si existen los operadores basicos
        If value.Contains("%math%") Then
            value = MathOperant(value.Replace("%math%", "")).Replace(".", ",") ''calcula las opraciones matematicas
            '' si no hay 0al inicio del decimal
            If value.Chars(0) = "," Or value.Chars(1) = "," _
                And (value.Chars(0) = "+" Or value.Chars(0) = "-") Then value = value.Replace(",", "0,")

        End If


        ''
        If strVal.Count > 1 And variable <> Comm And Not strFuncs.Contains(strVar(1)) Then
            If getVariable(variable) = "" Then Throw New Exception("'" + variable + "' no esta declarado.")

            setVariable(variable, value)

            Return "set " + variable + " = " + value
        End If

        Select Case Comm
            Case "speak"
                Dim textSpk As String = params.Replace("speak", "")
                silencio = False
                _speak(textSpk)
                Return textSpk
            Case "set"
                Dim variableToSet As String = params.Split(New Char() {" ", "="})(1)

                setVariable(variableToSet, value)

                Return params
            Case "dim"
                Dim variableToSet As String = strVar(1)
                Dim type As String = strVar(3)

                If strTypes.Contains(type) = False Then Throw New Exception("No esta definido el tipo '" + type + "'.")

                setVariable(variableToSet, value, type)

                Return "set " + variable + " = " + value
            Case "msgbox"
                Dim msgSpl As String() = params.Split(New Char() {","})
                Dim promt As String = msgSpl(0).Replace(Comm, "")
                Dim buttons As Integer = "1"
                Dim title As String = "System S.A.V.I."

                If msgSpl.Count > 1 Then
                    buttons = msgSpl(1)
                    title = msgSpl(2)
                End If

                MsgBox(promt, buttons, title)

                Return promt
            Case "port.write"

                Return SerialPortWrite(Comm, params)
            Case "port.read"

                Return SerialPortRead(Comm, params)
            Case Else
                Return params
        End Select

    End Function


    Function SerialPortWrite(c As String, params As String) As String
        Dim portSpl As String() = params.Split(New Char() {","})
        Dim portname As String = portSpl(0).Replace(c, "")
        Dim data As Integer = 1

        If portSpl.Count > 1 Then
            data = portSpl(1)
        End If

        ''MsgBox("" & portname & " " & data)

        portHandler.PortName = portname.Replace(" ", "") ''quitamos los espacios
        portHandler.Open()

        portHandler.Write(data)
        portHandler.Close()
        Return "writing port " + portname
    End Function

    Function SerialPortRead(c As String, params As String)
        Dim variable As String = params.Split(New Char() {"="})(0)
        Dim value As String = params.Split(New Char() {"="})(1)
        Dim portSpl As String() = value.Split(New Char() {","})
        Dim portname As String = ""
        Dim offset As Integer = 0
        Dim count As Integer = 0
        Dim data As String = ""
        Dim result As Integer = 0
        ''cierra el puerto
        portHandler.Close()

        portname = portSpl(0).Replace(c, "")


        ''MsgBox(variable + " " + c + " " + portname + " " + offset.ToString + " " + count.ToString)
        ''asigna el nombre del puerto
        portHandler.PortName = portname.Replace(" ", "") ''quitamos los espacios
        portHandler.Open()
        '' lee el buffer de entrada del puerto
        portHandler.Read(data, offset, 1024)

        result = data

        ''cierra el puerto
        portHandler.Close()
        setVariable(variable, result)

        Return "reading port " + portname
    End Function
#End Region

#Region "Commnads Script"
    Sub setVariable(variable As String, value As Object)
        If value = "" Then value = " "
        If types.ContainsKey(variable) = False Then types.Add(variable, "object")
        If variables.ContainsKey(variable) = True Then
            variables.Item(variable) = value
        Else
            variables.Add(variable, value)
        End If
        Environment.SetEnvironmentVariable(variable, value)
    End Sub

    Sub setVariable(variable As String, value As Object, type As String)
        If value = "" Then value = " "
        If types.ContainsKey(variable) = False Then types.Add(variable, type)

        If variables.ContainsKey(variable) = True Then
            variables.Item(variable) = value
        Else
            variables.Add(variable, value)
        End If
        Environment.SetEnvironmentVariable(variable, value)
    End Sub

    Function getVariable(variable As String) As Object
        Return Environment.GetEnvironmentVariable(variable)
    End Function

    Sub LoadVar()
        '' asigna las variables  
        setVariable("nickname", strUserNickname)
        setVariable("avname", strAvName)
        setVariable("voice", strSaviVoiceName)
        setVariable("strPerson", strPerson)
        setVariable("nperson", frmInicio.lbl_npersv.Text)
        setVariable("persons", frmInicio.lbl_persv.Text)
    End Sub

    Function GetScriptVal(str As String) As String
        ''asigna las variables del sistema 

        If InStr(str, "%") > 0 Then

            Dim variables As IDictionary = Environment.GetEnvironmentVariables
            Dim valCount As Integer = variables.Count

            For i As Integer = 0 To variables.Count - 1
                str = str.Replace("%" + variables.Keys(i).ToString + "%", getVariable(variables.Keys(i).ToString))
            Next

        End If

        Return str
    End Function
    ''////////////////////////////////////////////////////
    ''
    '' operaciones matematicas con textos
    ''
    ''////////////////////////////////////////////////////
    Function MathOperant(str As String) As String
        Dim initCalcPos As Integer = 0
        Dim endCalPos As Integer = 0
        Dim strNum As String = ""
        Dim strNumRes As String = ""
        Dim op As String = ""
init:
        If str.Contains("sen") Then
            op = "sen"
        ElseIf str.Contains("cos") Then
            op = "cos"
        ElseIf str.Contains("tan") Then
            op = "tan"
        End If
        '' si hay operador matematico
        If op <> "" Then
            Dim initParent As Integer = 0

            initCalcPos = InStr(str, op) '' inicio de la cadena

            initParent = InStr(Mid(str, initCalcPos), "(") '' inicio del parentesis

            endCalPos = InStr(Mid(str, initParent + initCalcPos), ")") '' inicio del parentesis

            strNum = Mid(str, initParent + initCalcPos, endCalPos - 1) '' recorta la cadena para calcular


            Select Case op
                Case "sen"
                    strNumRes = Math.Sin(Evaluar("1*" & strNum))
                Case "cos"
                    strNumRes = Math.Cos(Evaluar("1*" & strNum))
                Case "tan"
                    strNumRes = Math.Tan(Evaluar("1*" & strNum))

            End Select

            If strNumRes <> 0 And strNumRes.Count > 5 Then strNumRes = strNumRes.Substring(0, strNumRes.IndexOf(".") + 5)

            str = str.Replace(Mid(str, initCalcPos, initParent + endCalPos), "(" & strNumRes & ")")

        End If
        If str.Contains("sen") Or str.Contains("cos") Or str.Contains("tan") Then
            GoTo init
        End If

        Return Evaluar(str)
    End Function

    Function Evaluar(ByVal Txt As String) As String
        Dim i As Integer, oNB As Integer, fNB As Integer
        Dim P1 As Integer, P2 As Integer
        Dim Buff As String
        Dim T As String
        'Para los calculos es necesario un punto en lugar de la coma  
        Txt = Replace(Txt, ",", ".")
        'Ver si hay (  
        For i = 1 To Len(Txt)
            If Mid(Txt, i, 1) = "(" Then oNB = oNB + 1
        Next i
        'Si hay ( (abiertos), ver si concuerdan) (cerrados)  
        If oNB > 0 Then
            For i = 1 To Len(Txt)
                If Mid(Txt, i, 1) = ")" Then fNB = fNB + 1
            Next i
        Else
            'No hay parentesis, Evalua directamente el calculo  
            Evaluar = EvalueExpression(Txt)
            Exit Function
        End If
        If oNB <> fNB Then
            'Los parentesis no concuerdan, mostrar mensaje de error de parentesis  
            Throw New Exception("Se esperaba ')'")

            Exit Function
        End If

        While oNB > 0
            'busca el ultimo parentesis abierto  
            P1 = InStrRev(Txt, "(")
            'Busca el parentesis que cierra la expresion  
            P2 = InStr(Mid(Txt, P1 + 1), ")")
            'Evalua la expresion que esta entre parentesis  
            Buff = EvalueExpression(Mid(Txt, P1 + 1, P2 - 1))
            'Reemplazar la expresion con el resultado y eliminar los parentesis  
            Txt = Left(Txt, P1 - 1) & Buff & Mid(Txt, P1 + P2 + 1)
            oNB = oNB - 1
        End While
        'no mas parentesis, evaluar la ultima expresion  
        Evaluar = EvalueExpression(Txt)

    End Function
    Function EvalueExpression(A As String) As String
        Dim T As Integer, S As Integer
        Dim i As Integer, C As Boolean
        Dim c1 As Double, c2 As Double, Signe As Integer
        Dim R As String, Fin As Boolean

        'quitar los espacios  
        A = Replace(A, " ", "")


        While Not Fin
            For i = 1 To Len(A)
                T = Asc(Mid(A, i, 1))
                If T < 48 And T <> 46 Or i = Len(A) Or T = 94 Then
                    If C Then 'evalua  
                        If i = Len(A) Then
                            c2 = Val(Mid(A, S))
                        Else
                            c2 = Val(Mid(A, S, i - S))
                        End If
                        R = Str(CalculSimple(c1, c2, Signe))
                        If i = Len(A) Then
                            Fin = True
                        Else
                            A = Trim(R & Mid(A, i))
                            C = False
                        End If
                        Exit For
                    Else 'separa la 1ra cifra  
                        c1 = Val(Left(A, i - 1))
                        Signe = T
                        S = i + 1
                        C = True
                    End If
                End If
            Next i
        End While
        'reemplazar la expresión con el resultado  
        EvalueExpression = Trim(R)
    End Function
    Function CalculSimple(n1 As Double, n2 As Double, Signe As Integer) As Double
        Select Case Signe
            Case 43 ' +  
                CalculSimple = n1 + n2
            Case 45 ' -  
                CalculSimple = n1 - n2
            Case 42 ' *  
                CalculSimple = n1 * n2
            Case 47 ' /  
                CalculSimple = n1 / n2
            Case 94 ' ^
                CalculSimple = n1 ^ n2
            Case Else
                If n2 <> 0 Then
                    CalculSimple = Val(IIf(Signe < 48, Signe & n2, n2))
                ElseIf n1 <> 0 Then
                    CalculSimple = n1
                Else
                    CalculSimple = n1
                End If
                'Aquí, agregar otro calculo...  
        End Select
    End Function
#End Region

#Region "Execute VBScript"

    Public Function VBScript(strC As String) As String
        Dim Archivo As String = frmCarga.StrSystem_commands_file
        Dim comando As String = strC.ToLower.Replace("%vbscript%", "").Replace(" $ ", vbCrLf)

        If Directory.Exists("C:\Windows\SysWOW64") = False Then '' si el pc no es de 64 bits
            Return VBSHost(comando)

        End If

        If comando.Contains("%") Then
            comando = GetScriptVal(comando)
        End If

        ' remplaza vbscript
        ScriptSavi.tbx.Text = ScriptSavi.vbsBasicScript.Replace("%voice%", speech.strSaviVoiceName) + comando

        File.WriteAllText(Archivo, ScriptSavi.tbx.Text)

        ScriptSavi.initDOSProcess()

        ScriptSavi.srInput.WriteLine("wscript """ + Archivo + """")
        ScriptSavi.srInput.WriteLine("exit")

        Dim ret As String = ScriptSavi.srOutput.ReadToEnd()
        ScriptSavi.endDOSRead()
        'ventana debbugger
        writeDebug(ret)
        Return ret
    End Function

    Public Function VBSHost(code As String) As String
        Dim host As MSScriptControl.ScriptControl
        Try


            host = New MSScriptControl.ScriptControl

            host.Language = "vbscript"
            host.AddCode(vbsBasicScript.Replace("%voice%", speech.strSaviVoiceName))
            LoadVar()

            For i As Integer = 0 To variables.Count - 1
                host.AddObject(variables.Keys(i), variables.Values(i))

            Next
            host.AllowUI = True
            host.AddCode(code)
            host.Run("", {})

        Catch ex As Exception
            writeDebug(ex.Message)
            Return ex.Message
        End Try
        writeDebug("Ejecucion terminada.")
    End Function

#End Region

#Region "Execute VB Code"

#End Region

End Module
