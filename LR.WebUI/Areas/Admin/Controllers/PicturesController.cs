using LR.WebUI.Infrastructure;
using LR.WebUI.Infrastructure.Repositories;
using SX.WebCore.MvcControllers;

namespace LR.WebUI.Areas.Admin.Controllers
{
    public sealed class PicturesController : SxPicturesController<DbContext>
    {
        public PicturesController()
        {
            if (Repo == null)
                Repo = new RepoPicture();
        }
    }
}