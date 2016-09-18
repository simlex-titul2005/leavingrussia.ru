using LR.WebUI.ViewModels;
using SX.WebCore.MvcControllers;
using static SX.WebCore.Enums;

namespace LR.WebUI.Controllers
{
    public sealed class SeoController : SxSeoController
    {
        protected override System.Func<dynamic, string> SeoItemUrlFunc
        {
            get
            {
                return model => { return SeoItemUrlFunc(model); };
            }
        }

        private string getSeoItemUrl(dynamic model)
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