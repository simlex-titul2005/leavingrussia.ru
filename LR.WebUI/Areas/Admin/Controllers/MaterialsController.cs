using LR.WebUI.Infrastructure;
using SX.WebCore.Abstract;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using static SX.WebCore.Enums;

namespace LR.WebUI.Areas.Admin.Controllers
{
    public abstract class MaterialsController<TModel, TViewModel> : SxMaterialsController<TModel, TViewModel, DbContext>
        where TModel : SxMaterial
        where TViewModel : SxVMMaterial, new()
    {
        public MaterialsController(ModelCoreType mct) : base(mct) { }
    }
}