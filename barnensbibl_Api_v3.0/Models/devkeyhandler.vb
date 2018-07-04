Public Class devkeyhandler
    Private _statusmessage As String
    Public Property Statusmessage() As String
        Get
            Return _statusmessage
        End Get
        Set(ByVal value As String)
            _statusmessage = value
        End Set
    End Property
    Public Function checkdevkey(devkey As String) As Boolean
        If devkey = "alf" Then
            _statusmessage = "Success"
            Return True
        Else
            _statusmessage = "Access Denied to API"
            Return False
        End If
    End Function
End Class
