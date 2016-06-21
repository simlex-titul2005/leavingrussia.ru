using SX.WebCore.MvcApplication;
using System;

namespace LR.WebUI
{
    public class MvcApplication : SxApplication<WebCoreExtantions.DbContext>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            var args = new SxApplicationEventArgs();
            args.WebApiConfigRegister = WebApiConfig.Register;
            args.RegisterRoutes = RouteConfig.RegisterRoutes;
            args.MapperConfiguration = AutoMapperConfig.MapperConfigurationInstance;
            args.LogDirectory = null;
            args.LoggingRequest = true;

            base.Application_Start(sender, args);
        }
    }
}
