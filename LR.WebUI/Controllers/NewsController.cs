using LR.WebUI.ViewModels;
using SX.WebCore;

namespace LR.WebUI.Controllers
{
    public sealed class NewsController : MaterialsController<VMNews>
    {
        public NewsController() : base(Enums.ModelCoreType.News) { }
    }
}