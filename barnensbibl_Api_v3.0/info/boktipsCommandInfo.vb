Public Class boktipsCommandInfo

    Private _cmdtyp As String
        Public Property Cmdtyp() As String
            Get
                Return _cmdtyp
            End Get
            Set(ByVal value As String)
                _cmdtyp = value
            End Set
        End Property

    Private _textvalue As String
    Public Property textValue() As String
        Get
            Return _textvalue
        End Get
        Set(ByVal value As String)
            _textvalue = value
        End Set
    End Property

    Private _value As Integer
        Public Property value() As Integer
            Get
                Return _value
            End Get
            Set(ByVal value As Integer)
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

