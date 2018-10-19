Imports BibbloMoney
Imports System.Configuration
Public Class AwardHandler
    Public Function getawards(cmdtyp As String, userid As Integer, awardGroupID As Integer) As bokmarkelserReturnInfo
        Dim retobj As New bokmarkelserReturnInfo
        Dim awardobj As New bibbloMoneyMainController
        Select Case cmdtyp
            Case "byuserid"
                retobj = awardobj.getUserbokmarkelser(userid)
            Case "byawardgroup"
                retobj = awardobj.getUserAwardgroupbokmarkelser(userid, awardGroupID)
        End Select

        Return retobj

    End Function

    Public Function setAwardtoUser(cmdtyp As String, userid As Integer, awardGroup As Object) As bokmarkelserReturnInfo
        Dim retobj As New bokmarkelserReturnInfo
        Dim awardobj As New bibbloMoneyMainController

        If isUseAwardHandler() Then
            Select Case cmdtyp
                Case "byAwardid"
                    retobj = awardobj.setuserawardbyAwardGroupID(userid, CInt(awardGroup))
                Case "byAwardName"
                    retobj = awardobj.getUserAwardgroupbokmarkelser(userid, awardGroup.ToString)
            End Select
        End If

        Return retobj

    End Function
    Private Function isUseAwardHandler() As Boolean
        Dim strbln As String = ConfigurationManager.AppSettings("UseAwardhandler")
        If strbln.ToLower = "true" Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
