﻿Imports System.Web.Http
Imports System.Web.Http.Cors
Imports katalogenLibrary_v4_0

'autocomplete
'values: typ/cmdtyp: autocomplete, val: searchstring/sökord, txtval: maxantal i resultat (default=20)
'localhost:59015/Api_v3.1/katalogen/typ/autocomplete/val/cirkeln/txtval/5/devkey/alf/?type=json&callback=testar
'localhost:59015/Api_v3.1/katalogen/typ/autocomplete/searchval/cirkeln/val/5/devkey/alf/?type=json&callback=testar

'Main search
'values: typ/cmdtyp: search, val: searchstring/sökord,
'localhost:59015/Api_v3.1/katalogen/typ/cat/searchval/9/val/7017/devkey/alf/?type=json&callback=testar
'localhost:59015/Api_v3.1/katalogen/typ/search/searchval/cirkeln/val/7017/devkey/alf/?type=json&callback=testar
'localhost:59015/Api_v3.1/katalogen/typ/bookid/searchval/5666/val/7017/devkey/alf/?type=json&callback=testar

<EnableCors("*", "*", "*")>
Public Class katalogenController
    Inherits ApiController

    Private _devkeyhandler As New devkeyhandler

    Public Function GetValues(cmdtyp As String, searchval As String, value As String, devkey As String) As Object
        Dim retobj As New Object
        Dim obj As New KatalogenHandler
        If String.IsNullOrEmpty(value) Or value = "undefined" Then
            value = 0
        End If
        If String.IsNullOrEmpty(searchval) Or searchval = "undefined" Then
            searchval = 0
        End If

        If _devkeyhandler.checkdevkey(devkey) Then
            Select Case cmdtyp
                Case "search"
                    retobj = obj.getKatalogenSearch(cmdtyp, searchval, CInt(value))
                Case "cat"
                    retobj = obj.getKatalogenSearchTyp(cmdtyp, CInt(searchval), CInt(value))
                Case "amne"
                    retobj = obj.getKatalogenSearchTyp(cmdtyp, CInt(searchval), CInt(value))
                Case "bookid"
                    retobj = obj.getKatalogenSearchTyp(cmdtyp, CInt(searchval), CInt(value))
                Case "searchOld"
                    retobj = obj.getKatalogenSearchOld(cmdtyp, searchval, CInt(value))
                Case "catOld"
                    retobj = obj.getKatalogenSearchTypOld(cmdtyp, CInt(searchval), CInt(value))
                Case "amneOld"
                    retobj = obj.getKatalogenSearchTypOld(cmdtyp, CInt(searchval), CInt(value))

                Case Else
                    retobj = obj.getautocomplete(cmdtyp, searchval, CInt(value))
            End Select


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

    Public Function PostValue(cmdtyp As String, devkey As String, <FromBody> searchform As autocompleteCommandInfo) As Object
        Dim retobj As New Object
        Dim obj As New KatalogenHandler

        If _devkeyhandler.checkdevkey(devkey) Then
            retobj = obj.getKatalogenSearch(cmdtyp, searchform.Searchstr, searchform.userid)

        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function
End Class

