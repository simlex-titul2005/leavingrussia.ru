using AutoMapper;
using LR.WebUI.Models;
using LR.WebUI.ViewModels;
using LR.WebUI.ViewModels.Abstract;
using SX.WebCore.ViewModels;

namespace LR.WebUI
{
    public class AutoMapperConfig
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            //article
            cfg.CreateMap<Article, VMArticle>();
            cfg.CreateMap<VMArticle, Article>();
            cfg.CreateMap<SxVMMaterial, VMMaterial>();
            cfg.CreateMap<SxVMMaterial, VMArticle>();
        }
    }
}