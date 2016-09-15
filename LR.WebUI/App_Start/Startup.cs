using Microsoft.Owin;
using LR.WebUI.Infrastructure;
using SX.WebCore;

[assembly: OwinStartup(typeof(SX.WebCore.MvcApplication.SxOwinStartup<DbContext>))]
