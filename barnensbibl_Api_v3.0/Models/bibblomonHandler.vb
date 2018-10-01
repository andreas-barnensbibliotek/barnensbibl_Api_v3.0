Imports BibblomonLibrary
Public Class bibblomonHandler
    Public Function getbokemondata(ByVal cmdobj As bibblomonCommandInfo) As bokemonInfo
        Dim obj As New BibblomonMainController
        Dim retobj As New bokemonInfo

        If Not cmdobj.Userid <= 0 Then
            Select Case cmdobj.Cmdtyp

                Case "usrmon"
                    retobj = obj.getbaseUserAndMonsterList(cmdobj.Userid)

                Case "addmon"
                    retobj = obj.MonsterToUserList(cmdobj.Userid, cmdobj.Monsterid)

                Case "gameplaywin"
                    retobj = obj.MonsterGameplay(cmdobj.Userid, cmdobj.Monsterid, "win")

                Case "gameplaylose"
                    retobj = obj.MonsterGameplay(cmdobj.Userid, cmdobj.Monsterid, "lose")
                Case Else
                    retobj.Status = "Error no correct cmdtyp"
            End Select
        Else

            Select Case cmdobj.Cmdtyp
                Case "allmon"
                    retobj = obj.getbaseAllMonsterList(cmdobj.Userid)
                Case "alldrakar"
                    retobj = obj.getbaseAllDrakarList(cmdobj.Userid)
                Case Else
                    retobj.Status = "Error no Userid"
            End Select

        End If
        Return retobj

    End Function
    Public Function getbokemonHighScoredata(ByVal cmdobj As bibblomonCommandInfo) As bibblomonHighscoreInfo
        Dim obj As New BibblomonMainController
        Dim retobj As New bibblomonHighscoreInfo

        Select Case cmdobj.Cmdtyp
            Case "Highscore"
                retobj = obj.getHighscorelist()
            Case Else
                retobj.Status = "Error no Userid"

        End Select

        Return retobj

    End Function
End Class
