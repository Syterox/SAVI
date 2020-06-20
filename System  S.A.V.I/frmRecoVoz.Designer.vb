<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecoVoz
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecoVoz))
        Me.tmrEvents = New System.Windows.Forms.Timer(Me.components)
        Me.cpbMicVol = New CircularProgressBar.CircularProgressBar()
        Me.cpbSpkVol = New CircularProgressBar.CircularProgressBar()
        Me.BtnMax = New System.Windows.Forms.Button()
        Me.btn_min = New System.Windows.Forms.Button()
        Me.BwCommand = New System.ComponentModel.BackgroundWorker()
        Me.tbxLog = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnMin = New System.Windows.Forms.Button()
        Me.tmrRecieveMsg = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrEvents
        '
        '
        'cpbMicVol
        '
        Me.cpbMicVol.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner
        Me.cpbMicVol.AnimationSpeed = 500
        Me.cpbMicVol.BackColor = System.Drawing.Color.Transparent
        Me.cpbMicVol.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold)
        Me.cpbMicVol.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cpbMicVol.InnerColor = System.Drawing.Color.Transparent
        Me.cpbMicVol.InnerMargin = 2
        Me.cpbMicVol.InnerWidth = -1
        Me.cpbMicVol.Location = New System.Drawing.Point(12, 8)
        Me.cpbMicVol.MarqueeAnimationSpeed = 2000
        Me.cpbMicVol.Maximum = 200
        Me.cpbMicVol.Name = "cpbMicVol"
        Me.cpbMicVol.OuterColor = System.Drawing.Color.LightGray
        Me.cpbMicVol.OuterMargin = 2
        Me.cpbMicVol.OuterWidth = 5
        Me.cpbMicVol.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cpbMicVol.ProgressWidth = 5
        Me.cpbMicVol.SecondaryFont = New System.Drawing.Font("Microsoft Sans Serif", 36.0!)
        Me.cpbMicVol.Size = New System.Drawing.Size(179, 179)
        Me.cpbMicVol.StartAngle = 180
        Me.cpbMicVol.SubscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.cpbMicVol.SubscriptMargin = New System.Windows.Forms.Padding(10, -35, 0, 0)
        Me.cpbMicVol.SubscriptText = ""
        Me.cpbMicVol.SuperscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.cpbMicVol.SuperscriptMargin = New System.Windows.Forms.Padding(10, 35, 0, 0)
        Me.cpbMicVol.SuperscriptText = ""
        Me.cpbMicVol.TabIndex = 42
        Me.cpbMicVol.TextMargin = New System.Windows.Forms.Padding(8, 8, 0, 0)
        Me.cpbMicVol.Value = 100
        '
        'cpbSpkVol
        '
        Me.cpbSpkVol.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner
        Me.cpbSpkVol.AnimationSpeed = 200
        Me.cpbSpkVol.BackColor = System.Drawing.Color.Transparent
        Me.cpbSpkVol.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpbSpkVol.ForeColor = System.Drawing.Color.DimGray
        Me.cpbSpkVol.InnerColor = System.Drawing.Color.Indigo
        Me.cpbSpkVol.InnerMargin = 0
        Me.cpbSpkVol.InnerWidth = -1
        Me.cpbSpkVol.Location = New System.Drawing.Point(58, 50)
        Me.cpbSpkVol.MarqueeAnimationSpeed = 2000
        Me.cpbSpkVol.Name = "cpbSpkVol"
        Me.cpbSpkVol.OuterColor = System.Drawing.Color.LightGray
        Me.cpbSpkVol.OuterMargin = 1
        Me.cpbSpkVol.OuterWidth = 7
        Me.cpbSpkVol.ProgressColor = System.Drawing.Color.DimGray
        Me.cpbSpkVol.ProgressWidth = 7
        Me.cpbSpkVol.SecondaryFont = New System.Drawing.Font("Microsoft Sans Serif", 36.0!)
        Me.cpbSpkVol.Size = New System.Drawing.Size(88, 88)
        Me.cpbSpkVol.StartAngle = 270
        Me.cpbSpkVol.SubscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.cpbSpkVol.SubscriptMargin = New System.Windows.Forms.Padding(10, -35, 0, 0)
        Me.cpbSpkVol.SubscriptText = ""
        Me.cpbSpkVol.SuperscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.cpbSpkVol.SuperscriptMargin = New System.Windows.Forms.Padding(10, 35, 0, 0)
        Me.cpbSpkVol.SuperscriptText = ""
        Me.cpbSpkVol.TabIndex = 43
        Me.cpbSpkVol.Text = "S.A.V.I"
        Me.cpbSpkVol.TextMargin = New System.Windows.Forms.Padding(1, 5, 0, 0)
        Me.cpbSpkVol.Value = 100
        '
        'BtnMax
        '
        Me.BtnMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMax.BackColor = System.Drawing.Color.Gold
        Me.BtnMax.Enabled = False
        Me.BtnMax.FlatAppearance.BorderSize = 0
        Me.BtnMax.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.BtnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMax.Location = New System.Drawing.Point(360, 3)
        Me.BtnMax.Name = "BtnMax"
        Me.BtnMax.Size = New System.Drawing.Size(40, 8)
        Me.BtnMax.TabIndex = 58
        Me.BtnMax.UseVisualStyleBackColor = False
        '
        'btn_min
        '
        Me.btn_min.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_min.BackColor = System.Drawing.Color.Gray
        Me.btn_min.FlatAppearance.BorderSize = 0
        Me.btn_min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_min.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_min.Location = New System.Drawing.Point(402, 139)
        Me.btn_min.Name = "btn_min"
        Me.btn_min.Size = New System.Drawing.Size(44, 9)
        Me.btn_min.TabIndex = 60
        Me.btn_min.UseVisualStyleBackColor = False
        '
        'BwCommand
        '
        Me.BwCommand.WorkerReportsProgress = True
        Me.BwCommand.WorkerSupportsCancellation = True
        '
        'tbxLog
        '
        Me.tbxLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.tbxLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbxLog.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxLog.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.tbxLog.Location = New System.Drawing.Point(207, 21)
        Me.tbxLog.Multiline = True
        Me.tbxLog.Name = "tbxLog"
        Me.tbxLog.ReadOnly = True
        Me.tbxLog.Size = New System.Drawing.Size(167, 115)
        Me.tbxLog.TabIndex = 61
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.Orange
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Location = New System.Drawing.Point(402, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(53, 8)
        Me.btnSalir.TabIndex = 62
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Location = New System.Drawing.Point(12, 98)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(189, 50)
        Me.PictureBox1.TabIndex = 63
        Me.PictureBox1.TabStop = False
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Beige
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(318, 3)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(40, 8)
        Me.btnMin.TabIndex = 68
        Me.btnMin.UseVisualStyleBackColor = False
        '
        'tmrRecieveMsg
        '
        '
        'frmRecoVoz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(467, 148)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btn_min)
        Me.Controls.Add(Me.BtnMax)
        Me.Controls.Add(Me.cpbSpkVol)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cpbMicVol)
        Me.Controls.Add(Me.tbxLog)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRecoVoz"
        Me.Opacity = 0.85R
        Me.Text = "Savi"
        Me.TransparencyKey = System.Drawing.SystemColors.ControlLight
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrEvents As System.Windows.Forms.Timer
    Friend WithEvents cpbMicVol As CircularProgressBar.CircularProgressBar
    Friend WithEvents cpbSpkVol As CircularProgressBar.CircularProgressBar
    Friend WithEvents BtnMax As System.Windows.Forms.Button
    Friend WithEvents btn_min As System.Windows.Forms.Button
    Friend WithEvents BwCommand As System.ComponentModel.BackgroundWorker
    Friend WithEvents tbxLog As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents tmrRecieveMsg As Timer
    Friend WithEvents Timer1 As Timer
End Class
