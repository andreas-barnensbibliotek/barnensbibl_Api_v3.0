Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports krypinBoktips

'Boktips
'localhost:59015/Api_v3.1/boktips/typ/ByAuthor/val/0/txtval/Johanna%20Thydell/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/boktips/typ/Latest/val/3/txtval/0/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/boktips/typ/ByCategory/val/2/txtval/0/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/boktips/typ/ByRndInCategory/val/2/txtval/2/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/boktips/typ/ByRandom/val/2/txtval/0/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/boktips/typ/ByAge/val/2/txtval/0/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/boktips/typ/BySearch/val/2/txtval/0/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/boktips/typ/ByTitle/val/2/txtval/0/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/boktips/typ/ByTipId/val/86/txtval/0/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/boktips/typ/ByUserId/val/7017/txtval/0/devkey/alf/?type=jsonp&callback=testar
'localhost:59015/Api_v3.1/boktips/typ/ByBookId/val/10438/txtval/0/devkey/alf/?type=jsonp&callback=testar

'ADD Och EDIT Och delete
'localhost:59015/Api_v3.1/boktips/typ/addboktips/devkey/alf/?type=json&callback=testar
'POST
'{
'"Approved": "1",
'"Author":"Johanna Thydell",
'"Bookid":"11463",
'"Title":"Ursäkta att man vill bli lite älskad",
'"Userage":"12",
'"HighAge":"14",
'"LowAge":"3",
'"Review":"NYTT Från API",
'"Tiptype":"2",
'"Userid":"7017",
'"UserName":"Testlisa",
'"Category":"2",
'"TipID":""
'}

<EnableCors("*", "*", "*")>
Public Class boktipsController
    Inherits ApiController

    Private _devkeyhandler As New devkeyhandler
    Public Function GetValues(cmdtyp As String, value As String, txtvalue As String, devkey As String) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim obj As New boktipsHandler

        If _devkeyhandler.checkdevkey(devkey) Then

            Dim cmdsettings As New boktipsCommandInfo
            cmdsettings.Cmdtyp = cmdtyp
            cmdsettings.value = CInt(value)
            cmdsettings.textValue = txtvalue

            retobj = obj.handleBoktips(cmdsettings)

        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function


    Public Function PostValue(cmdtyp As String, devkey As String, <FromBody> boktips As boktipsInfo) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim obj As New boktipsHandler
        Dim cmdobj As New boktipsCommandInfo

        If _devkeyhandler.checkdevkey(devkey) Then
            cmdobj.Cmdtyp = cmdtyp

            retobj = obj.handleCrudBoktips(cmdobj, boktips)
            'If retobj.Boktips.Count <= 0 Then
            '    retobj.Boktips.Add(New boktipsInfo)
            'End If
        Else
            'retobj.Boktips.Add(New boktipsInfo)
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj
        'exempel på cmd= byStatus,bySearch

    End Function
End Class
