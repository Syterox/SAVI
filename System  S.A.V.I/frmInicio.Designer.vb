<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicio))
        Me.btn_text = New System.Windows.Forms.Button()
        Me.ConMS_ico = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RestaurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TamañoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinimizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaximizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmr_deteccion = New System.Windows.Forms.Timer(Me.components)
        Me.LblPers = New System.Windows.Forms.Label()
        Me.LblNPers = New System.Windows.Forms.Label()
        Me.lbl_npersv = New System.Windows.Forms.Label()
        Me.lbl_persv = New System.Windows.Forms.Label()
        Me.lbl_upersv = New System.Windows.Forms.Label()
        Me.LblUPers = New System.Windows.Forms.Label()
        Me.tbx_nombre = New System.Windows.Forms.TextBox()
        Me.tbxDebug = New System.Windows.Forms.TextBox()
        Me.pic_ico = New System.Windows.Forms.PictureBox()
        Me.pic_visor = New System.Windows.Forms.PictureBox()
        Me.btnMax = New System.Windows.Forms.Button()
        Me.btnMin = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.lblHover = New System.Windows.Forms.Label()
        Me.LblRegPers = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ConMS_ico.SuspendLayout()
        CType(Me.pic_ico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_visor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_text
        '
        Me.btn_text.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_text.BackColor = System.Drawing.Color.Transparent
        Me.btn_text.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_text.FlatAppearance.BorderSize = 0
        Me.btn_text.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_text.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_text.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_text.Font = New System.Drawing.Font("Lucida Console", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_text.Location = New System.Drawing.Point(62, 64)
        Me.btn_text.Name = "btn_text"
        Me.btn_text.Size = New System.Drawing.Size(499, 22)
        Me.btn_text.TabIndex = 13
        Me.btn_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_text.UseVisualStyleBackColor = False
        '
        'ConMS_ico
        '
        Me.ConMS_ico.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestaurarToolStripMenuItem, Me.MoverToolStripMenuItem, Me.TamañoToolStripMenuItem, Me.MinimizarToolStripMenuItem, Me.MaximizarToolStripMenuItem, Me.ToolStripSeparator1, Me.CerrarToolStripMenuItem})
        Me.ConMS_ico.Name = "ConMS_ico"
        Me.ConMS_ico.Size = New System.Drawing.Size(129, 142)
        '
        'RestaurarToolStripMenuItem
        '
        Me.RestaurarToolStripMenuItem.Name = "RestaurarToolStripMenuItem"
        Me.RestaurarToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.RestaurarToolStripMenuItem.Text = "Restaurar"
        '
        'MoverToolStripMenuItem
        '
        Me.MoverToolStripMenuItem.Name = "MoverToolStripMenuItem"
        Me.MoverToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.MoverToolStripMenuItem.Text = "Mover"
        '
        'TamañoToolStripMenuItem
        '
        Me.TamañoToolStripMenuItem.Name = "TamañoToolStripMenuItem"
        Me.TamañoToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.TamañoToolStripMenuItem.Text = "Tamaño"
        '
        'MinimizarToolStripMenuItem
        '
        Me.MinimizarToolStripMenuItem.Name = "MinimizarToolStripMenuItem"
        Me.MinimizarToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.MinimizarToolStripMenuItem.Text = "Minimizar"
        '
        'MaximizarToolStripMenuItem
        '
        Me.MaximizarToolStripMenuItem.Name = "MaximizarToolStripMenuItem"
        Me.MaximizarToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.MaximizarToolStripMenuItem.Text = "Maximizar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(125, 6)
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'tmr_deteccion
        '
        '
        'LblPers
        '
        Me.LblPers.AutoSize = True
        Me.LblPers.BackColor = System.Drawing.Color.Transparent
        Me.LblPers.Font = New System.Drawing.Font("Lucida Console", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPers.ForeColor = System.Drawing.Color.White
        Me.LblPers.Location = New System.Drawing.Point(59, 336)
        Me.LblPers.Name = "LblPers"
        Me.LblPers.Size = New System.Drawing.Size(108, 16)
        Me.LblPers.TabIndex = 27
        Me.LblPers.Text = "Personas :"
        '
        'LblNPers
        '
        Me.LblNPers.AutoSize = True
        Me.LblNPers.BackColor = System.Drawing.Color.Transparent
        Me.LblNPers.Font = New System.Drawing.Font("Lucida Console", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNPers.ForeColor = System.Drawing.Color.White
        Me.LblNPers.Location = New System.Drawing.Point(59, 309)
        Me.LblNPers.Name = "LblNPers"
        Me.LblNPers.Size = New System.Drawing.Size(138, 16)
        Me.LblNPers.TabIndex = 28
        Me.LblNPers.Text = "N. Personas :"
        '
        'lbl_npersv
        '
        Me.lbl_npersv.AutoSize = True
        Me.lbl_npersv.BackColor = System.Drawing.Color.Transparent
        Me.lbl_npersv.Font = New System.Drawing.Font("Lucida Console", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_npersv.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lbl_npersv.Location = New System.Drawing.Point(203, 309)
        Me.lbl_npersv.Name = "lbl_npersv"
        Me.lbl_npersv.Size = New System.Drawing.Size(18, 16)
        Me.lbl_npersv.TabIndex = 29
        Me.lbl_npersv.Text = "0"
        '
        'lbl_persv
        '
        Me.lbl_persv.AutoSize = True
        Me.lbl_persv.BackColor = System.Drawing.Color.Transparent
        Me.lbl_persv.Font = New System.Drawing.Font("Lucida Console", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_persv.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lbl_persv.Location = New System.Drawing.Point(173, 336)
        Me.lbl_persv.Name = "lbl_persv"
        Me.lbl_persv.Size = New System.Drawing.Size(38, 16)
        Me.lbl_persv.TabIndex = 30
        Me.lbl_persv.Text = "   "
        '
        'lbl_upersv
        '
        Me.lbl_upersv.AutoSize = True
        Me.lbl_upersv.BackColor = System.Drawing.Color.Transparent
        Me.lbl_upersv.Font = New System.Drawing.Font("Lucida Console", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_upersv.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lbl_upersv.Location = New System.Drawing.Point(293, 365)
        Me.lbl_upersv.Name = "lbl_upersv"
        Me.lbl_upersv.Size = New System.Drawing.Size(0, 16)
        Me.lbl_upersv.TabIndex = 32
        '
        'LblUPers
        '
        Me.LblUPers.AutoSize = True
        Me.LblUPers.BackColor = System.Drawing.Color.Transparent
        Me.LblUPers.Font = New System.Drawing.Font("Lucida Console", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUPers.ForeColor = System.Drawing.Color.White
        Me.LblUPers.Location = New System.Drawing.Point(59, 365)
        Me.LblUPers.Name = "LblUPers"
        Me.LblUPers.Size = New System.Drawing.Size(228, 16)
        Me.LblUPers.TabIndex = 31
        Me.LblUPers.Text = "Ultima persona vista :"
        '
        'tbx_nombre
        '
        Me.tbx_nombre.Location = New System.Drawing.Point(636, 367)
        Me.tbx_nombre.Name = "tbx_nombre"
        Me.tbx_nombre.Size = New System.Drawing.Size(134, 20)
        Me.tbx_nombre.TabIndex = 37
        '
        'tbxDebug
        '
        Me.tbxDebug.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.tbxDebug.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbxDebug.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDebug.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.tbxDebug.Location = New System.Drawing.Point(61, 125)
        Me.tbxDebug.Multiline = True
        Me.tbxDebug.Name = "tbxDebug"
        Me.tbxDebug.ReadOnly = True
        Me.tbxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbxDebug.Size = New System.Drawing.Size(433, 163)
        Me.tbxDebug.TabIndex = 42
        '
        'pic_ico
        '
        Me.pic_ico.BackColor = System.Drawing.Color.Transparent
        Me.pic_ico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pic_ico.Location = New System.Drawing.Point(531, 62)
        Me.pic_ico.Name = "pic_ico"
        Me.pic_ico.Size = New System.Drawing.Size(31, 28)
        Me.pic_ico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_ico.TabIndex = 14
        Me.pic_ico.TabStop = False
        '
        'pic_visor
        '
        Me.pic_visor.BackColor = System.Drawing.Color.Transparent
        Me.pic_visor.Image = CType(resources.GetObject("pic_visor.Image"), System.Drawing.Image)
        Me.pic_visor.Location = New System.Drawing.Point(500, 108)
        Me.pic_visor.Name = "pic_visor"
        Me.pic_visor.Size = New System.Drawing.Size(320, 248)
        Me.pic_visor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pic_visor.TabIndex = 23
        Me.pic_visor.TabStop = False
        '
        'btnMax
        '
        Me.btnMax.BackColor = System.Drawing.Color.Gold
        Me.btnMax.FlatAppearance.BorderSize = 0
        Me.btnMax.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMax.Location = New System.Drawing.Point(478, 35)
        Me.btnMax.Name = "btnMax"
        Me.btnMax.Size = New System.Drawing.Size(40, 9)
        Me.btnMax.TabIndex = 58
        Me.btnMax.UseVisualStyleBackColor = False
        '
        'btnMin
        '
        Me.btnMin.BackColor = System.Drawing.Color.Beige
        Me.btnMin.FlatAppearance.BorderSize = 0
        Me.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.Location = New System.Drawing.Point(432, 35)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(40, 9)
        Me.btnMin.TabIndex = 57
        Me.btnMin.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Orange
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(524, 35)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(53, 9)
        Me.btnExit.TabIndex = 56
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnConfig
        '
        Me.btnConfig.BackColor = System.Drawing.Color.Gold
        Me.btnConfig.FlatAppearance.BorderSize = 0
        Me.btnConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfig.Location = New System.Drawing.Point(776, 401)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(44, 9)
        Me.btnConfig.TabIndex = 59
        Me.btnConfig.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.Orange
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Location = New System.Drawing.Point(776, 368)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(44, 9)
        Me.btnGuardar.TabIndex = 60
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnIniciar
        '
        Me.btnIniciar.BackColor = System.Drawing.Color.Beige
        Me.btnIniciar.FlatAppearance.BorderSize = 0
        Me.btnIniciar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIniciar.Location = New System.Drawing.Point(52, 401)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(44, 9)
        Me.btnIniciar.TabIndex = 61
        Me.btnIniciar.UseVisualStyleBackColor = False
        '
        'lblHover
        '
        Me.lblHover.AutoSize = True
        Me.lblHover.BackColor = System.Drawing.Color.Transparent
        Me.lblHover.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHover.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblHover.Location = New System.Drawing.Point(648, 397)
        Me.lblHover.Name = "lblHover"
        Me.lblHover.Size = New System.Drawing.Size(0, 13)
        Me.lblHover.TabIndex = 62
        '
        'LblRegPers
        '
        Me.LblRegPers.AutoSize = True
        Me.LblRegPers.BackColor = System.Drawing.Color.Transparent
        Me.LblRegPers.Font = New System.Drawing.Font("Lucida Console", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegPers.ForeColor = System.Drawing.Color.White
        Me.LblRegPers.Location = New System.Drawing.Point(452, 368)
        Me.LblRegPers.Name = "LblRegPers"
        Me.LblRegPers.Size = New System.Drawing.Size(178, 16)
        Me.LblRegPers.TabIndex = 63
        Me.LblRegPers.Text = "Registrar persona"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lucida Console", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label2.Location = New System.Drawing.Point(59, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 16)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Debuger Script:"
        '
        'frmInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(856, 423)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblRegPers)
        Me.Controls.Add(Me.lblHover)
        Me.Controls.Add(Me.btnIniciar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.btnMax)
        Me.Controls.Add(Me.btnMin)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.tbx_nombre)
        Me.Controls.Add(Me.pic_ico)
        Me.Controls.Add(Me.btn_text)
        Me.Controls.Add(Me.lbl_upersv)
        Me.Controls.Add(Me.LblUPers)
        Me.Controls.Add(Me.lbl_persv)
        Me.Controls.Add(Me.lbl_npersv)
        Me.Controls.Add(Me.LblNPers)
        Me.Controls.Add(Me.LblPers)
        Me.Controls.Add(Me.pic_visor)
        Me.Controls.Add(Me.tbxDebug)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(300, 200)
        Me.Name = "frmInicio"
        Me.Opacity = 0.8R
        Me.Text = "Iniciado-System S.A.V.I."
        Me.TransparencyKey = System.Drawing.SystemColors.ControlLight
        Me.ConMS_ico.ResumeLayout(False)
        CType(Me.pic_ico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_visor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_text As System.Windows.Forms.Button
    Friend WithEvents pic_ico As System.Windows.Forms.PictureBox
    Friend WithEvents ConMS_ico As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RestaurarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TamañoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinimizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaximizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pic_visor As System.Windows.Forms.PictureBox
    Friend WithEvents tmr_deteccion As System.Windows.Forms.Timer
    Friend WithEvents LblPers As System.Windows.Forms.Label
    Friend WithEvents LblNPers As System.Windows.Forms.Label
    Friend WithEvents lbl_npersv As System.Windows.Forms.Label
    Friend WithEvents lbl_persv As System.Windows.Forms.Label
    Friend WithEvents lbl_upersv As System.Windows.Forms.Label
    Friend WithEvents LblUPers As System.Windows.Forms.Label
    Friend WithEvents tbx_nombre As System.Windows.Forms.TextBox
    Friend WithEvents tbxDebug As System.Windows.Forms.TextBox
    Friend WithEvents btnMax As System.Windows.Forms.Button
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnIniciar As System.Windows.Forms.Button
    Friend WithEvents lblHover As System.Windows.Forms.Label
    Friend WithEvents LblRegPers As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
