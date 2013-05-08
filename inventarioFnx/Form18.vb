Public Class Form18

    Dim producto_id As Integer
    Dim ean As String
    Dim cantidadActual As Integer
    Dim cantidadNueva As Integer
    Dim id As Integer
    Private gDbFile As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\basededatos.db3"

    Private Sub Form18_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Module1.aplicacion & " - Ajuste por producto"
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ean = TextBox1.Text


            Using Conn As New System.Data.SQLite.SQLiteConnection
                Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
                Conn.Open()

                'Add record.
                Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                    'Prepare base statement for inserting parametrized values.
                    Cmd.CommandText = "SELECT * FROM productos where ean = '" + Me.ean.ToString + "';"

                    'Fetch.
                    Try
                        Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                            'Return Reader
                            While Reader.Read()
                                Label2.Text = Reader.GetString(3)
                                Me.producto_id = Reader.GetInt32(0)
                                Me.cantidadActual = Reader.GetInt64(6)
                            End While
                        End Using
                    Catch
                        'Return DBNull.Value
                    End Try

                End Using

            End Using

            If Me.producto_id > 0 Then
                TextBox1.Enabled = False
                TextBox3.Enabled = True
                TextBox2.Text = Me.cantidadActual.ToString
                TextBox3.Focus()
            Else
                TextBox1.Text = ""
                MsgBox("El producto no esta en el catalogo.", vbCritical, Module1.aplicacion)
                TextBox1.Focus()
            End If

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Me.cantidadNueva = TextBox3.Text


            Dim respuestamensaje As Integer = MsgBox("¿ Deseas realizar el ajuste de inventario de este producto en este momento ?", vbYesNo, "Aviso")
            If respuestamensaje = 6 Then

                If Me.producto_id > 0 And Me.cantidadActual >= 0 And Me.cantidadNueva >= 0 Then

                    Dim comando As String = "UPDATE productos set inv = " & Me.cantidadNueva.ToString & " WHERE id = " & Me.producto_id.ToString & ";"
                    comando = comando & "INSERT INTO ajustes " _
    & "(sucursal, producto_id, cantidadvieja, cantidadnueva, usuario_id, fecha) " _
    & "values (" & Module1.sucursal.ToString & ", " & Me.producto_id.ToString & ", " & Me.cantidadActual.ToString & ", " & Me.cantidadNueva.ToString & ", " & Module1.id.ToString & ", datetime('now', 'localtime'));SELECT last_insert_rowid();"


                    Try
                        Dim ajuste As conexion = New conexion
                        Me.id = ajuste.ajusteInventario(comando)
                        If Me.id > 0 Then
                            PrintDocument1.Print()
                            enviaXML()
                            nuevoAjuste()
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, vbCritical, Module1.aplicacion)
                    End Try


                Else
                    MsgBox("Imposible cambiar debido a los parametros insertados.", vbCritical, Module1.aplicacion)
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, Module1.aplicacion)
        End Try

    End Sub

    Private Sub TextBox3_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyUp
        If e.KeyCode = Keys.Enter Then
            Try
                Me.cantidadNueva = TextBox3.Text
                Button1.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, Module1.aplicacion)
            End Try
        End If
    End Sub

    Private Sub nuevoAjuste()
        Me.producto_id = 0
        Me.cantidadActual = 0
        Me.cantidadNueva = 0
        Me.ean = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Label2.Text = "Producto"
        TextBox1.Enabled = True
        TextBox3.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        nuevoAjuste()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fuente As New Font("Courier New", 7, FontStyle.Bold)
        Dim ticketCabeza As conexion = New conexion()

        e.Graphics.DrawString(ticketCabeza.getTicketEncabezado(), fuente, Brushes.Black, 0, 0)

        Dim blackPen As New Pen(Color.Black, 1)

        ' Create points that define line. 
        Dim point1 As New Point(0, 170)
        Dim point2 As New Point(280, 170)

        Dim point3 As New Point(0, 180)
        Dim point4 As New Point(280, 180)

        e.Graphics.DrawString("FOLIO: " + Me.id.ToString, fuente, Brushes.Black, 0, 150)

        ' Draw line to screen.
        e.Graphics.DrawLine(blackPen, point1, point2)
        e.Graphics.DrawString("DETALLE DEL AJUSTE", fuente, Brushes.Black, 0, 170)
        e.Graphics.DrawLine(blackPen, point3, point4)

        e.Graphics.DrawString(ticketCabeza.getImpresionAjuste(Me.id), fuente, Brushes.Black, 0, 180)
    End Sub

    Private Sub enviaXML()
        Dim ajuste As conexion = New conexion()
        Dim envia As New Fargente.gente
        envia.ajuste(ajuste.creaXMLAjuste(Me.id))
    End Sub

End Class