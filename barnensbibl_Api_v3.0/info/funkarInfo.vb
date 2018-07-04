Public Class funkarInfo

    Private _namn As String
    Public Property namn() As String
        Get
            Return _namn
        End Get
        Set(ByVal value As String)
            _namn = value
        End Set
    End Property

    Private _devkey As String
    Public Property devkey() As String
        Get
            Return _devkey
        End Get
        Set(ByVal value As String)
            _devkey = value
        End Set
    End Property
End Class
