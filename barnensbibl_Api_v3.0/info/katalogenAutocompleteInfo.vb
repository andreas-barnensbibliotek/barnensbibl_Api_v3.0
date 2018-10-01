Imports katalogenLibrary_v4_0
Public Class katalogenAutocompleteInfo

    Public Sub New()
        _booklist = New List(Of ShortBookInfo)
        _status = ""
    End Sub
    Private _booklist As List(Of ShortBookInfo)
    Public Property BookList() As List(Of ShortBookInfo)
        Get
            Return _booklist
        End Get
        Set(ByVal value As List(Of ShortBookInfo))
            _booklist = value
        End Set
    End Property

    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

End Class
