Public Class Form8

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim usuario As String = TextBox1.Text
        Dim password As String = TextBox2.Text
        Dim nombre As String = TextBox3.Text
        Dim nomina As Integer = MaskedTextBox1.Text
        Dim insertaUsuario As conexion = New conexion()

        If usuario.Length > 0 And password.Length > 0 And nombre.Length > 0 And nomina > 0 Then

            If insertaUsuario.insertUsuario(usuario, password, nombre, nomina) = True Then
                Me.Close()
            Else
                MsgBox("Error al agregar al usuario.", MsgBoxStyle.Exclamation, "Alta de usuario")
            End If
        Else
            MsgBox("Revisa los datos, no pueden estar vacios.", MsgBoxStyle.Exclamation, "Alta de usuario")
        End If
    End Sub
End Class