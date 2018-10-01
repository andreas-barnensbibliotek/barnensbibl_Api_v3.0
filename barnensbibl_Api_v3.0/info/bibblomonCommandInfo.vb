Public Class bibblomonCommandInfo
    Private _cmdtyp As String
    Public Property Cmdtyp() As String
        Get
            Return _cmdtyp
        End Get
        Set(ByVal value As String)
            _cmdtyp = value
        End Set
    End Property

    Private _userid As Integer
    Public Property Userid() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal value As Integer)
            _userid = value
        End Set
    End Property

    Private _monsterid As Integer
    Public Property Monsterid() As Integer
        Get
            Return _monsterid
        End Get
        Set(ByVal value As Integer)
            _monsterid = value
        End Set
    End Property

End Class
