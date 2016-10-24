using LR.WebUI.ViewModels;
using LR.WebUI.ViewModels.Abstract;
using SX.WebCore.DbModels.Abstract;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace LR.WebUI.Controllers
{
    public abstract class MaterialsController<TModel, TViewModel> : SxMaterialsController<TModel, TViewModel>
        where TModel : SxMaterial
        where TViewModel : SxVMMaterial, new()
    {
        public MaterialsController(byte mct) : base(mct) { }

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

        [ChildActionOnly]
        public sealed override PartialViewResult Popular(int? mct = default(int?), int? mid = default(int?), int amount = 4)
        {
            var mctProvider = MvcApplication.ModelCoreTypeProvider;
            var data = Repo.GetPopular(mct, mid, amount);
            var viewModel = new VMMaterial[data.Length];
            SxVMMaterial item = null;
            for (int i = 0; i < data.Length; i++)
            {
                item = data[i];
                if (item.ModelCoreType == 1)
                    viewModel[i] = Mapper.Map<SxVMMaterial, VMArticle>(item);
            }
            return PartialView("_Popular", viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult ReadingMaterial()
        {
            var viewModel = MvcApplication.ReadingMaterial;
            if(viewModel==null)
            {
                viewModel = Repo.Last(mct: ModelCoreType, amount: 1, mid: null).FirstOrDefault();
                if(viewModel==null)
                {
                    viewModel= new VMArticle() { Html = "Отсутсвуют данные БД" };
                }
                else
                    MvcApplication.ReadingMaterial = viewModel;
            }
                
            return PartialView("_ReadingMaterial", viewModel);
        }
    }
}