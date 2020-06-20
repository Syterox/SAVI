Imports AIMLbot.Utils
Imports System.Net
Imports System.Xml
Imports System.Text

Module AMLTags
    ''' <summary>
    ''' Uses BBC's rss feed to display the latest headlines. If the attribute "description" has the value
    ''' "true" will also output a story summary. Uses the rss feed found here : 
    ''' 
    ''' http://newsrss.bbc.co.uk/rss/newsonline_world_edition/front_page/rss.xml
    ''' </summary>


    <CustomTag()>
    Private Class news
        Inherits AIMLTagHandler

        Public Sub New()
            Me.InputString = "news"
        End Sub

        Protected Overrides Function ProcessChange() As String
            Dim result2 As String
            If Me.templateNode.Name.ToLower() = "news" Then
                Dim includeDescription As Boolean = False
                If Me.templateNode.Attributes.Count = 1 Then
                    If Me.templateNode.Attributes(0).Name.ToLower() = "description" Then
                        If Me.templateNode.Attributes(0).Value.ToLower() = "true" Then
                            includeDescription = True
                        End If
                    End If
                End If
                Dim rssAddress As String = "http://newsrss.bbc.co.uk/rss/newsonline_world_edition/front_page/rss.xml"
                Dim rssFeed As HttpWebRequest = CType(WebRequest.Create(rssAddress), HttpWebRequest)
                Dim response As HttpWebResponse = CType(rssFeed.GetResponse(), HttpWebResponse)
                Dim feedAsXML As XmlDocument = New XmlDocument()
                feedAsXML.Load(response.GetResponseStream())
                Dim result As StringBuilder = New StringBuilder()
                If feedAsXML.HasChildNodes Then
                    Dim headlines As XmlNodeList = feedAsXML.GetElementsByTagName("item")
                    For Each item As XmlNode In headlines
                        result.Append(item.ChildNodes(0).InnerText)
                        If includeDescription Then
                            result.Append(" (" + item.ChildNodes(1).InnerText + ")")
                        End If
                        result.Append(", ")
                    Next
                End If
                result.Append("[BBC News]")
                result2 = result.ToString()
            Else
                result2 = String.Empty
            End If
            Return result2
        End Function
    End Class

    <CustomTag()>
    Private Class vbscript
        Inherits AIMLTagHandler

        Public Sub New()
            Me.InputString = "vbscript"
        End Sub

        Protected Overrides Function ProcessChange() As String
            Dim DebugResult As String
            If Me.templateNode.Name.ToLower() = "news" Then

            Else
                DebugResult = String.Empty
            End If
            Return DebugResult
        End Function
    End Class
End Module
