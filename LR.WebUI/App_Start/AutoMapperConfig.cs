using AutoMapper;
using LR.WebUI.Models;
using LR.WebUI.ViewModels;
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
            cfg.CreateMap<SxVMMaterial, VMArticle>();
        }
    }
}