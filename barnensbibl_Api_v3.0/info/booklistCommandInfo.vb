Public Class booklistCommandInfo
    Private _cmdtyp As String
    Public Property Cmdtyp() As String
        Get
            Return _cmdtyp
        End Get
        Set(ByVal value As String)
            _cmdtyp = value
        End Set
    End Property

    Private _boklistid As Integer
    Public Property Boklistid() As Integer
        Get
            Return _boklistid
        End Get
        Set(ByVal value As Integer)
            _boklistid = value
        End Set
    End Property

    Private _value As String
    Public Property value() As String
        Get
            Return _value
        End Get
        Set(ByVal value As String)
            _value = value
        End Set
    End Property

    Private _userid As Integer
    Public Property userid() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal value As Integer)
            _userid = value
        End Set
    End Property

End Class
