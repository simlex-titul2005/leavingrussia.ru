using LR.WebUI.Infrastructure.Repositories;
using LR.WebUI.Models;
using LR.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.Repositories;

namespace LR.WebUI.Areas.Admin.Controllers
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
    }
}