using LR.WebUI.Infrastructure;
using SX.WebCore.Managers;
using SX.WebCore.MvcApplication;
using SX.WebCore.ViewModels;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace LR.WebUI
{
    public class MvcApplication : SxApplication<DbContext>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            var args = new SxApplicationEventArgs
            {
                WebApiConfigRegister = WebApiConfig.Register,
                RegisterRoutes = RouteConfig.RegisterRoutes,
                MapperConfiguration = AutoMapperConfig.MapperConfigurationInstance,
                LoggingRequest = Convert.ToBoolean(ConfigurationManager.AppSettings["LoggingRequest"])
            };

            base.Application_Start(sender, args);
        }

        private static readonly object _readingMaterialLocker = new object();
        public static SxVMMaterial ReadingMaterial
        {
            get
            {
                return (SxVMMaterial)AppCache.Get("CACHE_READING_MATERIAL");
            }
            set
            {
                var data = (SxVMMaterial)AppCache.Get("CACHE_READING_MATERIAL");
                if(data==null)
                    lock(_readingMaterialLocker)
                    {
                        AppCache.Add("CACHE_READING_MATERIAL", value, SxCacheExpirationManager.GetExpiration(minutes: 1));
                    }
            }
        }

    }
}
