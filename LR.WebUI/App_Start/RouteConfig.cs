using System.Web.Mvc;
using System.Web.Routing;

namespace LR.WebUI
{
    public class RouteConfig
    {
        private static readonly string[] _dafaultNamespaces = new string[] { "LR.WebUI.Controllers" };

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:null,
                url: "{controller}/{year}/{month}/{day}/{titleUrl}",
                defaults: new { controller = "Articles", action = "Details", area = "" },
                namespaces: _dafaultNamespaces
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, area="" },
                namespaces: _dafaultNamespaces
            );
        }
    }
}
