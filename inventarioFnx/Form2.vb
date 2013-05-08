Option Strict On
Public Class Form2
    Private gDbFile As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\example.db3"

    'Declare form controls.
    Private gControlHeight As Integer = 24
    Private gPadding As Integer = 12
    Private lvItems As New System.Windows.Forms.ListView
    Private lblTextToInsert As New System.Windows.Forms.Label
    Private txtTextToInsert As New System.Windows.Forms.TextBox
    Private WithEvents btnSubmit As New System.Windows.Forms.Button
    Private WithEvents btnClearAll As New System.Windows.Forms.Button

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Setup form controls.
        With lvItems
            .View = System.Windows.Forms.View.Details
            .GridLines = True
            .Columns.Add("ROWID")
            .Columns.Add("Datetime")
            .Columns.Add("Sample Text")
        End With
        With lblTextToInsert
            .Text = "Text to insert"
            .Height = gControlHeight
        End With
        With txtTextToInsert
            .Text = ""
            .Height = gControlHeight
        End With
        With btnSubmit
            .Text = "Submit"
            .Height = gControlHeight
        End With
        With btnClearAll
            .Text = "Clear All"
            .Height = gControlHeight
        End With
        With Me.Controls
            .Add(lvItems)
            .Add(lblTextToInsert)
            .Add(txtTextToInsert)
            .Add(btnSubmit)
            .Add(btnClearAll)
        End With

        'Size form controls.
        Me.Width = 500
        SizeControls()

        'Create/Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Create table (only if it doesn't already exist).
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = "CREATE TABLE IF NOT EXISTS items " & _
                                  "(" & _
                                      "datetime INTEGER NOT NULL, " & _
                                      "sampletext TEXT " & _
                                  ")"
                Try
                    Cmd.ExecuteNonQuery()
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        'Update the listview to show all the items in the database.
        UpdateListView()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "INSERT INTO items " & _
                                      "(datetime, sampletext) " & _
                                  "VALUES " & _
                                      "(@datetime, @sampletext)"

                'Create & set parameters.
                Dim Timestamp As Int64 = GetTimestampUtc()
                Cmd.Parameters.AddWithValue("@datetime", Timestamp)
                Cmd.Parameters.AddWithValue("@sampletext", Trim(txtTextToInsert.Text))

                'Insert record.
                Try
                    Cmd.ExecuteNonQuery()
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        'Update the listview to show all the items in the database.
        UpdateListView()
    End Sub

    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click

        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "DELETE FROM items"

                'Delete.
                Try
                    Cmd.ExecuteNonQuery()
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        'Update the listview to show all the items in the database.
        UpdateListView()
    End Sub

    Private Sub UpdateListView()

        'Clear current items.
        lvItems.Items.Clear()

        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT ROWID, datetime, sampletext FROM items ORDER BY ROWID DESC"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            Dim Lvi As New System.Windows.Forms.ListViewItem
                            With Lvi
                                .Text = Reader.GetInt64(0).ToString
                                .SubItems.Add(GetLocalTimeFromUtcTimestamp(Reader.GetInt64(1)))
                                .SubItems.Add(Reader.GetString(2))
                            End With
                            lvItems.Items.Add(Lvi)
                        End While
                    End Using
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        'Resize columns.
        Dim NumOfCols As Integer = lvItems.Columns.Count
        Dim WidthMinusScrollbar = lvItems.ClientRectangle.Width
        If WidthMinusScrollbar > 0 Then
            Dim WidthToSet As Integer = Convert.ToInt32(WidthMinusScrollbar / NumOfCols)
            If WidthToSet > 0 Then
                For Each Col As System.Windows.Forms.ColumnHeader In lvItems.Columns
                    Col.Width = WidthToSet
                Next
            End If
        End If
    End Sub

    Private Function GetTimestampUtc(Optional ByVal OfSpecificDatetime As System.DateTime = Nothing) As Int64
        If OfSpecificDatetime = Nothing Then
            Return Convert.ToInt64(System.DateTime.UtcNow.Subtract(#1/1/1970#).TotalSeconds)
        Else
            Return Convert.ToInt64(OfSpecificDatetime.ToUniversalTime.Subtract(#1/1/1970#).TotalSeconds)
        End If
    End Function

    Private Function GetLocalTimeFromUtcTimestamp(ByVal Timestamp As Int64) As String
        Dim Dtime As New System.DateTime(1970, 1, 1, 0, 0, 0, 0)
        Dtime = Dtime.AddSeconds(Timestamp)
        Return Dtime.ToLocalTime.ToString("yyyy-MM-dd h:mm:ss tt")
    End Function


    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        SizeControls()
    End Sub

    Private Sub SizeControls()
        With lblTextToInsert
            .Location = New System.Drawing.Point(gPadding, Me.ClientRectangle.Height - (gPadding + gControlHeight))
        End With
        With txtTextToInsert
            .Location = New System.Drawing.Point(lblTextToInsert.Right + gPadding, lblTextToInsert.Top)
        End With
        With btnSubmit
            .Location = New System.Drawing.Point(txtTextToInsert.Right + gPadding, txtTextToInsert.Top)
        End With
        With btnClearAll
            .Location = New System.Drawing.Point(btnSubmit.Right + gPadding, txtTextToInsert.Top)
        End With
        With lvItems
            .Location = New System.Drawing.Point(0, 0)
            .Size = New System.Drawing.Size(Me.ClientRectangle.Width, lblTextToInsert.Top - gPadding)
        End With
    End Sub
End Class