Public Class Form17

    Private Sub Form17_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Module1.aplicacion
        RichTextBox1.Text = "No haz configurado correctamente la sucursal." _
            & vbCrLf.ToString _
            & vbCrLf.ToString _
            & "Para hacerlo entra al menu Configuración > Sucursal y modifica los parametros." _
            & vbCrLf.ToString _
            & "Una vez cambiado, reinicia la aplicación para que tome los cambios." _
            & vbCrLf.ToString _
            & "No olvides poner los datos de la sucursal(dirección) en el menu Configuración > Ticket."
    End Sub

End Class