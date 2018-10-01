Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports krypinSkrivboken
' Skrivboken API v3.1
' byuserid
' Required values: cmdtyp = ByUserID, val= Userid, typ= publishtyp 1 (default) (2 alla värden oavsett om dom är approved eller ej 
' och oavsett vilket publishvärde dvs 1 publicerad, 2 privat, 3 publik)
' Optional values: ap = 1 eller 2 (approved: 1=ja (default), 2=nej) pub= 1-3 (published: 1=publicerad, 2=privat, 3=publik (default))
' localhost:59015/Api_v3.1/skrivboken/cmdtyp/ByUserID/val/105/typ/2/ap/0/pub/0/devkey/alf/?type=jsonp&callback=testar

' bycategory
' Required values: cmdtyp = ByCategory, val= categoryid  typ=publishtyp 1 (default) (2 ENDAST ADMIN - hämtar användarens data 
' (userid requred) oavsett om den är approved eller ej eller vilken publish den är
' Optional values: ap = 1 eller 2 (approved: 1=ja (default), 2=nej) pub= 1-3 (published: 1=publicerad, 2=privat, 3=publik (default))
' localhost:59015/Api_v3.1/skrivboken/cmdtyp/ByCategory/val/11/typ/1/ap/0/pub/0/devkey/alf/?type=jsonp&callback=testar
' Note: säkerhetsnotering: approved är satt till 1 och publicerat till 3 default hårdkodat i skrivbokenhandler (rad 21-22)

' byskrivid
' Required values: cmdtyp = BySkrivid, val= skrivid, typevalue = userid  
' Optional values: none
' localhost:59015/Api_v3.1/skrivboken/cmdtyp/BySkrivid/val/105/typ/7017/ap/0/pub/0/devkey/alf/?type=jsonp&callback=testar

<EnableCors("*", "*", "*")>
    Public Class skrivbokenController
        Inherits ApiController

    Private _devkeyhandler As New devkeyhandler
    Public Function GetValues(cmdtyp As String, value As String, typevalue As String, approved As String, publish As String, devkey As String) As skrivbokenJsonContainerInfo
        Dim skrivbokenObj As New skrivbokenHandler
        Dim retobj As New skrivbokenJsonContainerInfo

        If _devkeyhandler.checkdevkey(devkey) Then
            retobj = skrivbokenObj.handleskrivboken(cmdtyp, value, typevalue, approved, publish)
        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function


    'localhost:59015/Api_v3.1/skrivboken/devkey/alf/?type=jsonp&callback=testar
    Public Function GetValues(devkey As String) As funkarInfo

        Dim testar As funkarInfo = New funkarInfo
        If _devkeyhandler.checkdevkey(devkey) Then
            testar.namn = "Andreas build2"
            testar.devkey = "inga värden" & _devkeyhandler.Statusmessage
        Else
            testar.namn = ""
            testar.devkey = _devkeyhandler.Statusmessage
        End If

        Return testar

    End Function

    Public Function PostValue(cmdtyp As String, devkey As String, <FromBody> skrivItem As skrivItemInfo) As skrivbokenJsonContainerInfo
        Dim retobj As New skrivbokenJsonContainerInfo
        Dim obj As New skrivbokenHandler
        Dim cmdobj As New skrivbokenCommandInfo

        If _devkeyhandler.checkdevkey(devkey) Then
            cmdobj.Cmdtyp = cmdtyp

            retobj = obj.handleCrudSkrivboken(cmdobj, skrivItem)

        Else

            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function
End Class
