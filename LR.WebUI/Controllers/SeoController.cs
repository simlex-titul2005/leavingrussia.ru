using LR.WebUI.Infrastructure;
using LR.WebUI.ViewModels;
using SX.WebCore.MvcControllers;
using static SX.WebCore.Enums;

namespace LR.WebUI.Controllers
{
    public sealed class SeoController : SxSeoController<DbContext>
    {
        public SeoController()
        {
            SeoItemUrlFunc = SeoItemUrl;
        }

        public string SeoItemUrl(dynamic model)
        {
            var mct = (ModelCoreType)model.ModelCoreType;
            switch (mct)
            {
                case ModelCoreType.Article:
                    return new VMArticle { DateCreate = model.DateCreate, TitleUrl = model.TitleUrl }.GetUrl(Url);
                default:
                    return null;
            }
        }
    }
}