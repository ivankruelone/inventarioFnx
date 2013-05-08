Imports System.IO
Imports System.Net.NetworkInformation

Public Class conexion

    Private gDbFile As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\basededatos.db3"

    Function getMacAddress()

        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()

        Return nics(0).GetPhysicalAddress.ToString

    End Function

    Private Function nics(ByVal p1 As Integer) As Object
        Throw New NotImplementedException
    End Function

    Public Function crear()
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Create table (only if it doesn't already exist).
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = My.Resources.basededatos
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using
    End Function

    Public Function inicialConfig()
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Create table (only if it doesn't already exist).
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = My.Resources.config
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using
    End Function

    Public Function inicialDestinos()
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Create table (only if it doesn't already exist).
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = My.Resources.destinos
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using
    End Function

    Public Function inicialProductos()
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Create table (only if it doesn't already exist).
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = My.Resources.productos
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using
    End Function

    Public Function inicialTicket()
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Create table (only if it doesn't already exist).
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = My.Resources.ticket
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using
    End Function

    Public Function inicialTipo_salida()
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Create table (only if it doesn't already exist).
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = My.Resources.tipo_salida
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using
    End Function

    Public Function inicialUsuarios()
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Create table (only if it doesn't already exist).
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = My.Resources.usuarios
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using
    End Function

    Public Function insertProducto(ByVal id As Integer, ByVal clave As String, ByVal ean As String, ByVal descripcion As String, ByVal precio As Decimal, ByVal cambio As String)

        Dim Str As String = "INSERT INTO productos (id, clave, ean, descripcion, precio, cambio) values(" & id & ", '" & clave & "', '" & ean & "', '" & descripcion & "', " & precio & ", '" & cambio & "');"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function insertDestino(ByVal suc As Integer, ByVal nombre As String)

        Dim Str As String = "INSERT INTO destinos (suc, nomsuc) values(" & suc & ", '" & nombre & "');"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function insertTipo(ByVal id As Integer, ByVal tipo As Integer, ByVal salida As String)

        Dim Str As String = "INSERT INTO tipo_salida (id, tipo, salida) values(" & id & ", " & tipo & ", '" & nombre & "');"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function updateProducto(ByVal id As Integer, ByVal clave As String, ByVal ean As String, ByVal descripcion As String, ByVal precio As Decimal, ByVal cambio As String)

        Dim Str As String = "UPDATE productos set clave = '" & clave & "', ean = '" & ean & "', descripcion = '" & descripcion & "', precio = " & precio & ", cambio = '" & cambio & "' where id = " & id & ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function updateDestino(ByVal suc As Integer, ByVal nombre As String)

        Dim Str As String = "UPDATE destinos set nomsuc = '" & nombre & "' where suc = " & suc & ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function updateTipo(ByVal id As Integer, ByVal tipo As Integer, ByVal salida As String)

        Dim Str As String = "UPDATE tipo_salida set tipo = " & tipo & ", salida = '" & salida & "' where id = " & id & ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function getProductos()
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT * FROM productos ORDER BY id DESC"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Return Reader
                    End Using
                Catch
                    Return DBNull.Value
                End Try

            End Using

        End Using

    End Function

    Public Function getFolio(ByVal folio As String)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT * FROM venta_c WHERE folio = '" & folio & "'"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()

                        If Reader.HasRows = True Then
                            Return True
                        Else
                            Return False
                        End If

                    End Using
                Catch
                    Return DBNull.Value
                End Try

            End Using

        End Using

    End Function

    Public Function getIdFolio(ByVal folio As String)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT id FROM venta_c WHERE folio = '" & folio & "'"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim id As Integer
                        While Reader.Read()

                            id = Reader.GetInt64(0)

                        End While
                        Return id
                    End Using
                Catch
                    Return DBNull.Value
                End Try

            End Using

        End Using

    End Function


    Public Function insertVenta(ByVal folio As String)

        Dim Str As String = "INSERT INTO venta_c (folio, fecha, usuario_id, sucursal) values('" & folio & "', datetime('now', 'localtime'), " + Module1.id.ToString() + ", " + Module1.sucursal.ToString() + ");SELECT last_insert_rowid();"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim id As Integer = Cmd.ExecuteScalar()
                    Return id
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message, vbCritical)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function fechaActual()

        Dim Str As String = "SELECT datetime('now', 'localtime');"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim fecha As String = Cmd.ExecuteScalar()
                    Return fecha
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function fechaMaxCatalogo()

        Dim Str As String = "SELECT ifnull(max(cambio), '0000-00-00 00:00:00') from productos;"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim fecha As String = Cmd.ExecuteScalar()
                    Return fecha
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function cancelaVenta(ByVal id As Integer)

        Dim Str As String = "DELETE FROM venta_c WHERE id = " + id.ToString + ";DELETE FROM venta_d WHERE c_id = " + id.ToString + ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteScalar()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function getIdPrecioFromProducto(ByVal c_id As String, ByVal ean As String)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT id, precio FROM productos WHERE ean = '" & ean & "'"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim id As Integer
                        Dim precio As Decimal
                        If Reader.HasRows = True Then
                            While Reader.Read()

                                id = Reader.GetInt64(0)
                                precio = Reader.GetDecimal(1)

                            End While
                            Return insertVentaDetalle(c_id, id, precio)
                        Else
                            MsgBox("Este producto no esta en el catalogo.", vbCritical, Module1.aplicacion)
                            Return True
                        End If
                    End Using
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function

    Public Function getTotalTicket(ByVal id As Integer)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT ifnull(sum(precio * cantidad), 0) as total FROM venta_d WHERE c_id = " & id

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim total As Decimal
                        While Reader.Read()

                            total = Reader.GetDecimal(0)

                        End While
                        Return total
                    End Using
                Catch
                    Return 0
                End Try

            End Using

        End Using

    End Function

    Public Function insertVentaDetalle(ByVal c_id As String, ByVal producto_id As Integer, ByVal precio As Decimal)

        Dim Str As String = "INSERT INTO venta_d (c_id, producto_id, precio, cantidad) values(" & c_id & ", " & producto_id & ", " & precio & ", 1)"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function


    Public Function BorraDetalle(ByVal c_id As String)

        Dim Str As String = "Delete from venta_d where c_id = " & c_id
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function creaXML(ByVal id As Integer)

        Dim xDoc As String = ""
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT v.sucursal, v.id, v.folio, v.fecha, v.enviada, v.corte_id, v.usuario_id FROM venta_c v where v.id = " & id

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            xDoc = "<?xml version='1.0'?>" _
                                   + "<receta suc='" & Reader.GetInt64(0) & "' id='" & Reader.GetInt64(1) & "' folio='" & Reader.GetString(2) & "' fecha='" & Reader.GetString(3) & "' enviada='" & Reader.GetInt16(4) & "' corte='" & Reader.GetInt16(5) & "' usuario_id='" & Reader.GetInt64(6) & "'>" _
                                   + creaXML2(id) _
                                  + "</receta>"


                        End While

                    End Using
                    Return xDoc
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function

    Public Function creaXML2(ByVal id As Integer)

        Dim xDoc As String = ""
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT v.*, inv FROM venta_d v left join productos p on v.producto_id = p.id where c_id = " & id

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            xDoc = xDoc + "<producto>" _
        + "<id>" & Reader.GetInt64(0) & "</id>" _
        + "<producto_id>" & Reader.GetInt64(2) & "</producto_id>" _
        + "<piezas>" & Reader.GetInt64(4) & "</piezas>" _
        + "<precio>" & Reader.GetDecimal(3) & "</precio>" _
        + "<inv>" & Reader.GetInt32(5) & "</inv>" _
        + "</producto>"


                        End While

                    End Using
                    Return xDoc
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function

    Public Function getTicket(ByVal id As Integer)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT * FROM config cross join ticket"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim cabeza As String = ""
                        While Reader.Read()

                            cabeza = cabeza + Reader.GetString(4) + vbCrLf.ToString()
                            cabeza = cabeza + "R. F. C.: " + Reader.GetString(3) + vbCrLf.ToString()
                            cabeza = cabeza + Reader.GetString(5) + vbCrLf.ToString()
                            cabeza = cabeza + Reader.GetString(6) + vbCrLf.ToString()
                            cabeza = cabeza + Reader.GetString(7) + vbCrLf.ToString() + vbCrLf.ToString()

                            cabeza = cabeza + "SUCURSAL: " + Reader.GetInt32(1).ToString() + " - " + Reader.GetString(2) + vbCrLf.ToString()

                            cabeza = cabeza + "LUGAR DE EXPEDICIÓN: " + vbCrLf.ToString()

                            cabeza = cabeza + Reader.GetString(8) + vbCrLf.ToString()
                            cabeza = cabeza + Reader.GetString(9) + vbCrLf.ToString()
                            cabeza = cabeza + Reader.GetString(10) + vbCrLf.ToString() + vbCrLf.ToString()

                            cabeza = cabeza + "FECHA:   " + Date.Today() + vbTab.ToString() + "HORA: " + vbTab.ToString() + DateAndTime.Now().ToLongTimeString() + vbCrLf.ToString()
                            cabeza = cabeza + "No. de Ticket: " + id.ToString() + vbCrLf.ToString()


                        End While
                        Return cabeza
                    End Using
                Catch
                    Return 0
                End Try

            End Using

        End Using

    End Function

    Public Function getTicketProductos(ByVal id As Integer)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT sum(cantidad), descripcion, d.precio, sum(d.precio * d.cantidad)" _
                                    + " FROM venta_d d" _
                                    + " left join productos p on d.producto_id = p.id" _
                                    + " where(d.c_id = " + id.ToString() + ")" _
                                    + " group by producto_id"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()

                        Dim detalle As String = ""

                        Dim cantidad As String = ""
                        Dim cantidadLen As Integer = 0

                        Dim descripcion As String = ""
                        Dim descripcionLen As Integer = 0

                        Dim precio As String = ""
                        Dim precioLen As Integer = 0

                        Dim importe As String = ""
                        Dim importeLen As Integer = 0

                        Dim totalPagar As Decimal = 0
                        Dim pagar As String = ""
                        Dim numeroaletra As String = ""

                        While Reader.Read()

                            cantidad = FormatNumber(Reader.GetInt32(0), 0).ToString()
                            cantidadLen = cantidad.Length

                            If cantidadLen <= 4 Then
                                cantidad = cantidad.PadLeft(5, " ")
                            End If

                            descripcion = Reader.GetString(1)
                            descripcionLen = descripcion.Length

                            If descripcionLen <= 20 Then
                                descripcion = descripcion.PadRight(20, " ")
                            Else
                                descripcion = descripcion.Substring(0, 20)
                            End If

                            precio = FormatNumber(Reader.GetDecimal(2), 2).ToString()
                            precioLen = precio.Length

                            If precioLen <= 8 Then
                                precio = precio.PadLeft(8, " ")
                            Else
                                precio = precio.Substring(precioLen - 8, 8)
                            End If

                            importe = FormatNumber(Reader.GetDecimal(3), 2).ToString()
                            importeLen = importe.Length

                            If importeLen <= 10 Then
                                importe = importe.PadLeft(10, " ")
                            Else
                                importe = importe.Substring(importeLen - 10, 10)
                            End If

                            totalPagar = totalPagar + Reader.GetDecimal(3)
                            pagar = FormatCurrency(totalPagar).ToString
                            pagar = "             TOTAL A PAGAR " + pagar.PadLeft(19, " ")

                            detalle = detalle + cantidad + " " + descripcion + " " + precio + " " + importe + vbCrLf.ToString()

                        End While

                        numeroaletra = Numalet.ToCardinal(totalPagar).ToUpper()

                        detalle = detalle + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + pagar + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + "SON " + numeroaletra + vbCrLf.ToString()
                        detalle = detalle + "ENTREGADA LA MERCANCIA NO HAY DEVOLUCIONES." + vbCrLf.ToString()
                        detalle = detalle + "GRACIAS POR SU COMPRA."

                        Return detalle
                    End Using
                Catch
                    Return 0
                End Try

            End Using

        End Using

    End Function

    Public Function updateConfig(ByVal sucursal As Integer, ByVal nombre As String)

        Dim Str As String = "UPDATE config set sucursal = '" & sucursal & "', nombre = '" & nombre & "' where id = 1"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function updateTicket(ByVal rfc As String, _
                                 ByVal razonsocial As String, _
                                 ByVal linea1 As String, _
                                 ByVal linea2 As String, _
                                 ByVal linea3 As String, _
                                 ByVal suc1 As String, _
                                 ByVal suc2 As String, _
                                 ByVal suc3 As String)

        Dim Str As String = "UPDATE ticket set rfc = '" & rfc & "', razonsocial = '" & razonsocial & "', linea1 = '" & linea1 & "', linea2 = '" & linea2 & "', linea3 = '" & linea3 & "', suc1 = '" & suc1 & "', suc2 = '" & suc2 & "', suc3 = '" & suc3 & "' where id = 1"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function validaUsuario(ByVal usuario As String, ByVal pass As String)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT u.*, c.sucursal, c.nombre FROM usuarios u CROSS JOIN config c WHERE u.username = '" & usuario & "' and u.password = '" & pass & "' and u.activo = 1 and c.id = 1"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()

                        If Reader.HasRows = True Then

                            While Reader.Read()

                                Module1.id = Reader.GetInt32(0)
                                Module1.nombre = Reader.GetString(3)
                                Module1.nivel = Reader.GetInt32(4)
                                Module1.nomina = Reader.GetInt32(5)
                                Module1.sucursal = Reader.GetInt32(7)
                                Module1.nombreSucursal = Reader.GetString(8)
                                Module1.maquina = getMacAddress()

                            End While

                            Return True
                        Else
                            Return False
                        End If

                    End Using
                Catch
                    Return DBNull.Value
                End Try

            End Using

        End Using

    End Function

    Public Function insertUsuario(ByVal usuario As String, ByVal password As String, ByVal nombre As String, ByVal nomina As Integer)

        Dim Str As String = "INSERT INTO usuarios (username, password, nombre, nivel, nomina) values('" & usuario & "', '" & password & "', '" & nombre.ToUpper() & "', 2, " & nomina & ")"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function updateUsuario(ByVal id As Integer)

        Dim Str As String = "UPDATE usuarios set activo =  0 where id = " & id & ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function updateUsuario2(ByVal id As Integer)

        Dim Str As String = "UPDATE usuarios set activo =  1 where id = " & id & ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function insertFondo(ByVal fondo As String)

        Dim Str As String = "INSERT INTO fondos (monto, fecha, responsable) values('" & fondo & "', datetime('now', 'localtime'), " + Module1.id.ToString() + ");SELECT last_insert_rowid();"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim id As Integer = Cmd.ExecuteScalar()
                    Console.WriteLine(id.ToString)
                    Return id
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function insertRetiroFondo(ByVal fondo As String)

        Dim Str As String = "INSERT INTO retiro_fondo (monto, fecha, responsable) values('" & fondo & "', datetime('now', 'localtime'), " + Module1.id.ToString() + ");SELECT last_insert_rowid();"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim id As Integer = Cmd.ExecuteScalar()
                    Console.WriteLine(id.ToString)
                    Return id
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function


    Public Function getTicketEncabezado()
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT * FROM config cross join ticket"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim cabeza As String = ""
                        While Reader.Read()

                            cabeza = cabeza + Reader.GetString(4) + vbCrLf.ToString()
                            cabeza = cabeza + "R. F. C.: " + Reader.GetString(3) + vbCrLf.ToString()
                            cabeza = cabeza + Reader.GetString(5) + vbCrLf.ToString()
                            cabeza = cabeza + Reader.GetString(6) + vbCrLf.ToString()
                            cabeza = cabeza + Reader.GetString(7) + vbCrLf.ToString() + vbCrLf.ToString()

                            cabeza = cabeza + "SUCURSAL: " + Reader.GetInt32(1).ToString() + " - " + Reader.GetString(2) + vbCrLf.ToString()

                            cabeza = cabeza + "LUGAR DE EXPEDICIÓN: " + vbCrLf.ToString()

                            cabeza = cabeza + Reader.GetString(8) + vbCrLf.ToString()
                            cabeza = cabeza + Reader.GetString(9) + vbCrLf.ToString()
                            cabeza = cabeza + Reader.GetString(10) + vbCrLf.ToString() + vbCrLf.ToString()

                            cabeza = cabeza + "FECHA:   " + Date.Today() + vbTab.ToString() + "HORA: " + vbTab.ToString() + DateAndTime.Now().ToLongTimeString() + vbCrLf.ToString()


                        End While
                        Return cabeza
                    End Using
                Catch
                    Return 0
                End Try

            End Using

        End Using

    End Function

    Public Function getFondoCajaDetalle(ByVal id As Integer)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT * FROM fondos where id = " & id.ToString

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim detalle As String = ""
                        While Reader.Read()

                            detalle = detalle + "Id: " + Reader.GetInt32(0).ToString() + vbCrLf.ToString()
                            detalle = detalle + "Fecha: " + Reader.GetString(2) + vbCrLf.ToString()
                            detalle = detalle + "Monto: " + FormatCurrency(Reader.GetDecimal(1)) + vbCrLf.ToString()
                            detalle = detalle + "Resp.: " + Module1.nombre.ToString() + vbCrLf.ToString()
                            detalle = detalle + "No. Nomina: " + Module1.nomina.ToString() + vbCrLf.ToString() + vbCrLf.ToString()

                        End While
                        Return detalle
                    End Using
                Catch
                    Return 0
                End Try

            End Using

        End Using

    End Function

    Public Function getRetiroFondoCajaDetalle(ByVal id As Integer)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT * FROM retiro_fondo where id = " & id.ToString

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim detalle As String = ""
                        While Reader.Read()

                            detalle = detalle + "Id: " + Reader.GetInt32(0).ToString() + vbCrLf.ToString()
                            detalle = detalle + "Fecha: " + Reader.GetString(2) + vbCrLf.ToString()
                            detalle = detalle + "Monto: " + FormatCurrency(Reader.GetDecimal(1)) + vbCrLf.ToString()
                            detalle = detalle + "Resp.: " + Module1.nombre.ToString() + vbCrLf.ToString()
                            detalle = detalle + "No. Nomina: " + Module1.nomina.ToString() + vbCrLf.ToString() + vbCrLf.ToString()

                        End While
                        Return detalle
                    End Using
                Catch
                    Return 0
                End Try

            End Using

        End Using

    End Function

    Public Function getVentaCorte()

        Dim Str As String = "SELECT ifnull(sum(precio * cantidad), 0) as venta FROM venta_c c " _
& "left join venta_d d on c.id = d.c_id " _
& "where c.corte_id = 0"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim venta As Decimal = Cmd.ExecuteScalar()
                    Console.WriteLine(venta.ToString)
                    Return venta
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function getFondoCorte()

        Dim Str As String = "SELECT ifnull(sum(monto), 0) as monto from fondos where corte_id = 0"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim fondo As Decimal = Cmd.ExecuteScalar()
                    Console.WriteLine(fondo.ToString)
                    Return fondo
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function getRetiroFondoCorte()

        Dim Str As String = "SELECT ifnull(sum(monto), 0) as monto from retiro_fondo where corte_id = 0"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim retiro As Decimal = Cmd.ExecuteScalar()
                    Console.WriteLine(retiro.ToString)
                    Return retiro
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function insertaCorte()

        Dim Str As String = "INSERT INTO cortes (fecha, usuario_id) values(datetime('now', 'localtime'), " + Module1.id.ToString() + ");SELECT last_insert_rowid();"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim id As Integer = Cmd.ExecuteScalar()
                    Console.WriteLine(id.ToString)
                    Return id
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function


    Public Function getInsertaVentaCorte(ByVal id As Integer)

        Dim Str As String = "UPDATE venta_c set corte_id = " & id.ToString() & " where corte_id = 0;SELECT ifnull(sum(precio * cantidad), 0) as venta FROM venta_c c " _
& "left join venta_d d on c.id = d.c_id " _
& "where c.corte_id = " & id.ToString
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim venta As Decimal = Cmd.ExecuteScalar()
                    Console.WriteLine(venta.ToString)
                    Return venta
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function getInsertaFondoCorte(ByVal id As Integer)

        Dim Str As String = "UPDATE fondos set corte_id = " & id.ToString() & " WHERE corte_id = 0;SELECT ifnull(sum(monto), 0) as monto from fondos where corte_id = " & id.ToString()
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim fondo As Decimal = Cmd.ExecuteScalar()
                    Console.WriteLine(fondo.ToString)
                    Return fondo
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function getInsertaRetiroFondoCorte(ByVal id As Integer)

        Dim Str As String = "UPDATE retiro_fondo set corte_id = " & id.ToString() & " WHERE corte_id = 0;SELECT ifnull(sum(monto), 0) as monto from retiro_fondo where corte_id = " & id.ToString()
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim retiro As Decimal = Cmd.ExecuteScalar()
                    Console.WriteLine(retiro.ToString)
                    Return retiro
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function updateCorte(ByVal id As Integer, ByVal fondo As Decimal, ByVal retiro As Decimal, ByVal ventas As Decimal, ByVal total As Decimal, ByVal dinero As Decimal, ByVal faltante As Decimal, ByVal sobrante As Decimal)

        Dim Str As String = "UPDATE cortes set fondo = " & fondo & ", retiro = " & retiro & ", ventas = " & ventas & ", total = " & total & ", dinero = " & dinero & ", faltante = " & faltante & ", sobrante = " & sobrante & " where id = " & id.ToString & ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function getCorteCajaDetalle(ByVal id As Integer)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT * FROM cortes where id = " & id.ToString

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim detalle As String = ""
                        While Reader.Read()

                            detalle = detalle + " Id:        " + Reader.GetInt32(0).ToString() + vbCrLf.ToString()
                            detalle = detalle + " Fecha:     " + Reader.GetString(8) + vbCrLf.ToString()
                            detalle = detalle + "+ Fondo:    " + FormatCurrency(Reader.GetDecimal(1)).ToString().PadLeft(20, " ") + vbCrLf.ToString()
                            detalle = detalle + "- Retiro:   " + FormatCurrency(Reader.GetDecimal(2)).ToString().PadLeft(20, " ") + vbCrLf.ToString()
                            detalle = detalle + "+ Ventas:   " + FormatCurrency(Reader.GetDecimal(3)).ToString().PadLeft(20, " ") + vbCrLf.ToString()
                            detalle = detalle + "= Total:    " + FormatCurrency(Reader.GetDecimal(4)).ToString().PadLeft(20, " ") + vbCrLf.ToString()
                            detalle = detalle + "  Dinero:   " + FormatCurrency(Reader.GetDecimal(5)).ToString().PadLeft(20, " ") + vbCrLf.ToString()
                            detalle = detalle + "  Faltante: " + FormatCurrency(Reader.GetDecimal(6)).ToString().PadLeft(20, " ") + vbCrLf.ToString()
                            detalle = detalle + "  Sobrante: " + FormatCurrency(Reader.GetDecimal(7)).ToString().PadLeft(20, " ") + vbCrLf.ToString() + vbCrLf.ToString()
                            detalle = detalle + "Resp.:      " + Module1.nombre.ToString() + vbCrLf.ToString()
                            detalle = detalle + "No. Nomina: " + Module1.nomina.ToString() + vbCrLf.ToString() + vbCrLf.ToString()

                        End While
                        Return detalle
                    End Using
                Catch
                    Return 0
                End Try

            End Using

        End Using

    End Function

    Public Function creaXMLCorte(ByVal id As Integer)

        Dim xDoc As String = ""
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT c.*, sucursal FROM cortes c cross join config g where c.id = " & id.ToString()

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            xDoc = "<?xml version='1.0' ?>" _
                                   + "<corte suc='" & Reader.GetInt64(10) & "' id='" & Reader.GetInt64(0) & "' fondo='" & Reader.GetDecimal(1) & "' retiro='" & Reader.GetDecimal(2) & "' ventas='" & Reader.GetDecimal(3) & "' total='" & Reader.GetDecimal(4) & "' dinero='" & Reader.GetDecimal(5) & "' faltante='" & Reader.GetDecimal(6) & "' sobrante='" & Reader.GetDecimal(7) & "' fecha='" & Reader.GetString(8) & "' usuario_id='" & Reader.GetInt64(9) & "'>" _
                                   + creaXMLCorte2(id) _
                                   + "</corte>"


                        End While

                    End Using
                    Return xDoc
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function


    Public Function creaXMLCorte2(ByVal id As Integer)

        Dim xDoc As String = ""
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT id FROM venta_c where corte_id = " & id

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            xDoc = xDoc + "<r>" _
        + "<id>" & Reader.GetInt64(0) & "</id>" _
        + "</r>"


                        End While

                    End Using
                    Return xDoc
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function

    Public Function insertInv(ByVal producto_id As Integer, ByVal cantidad As Integer)

        Dim Str As String = "INSERT INTO inv (producto_id, cantidad) values(" & producto_id.ToString & ", " & cantidad.ToString & ");"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function getUltimoMovInv()

        Dim Str As String = "SELECT ifnull(max(id), 0) as id FROM inv"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim ultimo As Integer = Cmd.ExecuteScalar()
                    Return ultimo
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function borraUltimoMovInv(ByVal id As Integer)

        Dim Str As String = "DELETE FROM inv where id = " & id.ToString & ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function compruebaCapturaInv()

        Dim Str As String = "select ifnull(count(*), 0) from inv;"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Dim cuenta As Integer
                Try
                    cuenta = Cmd.ExecuteScalar()
                    Return cuenta
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function



    Public Function getInsertInvReinicia()

        Dim Str As String = "insert into inv_c (fecha) values (datetime('now', 'localtime'));SELECT last_insert_rowid();"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim id As Integer = Cmd.ExecuteScalar()
                    Return id
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function reiniciaInvPaso2(ByVal id As Integer)

        Dim Str As String = "insert into inv_h (c_id, producto_id, cantidad) select '" & id.ToString & "', id, inv from productos;INSERT INTO inv_d (c_id, producto_id, cantidad) select '" & id.ToString & "', producto_id, sum(cantidad) from inv group by producto_id;update productos set inv = 0;"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteScalar()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function


    Public Function actualizaInvProductosSelect()
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT producto_id, sum(cantidad) FROM inv group by producto_id;"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim comando As String = ""
                        While Reader.Read()

                            comando = comando + "UPDATE productos set inv = " & Reader.GetInt32(1) & " where id = " & Reader.GetInt32(0) & ";"

                        End While
                        Return comando
                    End Using
                Catch
                    Return DBNull.Value
                End Try

            End Using

        End Using

    End Function

    Public Function actualizaInvProductos(ByVal comando As String)

        Dim Str As String = comando
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function borraInvReinicio()

        Dim Str As String = "DELETE FROM inv;"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function


    Public Function getImpresionDetalleInv(ByVal id As Integer)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT ean, descripcion, cantidad FROM inv_d i " _
                    & "left join productos p on i.producto_id = p.id " _
                & "where c_id = " & id.ToString

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()

                        Dim detalle As String = ""

                        Dim cantidad As String = ""
                        Dim cantidadLen As Integer = 0

                        Dim descripcion As String = ""
                        Dim descripcionLen As Integer = 0

                        Dim ean As String = ""
                        Dim eanLen As Integer = 0

                        Dim total As Integer = 0
                        Dim totalp As String = ""

                        While Reader.Read()

                            cantidad = FormatNumber(Reader.GetInt32(2), 0).ToString()
                            cantidadLen = cantidad.Length

                            If cantidadLen <= 6 Then
                                cantidad = cantidad.PadLeft(6, " ")
                            End If

                            descripcion = Reader.GetString(1)
                            descripcionLen = descripcion.Length

                            If descripcionLen <= 23 Then
                                descripcion = descripcion.PadRight(23, " ")
                            Else
                                descripcion = descripcion.Substring(0, 23)
                            End If

                            ean = Reader.GetString(0).ToString()
                            eanLen = ean.Length

                            If eanLen <= 15 Then
                                ean = ean.PadLeft(15, " ")
                            Else
                                ean = ean.Substring(eanLen - 8, 8)
                            End If


                            total = total + Reader.GetInt32(2)
                            totalp = FormatNumber(total, 0).ToString
                            totalp = "                     TOTAL " + totalp.PadLeft(19, " ")

                            detalle = detalle + ean + " " + descripcion + " " + cantidad + vbCrLf.ToString()

                        End While


                        detalle = detalle + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + totalp + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + "   _________________________________________   " + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + "                     FIRMA                     " + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString()
                        Return detalle
                    End Using
                Catch
                    Return 0
                End Try

            End Using

        End Using

    End Function

    Public Function creaXMLInvReinicia(ByVal id As Integer)

        Dim xDoc As String = ""
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT c.*, sucursal FROM inv_c c cross join config g where c.id = " & id.ToString()

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            xDoc = "<?xml version='1.0' ?>" _
                                   + "<inventario suc='" & Reader.GetInt64(3) & "' id='" & Reader.GetInt64(0) & "' fecha='" & Reader.GetString(1) & "' usuario_id='" & Reader.GetInt64(2) & "'>" _
                                   + creaXMLInvReinicia2(id) _
                                   + creaXMLInvReinicia3(id) _
                                   + "</inventario>"


                        End While

                    End Using
                    Console.WriteLine(xDoc)
                    Return xDoc
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function

    Public Function creaXMLInvReinicia2(ByVal id As Integer)

        Dim xDoc As String = ""
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT id, inv FROM productos"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            xDoc = xDoc + "<d>" _
        + "<id>" & Reader.GetInt64(0) & "</id>" _
        + "<can>" & Reader.GetInt64(1) & "</can>" _
        + "</d>"


                        End While

                    End Using
                    Return xDoc
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function

    Public Function creaXMLInvReinicia3(ByVal id As Integer)

        Dim xDoc As String = ""
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT producto_id, cantidad FROM inv_h where c_id = " & id

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            xDoc = xDoc + "<h>" _
        + "<id>" & Reader.GetInt64(0) & "</id>" _
        + "<can>" & Reader.GetInt64(1) & "</can>" _
        + "</h>"


                        End While

                    End Using
                    Return xDoc
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function

    Public Function insertEntrada(ByVal folio As String)

        Dim Str As String = "INSERT INTO entradas_c (folio, fecha, usuario_id) values('" & folio & "', datetime('now', 'localtime'), " + Module1.id.ToString() + ");SELECT last_insert_rowid();"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim id As Integer = Cmd.ExecuteScalar()
                    'Console.WriteLine(id.ToString)
                    Return id
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function insertEntradaDetalle(ByVal c_id As Integer, ByVal producto_id As Integer, ByVal cantidad As Integer)

        Dim Str As String = "INSERT INTO entradas_d (c_id, producto_id, cantidad) values(" & c_id.ToString & ", " & producto_id.ToString & ", " & cantidad.ToString & ");"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function borraEntrada(ByVal id As Integer)

        Dim Str As String = "DELETE FROM entradas_c where id = " + id.ToString + " and cerrada = 0;DELETE FROM entradas_d where c_id = " + id.ToString + ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteScalar()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function deshacerEntrada(ByVal c_id As Integer)

        Dim Str As String = "SELECT ifnull(MAX(id), 0) from entradas_d where c_id = " + c_id.ToString + ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Dim id As Integer = 0
                Try
                    id = Cmd.ExecuteScalar()
                    Return id
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function borraUltimaEntrada(ByVal id As Integer)

        Dim Str As String = "DELETE FROM entradas_d where id = " + id.ToString + ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function cerrarEntradaGeneraQuery(ByVal id As Integer)

        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT producto_id, sum(cantidad) FROM entradas_d where c_id = " + id.ToString + " group by producto_id;"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim comando As String = ""
                        While Reader.Read()

                            comando = comando + "UPDATE productos set inv = inv + " & Reader.GetInt32(1) & " where id = " & Reader.GetInt32(0) & ";"

                        End While

                        comando = comando + "UPDATE entradas_c set cerrada = 1, fecha_cierre = datetime('now', 'localtime') where id = " + id.ToString + ";"

                        Return comando
                    End Using
                Catch
                    Return DBNull.Value
                End Try

            End Using

        End Using

    End Function

    Public Function cerrarEntrada(ByVal comando As String)

        Dim Str As String = comando
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Dim id As Integer = 0
                Try
                    Cmd.ExecuteScalar()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function getImpresionDetalleEntrada(ByVal id As Integer)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT ean, descripcion, cantidad FROM entradas_d i " _
                    & "left join productos p on i.producto_id = p.id " _
                & "where c_id = " & id.ToString

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()

                        Dim detalle As String = ""

                        Dim cantidad As String = ""
                        Dim cantidadLen As Integer = 0

                        Dim descripcion As String = ""
                        Dim descripcionLen As Integer = 0

                        Dim ean As String = ""
                        Dim eanLen As Integer = 0

                        Dim total As Integer = 0
                        Dim totalp As String = ""

                        While Reader.Read()

                            cantidad = FormatNumber(Reader.GetInt32(2), 0).ToString()
                            cantidadLen = cantidad.Length

                            If cantidadLen <= 6 Then
                                cantidad = cantidad.PadLeft(6, " ")
                            End If

                            descripcion = Reader.GetString(1)
                            descripcionLen = descripcion.Length

                            If descripcionLen <= 23 Then
                                descripcion = descripcion.PadRight(23, " ")
                            Else
                                descripcion = descripcion.Substring(0, 23)
                            End If

                            ean = Reader.GetString(0).ToString()
                            eanLen = ean.Length

                            If eanLen <= 15 Then
                                ean = ean.PadLeft(15, " ")
                            Else
                                ean = ean.Substring(eanLen - 8, 8)
                            End If


                            total = total + Reader.GetInt32(2)
                            totalp = FormatNumber(total, 0).ToString
                            totalp = "                     TOTAL " + totalp.PadLeft(19, " ")

                            detalle = detalle + ean + " " + descripcion + " " + cantidad + vbCrLf.ToString()

                        End While


                        detalle = detalle + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + totalp + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + "   _________________________________________   " + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + "                     FIRMA                     " + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString()
                        Return detalle
                    End Using
                Catch
                    Return 0
                End Try

            End Using

        End Using

    End Function

    Public Function creaXMLEntrada(ByVal id As Integer)

        Dim xDoc As String = ""
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT c.*, sucursal FROM entradas_c c cross join config g where c.id = " & id.ToString()

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            xDoc = "<?xml version='1.0' ?>" _
                                   + "<entrada suc='" & Reader.GetInt64(6) & "' id='" & Reader.GetInt64(0) & "' folio='" & Reader.GetString(1) & "' fecha='" & Reader.GetString(2) & "' usuario_id='" & Reader.GetInt64(3) & "' fecha_cierre='" & Reader.GetString(5) & "'>" _
                                   + creaXMLEntrada2(id) _
                                   + "</entrada>"


                        End While

                    End Using
                    Console.WriteLine(xDoc)
                    Return xDoc
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function

    Public Function creaXMLEntrada2(ByVal id As Integer)

        Dim xDoc As String = ""
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT e.c_id, producto_id,sum( cantidad) as cantidad, inv FROM entradas_d e " _
+ "left join productos p on e.producto_id = p.id " _
+ "where(c_id = " + id.ToString + ") " _
+ "group by producto_id"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            xDoc = xDoc + "<d>" _
        + "<id>" & Reader.GetInt64(0) & "</id>" _
        + "<p_id>" & Reader.GetInt64(1) & "</p_id>" _
        + "<can>" & Reader.GetInt64(2) & "</can>" _
        + "<inv>" & Reader.GetInt64(3) & "</inv>" _
        + "</d>"


                        End While

                    End Using
                    Return xDoc
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function

    Public Function cerrarVentaGeneraQuery(ByVal id As Integer)

        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT producto_id, sum(cantidad) FROM venta_d where c_id = " + id.ToString + " group by producto_id;"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim comando As String = ""
                        While Reader.Read()

                            comando = comando + "UPDATE productos set inv = inv - " & Reader.GetInt32(1) & " where id = " & Reader.GetInt32(0) & ";"

                        End While

                        comando = comando + "UPDATE venta_c set cerrada = 1, fecha = datetime('now', 'localtime') where id = " + id.ToString + ";"

                        Return comando
                    End Using
                Catch
                    Return DBNull.Value
                End Try

            End Using

        End Using

    End Function

    Public Function cerrarVenta(ByVal comando As String)

        Dim Str As String = comando
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Dim id As Integer = 0
                Try
                    Cmd.ExecuteScalar()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    MsgBox(ex.Message, vbCritical)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function insertSalidaDetalle(ByVal producto_id As Integer, ByVal cantidad As Integer)

        Dim Str As String = "INSERT INTO salidas_t (producto_id, cantidad) values(" & producto_id.ToString & ", " & cantidad.ToString & ");"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function deshacerSalida()

        Dim Str As String = "SELECT ifnull(MAX(id), 0) from salidas_t;"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Dim id As Integer = 0
                Try
                    id = Cmd.ExecuteScalar()
                    Return id
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function borraUltimaSalida(ByVal id As Integer)

        Dim Str As String = "DELETE FROM salidas_t where id = " + id.ToString + ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Cmd.ExecuteNonQuery()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function cerrarSalidaGeneraQuery(ByVal salida_id As Integer)

        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT producto_id, sum(cantidad) FROM salidas_t group by producto_id;"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim comando As String = ""
                        While Reader.Read()

                            comando = comando + "INSERT INTO salidas_d (c_id, producto_id, cantidad) values(" + salida_id.ToString + ", " + Reader.GetInt32(0).ToString + ", " + Reader.GetInt32(1).ToString + ");"
                            comando = comando + "UPDATE productos set inv = inv - " & Reader.GetInt32(1) & " where id = " & Reader.GetInt32(0) & ";"

                        End While

                        comando = comando + "DELETE FROM salidas_t;"

                        Return comando
                    End Using
                Catch
                    Return DBNull.Value
                End Try

            End Using

        End Using

    End Function

    Public Function cerrarSalida(ByVal comando As String)

        Dim Str As String = comando
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Dim id As Integer = 0
                Try
                    Cmd.ExecuteScalar()
                    Return True
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function generarFolioSalida()

        Dim Str As String = "SELECT sucursal from config where id = 1;"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Dim suc As Integer = 0
                Dim folio As String
                Try
                    suc = Cmd.ExecuteScalar()

                    Dim now As DateTime = DateTime.Now
                    Dim parte2 As String
                    parte2 = now.ToString("yyMMddHHmmss")

                    folio = suc.ToString.PadLeft(6, "0") & parte2

                    Return folio
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return False
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function insertSalidasControl(ByVal tipo_id As Integer, ByVal destino As Integer)

        Dim Str As String = "INSERT INTO salidas_c (folio, fecha, usuario_id, tipo_id, destino) values('" & generarFolioSalida() & "', datetime('now', 'localtime'), " + Module1.id.ToString() + ", " + tipo_id.ToString + ", " + destino.ToString + ");SELECT last_insert_rowid();"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim id As Integer = Cmd.ExecuteScalar()
                    Return id
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function getImpresionDetalleSalida(ByVal id As Integer)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT ean, descripcion, cantidad FROM salidas_d i " _
                    & "left join productos p on i.producto_id = p.id " _
                & "where c_id = " & id.ToString

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()

                        Dim detalle As String = ""

                        Dim cantidad As String = ""
                        Dim cantidadLen As Integer = 0

                        Dim descripcion As String = ""
                        Dim descripcionLen As Integer = 0

                        Dim ean As String = ""
                        Dim eanLen As Integer = 0

                        Dim total As Integer = 0
                        Dim totalp As String = ""

                        While Reader.Read()

                            cantidad = FormatNumber(Reader.GetInt32(2), 0).ToString()
                            cantidadLen = cantidad.Length

                            If cantidadLen <= 6 Then
                                cantidad = cantidad.PadLeft(6, " ")
                            End If

                            descripcion = Reader.GetString(1)
                            descripcionLen = descripcion.Length

                            If descripcionLen <= 23 Then
                                descripcion = descripcion.PadRight(23, " ")
                            Else
                                descripcion = descripcion.Substring(0, 23)
                            End If

                            ean = Reader.GetString(0).ToString()
                            eanLen = ean.Length

                            If eanLen <= 15 Then
                                ean = ean.PadLeft(15, " ")
                            Else
                                ean = ean.Substring(eanLen - 8, 8)
                            End If


                            total = total + Reader.GetInt32(2)
                            totalp = FormatNumber(total, 0).ToString
                            totalp = "                     TOTAL " + totalp.PadLeft(19, " ")

                            detalle = detalle + ean + " " + descripcion + " " + cantidad + vbCrLf.ToString()

                        End While


                        detalle = detalle + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + totalp + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + "   _________________________________________   " + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + "                     FIRMA                     " + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString()
                        Return detalle
                    End Using
                Catch
                    Return 0
                End Try

            End Using

        End Using

    End Function


    Public Function getFolioEntradaSalida(ByVal tabla As String, ByVal id As Integer)

        Dim Str As String = "SELECT folio FROM " + tabla + " WHERE id = " + id.ToString + ";"
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim folio As String = Cmd.ExecuteScalar()
                    Return folio
                Catch ex As System.Data.SQLite.SQLiteException
                    'WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function creaXMLSalida(ByVal id As Integer)

        Dim xDoc As String = ""
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT c.*, sucursal FROM salidas_c c cross join config g where c.id = " & id.ToString()

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            xDoc = "<?xml version='1.0' ?>" _
                                   + "<salida suc='" & Reader.GetInt64(6) & "' id='" & Reader.GetInt64(0) & "' folio='" & Reader.GetString(1) & "' fecha='" & Reader.GetString(2) & "' usuario_id='" & Reader.GetInt64(3) & "' tipo='" & Reader.GetInt32(4) & "'  destino='" & Reader.GetInt32(5) & "'>" _
                                   + creaXMLSalida2(id) _
                                   + "</salida>"


                        End While

                    End Using
                    Console.WriteLine(xDoc)
                    Return xDoc
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function

    Public Function creaXMLSalida2(ByVal id As Integer)

        Dim xDoc As String = ""
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT e.c_id, producto_id,sum( cantidad) as cantidad, inv FROM salidas_d e " _
+ "left join productos p on e.producto_id = p.id " _
+ "where(c_id = " + id.ToString + ") " _
+ "group by producto_id"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            xDoc = xDoc + "<d>" _
        + "<id>" & Reader.GetInt64(0) & "</id>" _
        + "<p_id>" & Reader.GetInt64(1) & "</p_id>" _
        + "<can>" & Reader.GetInt64(2) & "</can>" _
        + "<inv>" & Reader.GetInt64(3) & "</inv>" _
        + "</d>"


                        End While

                    End Using
                    Return xDoc
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function

    Public Function ajusteInventario(ByVal comando As String)

        Dim Str As String = comando
        'Console.WriteLine(Str)
        Using Conn As New System.Data.SQLite.SQLiteConnection

            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand
                Cmd.CommandText = Str
                Try
                    Dim id As Integer
                    id = Cmd.ExecuteScalar()
                    Return id
                Catch ex As System.Data.SQLite.SQLiteException
                    WriteLine(ex.Message)
                    Return 0
                End Try
            End Using
            Conn.Close()
        End Using

    End Function

    Public Function getImpresionAjuste(ByVal id As Integer)
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT a. *, ean, descripcion, nombre FROM ajustes a " _
& "left join productos p on a.producto_id = p.id " _
& "left join usuarios u on a.usuario_id = u.id " _
& "where (a.id = " & id.ToString & ");"

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        Dim detalle As String = ""
                        While Reader.Read()

                            detalle = detalle + "Id: " + Reader.GetInt32(0).ToString() + vbCrLf.ToString()
                            detalle = detalle + "Fecha: " + Reader.GetString(6) + vbCrLf.ToString()
                            detalle = detalle + "EAN: " + Reader.GetString(7) + vbCrLf.ToString()
                            detalle = detalle + "Descripción: " + Reader.GetString(8) + vbCrLf.ToString()
                            detalle = detalle + "Cantidad anterior: " + Reader.GetInt32(3).ToString() + vbCrLf.ToString()
                            detalle = detalle + "Cantidad Nueva: " + Reader.GetInt32(4).ToString() + vbCrLf.ToString()
                            detalle = detalle + "Resp.: " + Reader.GetString(9) + vbCrLf.ToString()

                        End While

                        detalle = detalle + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + "   _________________________________________   " + vbCrLf.ToString() + vbCrLf.ToString()
                        detalle = detalle + "                     FIRMA                     " + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString() + vbCrLf.ToString()

                        Return detalle
                    End Using
                Catch
                    Return 0
                End Try

            End Using

        End Using
    End Function

    Public Function creaXMLAjuste(ByVal id As Integer)

        Dim xDoc As String = ""
        'Open database.
        Using Conn As New System.Data.SQLite.SQLiteConnection
            Conn.ConnectionString = String.Format("Data Source={0};", gDbFile)
            Conn.Open()

            'Add record.
            Using Cmd As System.Data.SQLite.SQLiteCommand = Conn.CreateCommand

                'Prepare base statement for inserting parametrized values.
                Cmd.CommandText = "SELECT * from ajustes where id = " & id.ToString()

                'Fetch.
                Try
                    Using Reader As System.Data.SQLite.SQLiteDataReader = Cmd.ExecuteReader()
                        While Reader.Read()
                            xDoc = "<?xml version='1.0' ?>" _
                                   + "<ajuste suc='" & Reader.GetInt64(1) & "' id='" & Reader.GetInt64(0) & "' fecha='" & Reader.GetString(6) & "' usuario_id='" & Reader.GetInt64(5) & "' vieja='" & Reader.GetInt32(3) & "'  nueva='" & Reader.GetInt32(4) & "' producto_id='" & Reader.GetInt32(2) & "'>" _
                                   + "</ajuste>"


                        End While

                    End Using
                    Console.WriteLine(xDoc)
                    Return xDoc
                Catch
                    Return False
                End Try

            End Using

        End Using

    End Function


End Class
