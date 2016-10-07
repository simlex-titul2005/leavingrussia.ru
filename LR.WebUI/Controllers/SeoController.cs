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
                return getSeoItemUrl;
            }
        }

        private string getSeoItemUrl(dynamic model)
        {
            var mct = (byte)model.ModelCoreType;
            switch (mct)
            {
                case (byte)ModelCoreType.Article:
                    return new VMArticle { DateCreate = model.DateCreate, TitleUrl = model.TitleUrl, ModelCoreType = mct }.GetUrl(Url); ;
                default:
                    return null;
            }
        }
    }
}