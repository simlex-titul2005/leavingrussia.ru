using LR.WebUI.Infrastructure;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using System.Web.Mvc;

namespace LR.WebUI.Controllers
{
    public class PicturesController : SxPicturesController<DbContext>
    {
        public ActionResult Last(int amount = 9)
        {
            var data = new SxVMPicture[0];
            return PartialView("_Last", data);
        }
    }
}