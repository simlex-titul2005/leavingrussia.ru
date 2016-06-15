using SX.Web.Core.MvcConfig;
using System.Web.Mvc;
using System.Web.Routing;

namespace LR.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            SxMvcRouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
