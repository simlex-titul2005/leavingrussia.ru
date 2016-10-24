using System.Web.Mvc;
using System.Web.Routing;

namespace LR.WebUI
{
    public class RouteConfig
    {
        private static readonly string[] _defaultNamespaces = new string[] { "LR.WebUI.Controllers" };
        public static void PreRouteAction(RouteCollection routes)
        {
            //routes.MapRoute(name: null, url: "Admin", defaults: new { controller = "Home", action = "Index", area = "Admin" }, namespaces: _defaultNamespaces);
        }

        public static void PostRouteAction(RouteCollection routes)
        {

        }
    }
}