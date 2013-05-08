Public Class Form16

    Private ListView1 As New System.Windows.Forms.ListView
    Private gDbFile As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\basededatos.db3"

    Dim ean As String
    Dim producto_id As Integer
    Dim cantidad As Integer
    Dim salida_id As Integer


    Private Sub Form16_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With ListView1
            .View = System.Windows.Forms.View.Details
            .GridLines = True
            .Columns.Add("Clave")
            .Columns.Add("EAN")
            .Columns.Add("Descripción")
            .Columns.Add("Cantidad")
        End With

        With Me.Controls
            .Add(ListView1)
        End With


        UpdateListView()

        'Size form controls.
        Me.Width = 718
        SizeControls()

    End Sub

    Private Sub UpdateListView()

        'Clear current items.
        ListView1.Items.Clear()

        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT i.id, p.clave, p.ean, p.descripcion, sum(i.cantidad) as cantidad FROM salidas_t i INNER JOIN productos p ON i.producto_id = p.id GROUP BY producto_id"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            Dim Lvi As New System.Windows.Forms.ListViewItem
                            With Lvi
                                .Text = Reader.GetString(1)
                                .SubItems.Add(Reader.GetString(2))
                                .SubItems.Add(Reader.GetString(3))
                                .SubItems.Add(Reader.GetInt64(4))
                            End With
                            ListView1.Items.Add(Lvi)
                        End While
                    End Using
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        ListView1.Columns.Item(0).Width = 90
        ListView1.Columns.Item(1).Width = 90
        ListView1.Columns.Item(2).Width = 300
        ListView1.Columns.Item(3).Width = 50


        llenaTipo()
        llenaDestino()

    End Sub

    Private Sub llenaTipo()
        'Llenar combobox tipo
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT tipo, salida FROM tipo_salida;"
                Dim dt As New DataTable
                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        'Return Reader
                        dt.Load(Reader)


                        With ComboBox1
                            .DataSource = dt
                            .ValueMember = "tipo"
                            .DisplayMember = "salida"
                        End With

                    End Using
                Catch
                    'Return DBNull.Value
                End Try

            End Using

        End Using
    End Sub

    Private Sub llenaDestino()
        'Llenar combobox tipo
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT suc, nomsuc FROM destinos;"
                Dim dt As New DataTable
                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        'Return Reader
                        dt.Load(Reader)


                        With ComboBox2
                            .DataSource = dt
                            .ValueMember = "suc"
                            .DisplayMember = "nomsuc"
                        End With

                    End Using
                Catch
                    'Return DBNull.Value
                End Try

            End Using

        End Using
    End Sub

    Private Sub SizeControls()
        With ListView1
            .Location = New System.Drawing.Point(16, 128)
            .Size = New System.Drawing.Size(Me.ClientRectangle.Width - 38, Me.ClientRectangle.Height - 148)
        End With
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
                    Cmd.CommandText = "SELECT * FROM productos where ean = '" + Me.ean.ToString + "' or clave = '" + Me.ean.ToString + "';"

                    'Fetch.
                    Try
                        Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                            'Return Reader
                            If Reader.HasRows = True Then

                                While Reader.Read()
                                    Label4.Text = Reader.GetString(3)
                                    Me.producto_id = Reader.GetInt32(0)
                                End While

                            Else

                                Label4.Text = "Producto"
                                Me.producto_id = 0

                            End If
                        End Using
                    Catch
                        'Return DBNull.Value
                    End Try

                End Using

            End Using

            If Me.producto_id > 0 Then
                TextBox2.Focus()
            End If

        End If

    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyUp
        If e.KeyCode = Keys.Enter Then

            Try
                Me.cantidad = TextBox2.Text
                Dim inserta As conexion = New conexion
                If inserta.insertSalidaDetalle(Me.producto_id, Me.cantidad) = True Then
                    Me.producto_id = 0
                    Me.ean = vbNull
                    Me.cantidad = 0
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    Label4.Text = "Producto"
                    UpdateListView()
                    TextBox1.Focus()
                End If

            Catch ex As Exception

                Me.producto_id = 0
                Me.ean = vbNull
                Me.cantidad = 0
                TextBox1.Text = ""
                TextBox2.Text = ""
                Label4.Text = "Producto"
                UpdateListView()
                TextBox1.Focus()

            End Try






        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim borra As conexion = New conexion
        Try
            borra.borraUltimaSalida(borra.deshacerSalida())
            UpdateListView()
            TextBox1.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim respuestamensaje As Integer = MsgBox("¿ Deseas cerrar esta salida ?" + vbCrLf.ToString + "Estas piezas se adicionaran al inventario.", vbYesNo, "Aviso")
        If respuestamensaje = 6 Then

            Dim cerrar As conexion = New conexion

            Try

                Dim tipo As Integer = Me.ComboBox1.SelectedValue
                Dim destino As Integer = Me.ComboBox2.SelectedValue

                If tipo > 0 And destino > 0 Then
                    Me.salida_id = cerrar.insertSalidasControl(tipo, destino)

                    Try
                        Dim comando As String = cerrar.cerrarSalidaGeneraQuery(Me.salida_id)

                        cerrar.cerrarSalida(comando)
                        PrintDocument1.Print()
                        enviaXML()
                        Me.Close()

                    Catch ex As Exception
                        MsgBox(ex.Message, vbCritical)
                    End Try
                Else
                    MsgBox("Tipo o Destino no validos.")

                End If

            Catch ex As Exception
                MsgBox(ex.Message, vbCritical)
            End Try



        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

        e.Graphics.DrawString("FOLIO: " + ticketCabeza.getFolioEntradaSalida("salidas_c", Me.salida_id), fuente, Brushes.Black, 0, 150)

        ' Draw line to screen.
        e.Graphics.DrawLine(blackPen, point1, point2)
        e.Graphics.DrawString("DETALLE DE LA SALIDA DE MERCANCIA", fuente, Brushes.Black, 0, 170)
        e.Graphics.DrawLine(blackPen, point3, point4)

        e.Graphics.DrawString(ticketCabeza.getImpresionDetalleSalida(Me.salida_id), fuente, Brushes.Black, 0, 180)

    End Sub

    Private Sub enviaXML()
        Dim salida As conexion = New conexion()
        Dim envia As New Fargente.gente
        envia.salida(salida.creaXMLSalida(Me.salida_id))
    End Sub

End Class