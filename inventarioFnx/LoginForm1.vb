Public Class LoginForm1

    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Dim config As Integer = 0
    Dim destinos As Integer = 0
    Dim productos As Integer = 0
    Dim ticket As Integer = 0
    Dim tipo_salida As Integer = 0
    Dim usuarios As Integer = 0
    Private gDbFile As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\basededatos.db3"


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Dim login As conexion = New conexion()



        Dim usuario As String = UsernameTextBox.Text
        Dim pass As String = PasswordTextBox.Text

        If login.validaUsuario(usuario, pass) = True Then

            MDIParent1.Show()

            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
            UsernameTextBox.Focus()
            Me.Hide()
        Else
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
            Label1.Text = "Los datos no son correctos." + vbCrLf.ToString() + "Intentalo nuevamente."
            UsernameTextBox.Focus()
        End If


    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Acceso: " + Module1.aplicacion

        Dim crear As conexion = New conexion
        crear.crear()
        datos()

        If Me.config = 0 Then
            crear.inicialConfig()
        End If

        If Me.destinos = 0 Then
            crear.inicialDestinos()
        End If

        If Me.productos = 0 Then
            crear.inicialProductos()
        End If

        If Me.ticket = 0 Then
            crear.inicialTicket()
        End If

        If Me.tipo_salida = 0 Then
            crear.inicialTipo_salida()
        End If

        If Me.usuarios = 0 Then
            crear.inicialUsuarios()
        End If

    End Sub

    Private Sub datos()
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT (select count(*) from config) as config," _
                    & "(select count(*) from destinos) as destinos," _
                    & "(select count(*) from productos) as productos," _
                    & "(select count(*) from ticket) as ticket," _
                    & "(select count(*) from tipo_salida) as tipo_salida," _
                    & "(select count(*) from usuarios) as usuarios"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()

                            Me.config = Reader.GetInt32(0)
                            Me.destinos = Reader.GetInt32(1)
                            Me.productos = Reader.GetInt32(2)
                            Me.ticket = Reader.GetInt32(3)
                            Me.tipo_salida = Reader.GetInt32(4)
                            Me.usuarios = Reader.GetInt32(5)

                        End While
                    End Using
                Catch
                End Try

            End Using

        End Using

    End Sub

End Class