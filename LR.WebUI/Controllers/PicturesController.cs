using LR.WebUI.Infrastructure;
using LR.WebUI.Infrastructure.Repositories;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using System.Web.Mvc;

namespace LR.WebUI.Controllers
{
    public sealed class PicturesController : SxPicturesController<DbContext>
    {
        static PicturesController()
        {
            if (Repo == null)
                Repo = new RepoPicture();
        }

        [ChildActionOnly]
        public PartialViewResult Last(int amount = 9)
        {
            var viewModel = (Repo as RepoPicture).Last(amount);
            return PartialView("_Last", viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult Best(int amount=6)
        {
            var viewModel = (Repo as RepoPicture).Best(amount);
            return PartialView("_Best", viewModel);
        }
    }
}