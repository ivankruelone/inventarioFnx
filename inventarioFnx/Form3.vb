Imports System.Xml
Imports System.IO

Public Class Form3

    Private Sub Form3_Shown1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim catalogo As New Fargente.gente
        Dim insert As conexion = New conexion()
        Dim update As conexion = New conexion()

        Try
            Dim resultado As String = catalogo.productos(insert.fechaMaxCatalogo)
            Try

                Dim Xml As XmlDocument
                Dim NodeList As XmlNodeList
                Dim Node As XmlNode
                Try
                    Xml = New XmlDocument()
                    Xml.LoadXml(resultado)
                    NodeList = Xml.SelectNodes("/catalogo/producto")
                    Console.WriteLine("Nodos por Leer: " & NodeList.Count & vbNewLine)

                    Dim i As Integer = 1

                    For Each Node In NodeList

                        Label1.Text = "Productos actualizados: " & (i / NodeList.Count) * 100 & "%, " & NodeList.Count.ToString & " Productos."

                        With Node.Attributes

                            Try
                                If insert.insertProducto(.GetNamedItem("id").Value, .GetNamedItem("clave").Value, .GetNamedItem("ean").Value, .GetNamedItem("descripcion").Value, .GetNamedItem("precio").Value, .GetNamedItem("cambio").Value) = False Then
                                    update.updateProducto(.GetNamedItem("id").Value, .GetNamedItem("clave").Value, .GetNamedItem("ean").Value, .GetNamedItem("descripcion").Value, .GetNamedItem("precio").Value, .GetNamedItem("cambio").Value)
                                End If
                            Catch ex As Exception
                                Console.WriteLine("No se puede agregar el producto" + ex.Message + ex.InnerException.ToString)
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

        actualizaSucursales()
        actualizaTipos()

    End Sub

    Private Sub actualizaSucursales()
        Dim catalogo As New Fargente.gente
        Dim insert As conexion = New conexion()
        Dim update As conexion = New conexion()

        Try
            Dim resultado As String = catalogo.sucursales(insert.fechaMaxCatalogo)
            Try

                Dim Xml As XmlDocument
                Dim NodeList As XmlNodeList
                Dim Node As XmlNode
                Try
                    Xml = New XmlDocument()
                    Xml.LoadXml(resultado)
                    NodeList = Xml.SelectNodes("/sucursales/sucursal")
                    Console.WriteLine("Nodos por Leer: " & NodeList.Count & vbNewLine)

                    Dim i As Integer = 1

                    For Each Node In NodeList

                        Label2.Text = "Destinos actualizados: " & (i / NodeList.Count) * 100 & "%, " & NodeList.Count.ToString & " Destinos."

                        With Node.Attributes

                            Try
                                If insert.insertDestino(.GetNamedItem("suc").Value, .GetNamedItem("nombre").Value) = False Then
                                    update.updateDestino(.GetNamedItem("suc").Value, .GetNamedItem("nombre").Value)
                                End If
                            Catch ex As Exception
                                Console.WriteLine("No se puede agregar la sucursal" + ex.Message + ex.InnerException.ToString)
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

    End Sub

    Private Sub actualizaTipos()
        Dim catalogo As New Fargente.gente
        Dim insert As conexion = New conexion()
        Dim update As conexion = New conexion()

        Try
            Dim resultado As String = catalogo.tiposalida(insert.fechaMaxCatalogo)
            Try

                Dim Xml As XmlDocument
                Dim NodeList As XmlNodeList
                Dim Node As XmlNode
                Try
                    Xml = New XmlDocument()
                    Xml.LoadXml(resultado)
                    NodeList = Xml.SelectNodes("/tipos/tipo")
                    Console.WriteLine("Nodos por Leer: " & NodeList.Count & vbNewLine)

                    Dim i As Integer = 1

                    For Each Node In NodeList

                        Label3.Text = "Tipos de salida actualizados: " & (i / NodeList.Count) * 100 & "%, " & NodeList.Count.ToString & " Tipos."

                        With Node.Attributes

                            Try
                                If insert.insertTipo(.GetNamedItem("id").Value, .GetNamedItem("tipo").Value, .GetNamedItem("salida").Value) = False Then
                                    update.updateTipo(.GetNamedItem("id").Value, .GetNamedItem("tipo").Value, .GetNamedItem("salida").Value)
                                End If
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

    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Module1.aplicacion
    End Sub
End Class