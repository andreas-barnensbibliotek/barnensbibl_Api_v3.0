Public Class skrivbokenCommandInfo

    Public Sub New()
        _cmdtyp = ""
        _mainval = 0
        _pubtyp = 1
        _getapproved = 1
        _getpublished = 3

    End Sub
    Private _cmdtyp As String
    Public Property Cmdtyp() As String
        Get
            Return _cmdtyp
        End Get
        Set(ByVal value As String)
            _cmdtyp = value
        End Set
    End Property

    Private _getpublished As Integer
    Public Property getPublished() As Integer
        Get
            Return _getpublished
        End Get
        Set(ByVal value As Integer)
            _getpublished = value
        End Set
    End Property
    Private _getapproved As Integer
    Public Property getApproved() As Integer
        Get
            Return _getapproved
        End Get
        Set(ByVal value As Integer)
            _getapproved = value
        End Set
    End Property
    Private _pubtyp As Integer
    Public Property Pubtyp() As Integer
        Get
            Return _pubtyp
        End Get
        Set(ByVal value As Integer)
            _pubtyp = value
        End Set
    End Property
    Private _mainval As Integer
    Public Property MainValue() As Integer
        Get
            Return _mainval
        End Get
        Set(ByVal value As Integer)
            _mainval = value
        End Set
    End Property
End Class
