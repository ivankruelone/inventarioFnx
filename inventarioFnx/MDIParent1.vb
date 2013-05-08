Imports System.Windows.Forms

Public Class MDIParent1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        Form5.MdiParent = Me
        Form5.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: agregue código aquí para abrir el archivo.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: agregue código aquí para guardar el contenido actual del formulario en un archivo.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
        LoginForm1.Show()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    End Sub


    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub ProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosToolStripMenuItem.Click
        Form4.MdiParent = Me
        Form4.Show()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Form6.MdiParent = Me
        Form6.Show()
    End Sub

    Private Sub TicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TicketToolStripMenuItem.Click
        Form7.MdiParent = Me
        Form7.Show()
    End Sub

    Private Sub AltaDeUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltaDeUsuariosToolStripMenuItem.Click
        Form8.MdiParent = Me
        Form8.Show()
    End Sub

    Private Sub BajaDeUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BajaDeUsuariosToolStripMenuItem.Click
        Form9.MdiParent = Me
        Form9.Show()
    End Sub

    Private Sub CatalogoDeUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CatalogoDeUsuariosToolStripMenuItem.Click
        Form10.MdiParent = Me
        Form10.Show()
    End Sub

    Private Sub RecibirFondoDeCajaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecibirFondoDeCajaToolStripMenuItem.Click
        Form11.MdiParent = Me
        Form11.Show()
    End Sub

    Private Sub RetirarFondoDeCajaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetirarFondoDeCajaToolStripMenuItem.Click
        Form12.MdiParent = Me
        Form12.Show()
    End Sub

    Private Sub CorteDeCajaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorteDeCajaToolStripMenuItem.Click
        Form13.MdiParent = Me
        Form13.Show()
    End Sub

    Private Sub ActualizarCatalogoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarCatalogoToolStripMenuItem.Click
        Form3.MdiParent = Me
        Form3.Show()
    End Sub

    Private Sub ReiniciarInventarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReiniciarInventarioToolStripMenuItem.Click
        Form14.MdiParent = Me
        Form14.Show()
    End Sub

    Private Sub NuevaEntradaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaEntradaToolStripMenuItem.Click
        Form15.MdiParent = Me
        Form15.Show()
    End Sub

    Private Sub NuevaSalidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaSalidaToolStripMenuItem.Click
        Form16.MdiParent = Me
        Form16.Show()
    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStripStatusLabel1.Text = "Sucursal: " + Module1.sucursal.ToString + " - " + Module1.nombreSucursal
        ToolStripStatusLabel2.Text = "Usuario: " + Module1.nomina.ToString + " - " + Module1.nombre
        ToolStripStatusLabel3.Text = "PDV: " + Module1.maquina
        Me.Text = aplicacion

        If Module1.nivel = 2 Then
            TicketToolStripMenuItem.Enabled = False
            OptionsToolStripMenuItem.Enabled = False
            AltaDeUsuariosToolStripMenuItem.Enabled = False
            BajaDeUsuariosToolStripMenuItem.Enabled = False
            CatalogoDeUsuariosToolStripMenuItem.Enabled = False
            ReiniciarInventarioToolStripMenuItem.Enabled = False
            AjustePorProductoToolStripMenuItem.Enabled = False
        End If

        If Module1.sucursal = 0 And Module1.nivel = 1 Then

            VentaToolStripMenuItem.Enabled = False
            TicketToolStripMenuItem.Enabled = False
            AltaDeUsuariosToolStripMenuItem.Enabled = False
            BajaDeUsuariosToolStripMenuItem.Enabled = False
            CatalogoDeUsuariosToolStripMenuItem.Enabled = False
            ReiniciarInventarioToolStripMenuItem.Enabled = False
            AjustePorProductoToolStripMenuItem.Enabled = False
            RecibirFondoDeCajaToolStripMenuItem.Enabled = False
            RetirarFondoDeCajaToolStripMenuItem.Enabled = False
            CorteDeCajaToolStripMenuItem.Enabled = False
            NuevaEntradaToolStripMenuItem.Enabled = False
            NuevaSalidaToolStripMenuItem.Enabled = False
            Form17.MdiParent = Me
            Form17.Show()

        End If

        If Module1.sucursal = 0 And Module1.nivel = 2 Then

            VentaToolStripMenuItem.Enabled = False
            TicketToolStripMenuItem.Enabled = False
            AltaDeUsuariosToolStripMenuItem.Enabled = False
            BajaDeUsuariosToolStripMenuItem.Enabled = False
            CatalogoDeUsuariosToolStripMenuItem.Enabled = False
            ReiniciarInventarioToolStripMenuItem.Enabled = False
            AjustePorProductoToolStripMenuItem.Enabled = False
            RecibirFondoDeCajaToolStripMenuItem.Enabled = False
            RetirarFondoDeCajaToolStripMenuItem.Enabled = False
            CorteDeCajaToolStripMenuItem.Enabled = False
            NuevaEntradaToolStripMenuItem.Enabled = False
            NuevaSalidaToolStripMenuItem.Enabled = False
            Form17.MdiParent = Me
            Form17.Show()

        End If

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.MdiParent = Me
        AboutBox1.Show()
    End Sub

    Private Sub VentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaToolStripMenuItem.Click
        Form5.MdiParent = Me
        Form5.Show()
    End Sub

    Private Sub AjustePorProductoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjustePorProductoToolStripMenuItem.Click
        Form18.MdiParent = Me
        Form18.Show()
    End Sub

    Private Sub EnviarVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarVentasToolStripMenuItem.Click
        Form19.MdiParent = Me
        Form19.Show()
    End Sub
End Class
