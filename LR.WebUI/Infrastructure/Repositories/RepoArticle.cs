using LR.WebUI.Models;
using LR.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.Repositories;

namespace LR.WebUI.Infrastructure.Repositories
{
    public sealed class RepoArticle : SxRepoMaterial<Article, VMArticle, DbContext>
    {
        public RepoArticle() : base(Enums.ModelCoreType.Article) { }
    }
}