<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIParent1))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatalogoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizarCatalogoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AltaDeUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BajaDeUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatalogoDeUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecibirFondoDeCajaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RetirarFondoDeCajaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CorteDeCajaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReiniciarInventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjustePorProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntradasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaEntradaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalidasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaSalidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.EnviarVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ViewMenu, Me.ToolsMenu, Me.CatalogoToolStripMenuItem, Me.OperacionToolStripMenuItem, Me.InventarioToolStripMenuItem, Me.EntradasToolStripMenuItem, Me.SalidasToolStripMenuItem, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarVentasToolStripMenuItem, Me.VentaToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(47, 20)
        Me.FileMenu.Text = "&Venta"
        '
        'VentaToolStripMenuItem
        '
        Me.VentaToolStripMenuItem.Name = "VentaToolStripMenuItem"
        Me.VentaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.VentaToolStripMenuItem.Text = "&Venta"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "&Salir"
        '
        'ViewMenu
        '
        Me.ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusBarToolStripMenuItem})
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(35, 20)
        Me.ViewMenu.Text = "&Ver"
        '
        'StatusBarToolStripMenuItem
        '
        Me.StatusBarToolStripMenuItem.Checked = True
        Me.StatusBarToolStripMenuItem.CheckOnClick = True
        Me.StatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem"
        Me.StatusBarToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.StatusBarToolStripMenuItem.Text = "&Barra de estado"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.TicketToolStripMenuItem})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(85, 20)
        Me.ToolsMenu.Text = "&Configuración"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.OptionsToolStripMenuItem.Text = "&Sucursal"
        '
        'TicketToolStripMenuItem
        '
        Me.TicketToolStripMenuItem.Name = "TicketToolStripMenuItem"
        Me.TicketToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.TicketToolStripMenuItem.Text = "&Ticket"
        '
        'CatalogoToolStripMenuItem
        '
        Me.CatalogoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductosToolStripMenuItem, Me.ActualizarCatalogoToolStripMenuItem, Me.ToolStripSeparator3, Me.AltaDeUsuariosToolStripMenuItem, Me.BajaDeUsuariosToolStripMenuItem, Me.CatalogoDeUsuariosToolStripMenuItem})
        Me.CatalogoToolStripMenuItem.Name = "CatalogoToolStripMenuItem"
        Me.CatalogoToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.CatalogoToolStripMenuItem.Text = "Catalogos"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ProductosToolStripMenuItem.Text = "&Productos"
        '
        'ActualizarCatalogoToolStripMenuItem
        '
        Me.ActualizarCatalogoToolStripMenuItem.Name = "ActualizarCatalogoToolStripMenuItem"
        Me.ActualizarCatalogoToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ActualizarCatalogoToolStripMenuItem.Text = "Act&ualizar catalogos"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(183, 6)
        '
        'AltaDeUsuariosToolStripMenuItem
        '
        Me.AltaDeUsuariosToolStripMenuItem.Name = "AltaDeUsuariosToolStripMenuItem"
        Me.AltaDeUsuariosToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.AltaDeUsuariosToolStripMenuItem.Text = "&Alta de usuarios"
        '
        'BajaDeUsuariosToolStripMenuItem
        '
        Me.BajaDeUsuariosToolStripMenuItem.Name = "BajaDeUsuariosToolStripMenuItem"
        Me.BajaDeUsuariosToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.BajaDeUsuariosToolStripMenuItem.Text = "&Baja de usuarios"
        '
        'CatalogoDeUsuariosToolStripMenuItem
        '
        Me.CatalogoDeUsuariosToolStripMenuItem.Name = "CatalogoDeUsuariosToolStripMenuItem"
        Me.CatalogoDeUsuariosToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.CatalogoDeUsuariosToolStripMenuItem.Text = "&Catalogo de usuarios"
        '
        'OperacionToolStripMenuItem
        '
        Me.OperacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RecibirFondoDeCajaToolStripMenuItem, Me.RetirarFondoDeCajaToolStripMenuItem, Me.CorteDeCajaToolStripMenuItem})
        Me.OperacionToolStripMenuItem.Name = "OperacionToolStripMenuItem"
        Me.OperacionToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.OperacionToolStripMenuItem.Text = "&Operacion"
        '
        'RecibirFondoDeCajaToolStripMenuItem
        '
        Me.RecibirFondoDeCajaToolStripMenuItem.Name = "RecibirFondoDeCajaToolStripMenuItem"
        Me.RecibirFondoDeCajaToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.RecibirFondoDeCajaToolStripMenuItem.Text = "&Recibir fondo de caja"
        '
        'RetirarFondoDeCajaToolStripMenuItem
        '
        Me.RetirarFondoDeCajaToolStripMenuItem.Name = "RetirarFondoDeCajaToolStripMenuItem"
        Me.RetirarFondoDeCajaToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.RetirarFondoDeCajaToolStripMenuItem.Text = "Re&tirar fondo de caja"
        '
        'CorteDeCajaToolStripMenuItem
        '
        Me.CorteDeCajaToolStripMenuItem.Name = "CorteDeCajaToolStripMenuItem"
        Me.CorteDeCajaToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.CorteDeCajaToolStripMenuItem.Text = "&Corte de caja"
        '
        'InventarioToolStripMenuItem
        '
        Me.InventarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReiniciarInventarioToolStripMenuItem, Me.AjustePorProductoToolStripMenuItem})
        Me.InventarioToolStripMenuItem.Name = "InventarioToolStripMenuItem"
        Me.InventarioToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.InventarioToolStripMenuItem.Text = "&Inventario"
        '
        'ReiniciarInventarioToolStripMenuItem
        '
        Me.ReiniciarInventarioToolStripMenuItem.Name = "ReiniciarInventarioToolStripMenuItem"
        Me.ReiniciarInventarioToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ReiniciarInventarioToolStripMenuItem.Text = "&Reiniciar inventario"
        '
        'AjustePorProductoToolStripMenuItem
        '
        Me.AjustePorProductoToolStripMenuItem.Name = "AjustePorProductoToolStripMenuItem"
        Me.AjustePorProductoToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.AjustePorProductoToolStripMenuItem.Text = "&Ajuste por producto"
        '
        'EntradasToolStripMenuItem
        '
        Me.EntradasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaEntradaToolStripMenuItem})
        Me.EntradasToolStripMenuItem.Name = "EntradasToolStripMenuItem"
        Me.EntradasToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.EntradasToolStripMenuItem.Text = "&Entradas"
        '
        'NuevaEntradaToolStripMenuItem
        '
        Me.NuevaEntradaToolStripMenuItem.Name = "NuevaEntradaToolStripMenuItem"
        Me.NuevaEntradaToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.NuevaEntradaToolStripMenuItem.Text = "&Nueva entrada"
        '
        'SalidasToolStripMenuItem
        '
        Me.SalidasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaSalidaToolStripMenuItem})
        Me.SalidasToolStripMenuItem.Name = "SalidasToolStripMenuItem"
        Me.SalidasToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.SalidasToolStripMenuItem.Text = "&Salidas"
        '
        'NuevaSalidaToolStripMenuItem
        '
        Me.NuevaSalidaToolStripMenuItem.Name = "NuevaSalidaToolStripMenuItem"
        Me.NuevaSalidaToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.NuevaSalidaToolStripMenuItem.Text = "&Nueva salida"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(50, 20)
        Me.HelpMenu.Text = "Ay&uda"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.AboutToolStripMenuItem.Text = "&Acerca de..."
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(632, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(40, 17)
        Me.ToolStripStatusLabel.Text = "Estado"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(111, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(111, 17)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(111, 17)
        Me.ToolStripStatusLabel3.Text = "ToolStripStatusLabel3"
        '
        'EnviarVentasToolStripMenuItem
        '
        Me.EnviarVentasToolStripMenuItem.Name = "EnviarVentasToolStripMenuItem"
        Me.EnviarVentasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EnviarVentasToolStripMenuItem.Text = "&Enviar ventas"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'MDIParent1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.ControlBox = False
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MDIParent1"
        Me.Text = "Farmacias de la gente"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CatalogoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AltaDeUsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BajaDeUsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CatalogoDeUsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecibirFondoDeCajaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RetirarFondoDeCajaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CorteDeCajaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActualizarCatalogoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReiniciarInventarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EntradasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevaEntradaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalidasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevaSalidaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents VentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AjustePorProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarVentasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class
