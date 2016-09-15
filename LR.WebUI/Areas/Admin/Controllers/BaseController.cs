using LR.WebUI.Infrastructure;
using SX.WebCore.MvcControllers;
using System.Web.Mvc;

namespace LR.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public abstract class BaseController : SxBaseController
    {
        
    }
}