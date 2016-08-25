using LR.WebUI.Infrastructure;
using SX.WebCore.Abstract;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using System.Web.Mvc;
using static SX.WebCore.Enums;

namespace LR.WebUI.Controllers
{
    public abstract class MaterialsController<TViewModel> : SxMaterialsController<SxMaterial, TViewModel, DbContext>
        where TViewModel : SxVMMaterial
    {
        public MaterialsController(ModelCoreType mct) : base(mct) { }

        [HttpGet]
        public virtual ActionResult Details(int year, string month, string day, string titleUrl)
        {
            var viewModel = Repo.GetByTitleUrl(year, month, day, titleUrl);
            if (viewModel == null)
                return new HttpNotFoundResult();

            return View(viewModel);
        }
    }
}