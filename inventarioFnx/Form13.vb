Public Class Form13

    Dim venta As Decimal
    Dim fondo As Decimal
    Dim retiro As Decimal
    Dim total As Decimal
    Dim dinero As Decimal
    Dim diff As Decimal

    Dim corteVenta As Decimal
    Dim corteFondo As Decimal
    Dim corteRetiro As Decimal
    Dim corteTotal As Decimal
    Dim corteDiff As Decimal
    Dim faltante As Decimal
    Dim sobrante As Decimal
    Dim id As Integer

    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim consulta As conexion = New conexion

        venta = consulta.getVentaCorte()
        fondo = consulta.getFondoCorte()
        retiro = consulta.getRetiroFondoCorte()
        total = venta + fondo - retiro


        TextBox1.Text = FormatCurrency(fondo).ToString
        TextBox1.Enabled = False
        TextBox1.TextAlign = HorizontalAlignment.Right

        TextBox2.Text = FormatCurrency(retiro).ToString
        TextBox2.Enabled = False
        TextBox2.TextAlign = HorizontalAlignment.Right

        TextBox3.Text = FormatCurrency(venta).ToString
        TextBox3.Enabled = False
        TextBox3.TextAlign = HorizontalAlignment.Right

        TextBox4.Text = FormatCurrency(total).ToString
        TextBox4.Enabled = False
        TextBox4.TextAlign = HorizontalAlignment.Right

        TextBox6.Enabled = False
        TextBox6.TextAlign = HorizontalAlignment.Right

        TextBox7.Enabled = False
        TextBox7.TextAlign = HorizontalAlignment.Right

        Button2.Enabled = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.dinero = TextBox5.Text

            diff = Me.dinero - total

            If diff < 0 Then
                TextBox6.Text = FormatCurrency(diff).ToString()
                TextBox7.Text = FormatCurrency(0).ToString()
            Else
                TextBox6.Text = FormatCurrency(0).ToString()
                TextBox7.Text = FormatCurrency(diff).ToString()
            End If

            Button2.Enabled = True
            Button1.Enabled = False

            TextBox5.Text = FormatCurrency(Me.dinero).ToString
            TextBox5.Enabled = False
            TextBox5.TextAlign = HorizontalAlignment.Right

        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Exclamation, "Corte de caja")
            Button2.Enabled = False
            TextBox6.Text = FormatCurrency(0).ToString()
            TextBox7.Text = FormatCurrency(0).ToString()


        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If dinero > 0 Then
            Dim respuestamensaje As Integer = MsgBox("¿ Deseas realizar el corte de caja en este momento ?", vbYesNo, "Aviso")
            If respuestamensaje = 6 Then

                corte()


            End If
        Else
            MsgBox("No hay nada en la casilla de dinero", MsgBoxStyle.Exclamation, "Corte de caja")
        End If


    End Sub

    Private Sub corte()

        Dim corte As conexion = New conexion

        Try

            Me.id = corte.insertaCorte()

            Me.corteVenta = corte.getInsertaVentaCorte(Me.id)
            Me.corteFondo = corte.getInsertaFondoCorte(Me.id)
            Me.corteRetiro = corte.getInsertaRetiroFondoCorte(Me.id)
            Me.corteTotal = Me.corteVenta + Me.corteFondo - Me.corteRetiro
            Me.corteDiff = Me.dinero - Me.corteTotal

            If Me.corteDiff < 0 Then
                Me.faltante = Me.corteDiff
                Me.sobrante = 0
            Else
                Me.sobrante = Me.corteDiff
                Me.faltante = 0
            End If

            corte.updateCorte(Me.id, Me.corteFondo, Me.corteRetiro, Me.corteVenta, Me.corteTotal, Me.dinero, Me.faltante, Me.sobrante)
            PrintDocument1.Print()
            enviaXML()
            Me.Close()

        Catch ex As Exception
            MsgBox("Error OK: " + ex.Message.ToString(), MsgBoxStyle.Exclamation, "Corte de caja")
        End Try


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button2.Enabled = False
        Button1.Enabled = True

        TextBox5.Text = ""
        TextBox5.Enabled = True
        TextBox5.TextAlign = HorizontalAlignment.Left

        TextBox6.Text = FormatCurrency(0).ToString()
        TextBox7.Text = FormatCurrency(0).ToString()

        TextBox5.Focus()

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

        ' Draw line to screen.
        e.Graphics.DrawLine(blackPen, point1, point2)
        e.Graphics.DrawString("DETALLE DEL CORTE DE CAJA", fuente, Brushes.Black, 0, 170)
        e.Graphics.DrawLine(blackPen, point3, point4)

        e.Graphics.DrawString(ticketCabeza.getCorteCajaDetalle(Me.id), fuente, Brushes.Black, 0, 180)

        Dim point5 As New Point(30, 350)
        Dim point6 As New Point(250, 350)

        e.Graphics.DrawLine(blackPen, point5, point6)
        e.Graphics.DrawString("                     FIRMA                     ", fuente, Brushes.Black, 0, 360)


    End Sub

    Private Sub enviaXML()
        Dim corte As conexion = New conexion()
        Dim enviaCorte As New Fargente.gente
        enviaCorte.corte(corte.creaXMLCorte(Me.id))
    End Sub

End Class