using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LR.WebUI
{
    public class RouteConfig
    {
        private static readonly string[] _defNamespace = new string[] { "LR.WebUI.Controllers" };

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "home", action = "index", id = UrlParameter.Optional, area = "" },
                namespaces: _defNamespace
            );
        }
    }
}
