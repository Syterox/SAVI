<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditor))
        Me.TmrLine = New System.Windows.Forms.Timer(Me.components)
        Me.menu = New System.Windows.Forms.ToolStrip()
        Me.btn_abrir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_guardar = New System.Windows.Forms.ToolStripButton()
        Me.btn_gcomo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonEjecutar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonPausar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFinalizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripNameFile = New System.Windows.Forms.ToolStripLabel()
        Me.txtTexto = New ICSharpCode.TextEditor.TextEditorControl()
        Me.dlgfuente = New System.Windows.Forms.FontDialog()
        Me.dlggrabar = New System.Windows.Forms.SaveFileDialog()
        Me.dlgAbrir = New System.Windows.Forms.OpenFileDialog()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CerrarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarTodasMenosLaActualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompilarToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.CompilarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_estado = New System.Windows.Forms.ToolStrip()
        Me.TSlblFile = New System.Windows.Forms.ToolStripLabel()
        Me.codificacion = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ubicación = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl_pos = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl_num = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl_tipo = New System.Windows.Forms.ToolStripLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarComoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesacerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.CortarCtrlXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiarCtrlCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PegarCtrlVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.SeleccionarTodoCtrlAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NumeroDeLineaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HerramientasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompilarF9ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.FormatoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FuentesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbxDebug = New System.Windows.Forms.TextBox()
        Me.menu.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.menu_estado.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TmrLine
        '
        '
        'menu
        '
        Me.menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_abrir, Me.ToolStripSeparator11, Me.btn_guardar, Me.btn_gcomo, Me.ToolStripSeparator2, Me.ToolStripButtonEjecutar, Me.ToolStripButtonPausar, Me.ToolStripSeparator1, Me.btnFinalizar, Me.ToolStripNameFile})
        Me.menu.Location = New System.Drawing.Point(0, 24)
        Me.menu.Name = "menu"
        Me.menu.Size = New System.Drawing.Size(693, 25)
        Me.menu.TabIndex = 14
        Me.menu.Text = "ToolStrip2"
        '
        'btn_abrir
        '
        Me.btn_abrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_abrir.Image = Global.System__SAVI.My.Resources.Resources.Folder
        Me.btn_abrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_abrir.Name = "btn_abrir"
        Me.btn_abrir.Size = New System.Drawing.Size(23, 22)
        Me.btn_abrir.Text = "Abrir"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'btn_guardar
        '
        Me.btn_guardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_guardar.Image = Global.System__SAVI.My.Resources.Resources.media_floppy
        Me.btn_guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(23, 22)
        Me.btn_guardar.Text = "Guardar"
        '
        'btn_gcomo
        '
        Me.btn_gcomo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_gcomo.Image = Global.System__SAVI.My.Resources.Resources.document_save_as
        Me.btn_gcomo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_gcomo.Name = "btn_gcomo"
        Me.btn_gcomo.Size = New System.Drawing.Size(23, 22)
        Me.btn_gcomo.Text = "Guardar como"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonEjecutar
        '
        Me.ToolStripButtonEjecutar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonEjecutar.Image = Global.System__SAVI.My.Resources.Resources.audacious
        Me.ToolStripButtonEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEjecutar.Name = "ToolStripButtonEjecutar"
        Me.ToolStripButtonEjecutar.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonEjecutar.Text = "Probar"
        '
        'ToolStripButtonPausar
        '
        Me.ToolStripButtonPausar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonPausar.Image = Global.System__SAVI.My.Resources.Resources.Xion
        Me.ToolStripButtonPausar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonPausar.Name = "ToolStripButtonPausar"
        Me.ToolStripButtonPausar.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonPausar.Text = "Pausar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnFinalizar
        '
        Me.btnFinalizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFinalizar.Image = Global.System__SAVI.My.Resources.Resources.gnome_session_hibernate
        Me.btnFinalizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(23, 22)
        Me.btnFinalizar.Text = "terminar"
        '
        'ToolStripNameFile
        '
        Me.ToolStripNameFile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripNameFile.Name = "ToolStripNameFile"
        Me.ToolStripNameFile.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripNameFile.Text = "command"
        '
        'txtTexto
        '
        Me.txtTexto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTexto.IsReadOnly = False
        Me.txtTexto.Location = New System.Drawing.Point(0, 49)
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.Size = New System.Drawing.Size(693, 301)
        Me.txtTexto.TabIndex = 15
        '
        'dlgfuente
        '
        Me.dlgfuente.AllowVectorFonts = False
        Me.dlgfuente.AllowVerticalFonts = False
        Me.dlgfuente.FixedPitchOnly = True
        Me.dlgfuente.ShowApply = True
        Me.dlgfuente.ShowColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarToolStripMenuItem1, Me.CerrarTodasMenosLaActualToolStripMenuItem, Me.CompilarToolStripMenuItem, Me.CompilarToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(225, 76)
        '
        'CerrarToolStripMenuItem1
        '
        Me.CerrarToolStripMenuItem1.Name = "CerrarToolStripMenuItem1"
        Me.CerrarToolStripMenuItem1.Size = New System.Drawing.Size(224, 22)
        Me.CerrarToolStripMenuItem1.Text = "Cerrar"
        '
        'CerrarTodasMenosLaActualToolStripMenuItem
        '
        Me.CerrarTodasMenosLaActualToolStripMenuItem.Name = "CerrarTodasMenosLaActualToolStripMenuItem"
        Me.CerrarTodasMenosLaActualToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.CerrarTodasMenosLaActualToolStripMenuItem.Text = "Cerrar todas menos la actual"
        '
        'CompilarToolStripMenuItem
        '
        Me.CompilarToolStripMenuItem.Name = "CompilarToolStripMenuItem"
        Me.CompilarToolStripMenuItem.Size = New System.Drawing.Size(221, 6)
        '
        'CompilarToolStripMenuItem1
        '
        Me.CompilarToolStripMenuItem1.Name = "CompilarToolStripMenuItem1"
        Me.CompilarToolStripMenuItem1.Size = New System.Drawing.Size(224, 22)
        Me.CompilarToolStripMenuItem1.Text = "Compilar"
        '
        'menu_estado
        '
        Me.menu_estado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.menu_estado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSlblFile, Me.codificacion, Me.ToolStripSeparator7, Me.ubicación, Me.ToolStripSeparator8, Me.lbl_pos, Me.ToolStripSeparator9, Me.lbl_num, Me.ToolStripButton5, Me.lbl_tipo})
        Me.menu_estado.Location = New System.Drawing.Point(0, 407)
        Me.menu_estado.Name = "menu_estado"
        Me.menu_estado.Size = New System.Drawing.Size(693, 25)
        Me.menu_estado.TabIndex = 18
        Me.menu_estado.Text = "ToolStrip1"
        '
        'TSlblFile
        '
        Me.TSlblFile.Name = "TSlblFile"
        Me.TSlblFile.Size = New System.Drawing.Size(22, 22)
        Me.TSlblFile.Text = "Dir"
        '
        'codificacion
        '
        Me.codificacion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.codificacion.Name = "codificacion"
        Me.codificacion.Size = New System.Drawing.Size(33, 22)
        Me.codificacion.Text = "ANSI"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ubicación
        '
        Me.ubicación.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ubicación.Name = "ubicación"
        Me.ubicación.Size = New System.Drawing.Size(13, 22)
        Me.ubicación.Text = "  "
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'lbl_pos
        '
        Me.lbl_pos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lbl_pos.Name = "lbl_pos"
        Me.lbl_pos.Size = New System.Drawing.Size(60, 22)
        Me.lbl_pos.Text = "lin:      col:"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'lbl_num
        '
        Me.lbl_num.Name = "lbl_num"
        Me.lbl_num.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(6, 25)
        '
        'lbl_tipo
        '
        Me.lbl_tipo.Name = "lbl_tipo"
        Me.lbl_tipo.Size = New System.Drawing.Size(68, 22)
        Me.lbl_tipo.Text = "Texto plano"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.EditarToolStripMenuItem, Me.VerToolStripMenuItem, Me.HerramientasToolStripMenuItem, Me.FormatoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(693, 24)
        Me.MenuStrip1.TabIndex = 17
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.AbrirToolStripMenuItem, Me.ToolStripSeparator5, Me.GuardarToolStripMenuItem, Me.GuardarComoToolStripMenuItem, Me.ToolStripSeparator6, Me.SalirToolStripMenuItem, Me.CerrarToolStripMenuItem, Me.SalirToolStripMenuItem1})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Image = CType(resources.GetObject("NuevoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.NuevoToolStripMenuItem.Text = "Nuevo         "
        '
        'AbrirToolStripMenuItem
        '
        Me.AbrirToolStripMenuItem.Image = CType(resources.GetObject("AbrirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        Me.AbrirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AbrirToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.AbrirToolStripMenuItem.Text = "Abrir        "
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(233, 6)
        '
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.Image = CType(resources.GetObject("GuardarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.GuardarToolStripMenuItem.Text = "Guardar     "
        '
        'GuardarComoToolStripMenuItem
        '
        Me.GuardarComoToolStripMenuItem.Image = CType(resources.GetObject("GuardarComoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GuardarComoToolStripMenuItem.Name = "GuardarComoToolStripMenuItem"
        Me.GuardarComoToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.GuardarComoToolStripMenuItem.Text = "Guardar Como                            "
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(233, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = CType(resources.GetObject("SalirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.SalirToolStripMenuItem.Text = "Imprimir"
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'SalirToolStripMenuItem1
        '
        Me.SalirToolStripMenuItem1.Name = "SalirToolStripMenuItem1"
        Me.SalirToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem1.Size = New System.Drawing.Size(236, 22)
        Me.SalirToolStripMenuItem1.Text = "Salir"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DesacerToolStripMenuItem, Me.ToolStripComboBox1, Me.ToolStripSeparator10, Me.CortarCtrlXToolStripMenuItem, Me.CopiarCtrlCToolStripMenuItem, Me.PegarCtrlVToolStripMenuItem, Me.ToolStripSeparator13, Me.SeleccionarTodoCtrlAToolStripMenuItem, Me.ToolStripSeparator14, Me.BuscarToolStripMenuItem})
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'DesacerToolStripMenuItem
        '
        Me.DesacerToolStripMenuItem.Image = CType(resources.GetObject("DesacerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DesacerToolStripMenuItem.Name = "DesacerToolStripMenuItem"
        Me.DesacerToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.DesacerToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.DesacerToolStripMenuItem.Text = "Deshacer       "
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.Image = CType(resources.GetObject("ToolStripComboBox1.Image"), System.Drawing.Image)
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(217, 22)
        Me.ToolStripComboBox1.Text = "Rehacer      "
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(214, 6)
        '
        'CortarCtrlXToolStripMenuItem
        '
        Me.CortarCtrlXToolStripMenuItem.Image = CType(resources.GetObject("CortarCtrlXToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CortarCtrlXToolStripMenuItem.Name = "CortarCtrlXToolStripMenuItem"
        Me.CortarCtrlXToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CortarCtrlXToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.CortarCtrlXToolStripMenuItem.Text = "Cortar     "
        '
        'CopiarCtrlCToolStripMenuItem
        '
        Me.CopiarCtrlCToolStripMenuItem.Image = CType(resources.GetObject("CopiarCtrlCToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopiarCtrlCToolStripMenuItem.Name = "CopiarCtrlCToolStripMenuItem"
        Me.CopiarCtrlCToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopiarCtrlCToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.CopiarCtrlCToolStripMenuItem.Text = "Copiar      "
        '
        'PegarCtrlVToolStripMenuItem
        '
        Me.PegarCtrlVToolStripMenuItem.Image = CType(resources.GetObject("PegarCtrlVToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PegarCtrlVToolStripMenuItem.Name = "PegarCtrlVToolStripMenuItem"
        Me.PegarCtrlVToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PegarCtrlVToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.PegarCtrlVToolStripMenuItem.Text = "Pegar       "
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(214, 6)
        '
        'SeleccionarTodoCtrlAToolStripMenuItem
        '
        Me.SeleccionarTodoCtrlAToolStripMenuItem.Name = "SeleccionarTodoCtrlAToolStripMenuItem"
        Me.SeleccionarTodoCtrlAToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.SeleccionarTodoCtrlAToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.SeleccionarTodoCtrlAToolStripMenuItem.Text = "Seleccionar todo     "
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(214, 6)
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = CType(resources.GetObject("BuscarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.BuscarToolStripMenuItem.Text = "Buscar "
        '
        'VerToolStripMenuItem
        '
        Me.VerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NumeroDeLineaToolStripMenuItem})
        Me.VerToolStripMenuItem.Name = "VerToolStripMenuItem"
        Me.VerToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.VerToolStripMenuItem.Text = "Ver"
        '
        'NumeroDeLineaToolStripMenuItem
        '
        Me.NumeroDeLineaToolStripMenuItem.Checked = True
        Me.NumeroDeLineaToolStripMenuItem.CheckOnClick = True
        Me.NumeroDeLineaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.NumeroDeLineaToolStripMenuItem.Name = "NumeroDeLineaToolStripMenuItem"
        Me.NumeroDeLineaToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.NumeroDeLineaToolStripMenuItem.Text = "Numero de linea"
        '
        'HerramientasToolStripMenuItem
        '
        Me.HerramientasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompilarF9ToolStripMenuItem, Me.ToolStripSeparator15})
        Me.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem"
        Me.HerramientasToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.HerramientasToolStripMenuItem.Text = "Herramientas"
        '
        'CompilarF9ToolStripMenuItem
        '
        Me.CompilarF9ToolStripMenuItem.Name = "CompilarF9ToolStripMenuItem"
        Me.CompilarF9ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.CompilarF9ToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.CompilarF9ToolStripMenuItem.Text = "Probar"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(125, 6)
        '
        'FormatoToolStripMenuItem
        '
        Me.FormatoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FuentesToolStripMenuItem})
        Me.FormatoToolStripMenuItem.Name = "FormatoToolStripMenuItem"
        Me.FormatoToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.FormatoToolStripMenuItem.Text = "Formato"
        '
        'FuentesToolStripMenuItem
        '
        Me.FuentesToolStripMenuItem.Image = CType(resources.GetObject("FuentesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FuentesToolStripMenuItem.Name = "FuentesToolStripMenuItem"
        Me.FuentesToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.FuentesToolStripMenuItem.Text = "Fuente"
        '
        'tbxDebug
        '
        Me.tbxDebug.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tbxDebug.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDebug.Location = New System.Drawing.Point(0, 350)
        Me.tbxDebug.Multiline = True
        Me.tbxDebug.Name = "tbxDebug"
        Me.tbxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbxDebug.Size = New System.Drawing.Size(693, 57)
        Me.tbxDebug.TabIndex = 19
        '
        'frmEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 432)
        Me.Controls.Add(Me.tbxDebug)
        Me.Controls.Add(Me.menu_estado)
        Me.Controls.Add(Me.txtTexto)
        Me.Controls.Add(Me.menu)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEditor"
        Me.Text = "Script Editor"
        Me.menu.ResumeLayout(False)
        Me.menu.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.menu_estado.ResumeLayout(False)
        Me.menu_estado.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TmrLine As System.Windows.Forms.Timer
    Friend WithEvents menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_abrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_guardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_gcomo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFinalizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonEjecutar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonPausar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtTexto As ICSharpCode.TextEditor.TextEditorControl
    Friend WithEvents dlgfuente As System.Windows.Forms.FontDialog
    Friend WithEvents dlggrabar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dlgAbrir As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CerrarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarTodasMenosLaActualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompilarToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CompilarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_estado As System.Windows.Forms.ToolStrip
    Friend WithEvents lbl_tipo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents codificacion As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ubicación As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl_pos As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl_num As System.Windows.Forms.ToolStripLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GuardarComoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesacerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CortarCtrlXToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopiarCtrlCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PegarCtrlVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SeleccionarTodoCtrlAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NumeroDeLineaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormatoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FuentesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSlblFile As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HerramientasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompilarF9ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripNameFile As System.Windows.Forms.ToolStripLabel
    Friend WithEvents GuardarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbxDebug As TextBox
End Class
