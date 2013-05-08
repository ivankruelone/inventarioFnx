Public Class Form7

    Private gDbFile As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\basededatos.db3"

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT * FROM ticket"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()

                            rfc.Text = Reader.GetString(0)
                            razonsocial.Text = Reader.GetString(1)
                            linea1.Text = Reader.GetString(2)
                            linea2.Text = Reader.GetString(3)
                            linea3.Text = Reader.GetString(4)
                            suc1.Text = Reader.GetString(5)
                            suc2.Text = Reader.GetString(6)
                            suc3.Text = Reader.GetString(7)

                        End While

                    End Using
                Catch
                    Return
                End Try

            End Using

        End Using

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim arfc As String
        Dim arazonsocial As String
        Dim alinea1 As String
        Dim alinea2 As String
        Dim alinea3 As String
        Dim asuc1 As String
        Dim asuc2 As String
        Dim asuc3 As String

        arfc = rfc.Text
        arazonsocial = razonsocial.Text
        alinea1 = linea1.Text
        alinea2 = linea2.Text
        alinea3 = linea3.Text
        asuc1 = suc1.Text
        asuc2 = suc2.Text
        asuc3 = suc3.Text

        Dim actualiza As conexion = New conexion()

        If actualiza.updateTicket(arfc, arazonsocial, alinea1, alinea2, alinea3, asuc1, asuc2, asuc3) = True Then
            Me.Close()
        End If

    End Sub

    Private Sub rfc_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles rfc.MaskInputRejected
        ToolTip1.ToolTipTitle = "Invalid Input"
        ToolTip1.Show("We're sorry, but only digits (0-9) are allowed in dates.", rfc, 5000)
    End Sub
End Class