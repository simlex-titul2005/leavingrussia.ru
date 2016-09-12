using LR.WebUI.Infrastructure;
using SX.WebCore.MvcControllers;
using System.Web.Mvc;

namespace LR.WebUI.Controllers
{
    public sealed class SiteNetsController : SxSiteNetsController<DbContext>
    {
        [ChildActionOnly, AllowAnonymous]
        public ActionResult ForHeader()
        {
            var viewModel = MvcApplication.SiteNetsProvider.SiteNets;
            return PartialView("_ForHeader", viewModel);
        }

        [ChildActionOnly, AllowAnonymous]
        public ActionResult JoinUs()
        {
            var viewModel = MvcApplication.SiteNetsProvider.SiteNets;
            return PartialView("_JoinUs", viewModel);
        }

        [ChildActionOnly, AllowAnonymous]
        public ActionResult SocialGroups()
        {
            var viewModel = MvcApplication.SiteNetsProvider.SiteNets;
            return PartialView("_SocialGroups", viewModel);
        }
    }
}