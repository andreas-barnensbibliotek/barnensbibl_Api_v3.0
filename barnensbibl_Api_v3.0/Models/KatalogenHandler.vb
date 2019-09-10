Imports katalogenLibrary_v4_0
Imports katalogen_booklistLibrary

Public Class KatalogenHandler
    Private _SearchObj As New katalogenLibraryMainController
    Private _SearchObjExtended As New KatalogToBooklistMainController

    Public Function getKatalogenSearch(cmdtyp As String, searchstr As String, userid As Integer) As mainSearchResultInfoExtended
        Dim retobj As New mainSearchResultInfoExtended
        Try
            retobj = _SearchObjExtended.getKatalogenSearch(searchstr, 0, userid)

        Catch ex As Exception
            retobj.Status = "ERROR Fel vid Sökning i katalogen med sökordet: " & searchstr
        End Try

        Return retobj
    End Function

    Public Function getKatalogenSearchTyp(cmdtyp As String, id As Integer, userid As Integer) As mainSearchResultInfoExtended
        Dim retobj As New mainSearchResultInfoExtended
        Try
            retobj = _SearchObjExtended.getKatalogenTypeSearch(cmdtyp, id, userid)

        Catch ex As Exception
            retobj.Status = "ERROR Fel vid Sökning i katalogen med typ: " & cmdtyp & " id: " & id
        End Try

        Return retobj
    End Function

    Public Function getKatalogenSearchOld(cmdtyp As String, searchstr As String, userid As Integer) As mainSearchResultInfoExtended
        Dim retobj As New mainSearchResultInfoExtended
        Try
            retobj = _SearchObjExtended.getKatalogenSearchOld(searchstr, 0, userid)

        Catch ex As Exception
            retobj.Status = "ERROR Fel vid expensive sökning i katalogen med sökordet: " & searchstr
        End Try

        Return retobj
    End Function

    Public Function getKatalogenSearchTypOld(cmdtyp As String, id As Integer, userid As Integer) As mainSearchResultInfoExtended
        Dim retobj As New mainSearchResultInfoExtended
        Try
            retobj = _SearchObjExtended.getKatalogenTypeSearchOLD(cmdtyp, id, userid)

        Catch ex As Exception
            retobj.Status = "ERROR Fel vid expensive sökning i katalogen med typ: " & cmdtyp & " id: " & id
        End Try

        Return retobj
    End Function

    Public Function getKatalogenDetailbyBookid(cmdtyp As String, bookid As Integer, userid As Integer) As mainSearchResultInfoExtended
        Dim retobj As New mainSearchResultInfoExtended
        Try
            retobj = _SearchObjExtended.getKatalogenTypeSearch(cmdtyp, bookid, userid)

        Catch ex As Exception
            'retobj.Status = "ERROR Fel vid expensive sökning i katalogen med typ: " & cmdtyp & " id: " & id
        End Try

        Return retobj
    End Function

    Public Function getautocomplete(cmdtyp As String, searchstr As String, txtantal As String) As katalogenAutocompleteInfo
        Dim retobj As New katalogenAutocompleteInfo
        Try
            Dim autoObj = _SearchObj.autocompleteBookinfoList(searchstr, chkAntal(txtantal))
            retobj.BookList = autoObj.Booktitlelist
            retobj.Status = autoObj.Status
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
