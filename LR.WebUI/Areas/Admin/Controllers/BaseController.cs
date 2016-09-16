using SX.WebCore.MvcControllers.Abstract;
using System.Web.Mvc;

namespace LR.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public abstract class BaseController : SxBaseController
    {
        
    }
}