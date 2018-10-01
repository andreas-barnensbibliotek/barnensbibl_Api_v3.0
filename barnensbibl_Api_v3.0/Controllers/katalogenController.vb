Imports System.Web.Http
Imports System.Web.Http.Cors
Imports katalogenLibrary_v4_0

'autocomplete
'values: typ/cmdtyp: autocomplete, val: searchstring/sökord, txtval: maxantal i resultat (default=20)
'localhost:59015/Api_v3.1/katalogen/typ/autocomplete/val/cirkeln/txtval/5/devkey/alf/?type=json&callback=testar

<EnableCors("*", "*", "*")>
Public Class katalogenController
    Inherits ApiController

    Private _devkeyhandler As New devkeyhandler
    Public Function GetValues(cmdtyp As String, value As String, txtvalue As String, devkey As String) As katalogenAutocompleteInfo
        Dim retobj As New katalogenAutocompleteInfo
        Dim obj As New KatalogenHandler

        If _devkeyhandler.checkdevkey(devkey) Then

            retobj = obj.getautocomplete(cmdtyp, value, CInt(txtvalue))

        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function

    Public Function PostValue(cmdtyp As String, antal As String, devkey As String, <FromBody> searchform As autocompleteCommandInfo) As katalogenAutocompleteInfo
        Dim retobj As New katalogenAutocompleteInfo
        Dim obj As New KatalogenHandler

        If _devkeyhandler.checkdevkey(devkey) Then

            retobj = obj.getautocomplete(cmdtyp, searchform.Searchstr, CInt(antal))

        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function

End Class

