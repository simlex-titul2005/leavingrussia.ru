using System.Web.Mvc;
using LR.WebUI.Infrastructure.Repositories;
using LR.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.ViewModels;
using LR.WebUI.Models;
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
        public PartialViewResult Subscribe()
        {
            var viewModel = new SxVMSubscriber();
            return PartialView("_Subscribe", viewModel);
        }

#if !DEBUG
        [OutputCache(Duration=3600)]
#endif
        [ChildActionOnly]
        public PartialViewResult ForHome(int amount=11)
        {
            var viewModel = (Repo as RepoArticle).ForHome(amount);
            return PartialView("_ForHome", viewModel);
        }

#if !DEBUG
        [OutputCache(Duration=3600)]
#endif
        [ChildActionOnly]
        public PartialViewResult Gallery(int boxesCount=3)
        {
            var viewModel = (Repo as RepoArticle).Gallery(boxesCount: boxesCount);

            ViewBag.BoxesCount = boxesCount;

            return PartialView("_Gallery", viewModel);
        }
    }
}