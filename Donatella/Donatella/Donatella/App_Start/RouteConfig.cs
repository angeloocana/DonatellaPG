using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Donatella
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                namespaces: new[] { "Donatella.Controllers" },
                name: "EsqueciSenha",
                url: "EsqueceuSenha/TrocaSenha/{token}",
                defaults: new { controller = "EsqueceuSenha", action = "TrocaSenha" }
            );

            routes.MapRoute(
                namespaces: new[] { "Donatella.Controllers" },
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}