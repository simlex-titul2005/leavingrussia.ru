using System.Web.Mvc;
using System.Web.Routing;

namespace LR.WebUI
{
    public class RouteConfig
    {
        private static readonly string[] _defaultNamespaces = new string[] { "LR.WebUI.Controllers" };
        public static void PreRouteAction(RouteCollection routes)
        {
            routes.MapRoute(name: null, url: "Articles", defaults: new { controller = "Articles", action = "List", page=1 }, namespaces: _defaultNamespaces);
        }

        public static void PostRouteAction(RouteCollection routes)
        {

        }
    }
}