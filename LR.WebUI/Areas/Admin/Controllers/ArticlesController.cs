using LR.WebUI.Infrastructure.Repositories;
using LR.WebUI.Models;
using LR.WebUI.ViewModels;
using SX.WebCore;

namespace LR.WebUI.Areas.Admin.Controllers
{
    public sealed class ArticlesController : MaterialsController<Article, VMArticle>
    {
        static ArticlesController()
        {
            Repo = new RepoArticle();
        }

        public ArticlesController() : base(Enums.ModelCoreType.Article) { }
    }
}