using LR.WebUI.Infrastructure;
using SX.WebCore.MvcApplication;
using System;
using System.Configuration;
using System.Web.Mvc;

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
                LoggingRequest = Convert.ToBoolean(ConfigurationManager.AppSettings["LoggingRequest"])
            };

            base.Application_Start(sender, args);
        }
    }
}
