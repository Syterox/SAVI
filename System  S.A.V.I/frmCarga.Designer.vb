<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCarga
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCarga))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cpbSyteroxlogo = New CircularProgressBar.CircularProgressBar()
        Me.cpbLogo = New CircularProgressBar.CircularProgressBar()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(217, 301)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "© 2017 Syterox Software"
        '
        'cpbSyteroxlogo
        '
        Me.cpbSyteroxlogo.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner
        Me.cpbSyteroxlogo.AnimationSpeed = 500
        Me.cpbSyteroxlogo.BackColor = System.Drawing.Color.Transparent
        Me.cpbSyteroxlogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpbSyteroxlogo.ForeColor = System.Drawing.Color.DimGray
        Me.cpbSyteroxlogo.InnerColor = System.Drawing.Color.Transparent
        Me.cpbSyteroxlogo.InnerMargin = 2
        Me.cpbSyteroxlogo.InnerWidth = -1
        Me.cpbSyteroxlogo.Location = New System.Drawing.Point(169, 142)
        Me.cpbSyteroxlogo.MarqueeAnimationSpeed = 2000
        Me.cpbSyteroxlogo.Name = "cpbSyteroxlogo"
        Me.cpbSyteroxlogo.OuterColor = System.Drawing.Color.Gray
        Me.cpbSyteroxlogo.OuterMargin = -25
        Me.cpbSyteroxlogo.OuterWidth = 26
        Me.cpbSyteroxlogo.ProgressColor = System.Drawing.Color.DarkGray
        Me.cpbSyteroxlogo.ProgressWidth = 7
        Me.cpbSyteroxlogo.SecondaryFont = New System.Drawing.Font("Microsoft Sans Serif", 36.0!)
        Me.cpbSyteroxlogo.Size = New System.Drawing.Size(138, 138)
        Me.cpbSyteroxlogo.StartAngle = 180
        Me.cpbSyteroxlogo.SubscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.cpbSyteroxlogo.SubscriptMargin = New System.Windows.Forms.Padding(10, -35, 0, 0)
        Me.cpbSyteroxlogo.SubscriptText = ""
        Me.cpbSyteroxlogo.SuperscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.cpbSyteroxlogo.SuperscriptMargin = New System.Windows.Forms.Padding(10, 35, 0, 0)
        Me.cpbSyteroxlogo.SuperscriptText = ""
        Me.cpbSyteroxlogo.TabIndex = 61
        Me.cpbSyteroxlogo.Text = "Syterox"
        Me.cpbSyteroxlogo.TextMargin = New System.Windows.Forms.Padding(1, 5, 0, 0)
        Me.cpbSyteroxlogo.Value = 30
        '
        'cpbLogo
        '
        Me.cpbLogo.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner
        Me.cpbLogo.AnimationSpeed = 500
        Me.cpbLogo.BackColor = System.Drawing.Color.Transparent
        Me.cpbLogo.Font = New System.Drawing.Font("Consolas", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpbLogo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cpbLogo.InnerColor = System.Drawing.Color.Transparent
        Me.cpbLogo.InnerMargin = 2
        Me.cpbLogo.InnerWidth = -1
        Me.cpbLogo.Location = New System.Drawing.Point(52, 12)
        Me.cpbLogo.MarqueeAnimationSpeed = 2000
        Me.cpbLogo.Name = "cpbLogo"
        Me.cpbLogo.OuterColor = System.Drawing.Color.SandyBrown
        Me.cpbLogo.OuterMargin = -25
        Me.cpbLogo.OuterWidth = 26
        Me.cpbLogo.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cpbLogo.ProgressWidth = 7
        Me.cpbLogo.SecondaryFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpbLogo.Size = New System.Drawing.Size(224, 224)
        Me.cpbLogo.StartAngle = 180
        Me.cpbLogo.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.cpbLogo.SubscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.cpbLogo.SubscriptMargin = New System.Windows.Forms.Padding(10, -35, 0, 0)
        Me.cpbLogo.SubscriptText = ""
        Me.cpbLogo.SuperscriptColor = System.Drawing.Color.Black
        Me.cpbLogo.SuperscriptMargin = New System.Windows.Forms.Padding(10, 35, 0, 0)
        Me.cpbLogo.SuperscriptText = ""
        Me.cpbLogo.TabIndex = 60
        Me.cpbLogo.Text = "S.A.V.I."
        Me.cpbLogo.TextMargin = New System.Windows.Forms.Padding(3, 6, 0, 0)
        Me.cpbLogo.Value = 68
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 291)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 62
        Me.ProgressBar1.Visible = False
        '
        'frmCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(355, 323)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.cpbSyteroxlogo)
        Me.Controls.Add(Me.cpbLogo)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCarga"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargando"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cpbSyteroxlogo As CircularProgressBar.CircularProgressBar
    Friend WithEvents cpbLogo As CircularProgressBar.CircularProgressBar
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
