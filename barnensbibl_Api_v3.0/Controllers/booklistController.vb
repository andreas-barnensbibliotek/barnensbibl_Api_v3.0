Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports krypinBoklistor

'localhost:59015/Api_v3.1/booklist/typ/addbook/blistid/0/value/testarnyboklista/uid/7017/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/booklist/typ/editbooklist/blistid/1244/value/testareditboklista/uid/7017/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/booklist/typ/delbooklist/blistid/1244/value/0/uid/7017/devkey/alf/?type=jsonp&callback=testar
'ADD DELETE BOOK FROM LIST
'localhost:59015/Api_v3.1/booklist/typ/addbook/blistid/1244/value/22423/uid/7017/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/booklist/typ/delbook/blistid/1244/value/22423/uid/7017/devkey/alf/?type=jsonp&callback=testar

<EnableCors("*", "*", "*")>
Public Class booklistController
    Inherits ApiController

    Private devkeyhandler As New devkeyhandler

    'localhost:59015/Api_v3.1/booklist/uid/7017/devkey/alf/?type=jsonp&callback=testar
    Public Function GetValues(devkey As String) As funkarInfo

        Dim testar As funkarInfo = New funkarInfo
        If devkeyhandler.checkdevkey(devkey) Then
            testar.namn = "Andreas build2"
            testar.devkey = "inga värden" & devkeyhandler.Statusmessage
        Else
            testar.namn = ""
            testar.devkey = devkeyhandler.Statusmessage
        End If

        Return testar

    End Function

    Public Function GetValues(userid As String, devkey As String) As krypinBookListInfo
        Dim obj As New booklistHandler
        Dim retobj As New krypinBookListInfo

        If devkeyhandler.checkdevkey(devkey) Then
            retobj = obj.getuserboklists(userid)

        Else
            retobj.Status = "ERROR Behörighet saknas"
        End If

        Return retobj

    End Function
    Public Function GetValues(cmdtyp As String, booklistid As String, value As String, userid As String, devkey As String) As krypinBookListInfo
        Dim obj As New booklistHandler
        Dim retobj As New krypinBookListInfo

        If devkeyhandler.checkdevkey(devkey) Then
            Dim cmdinfo As New booklistCommandInfo

            cmdinfo.Cmdtyp = cmdtyp
            cmdinfo.Boklistid = CInt(booklistid)
            cmdinfo.value = value
            cmdinfo.userid = CInt(userid)

            retobj = obj.handleBookToUserBooklist(cmdinfo)

        Else
            retobj.Status = "ERROR Behörighet saknas"
        End If

        Return retobj


    End Function
End Class
