using Microsoft.AspNet.Mvc;

namespace leavingrussia.ru.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
