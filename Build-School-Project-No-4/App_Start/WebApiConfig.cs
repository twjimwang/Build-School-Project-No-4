using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Build_School_Project_No_4
{
    public static class WebApiConfig
    {
        
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務
            config.EnableCors();
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
