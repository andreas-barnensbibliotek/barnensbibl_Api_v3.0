Public Class autocompleteCommandInfo
    Private _searchstr As String
    Public Property Searchstr() As String
        Get
            Return _searchstr
        End Get
        Set(ByVal value As String)
            _searchstr = value
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
