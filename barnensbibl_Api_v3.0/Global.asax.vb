Imports System.Web.Http
Imports System.Web.Http.Cors
Imports System.Web.Routing
Imports System.Web.SessionState
Imports WebApiContrib.Formatting.Jsonp

Public Class WebApiApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Att tänka på är att man inte ska skicka med ?callback=? i anropet för då returneras: /**/ typeof Test === 'function' && 
        GlobalConfiguration.Configuration.AddJsonpFormatter()
        'System.Web.Mvc.AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configuration.EnableCors()

        ' ''Använd denna för att alltid köra json lite skum formatering dock-------------------------------------------------
        'Dim json = GlobalConfiguration.Configuration.Formatters.JsonFormatter
        'json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects
        'GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter)

        'Använd denna för att få json response men måste då skicka med ?type=json i urlen-------------------------------------------------
        GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
           New System.Net.Http.Formatting.QueryStringMapping("type", "json", New System.Net.Http.Headers.MediaTypeHeaderValue("application/json")))


        'Använd denna för att få XML response men måste då skicka med ?type=xml i urlen-------------------------------------------------
        'GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
        '    New System.Net.Http.Formatting.QueryStringMapping("type", "xml", New System.Net.Http.Headers.MediaTypeHeaderValue("application/xml")))

        RouteTable.Routes.MapHttpRoute("Apiv3.1",
                                      "Api_v3.1/{controller}/devkey/{devkey}",
                                      defaults:=New With {.value = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Apiv3.1 userid",
                                      "Api_v3.1/{controller}/uid/{userid}/devkey/{devkey}",
                                      defaults:=New With {.userid = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Apiv3.1 Changebooktolist",
                                      "Api_v3.1/{controller}/typ/{cmdtyp}/blistid/{booklistid}/value/{value}/uid/{userid}/devkey/{devkey}",
                                      defaults:=New With {.cmdtyp = System.Web.Http.RouteParameter.Optional, .booklistid = System.Web.Http.RouteParameter.Optional, .value = System.Web.Http.RouteParameter.Optional, .userid = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Api_v3.1_getbooktip",
                                      "Api_v3.1/{controller}/typ/{cmdtyp}/val/{value}/txtval/{txtvalue}/devkey/{devkey}",
                                      defaults:=New With {.cmdtyp = System.Web.Http.RouteParameter.Optional, .value = System.Web.Http.RouteParameter.Optional, .txtvalue = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})

        RouteTable.Routes.MapHttpRoute("Apiv3.1 cmdtypform",
                                      "Api_v3.1/{controller}/typ/{cmdtyp}/devkey/{devkey}",
                                      defaults:=New With {.cmdtyp = System.Web.Http.RouteParameter.Optional, .devkey = System.Web.Http.RouteParameter.Optional})


    End Sub
End Class
