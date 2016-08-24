using LR.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.Abstract;
using SX.WebCore.Repositories;

namespace LR.WebUI.Infrastructure.Repositories
{
    public sealed class RepoArticle : SxRepoMaterial<SxMaterial, VMArticle, DbContext>
    {
        public RepoArticle() : base(Enums.ModelCoreType.Article) { }
    }
}