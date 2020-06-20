Imports System.Net
Imports System.Xml
Imports System.Xml.Linq
Imports agsXMPP
Imports agsXMPP.Collections
Imports agsXMPP.protocol.client
Imports Newtonsoft.Json
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows

Namespace savi.WebControl
    Class SearchControl

        Private condicionB As Boolean

        Private google As Boolean

        Private youtube As Boolean

        Private yahoo As Boolean

        Private wikipedia As Boolean

        Private facebook As Boolean

        Private twitter As Boolean

        Private nuevaFraseB As String
        '' realiza una pre busqueda en internet

        Private Sub PreSearchWeb(speech As String)
            Dim palabraDescompuesta As String() = speech.Split(New Char() {" "c})
            Dim contadorPalabra As Integer = palabraDescompuesta.Length
            Dim contador As Integer = 0
            Dim array As String() = palabraDescompuesta
            For i As Integer = 0 To array.Length - 1
                Dim palabra As String = array(i)
                If palabra = "buscar" Then
                    palabraDescompuesta(contador) = ""
                    Me.condicionB = True
                ElseIf palabra = "en" Then
                    palabraDescompuesta(contador) = ""
                ElseIf palabra = "google" Then
                    palabraDescompuesta(contador) = ""
                    Me.google = True
                ElseIf palabra = "youtube" Then
                    palabraDescompuesta(contador) = ""
                    Me.youtube = True
                ElseIf palabra = "facebook" Then
                    palabraDescompuesta(contador) = ""
                    Me.facebook = True
                ElseIf palabra = "wikipedia" Then
                    palabraDescompuesta(contador) = ""
                    Me.wikipedia = True
                ElseIf palabra = "yahoo" Then
                    palabraDescompuesta(contador) = ""
                    Me.yahoo = True
                ElseIf palabra = "twitter" Then
                    palabraDescompuesta(contador) = ""
                    Me.twitter = True
                ElseIf contador = contadorPalabra - 1 AndAlso Not Me.twitter AndAlso Not Me.yahoo AndAlso Not Me.wikipedia AndAlso Not Me.facebook AndAlso Not Me.youtube AndAlso Not Me.google Then
                    Return
                End If
                contador += 1
            Next
            If Me.condicionB AndAlso Me.google Then
                Dim array2 As String() = palabraDescompuesta
                For j As Integer = 0 To array2.Length - 1
                    Dim nuevapalabra As String = array2(j)
                    If nuevapalabra <> "" Then
                        Me.nuevaFraseB = Me.nuevaFraseB + " " + nuevapalabra
                    End If
                Next
                Process.Start("https://www.google.com.ec/search?q=" + Me.nuevaFraseB)
                SpeakAsyncCancell("buscando" + Me.nuevaFraseB + " en google ")
            ElseIf Me.condicionB AndAlso Me.youtube Then
                Dim array3 As String() = palabraDescompuesta
                For k As Integer = 0 To array3.Length - 1
                    Dim nuevapalabra2 As String = array3(k)
                    If nuevapalabra2 <> "" Then
                        Me.nuevaFraseB = Me.nuevaFraseB + " " + nuevapalabra2
                    End If
                Next
                Process.Start("http://www.youtube.com/results?search_query=" + Me.nuevaFraseB)
                SpeakAsyncCancell("buscando" + Me.nuevaFraseB + " en youtube ")
            ElseIf Me.condicionB AndAlso Me.wikipedia Then
                Dim array4 As String() = palabraDescompuesta
                For l As Integer = 0 To array4.Length - 1
                    Dim nuevapalabra3 As String = array4(l)
                    If nuevapalabra3 <> "" Then
                        Me.nuevaFraseB = Me.nuevaFraseB + " " + nuevapalabra3
                    End If
                Next
                Process.Start("http://es.wikipedia.org/wiki/" + Me.nuevaFraseB)
                SpeakAsyncCancell("buscando" + Me.nuevaFraseB + "en wikipedia ")
            ElseIf Me.condicionB AndAlso Me.yahoo Then
                Dim array5 As String() = palabraDescompuesta
                For m As Integer = 0 To array5.Length - 1
                    Dim nuevapalabra4 As String = array5(m)
                    If nuevapalabra4 <> "" Then
                        Me.nuevaFraseB = Me.nuevaFraseB + " " + nuevapalabra4
                    End If
                Next
                Process.Start("http://espanol.search.yahoo.com/search;_ylt=A86.Jo7py_JSL0QAb0tUcbt_;_ylc=X1MDMjE0Mjk5MDY3NgRfcgMyBGZyA3lmcC10LTcyNgRuX2dwcwMxMARvcmlnaW4DZXNwYW5vbC55YWhvby5jb20EcXVlcnkDbXVqZXJlcwRzYW8DMQ--?p=" + Me.nuevaFraseB)
                SpeakAsyncCancell("buscando" + Me.nuevaFraseB + "en yahoo ")
            ElseIf Me.condicionB AndAlso Me.facebook Then
                Dim array6 As String() = palabraDescompuesta
                For n As Integer = 0 To array6.Length - 1
                    Dim nuevapalabra5 As String = array6(n)
                    If nuevapalabra5 <> "" Then
                        Me.nuevaFraseB = Me.nuevaFraseB + " " + nuevapalabra5
                    End If
                Next
                Process.Start("https://www.facebook.com/search/results.php?q=" + Me.nuevaFraseB)
                SpeakAsyncCancell("buscando" + Me.nuevaFraseB + "en faisbuc ")
            Else
                If Not Me.condicionB OrElse Not Me.twitter Then
                    Return
                End If
                Dim array7 As String() = palabraDescompuesta
                For num As Integer = 0 To array7.Length - 1
                    Dim nuevapalabra6 As String = array7(num)
                    If nuevapalabra6 <> "" Then
                        Me.nuevaFraseB = Me.nuevaFraseB + " " + nuevapalabra6
                    End If
                Next
                Process.Start("https://twitter.com/search?q=" + Me.nuevaFraseB)
                SpeakAsyncCancell("buscando" + Me.nuevaFraseB + "en twitter ")
            End If
            Me.condicionB = False
            Me.google = False
            Me.youtube = False
            Me.yahoo = False
            Me.wikipedia = False
            Me.facebook = False
            comandoEjec = True
            Me.nuevaFraseB = ""
        End Sub

    End Class
    Class Weather

        Private Temperature As String

        Private Condition As String

        Private Humidity As String

        Private WinSpeed As String

        Private Town As String

        Private TFCond As String

        Private TFHigh As String

        Private TFLow As String

        Public Function GetWeather() As String
            Try
                Dim query As String = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + SaviUser.Predicates.grabSetting("coutry") + "%2C%20" + getCityS(SaviUser.Predicates.grabSetting("city")) + "%22)and%20u%3D'c'&diagnostics=true&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys"
                Dim wData As XmlDocument = New XmlDocument()
                wData.Load(query)
                Dim man As XmlNamespaceManager = New XmlNamespaceManager(wData.NameTable)
                man.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0")
                Dim channel As XmlNode = wData.SelectSingleNode("query").SelectSingleNode("results").SelectSingleNode("channel")
                wData.SelectNodes("/results/channel/item/yweather:forecast", man)
                Me.Temperature = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", man).Attributes("temp").Value
                Me.Condition = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", man).Attributes("text").Value
                Me.Humidity = channel.SelectSingleNode("yweather:atmosphere", man).Attributes("humidity").Value
                Me.WinSpeed = channel.SelectSingleNode("yweather:wind", man).Attributes("speed").Value
                Me.Town = channel.SelectSingleNode("yweather:location", man).Attributes("city").Value
                Me.TFCond = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", man).Attributes("text").Value
                Me.TFHigh = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", man).Attributes("high").Value
                Me.TFLow = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", man).Attributes("low").Value
                If Me.TFCond = "Partly Cloudy" OrElse Me.TFCond = "Mostly Cloudy" Then
                    Me.TFCond = "Parcialmente nublado"
                End If
                If Me.TFCond = "Cloudy" Then
                    Me.TFCond = "Nublado"
                End If
                If Me.TFCond = "Sunny" Then
                    Me.TFCond = "Soleado"
                End If
                If Me.TFCond = "Fair" OrElse Me.TFCond = "Mostly Clear" Then
                    Me.TFCond = "Despejado"
                End If
                If Me.TFCond = "Mostly Sunny" Then
                    Me.TFCond = "Mayormente soleado"
                End If
                If Me.TFCond = "Light Drizzle" Then
                    Me.TFCond = "Llovizna ligera"
                End If
                If Me.Condition = "Partly Cloudy" OrElse Me.Condition = "Mostly Cloudy" Then
                    Me.Condition = "Parcialmente nublado"
                End If
                If Me.Condition = "Cloudy" Then
                    Me.Condition = "Nublado"
                End If
                If Me.Condition = "Sunny" Then
                    Me.Condition = "Soleado"
                End If
                If Me.Condition = "Fair" Then
                    Me.Condition = "Despejado"
                End If
                If Me.Condition = "Mostly Sunny" Then
                    Me.Condition = "Mayormente soleado"
                End If
                If Me.Condition = "Showers" Then
                    Me.Condition = "Lluvioso"
                End If
                Return "el clima"
            Catch ex_372 As Exception

                Return "error: " + ex_372.Message
            End Try
        End Function

        Public Function getCondition() As String

            Return Condition
        End Function

        Public Function getTemperature() As String
            Return Temperature
        End Function

        Public Function getTFCond() As String
            Return TFCond
        End Function

        Public Function getTFHigh() As String
            Return TFHigh
        End Function

        Public Function getTown() As String
            Return Town
        End Function

        Public Function getTFLow() As String
            Return TFLow
        End Function

        Public Function getHumidity() As String
            Return Humidity
        End Function

        Public Function getWinSpeed() As String
            Return WinSpeed
        End Function

    End Class

    Friend Class FacebookChatClient
        Private _contacts As System.Collections.Generic.Dictionary(Of String, FacebookUser) = New System.Collections.Generic.Dictionary(Of String, FacebookUser)()

        Private _loggedIn As Boolean

        Private _clientNick As String = String.Empty

        Private wc As WebClient = New WebClient()

        Private xcc As XmppClientConnection

        Public OnUserAdded As System.Action(Of FacebookUser)

        Public OnUserRemoved As System.Action(Of FacebookUser)

        Public OnMessageReceived As Action(Of Message, FacebookUser)

        Public OnLoginResult As System.Action(Of Boolean)

        Public OnLogout As Action

        Public OnUserIsTyping As System.Action(Of FacebookUser)

        Public ReadOnly Property Contacts() As System.Collections.Generic.Dictionary(Of String, FacebookUser)
            Get
                Return Me._contacts
            End Get
        End Property

        Public ReadOnly Property LoggedIn() As Boolean
            Get
                Return Me._loggedIn
            End Get
        End Property

        Public ReadOnly Property ClientNick() As String
            Get
                Return Me._clientNick
            End Get
        End Property

        Public Sub Login(nick As String, pass As String)
            If Not Me._loggedIn Then
                Try
                    Me.xcc = New XmppClientConnection("chat.facebook.com")
                    AddHandler Me.xcc.OnPresence, AddressOf Me.UpdateUserList
                    AddHandler Me.xcc.OnLogin, AddressOf Me.OnLogin
                    Me.xcc.Open(nick, pass)
                Catch ex_55 As Exception
                    If Me.OnLoginResult IsNot Nothing Then
                        Me.OnLoginResult(False)
                    End If
                End Try
            End If
        End Sub

        Public Sub SendMessage(msg As String, receiverName As String)
            Me.xcc.Send(New Message(New Jid(Me._contacts.First(Function(x As System.Collections.Generic.KeyValuePair(Of String, FacebookUser)) x.Value.name = receiverName).Key), MessageType.chat, msg))
        End Sub

        Public Sub Logout()
            Me.xcc.Close()
            Me._loggedIn = False
            Me.OnLogout()
        End Sub

        Private Sub UpdateUserList(sender As Object, pres As Presence)
            Try
                Dim strUserName As FacebookUser = Me.GetUser(pres.From.User)
                strUserName.jid = pres.From.Bare
                If pres.Type = PresenceType.available AndAlso Not Me.Contacts.ContainsKey(pres.From.Bare) Then
                    Me.Contacts.Add(pres.From.Bare, strUserName)
                    Me.xcc.MessageGrabber.Add(New Jid(pres.From.Bare), New BareJidComparer(), AddressOf Me.MessageReceived, Nothing)
                    If Me.OnUserAdded IsNot Nothing Then
                        Me.OnUserAdded(strUserName )
                    End If
                ElseIf pres.Type = PresenceType.unavailable AndAlso Me.Contacts.ContainsKey(pres.From.Bare) Then
                    Me.xcc.MessageGrabber.Remove(New Jid(pres.From.Bare))
                    Me.Contacts.Remove(pres.From.Bare)
                    If Me.OnUserRemoved IsNot Nothing Then
                        Me.OnUserRemoved(Me.GetUser(pres.From.User))
                    End If
                End If
            Catch ex_124 As System.Exception
                MessageBox.Show("se ha perdido la conexion con el chat del facebook")
            End Try
        End Sub

        Private Function GetUser(ID As String) As FacebookUser
            ID = ID.Replace("-", String.Empty)
            Dim jsonResponse As String = Me.wc.DownloadString("https://graph.facebook.com/" + ID)
            Return JsonConvert.DeserializeObject(Of FacebookUser)(jsonResponse)
        End Function

        Private Sub OnLogin(sender As Object)
            Me._loggedIn = True
            If Me.OnLoginResult IsNot Nothing Then
                Me.OnLoginResult(True)
            End If
            AddHandler Me.xcc.OnPresence, AddressOf Me.UpdateUserList
            Dim p As Presence = New Presence(ShowType.chat, "Online")
            p.Type = PresenceType.available
            Me.xcc.Send(p)
        End Sub

        Private Sub MessageReceived(sender As Object, msg As Message, data As Object)
            If String.IsNullOrEmpty(msg.Body) AndAlso Me.OnUserIsTyping IsNot Nothing Then
                Me.Contacts(msg.From.Bare).isTyping = Not Me.Contacts(msg.From.Bare).isTyping
                Me.OnUserIsTyping(Me.Contacts(msg.From.Bare))
                Return
            End If
            If Me.OnMessageReceived IsNot Nothing Then
                Me.Contacts.First(Function(contact As System.Collections.Generic.KeyValuePair(Of String, FacebookUser)) contact.Key = msg.From.Bare).Value.isTyping = False
                Me.OnMessageReceived(msg, Me.Contacts.First(Function(contact As System.Collections.Generic.KeyValuePair(Of String, FacebookUser)) contact.Key = msg.From.Bare).Value)
            End If
        End Sub
    End Class

    Public Class FacebookUser
        Public isTyping As Boolean

        Public Property jid() As String

        Public Property id() As String

        Public Property name() As String

        Public Property first_name() As String

        Public Property last_name() As String

        Public Property username() As String

        Public Property gender() As String

        Public Property locale() As String
    End Class
End Namespace


