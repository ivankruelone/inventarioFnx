Public Class Form4

    Private gDbFile As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\basededatos.db3"
    Private ListView1 As New System.Windows.Forms.ListView

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With ListView1
            .View = System.Windows.Forms.View.Details
            .GridLines = True
            .Columns.Add("ID")
            .Columns.Add("Clave")
            .Columns.Add("EAN")
            .Columns.Add("Descripción")
            .Columns.Add("Precio")
            .Columns.Add("Modificado")
        End With

        With Me.Controls
            .Add(ListView1)
        End With


        ListView1.Items.Clear()
        UpdateListView()

        'Size form controls.
        Me.Width = 600
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
                Cmd.CommandText = "SELECT * FROM productos ORDER BY id ASC"

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
                                .SubItems.Add(Reader.GetDecimal(4).ToString)
                                .SubItems.Add(Reader.GetString(5))
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

    End Sub


    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        SizeControls()
    End Sub

    Private Sub SizeControls()
        With ListView1
            .Location = New System.Drawing.Point(0, 0)
            .Size = New System.Drawing.Size(Me.ClientRectangle.Width, Me.ClientRectangle.Height)
        End With
    End Sub


End Class