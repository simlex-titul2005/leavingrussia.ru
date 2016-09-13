using LR.WebUI.Infrastructure;
using LR.WebUI.Models;
using LR.WebUI.ViewModels;
using SX.WebCore.Managers;
using SX.WebCore.MvcApplication;
using SX.WebCore.ViewModels;
using System;
using System.Configuration;

namespace LR.WebUI
{
    public class MvcApplication : SxApplication<DbContext>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            var args = new SxApplicationEventArgs
            {
                WebApiConfigRegister = WebApiConfig.Register,
                LoggingRequest = Convert.ToBoolean(ConfigurationManager.AppSettings["LoggingRequest"]),
                MapperConfigurationExpression = cfg => {

                    //article
                    cfg.CreateMap<Article, VMArticle>();
                    cfg.CreateMap<VMArticle, Article>();

                },

                //routes
                DefaultControllerNamespaces= new string[] { "LR.WebUI.Controllers" }
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
