using LR.WebUI.Infrastructure;
using SX.WebCore.MvcApplication;
using System;

namespace LR.WebUI
{
    public class MvcApplication : SxApplication<DbContext>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            var args = new SxApplicationEventArgs {
                WebApiConfigRegister = WebApiConfig.Register,
                RegisterRoutes = RouteConfig.RegisterRoutes,
                MapperConfiguration = AutoMapperConfig.MapperConfigurationInstance,
                LoggingRequest = false
            };

            base.Application_Start(sender, args);
        }
    }
}
