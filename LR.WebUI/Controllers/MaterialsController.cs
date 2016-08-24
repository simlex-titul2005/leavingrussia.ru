using LR.WebUI.Infrastructure;
using SX.WebCore.Abstract;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using static SX.WebCore.Enums;

namespace LR.WebUI.Controllers
{
    public abstract class MaterialsController<TViewModel> : SxMaterialsController<SxMaterial, TViewModel, DbContext>
        where TViewModel : SxVMMaterial
    {
        public MaterialsController(ModelCoreType mct) : base(mct) { }
    }
}