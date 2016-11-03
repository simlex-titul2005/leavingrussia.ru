using LR.WebUI.Infrastructure;
using SX.WebCore.MvcApplication;
using SX.WebCore.ViewModels;
using System;
using System.Collections.Generic;

namespace LR.WebUI
{
    public class MvcApplication : SxMvcApplication
    {
        private static readonly Dictionary<string, byte> _customModelCoreTypes = new Dictionary<string, byte>();

        protected override void Application_Start(object sender, EventArgs e)
        {
            var args = new SxApplicationEventArgs(
                    defaultSiteName: "livingrussia.ru",
                    getDbContextInstance: ()=> new DbContext(),
                    getModelCoreTypeName: getMaterialName,
                    customModelCoreTypes: _customModelCoreTypes
                )
            {
                WebApiConfigRegister = WebApiConfig.Register,
                MapperConfigurationExpression = cfg => { AutoMapperConfig.Register(cfg); },

                //routes
                DefaultControllerNamespaces = new string[] { "LR.WebUI.Controllers" },
                PreRouteAction = RouteConfig.PreRouteAction,
                PostRouteAction = RouteConfig.PostRouteAction
            };

            base.Application_Start(sender, args);
        }

        private static string getMaterialName(byte mct)
        {
            switch(mct)
            {
                case 1:
                    return "Статьи";
                case 2:
                    return "Новости";
                default:
                    return null;
            }
        }
    }
}
