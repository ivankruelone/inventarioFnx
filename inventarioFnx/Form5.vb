Imports System.IO

Public Class Form5

    Dim id As Integer = 0
    Dim total As Decimal = 0
    Dim pago As Decimal = 0
    Dim cambio As Decimal = 0

    Private gDbFile As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\basededatos.db3"
    Private ListView1 As New System.Windows.Forms.ListView

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyCode = Keys.Enter Then

            Dim folio As conexion = New conexion()
            Dim folioStr As String = TextBox1.Text.Trim.ToUpper

            If folioStr = "" Then

            Else

                Try

                    Me.id = folio.insertVenta(folioStr)

                    If Me.id > 1 Then
                        TextBox2.Enabled = True
                        TextBox1.Enabled = False
                        TextBox2.Focus()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, vbExclamation)
                End Try

            End If

        End If
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyUp
        If e.KeyCode = Keys.Enter Then

            Dim ean As conexion = New conexion()
            Dim eanStr As String = TextBox2.Text.Trim.ToUpper

            If eanStr = "" Then

            Else

                If ean.getIdPrecioFromProducto(Me.id, eanStr) = True Then
                    UpdateListView()
                    TextBox2.Text = ""
                    TextBox2.Focus()
                End If

            End If

        ElseIf e.KeyCode = Keys.F4 Then

            TextBox3.Text = ""
            TextBox3.Show()
            TextBox3.Focus()

        ElseIf e.KeyCode = Keys.F8 Then

            Dim respuestamensaje As Integer = MsgBox("Deseas procesar esta venta", vbYesNo, "Aviso")


            If respuestamensaje = 6 Then

                Try

                    cierraVenta()
                    PrintDocument1.Print()
                    enviaXML(Me.id)
                    nuevaReceta()


                Catch ex As Exception
                    MsgBox(ex.Message, vbCritical)
                End Try

            End If


        End If


    End Sub

    Private Sub cierraVenta()
        Dim cierra As conexion = New conexion
        Dim comando As String = cierra.cerrarVentaGeneraQuery(Me.id)
        Try
            cierra.cerrarVenta(comando)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub


    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With ListView1
            .View = System.Windows.Forms.View.Details
            .GridLines = True
            .Columns.Add("Id")
            .Columns.Add("Clave")
            .Columns.Add("EAN")
            .Columns.Add("Descripción")
            .Columns.Add("Cantidad")
            .Columns.Add("Precio")
        End With

        With Me.Controls
            .Add(ListView1)
        End With


        ListView1.Items.Clear()
        UpdateListView()

        'Size form controls.
        Me.Width = 718
        SizeControls()
        TextBox3.Hide()
        ToolStripStatusLabel1.Text = "CAJERO: " + Module1.nombre

        TextBox2.Enabled = False
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
                Cmd.CommandText = "SELECT venta_d.producto_id, productos.clave, productos.ean, productos.descripcion, SUM(venta_d.cantidad) AS cantidad, SUM(venta_d.precio) AS precio FROM venta_d INNER JOIN productos ON venta_d.producto_id = productos.id WHERE(venta_d.c_id = " & Me.id & ") GROUP BY venta_d.producto_id"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            Dim Lvi As New System.Windows.Forms.ListViewItem
                            With Lvi
                                .Text = Reader.GetInt64(0).ToString
                                .SubItems.Add(Reader.GetString(1))
                                .SubItems.Add(Reader.GetString(2))
                                .SubItems.Add(Reader.GetString(3))
                                .SubItems.Add(Reader.GetInt64(4))
                                .SubItems.Add(Reader.GetDecimal(5).ToString)
                            End With
                            ListView1.Items.Add(Lvi)
                        End While
                    End Using
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        ListView1.Columns.Item(0).Width = 50
        ListView1.Columns.Item(1).Width = 90
        ListView1.Columns.Item(2).Width = 90
        ListView1.Columns.Item(3).Width = 300
        ListView1.Columns.Item(4).Width = 50
        ListView1.Columns.Item(5).Width = 120

        Dim actTotal As conexion = New conexion()
        Me.total = actTotal.getTotalTicket(Me.id)
        Me.cambio = Me.pago - Me.total

        Label3.Text = FormatCurrency(Me.total)
        Label5.Text = FormatCurrency(Me.pago)
        Label8.Text = FormatCurrency(Me.cambio)
    End Sub


    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        SizeControls()
    End Sub

    Private Sub SizeControls()
        With ListView1
            .Location = New System.Drawing.Point(16, 128)
            .Size = New System.Drawing.Size(Me.ClientRectangle.Width - 38, Me.ClientRectangle.Height - 148)
        End With
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim borra As conexion = New conexion()
        borra.BorraDetalle(Me.id)
        UpdateListView()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        nuevaReceta()
    End Sub

    Private Sub nuevaReceta()
        TextBox1.Enabled = True
        TextBox2.Enabled = False

        TextBox1.Text = ""
        TextBox2.Text = ""

        Me.id = 0
        Me.pago = 0
        Me.total = 0
        Me.cambio = 0

        UpdateListView()

        TextBox1.Focus()

    End Sub

    Private Sub enviaXML(ByVal id As Integer)
        Dim folio As conexion = New conexion()
        Dim enviaReceta As New Fargente.gente
        Dim resultado As String = enviaReceta.receta(folio.creaXML(id))
        Console.WriteLine(resultado)
    End Sub


    Private Sub TextBox3_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.pago = TextBox3.Text
            UpdateListView()
            TextBox3.Hide()
            TextBox2.Focus()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim respuestamensaje As Integer = MsgBox("Deseas cancelar esta venta", vbYesNo, "Aviso")


        If respuestamensaje = 6 Then
            If Me.id > 0 Then
                Dim cancela As conexion = New conexion
                If cancela.cancelaVenta(Me.id) = True Then
                    nuevaReceta()
                End If
            End If

        End If

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fuente As New Font("Courier New", 7, FontStyle.Bold)
        Dim ticketCabeza As conexion = New conexion()

        e.Graphics.DrawString(ticketCabeza.getTicket(Me.id), fuente, Brushes.Black, 0, 0)

        Dim blackPen As New Pen(Color.Black, 1)

        ' Create points that define line. 
        Dim point1 As New Point(0, 170)
        Dim point2 As New Point(280, 170)

        Dim point3 As New Point(0, 180)
        Dim point4 As New Point(280, 180)

        ' Draw line to screen.
        e.Graphics.DrawLine(blackPen, point1, point2)
        e.Graphics.DrawString("CANT. ARTICULO               PRECIO    IMPORTE", fuente, Brushes.Black, 0, 170)
        e.Graphics.DrawLine(blackPen, point3, point4)

        e.Graphics.DrawString(ticketCabeza.getTicketProductos(Me.id), fuente, Brushes.Black, 0, 180)

    End Sub

    Public Sub GiftReceipt()

        Try

            Dim displayString As String

            Dim ESC As String = Chr(&H1B)

            displayString = ESC + "!" + Chr(1) + ESC + "|cA" + "Store Name" + ESC + "|1lF"
            displayString += ESC + "|cA" + "Store Address" + ESC + "|1lF"
            displayString += ESC + "|2C" + ESC + "|cA" + ESC + "|bC" + "Gift Receipt" + ESC + "|1lF" + ESC + "|1lF"
            displayString += ESC + "|N" + ESC + "!" + Chr(1) + "  Transaction #:  " + vbTab.ToString() + "105" + ESC + "|1lF"

            displayString += "  Date:  " + Date.Today() + vbTab.ToString() + "Time: "

            displayString += DateAndTime.Now().ToLongTimeString() + ESC + "|1lF"

            displayString += "  Cashier:  " + CStr(54) + vbTab.ToString() + "Register:  " + CStr(5) + ESC + "|1lF" + ESC + "|1lF"

            displayString += ESC + "|2uC" + "  Item				 Description		   Quantity" + ESC + "|N" + ESC + "!" + Chr(1) + ESC + "|1lF" + ESC + "|1lF" + "  "

            'Iterate loop for each row of the Data Set.


            displayString += ESC + "|1lF"
            displayString += ESC + "|cA" + "Thank You for shopping" + ESC + "|1lF"
            displayString += ESC + "|cA" + "El Fenix" + ESC + "|1lF"
            displayString += ESC + "|cA" + "We hope you'll come back soon!" + ESC + "|1lF" + ESC + "|1lF" + ESC + "|fP"


            MsgBox("Gift Receipt printed Successfully.")

        Catch ex As Exception

            MsgBox(ex.ToString())

        End Try

    End Sub



    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

End Class