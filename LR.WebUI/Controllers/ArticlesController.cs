using System.Web.Mvc;
using LR.WebUI.Infrastructure.Repositories;
using LR.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.ViewModels;
using LR.WebUI.Models;
using System.Linq;
using SX.WebCore.Repositories;

namespace LR.WebUI.Controllers
{
    public sealed class ArticlesController : MaterialsController<Article, VMArticle>
    {
        private static RepoArticle _repo = new RepoArticle();
        public ArticlesController() : base((byte)Enums.ModelCoreType.Article) { }

        public sealed override SxRepoMaterial<Article, VMArticle> Repo
        {
            get
            {
                return _repo;
            }
        }

        [ChildActionOnly]
        public override PartialViewResult Last(byte? mct = null, int amount = 5, int? mid=null)
        {
            var viewModel = Repo.Last((byte)Enums.ModelCoreType.Article, amount, mid);
            return PartialView("_Last", viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult ReadingMaterial()
        {
            var viewModel = MvcApplication.ReadingMaterial ?? Repo.Last(mct: ModelCoreType, amount:1, mid:null).FirstOrDefault() ?? new VMArticle() { Html="Отсутсвуют данные БД"};
            return PartialView("_ReadingMaterial", viewModel);
        }

        [ChildActionOnly]
        public sealed override PartialViewResult Popular(int? mid = null, int amount = 4)
        {
            var viewModel = Repo.GetPopular(ModelCoreType, mid, amount);
            return PartialView("_Popular", viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult Subscribe()
        {
            var viewModel = new SxVMSubscriber();
            return PartialView("_Subscribe", viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult ForHome(int amount=11)
        {
            var viewModel = (Repo as RepoArticle).ForHome(amount);
            return PartialView("_ForHome", viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult Gallery(int boxesCount=3)
        {
            var viewModel = (Repo as RepoArticle).Gallery(boxesCount: boxesCount);

            ViewBag.BoxesCount = boxesCount;

            return PartialView("_Gallery", viewModel);
        }
    }
}