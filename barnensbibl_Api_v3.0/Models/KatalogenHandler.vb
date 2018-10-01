Imports katalogenLibrary_v4_0
Public Class KatalogenHandler
    Public Function getautocomplete(cmdtyp As String, searchstr As String, txtantal As String) As katalogenAutocompleteInfo
        Dim autocomplObj As New katalogenLibraryMainController
        Dim retobj As New katalogenAutocompleteInfo

        Try
            retobj.BookList = autocomplObj.autocompleteBookinfoList(searchstr, chkAntal(txtantal))
            retobj.Status = "Autocomplete list för sökordet: " & searchstr & " är hämtat"
        Catch ex As Exception
            retobj.Status = "ERROR Fel vid hämtning av autocomplete list för sökordet: " & searchstr
        End Try

        Return retobj
    End Function

    Private Function chkAntal(txtantal As String) As Integer
        Dim defaultantal As Integer = 20
        Dim antal As Integer
        If String.IsNullOrEmpty(txtantal) Then
            antal = defaultantal
        Else
            antal = CInt(txtantal)
            If antal <= 0 Then
                antal = defaultantal
            End If
        End If
        Return antal
    End Function

End Class
