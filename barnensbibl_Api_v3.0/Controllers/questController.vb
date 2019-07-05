Imports System.Web.Http
Imports System.Web.Http.Cors
Imports QuestLibrary


'QUESTINFO
'get Quest info
' cmdtyp "Qinf" 'Questinfo
'localhost:59015/Api_v3.1/quest/typ/Qinf/devkey/alf?type=jsonp
' POST json:
'{ 
'   "Userid" : "7017",
'   "QuestID" : "5"
'}

'LISTA QUEST
'get Lista alla befintliga och Activa quests. vid koll korrigeras frågande användares uppdrag om dom är slutförda
'om questcompleted =  -1 Questen är inte registrerad hos användaren
'om questcompleted = 0 Questen är registrerad men inte klar 
'om questcompleted = 1 Questen är registrerad och KLAR!

' cmdtyp "LstQ" 'List Quest
'localhost:59015/Api_v3.1/quest/typ/LstQ/devkey/alf?type=jsonp
' POST json:
'{ 
'   "Userid" : "7017"
'}

'CHECK IF QUEST Completed
'get 'Kolla om quests finns och om den är slutförd
' cmdtyp "chkQ" 'Check quest
'localhost:59015/Api_v3.1/quest/typ/chkQ/devkey/alf?type=jsonp
' POST json:
'{ 
'   "Userid" : "7017",
'   "QuestID" : "5"
'}

'REGISTRERA QUEST
'get 'Registrera quest till användaren. kolla om questen finns i userquestlistan om inte finns regga den då
' cmdtyp "regQ" ' register Quest
'localhost:59015/Api_v3.1/quest/typ/regQ/devkey/alf?type=jsonp
' POST json:
'{ 
'   "Userid" : "7017",
'   "QuestID" : "5"
'}

'TABORT QUEST
'get ' tabort quest från användaren
' cmdtyp "rmQ" ' remov/Delete quest
'localhost:59015/Api_v3.1/quest/typ/rmQ/devkey/alf?type=jsonp
' POST json:
'{ 
'   "Userid" : "7017",
'   "QuestID" : "5"
'}

'UTFÖR QUEST
'get 'Användaren gör quest, om quest uppfylld check as completed, om questsvar är fel (statuscode =2) inget utförs!
' cmdtyp "utSQ" ' utför Quest/subquest
'localhost:59015/Api_v3.1/quest/typ/utSQ/devkey/alf?type=jsonp
' POST json:
'{ 
'   "Userid" : "7017",
'   "QuestID" : "5",
'   "uQuestID" : "13",
'   "QTriggerID" : "10",
'   "Svar" : "testar1" 
'}


'CHECK IF SUBQUEST VISAS
' Ska subquest visas eller inte, om visas skicka med questbeskrivning. ingen användardata behövs utan endast questdata
' Request: Userid, QuestID, Qtriggerid
' Response: uQuestID, QTriggerID, QuestID, questbeskrivning, aid, subquestsvar,
' DETTA är det som admin placerar på sida för att köra en quest.
' cmdtyp "shhidQ" ' Show or hide quest om klar eller inte
'localhost:59015/Api_v3.1/quest/typ/shhidQ/devkey/alf?type=jsonp
' POST json:
' { 
' "Userid" : "7017",
' "QuestID" : "5",
' "QTriggerID":"11"
'}


<EnableCors("*", "*", "*")>
Public Class questController
    Inherits ApiController

    Private _devkeyhandler As New devkeyhandler
    Public Function GetValues(cmdtyp As String, userid As String, awardgroup As String, devkey As String) As UserQuestInfo
        Dim retobj As New UserQuestInfo
        Try
            Dim cmdobj As New cmdInfo
            cmdobj.cmdtyp = cmdtyp
            cmdobj.Userid = CInt(userid)
            cmdobj.uQuestID = CInt(awardgroup)
            retobj.Status = "Request not implemented!"

        Catch ex As Exception
            retobj.Status = "ERROR in Request!"

        End Try

        Return retobj

    End Function

    Public Function PostValue(cmdtyp As String, devkey As String, <FromBody> questinfo As cmdInfo) As UserQuestInfo
        Dim retobj As New UserQuestInfo
        Dim cmdobj As New QuestHandler

        If _devkeyhandler.checkdevkey(devkey) Then
            questinfo.cmdtyp = cmdtyp
            retobj = cmdobj.getquest(questinfo)

        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj
        'exempel på cmd= byStatus,bySearch

    End Function
End Class

