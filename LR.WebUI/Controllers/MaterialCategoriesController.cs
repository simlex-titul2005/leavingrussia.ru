using LR.WebUI.Infrastructure;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using System.Web.Mvc;

namespace LR.WebUI.Controllers
{
    [AllowAnonymous]
    public sealed class MaterialCategoriesController : SxMaterialCategoriesController<SxVMMaterialCategory, DbContext>
    {
        
    }
}