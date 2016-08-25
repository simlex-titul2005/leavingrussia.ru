using LR.WebUI.ViewModels.Abstract;
using System.Web.Mvc;

namespace LR.WebUI.ViewModels
{
    public sealed class VMArticle: VMMaterial
    {
        public sealed override string GetUrl(UrlHelper urlHelper)
        {
            return urlHelper.Action("Details", "Articles", new { year = DateCreate.Year, month = DateCreate.Month.ToString("00"), day = DateCreate.Day.ToString("00"), titleUrl = TitleUrl });
        }
    }
}