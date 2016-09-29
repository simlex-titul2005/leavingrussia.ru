using SX.WebCore;
using SX.WebCore.ViewModels;
using System.Web.Mvc;

namespace LR.WebUI.ViewModels.Abstract
{
    public abstract class VMMaterial : SxVMMaterial
    {
        public override string GetUrl(UrlHelper urlHelper)
        {
            switch(ModelCoreType)
            {
                case Enums.ModelCoreType.Article:
                    return urlHelper.Action("Details", "Articles", new { year = DateCreate.Year, month = DateCreate.Month.ToString("00"), day = DateCreate.Day.ToString("00"), titleUrl = TitleUrl });
                case Enums.ModelCoreType.News:
                    return urlHelper.Action("Details", "News", new { year = DateCreate.Year, month = DateCreate.Month.ToString("00"), day = DateCreate.Day.ToString("00"), titleUrl = TitleUrl });
                default:
                    return "#";
            }
        }
    }
}