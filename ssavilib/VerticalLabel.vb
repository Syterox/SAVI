

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

<ToolboxBitmap(GetType(VerticalLabel), "Varticallabel.ico")>
Public Class VerticalLabel

    'Since we are not using the additional resources/capabilities of 
    'UserControl we will inherit from Control instead to save overhead
    'Inherits System.Windows.Forms.UserControl
    Inherits System.Windows.Forms.Control

    Private labelText As String
    Private LinkColor_ As Color = Color.Orange
    Private ActiveLinkColor_ As Color = Color.Blue
    Private ForeColor_ As Color
#Region " Windows Form Designer generated code "

#End Region

    Protected Overrides Sub OnPaint(ByVal e As _
              System.Windows.Forms.PaintEventArgs)
        Dim sngControlWidth As Single
        Dim sngControlHeight As Single
        Dim sngTransformX As Single
        Dim sngTransformY As Single
        Dim labelColor As Color
        Dim labelBorderPen As New Pen(labelColor, 0)
        Dim labelBackColorBrush As New SolidBrush(MyBase.BackColor)
        Dim labelForeColorBrush As New SolidBrush(MyBase.ForeColor)

        MyBase.OnPaint(e)
        sngControlWidth = Me.Size.Width
        sngControlHeight = Me.Size.Height
        e.Graphics.DrawRectangle(labelBorderPen, 0, 0,
               sngControlWidth, sngControlHeight)
        e.Graphics.FillRectangle(labelBackColorBrush, 0,
               0, sngControlWidth, sngControlHeight)
        ' set the translation point for the 
        ' graphics object - the new (0,0) location
        sngTransformX = 0
        sngTransformY = sngControlHeight
        ' translate the origin used for rotation and drawing 
        e.Graphics.TranslateTransform(sngTransformX,
                        sngTransformY) ' (0, textwidth)
        'set the rotation angle for vertical text
        e.Graphics.RotateTransform(270)
        ' draw the text on the control
        e.Graphics.DrawString(labelText, Font,
               labelForeColorBrush, 0, 0)

    End Sub

    Private Sub VTextBox_Resize(ByVal sender As Object,
        ByVal e As System.EventArgs) Handles MyBase.Resize
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseHover(e As EventArgs)

        MyBase.ForeColor = LinkColor_
        MyBase.OnMouseHover(e)
    End Sub
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.ForeColor = LinkColor_
        MyBase.OnMouseMove(e)
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.ForeColor = ForeColor_
        MyBase.OnMouseLeave(e)
    End Sub
    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.ForeColor = ActiveLinkColor_
        MyBase.OnClick(e)
    End Sub
    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        MyBase.ForeColor = ActiveLinkColor_
        MyBase.OnMouseClick(e)
    End Sub


    <Category("Apariencia"),
Description("Texto que va a contener el control")>
    Public Overrides Property Text() As String
        Get
            Return labelText
        End Get
        Set(ByVal Value As String)
            labelText = Value
            Invalidate()
        End Set
    End Property
    <Category("Apariencia"),
Description("Color al momento que el mouse esta sobre el control")>
    Public Property LinkColor As Color
        Get
            Return LinkColor_
        End Get
        Set(ByVal Value As Color)
            LinkColor_ = Value
            Invalidate()
        End Set
    End Property
    <Category("Apariencia"),
Description("Color al momento de que el mouse da un click sobre el control")>
    Public Property ActiveLinkColor As Color
        Get
            Return ActiveLinkColor_
        End Get
        Set(ByVal Value As Color)
            ActiveLinkColor_ = Value
            Invalidate()
        End Set
    End Property
    Public Overrides Property ForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(value As Color)
            ForeColor_ = value
            MyBase.ForeColor = value
        End Set
    End Property

End Class


