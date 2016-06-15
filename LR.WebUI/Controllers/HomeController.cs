using SX.Web.Core.MvcControllers;
using System.Web.Mvc;

namespace LR.WebUI.Controllers
{
    public class HomeController : SxBaseMvcController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}