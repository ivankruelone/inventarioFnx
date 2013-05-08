Imports System.Xml
Imports System.IO

Public Class Form19

    Private Sub Form19_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Module1.aplicacion & " - Envio de ventas"
        actualizaVentas()
    End Sub

    Private Sub actualizaVentas()
        Dim servicio As New Fargente.gente
        Dim xmlCrea As conexion = New conexion
        Dim texto As String = ""

        Try
            Dim resultado As String = servicio.missing(Module1.sucursal.ToString)
            'Dim resultado As String = servicio.missing("18710")
            'texto = texto & resultado.ToString & vbCrLf.ToString
            Try

                Dim Xml As XmlDocument
                Dim NodeList As XmlNodeList
                Dim Node As XmlNode
                Try
                    Xml = New XmlDocument()
                    Xml.LoadXml(resultado)
                    NodeList = Xml.SelectNodes("/missing/miss")
                    Console.WriteLine("Nodos por Leer: " & NodeList.Count & vbNewLine)

                    Dim i As Integer = 1

                    texto = texto & "Inicio" & vbCrLf.ToString
                    texto = texto & "Renglones: " & NodeList.Count.ToString & vbCrLf.ToString

                    For Each Node In NodeList

                        'RichTextBox1.Text = "Ventas: " & (i / NodeList.Count) * 100 & "%, " & NodeList.Count.ToString & " Tipos."

                        With Node.Attributes

                            Try
                                'If insert.insertTipo(.GetNamedItem("id").Value, .GetNamedItem("tipo").Value, .GetNamedItem("salida").Value) = False Then
                                'Update.updateTipo(.GetNamedItem("id").Value, .GetNamedItem("tipo").Value, .GetNamedItem("salida").Value)
                                'End If

                                texto = texto & "del Folio: " & .GetNamedItem("inicio").Value.ToString & " hasta el Folio " & .GetNamedItem("fin").Value.ToString & vbCrLf.ToString

                                For index As Integer = .GetNamedItem("inicio").Value To .GetNamedItem("fin").Value

                                    texto = texto & "Envia id: " & index.ToString & vbCrLf.ToString

                                    Try
                                        Dim documento As String = xmlCrea.creaXML(index)
                                        Dim idbase As Integer = servicio.receta(documento)
                                        texto = texto & "Guardado como: " & idbase.ToString & vbCrLf.ToString
                                    Catch ex As Exception
                                        texto = texto & ex.Message & vbCrLf.ToString
                                    End Try
                                Next

                            Catch ex As Exception
                                Console.WriteLine("No se puede agregar el tipo" + ex.Message + ex.InnerException.ToString)
                            End Try
                        End With

                        i = i + 1
                    Next

                Catch ex As Exception
                    Console.WriteLine(ex.GetType.ToString & vbNewLine & ex.Message.ToString)
                Finally
                    Console.Read()
                End Try

            Catch

            End Try

        Catch ex As Exception
            MsgBox("Imposible acceder al servicio de farmacias de la gente." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Reloj Checador")
        End Try

        RichTextBox1.Text = texto
    End Sub


End Class