Public Class Form6

    Private gDbFile As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\basededatos.db3"

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaskedTextBox1.Focus()

        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT * FROM config"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()

                            MaskedTextBox1.Text = Reader.GetInt32(1)
                            TextBox2.Text = Reader.GetString(2)

                        End While

                    End Using
                Catch
                    Return
                End Try

            End Using

        End Using

        llenaSucursal()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sucursal As Integer
        Dim nombre As String

        sucursal = MaskedTextBox1.Text
        nombre = TextBox2.Text

        Dim actualiza As conexion = New conexion()

        If actualiza.updateConfig(sucursal, nombre) = True Then
            Me.Close()
        End If


    End Sub

    Private Sub llenaSucursal()
        'Llenar combobox tipo
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT suc, nomsuc FROM destinos where suc between 18001 and 18999;"
                Dim dt As New DataTable
                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        'Return Reader
                        dt.Load(Reader)


                        With ComboBox1
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

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        MaskedTextBox1.Text = ComboBox1.SelectedValue.ToString
        TextBox2.Text = ComboBox1.Text
    End Sub
End Class