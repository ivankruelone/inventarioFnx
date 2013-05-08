Public Class Sesion
    'Codigo de declaracion

    Private idValue As Integer
    Private nombreValue As String
    Private nivelValue As Integer

    'Ivan y sus variables de sesion
    Public Property id() As Integer
        Get
            id = idValue
        End Get
        Set(ByVal value As Integer)
            idValue = value
        End Set
    End Property

    Public Property nombre() As String
        Get
            nombre = nombreValue
        End Get
        Set(ByVal value As String)
            nombreValue = value
        End Set
    End Property

    Public Property nivel() As Integer
        Get
            nivel = nivelValue
        End Get
        Set(ByVal value As Integer)
            nivelValue = value
        End Set
    End Property

End Class
