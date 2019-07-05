Imports QuestLibrary
Public Class QuestHandler

    Public Function getquest(cmdobj As cmdInfo) As UserQuestInfo
        Dim retobj As New UserQuestInfo
        Dim Questobj As New QuestMainController

        Select Case cmdobj.cmdtyp()
            Case "Qinf" 'Questinfo
                retobj = Questobj.getQuestInfo(cmdobj)

            Case "LstQ" 'List Quest
                retobj = Questobj.getActiveQuestList(cmdobj)

            Case "chkQ" 'Check quest
                retobj = Questobj.checkQuestStatus(cmdobj)

            Case "regQ" ' register Quest
                retobj = Questobj.RegisterQuest(cmdobj)

            Case "rmQ" ' remov/Delete quest
                retobj = Questobj.removeQuestFromUser(cmdobj)

            Case "utSQ" ' utför Quest/subquest
                retobj = Questobj.CompleteSubQuest(cmdobj)

            Case "shhidQ" ' Show or hide quest om klar eller inte
                retobj = Questobj.getSubQuest(cmdobj)
            Case Else
                retobj.Status = "ERROR: Fel i quest request"

        End Select

        Return retobj
    End Function


End Class
