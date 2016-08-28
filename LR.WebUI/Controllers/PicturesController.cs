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
        public PartialViewResult Best()
        {
            var data = new SxVMPicture[0];
            return PartialView("_Best", data);
        }
    }
}