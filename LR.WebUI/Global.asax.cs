using LR.WebUI.Infrastructure;
using SX.WebCore.Managers;
using SX.WebCore.MvcApplication;
using SX.WebCore.ViewModels;
using System;

namespace LR.WebUI
{
    public class MvcApplication : SxMvcApplication
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            var args = new SxApplicationEventArgs
            {
                GetDbContextInstance = () => { return new DbContext(); },
                WebApiConfigRegister = WebApiConfig.Register,
                MapperConfigurationExpression = cfg => { AutoMapperConfig.Register(cfg); },

                //routes
                DefaultControllerNamespaces= new string[] { "LR.WebUI.Controllers" },
                PreRouteAction= RouteConfig.PreRouteAction,
                PostRouteAction=RouteConfig.PostRouteAction
            };

            base.Application_Start(sender, args);
        }

        private static readonly object _readingMaterialLocker = new object();
        public static SxVMMaterial ReadingMaterial
        {
            get
            {
                return CacheProvider.Get<SxVMMaterial>("CACHE_READING_MATERIAL");
            }
            set
            {
                var data = CacheProvider.Get<SxVMMaterial>("CACHE_READING_MATERIAL");
                if(data==null)
                    lock(_readingMaterialLocker)
                    {
                        CacheProvider.Set("CACHE_READING_MATERIAL", value, 1);
                    }
            }
        }

    }
}
