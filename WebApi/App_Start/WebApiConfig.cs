using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
           
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{area}/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
