using SX.WebCore.ViewModels;
using System.Web.Mvc;

namespace LR.WebUI.ViewModels.Abstract
{
    public abstract class VMMaterial : SxVMMaterial
    {
        public abstract string GetUrl(UrlHelper urlHelper);
    }
}