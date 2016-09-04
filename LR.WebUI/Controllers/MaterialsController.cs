using LR.WebUI.Infrastructure;
using SX.WebCore.Abstract;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using System.Web.Mvc;
using static SX.WebCore.Enums;

namespace LR.WebUI.Controllers
{
    public abstract class MaterialsController<TModel, TViewModel> : SxMaterialsController<TModel, TViewModel, DbContext>
        where TModel : SxMaterial
        where TViewModel : SxVMMaterial, new()
    {
        public MaterialsController(ModelCoreType mct) : base(mct) { }

        private static readonly int _pageSize = 10;

        [HttpGet]
        public virtual ActionResult Details(int year, string month, string day, string titleUrl)
        {
            var viewModel = Repo.GetByTitleUrl(year, month, day, titleUrl);
            if (viewModel == null)
                return new HttpNotFoundResult();

            MvcApplication.ReadingMaterial = viewModel;

            return View(viewModel);
        }
    }
}