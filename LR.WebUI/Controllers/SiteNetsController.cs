using LR.WebUI.Infrastructure;
using SX.WebCore.MvcControllers;
using System.Web.Mvc;

namespace LR.WebUI.Controllers
{
    public sealed class SiteNetsController : SxSiteNetsController<DbContext>
    {
        [ChildActionOnly]
        public ActionResult JoinUs()
        {
            var viewModel = MvcApplication.SiteNetsProvider.SiteNets;
            return PartialView("_JoinUs", viewModel);
        }

        [ChildActionOnly]
        public ActionResult SocialGroups()
        {
            var viewModel = MvcApplication.SiteNetsProvider.SiteNets;
            return PartialView("_SocialGroups", viewModel);
        }
    }
}