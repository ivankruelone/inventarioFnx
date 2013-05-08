Public Class Form9
    Private gDbFile As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\basededatos.db3"

    Dim id As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim nomina As Integer = MaskedTextBox1.Text

        If nomina > 0 Then


            Using Conn As New System.Data.SQLite.SQLiteConnection
                Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
                Conn.Open()

                'Add record.
                Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                    'Prepare base statement for inserting parametrized values.
                    Cmd.CommandText = "SELECT * FROM usuarios where nomina = " + nomina.ToString

                    'Fetch.
                    Try
                        Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                            'Return Reader
                            Dim activa As Integer

                            While Reader.Read()
                                Label2.Text = Reader.GetString(1)
                                Label3.Text = Reader.GetString(3)
                                Label4.Text = Reader.GetInt32(5).ToString
                                activa = Reader.GetInt32(6)
                                Me.id = Reader.GetInt32(0)

                                If activa = 1 Then
                                    Label5.Text = "Activo"
                                    Button3.Enabled = True
                                Else
                                    Label5.Text = "Inactivo"
                                    Button2.Enabled = True
                                End If


                            End While

                        End Using
                    Catch
                        'Return DBNull.Value
                    End Try

                End Using

            End Using



        Else
            MsgBox("Teclea un numero de nominaa valido.", MsgBoxStyle.Exclamation, "Baja de usuarios")
        End If

    End Sub

    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim actualiza As conexion = New conexion()

        If actualiza.updateUsuario(Me.id) = True Then
            Button2.Enabled = False
            Button3.Enabled = False
            Button1.PerformClick()
        Else

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim actualiza As conexion = New conexion()

        If actualiza.updateUsuario2(Me.id) = True Then
            Button2.Enabled = False
            Button3.Enabled = False
            Button1.PerformClick()
        Else

        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button2.Enabled = False
        Button3.Enabled = False
        MaskedTextBox1.Text = 0

        Label2.Text = "Usuario"
        Label3.Text = "Nombre completo"
        Label4.Text = "Nomina"
        Label5.Text = "Activo"
        Me.id = 0
        MaskedTextBox1.Focus()

    End Sub
End Class