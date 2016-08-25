using System.Web.Mvc;
using LR.WebUI.ViewModels.Abstract;

namespace LR.WebUI.ViewModels
{
    public sealed class VMNews : VMMaterial
    {
        public sealed override string GetUrl(UrlHelper urlHelper)
        {
            return urlHelper.Action("Details", "News", new { year = DateCreate.Year, month = DateCreate.Month.ToString("00"), day = DateCreate.Day.ToString("00"), titleUrl = TitleUrl });
        }
    }
}