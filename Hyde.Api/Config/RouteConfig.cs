using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
namespace Hyde.Api.Host.Config
{
    public class RouteConfig
    {
        public static void RouteRegister(HttpConfiguration config)
        {
            var routeTables = config.Routes;

            routeTables.MapHttpRoute("DefaultApi",
                routeTemplate: "api/{controller}/{action}/Key",
                defaults: new { Key = RouteParameter.Optional });
        }
    }
}