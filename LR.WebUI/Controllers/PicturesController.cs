using LR.WebUI.Infrastructure;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using System.Web.Mvc;

namespace LR.WebUI.Controllers
{
    public sealed class PicturesController : SxPicturesController<DbContext>
    {
        [ChildActionOnly]
        public PartialViewResult Last(int amount = 9)
        {
            var data = new SxVMPicture[0];
            return PartialView("_Last", data);
        }

        [ChildActionOnly]
        public PartialViewResult Best()
        {
            var data = new SxVMPicture[0];
            return PartialView("_Best", data);
        }
    }
}