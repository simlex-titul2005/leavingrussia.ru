using SX.WebCore.MvcApplication;

namespace LR.WebUI
{
    public class MvcApplication : SxApplication<LR.WebCoreExtantions.DbContext>
    {
        public MvcApplication() : base(
            WebApiConfig.Register,
            RouteConfig.RegisterRoutes,
            AutoMapperConfig.MapperConfigurationInstance,
            isLogRequests: true
            )
        { }
    }
}
