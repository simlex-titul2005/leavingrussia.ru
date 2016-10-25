using SX.WebCore.ViewModels;
using System.Web.Mvc;

namespace LR.WebUI.ViewModels.Abstract
{
    public class VMMaterial : SxVMMaterial
    {
        public override string GetUrl(UrlHelper urlHelper)
        {
            switch(ModelCoreType)
            {
                case 1:
                    return urlHelper.Action("Details", "Articles", new { year = DateCreate.Year, month = DateCreate.Month.ToString("00"), day = DateCreate.Day.ToString("00"), titleUrl = TitleUrl });
                case 2:
                    return urlHelper.Action("Details", "News", new { year = DateCreate.Year, month = DateCreate.Month.ToString("00"), day = DateCreate.Day.ToString("00"), titleUrl = TitleUrl });
                default:
                    return "#";
            }
        }
    }
}