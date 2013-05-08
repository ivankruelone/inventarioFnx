Public Class Form11

    Dim id As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim respuestamensaje As Integer = MsgBox("¿ Deseas recibir este fondo de caja ?" + vbCrLf.ToString + "Estas piezas se adicionaran al inventario.", vbYesNo, "Aviso")
        If respuestamensaje = 6 Then

            Dim fondo As Decimal

            Try
                fondo = TextBox1.Text

                Dim inserta As conexion = New conexion()

                Dim getId As Integer = inserta.insertFondo(fondo)

                If getId > 0 Then
                    Me.id = getId
                    PrintDocument1.Print()
                    Me.Close()
                Else
                    MsgBox("No se pudo insertar", MsgBoxStyle.Exclamation, "Fondo de caja")
                End If


            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Exclamation, "Fondo de caja")
            End Try

        End If

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
        e.Graphics.DrawString("DETALLE DEL FONDO DE CAJA", fuente, Brushes.Black, 0, 170)
        e.Graphics.DrawLine(blackPen, point3, point4)

        e.Graphics.DrawString(ticketCabeza.getFondoCajaDetalle(Me.id), fuente, Brushes.Black, 0, 180)

        Dim point5 As New Point(30, 280)
        Dim point6 As New Point(250, 280)

        e.Graphics.DrawLine(blackPen, point5, point6)
        e.Graphics.DrawString("                     FIRMA                     ", fuente, Brushes.Black, 0, 290)


    End Sub

    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class