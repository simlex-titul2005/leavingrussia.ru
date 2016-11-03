using LR.WebUI.ViewModels;
using LR.WebUI.ViewModels.Abstract;
using SX.WebCore;
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

            nowReadingMaterial = Mapper.Map<TViewModel, VMArticle>(viewModel);

            SxBBCodeParser.Replace(nowReadingMaterial);

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
            var viewModel = nowReadingMaterial;
            if (viewModel == null)
            {
                var last = Repo.Last(mct: ModelCoreType, amount: 1, mid: null).FirstOrDefault();
                if (last == null)
                    viewModel = new VMArticle() { Html = "Отсутсвуют данные БД" };
                else
                {
                    switch(last.ModelCoreType)
                    {
                        case 1:
                            nowReadingMaterial = Mapper.Map<SxVMMaterial, VMArticle>(last);
                            break;
                        case 2:
                            nowReadingMaterial = Mapper.Map<SxVMMaterial, VMNews>(last);
                            break;
                        default:
                            break;
                    }
                }
                    
            }

            return PartialView("_ReadingMaterial", nowReadingMaterial);
        }
        private static readonly object _readingMaterialLocker = new object();
        private static VMMaterial nowReadingMaterial
        {
            get
            {
                var data = MvcApplication.CacheProvider.Get<VMMaterial>("CACHE_READING_MATERIAL");
                return data;
            }
            set
            {
                lock (_readingMaterialLocker)
                {
                    MvcApplication.CacheProvider.Set("CACHE_READING_MATERIAL", value, 1);
                }
            }
        }

#if !DEBUG
        [OutputCache(Duration=3600)]
#endif
        [ChildActionOnly]
        public override PartialViewResult Last(byte? mct = null, int amount = 5, int? mid = null)
        {
            var viewModel = Repo.Last(null, amount, mid);
            if (viewModel.Any())
                viewModel = viewModel.Select(x => Mapper.Map<SxVMMaterial, VMMaterial>(x)).ToArray();
            return PartialView("_Last", viewModel);
        }
    }
}