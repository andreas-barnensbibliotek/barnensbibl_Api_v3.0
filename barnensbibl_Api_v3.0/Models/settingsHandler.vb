Imports KrypinSettings

Public Class settingsHandler

    Public Function getUserSettings(ByVal cmdobj As CmdSettingsInfo) As ListUserSettingsInfo
        Dim obj As New krypinSettingsMainController
        Dim retobj As New ListUserSettingsInfo

        If Not cmdobj.Userid <= 0 Then
            retobj = obj.KrypinSettings(cmdobj)
        Else
            retobj.Status = "ERROR Settings hämtades inte!"
        End If

        Return retobj

    End Function

End Class
