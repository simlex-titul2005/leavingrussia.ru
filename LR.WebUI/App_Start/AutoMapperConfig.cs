using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using SX.WebCore;
using SX.WebCore.ViewModels;

namespace LR.WebUI
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfigurationInstance
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    //net
                    cfg.CreateMap<SxNet, SxVMNet>();

                    //picture
                    cfg.CreateMap<SxPicture, SxVMPicture>();
                    cfg.CreateMap<SxPicture, SxVMEditPicture>();
                    cfg.CreateMap<SxVMEditPicture, SxPicture>();

                    //request
                    cfg.CreateMap<SxRequest, SxVMRequest>();

                    //role
                    cfg.CreateMap<SxAppRole, SxVMAppRole>();
                    cfg.CreateMap<SxAppRole, SxVMEditAppRole>();
                    cfg.CreateMap<SxVMEditAppRole, SxAppRole>();
                    cfg.CreateMap<IdentityUserRole, SxVMAppRole>();

                    //role
                    cfg.CreateMap<SxShareButton, SxVMShareButton>();
                    cfg.CreateMap<SxShareButton, SxVMEditShareButton>();
                    cfg.CreateMap<SxVMEditShareButton, SxShareButton>();

                    //seo keyword
                    cfg.CreateMap<SxSeoKeyword, SxVMSeoKeyword>();
                    cfg.CreateMap<SxSeoKeyword, SxVMEditSeoKeyword>();
                    cfg.CreateMap<SxVMEditSeoKeyword, SxSeoKeyword>();

                    //seo tags
                    cfg.CreateMap<SxSeoTags, SxVMSeoTags>();
                    cfg.CreateMap<SxSeoTags, SxVMEditSeoTags>();
                    cfg.CreateMap<SxVMEditSeoTags, SxSeoTags>();
                    cfg.CreateMap<SxVMSeoTags, SxSeoTags>();

                    //StatisticUserLogin 
                    cfg.CreateMap<SxStatisticUserLogin, SxVMStatisticUserLogin>()
                        .ForMember(d => d.DateCreate, d => d.MapFrom(s => s.Statistic.DateCreate))
                        .ForMember(d => d.NikName, d => d.MapFrom(s => s.User.NikName))
                        .ForMember(d => d.AvatarId, d => d.MapFrom(s => s.User.AvatarId));

                    //user
                    cfg.CreateMap<SxAppUser, SxVMAppUser>();
                    cfg.CreateMap<SxAppUser, SxVMEditAppUser>();
                    cfg.CreateMap<SxVMEditAppUser, SxAppUser>();

                    //video
                    cfg.CreateMap<SxVideo, SxVMVideo>();
                    cfg.CreateMap<SxVideo, SxVMEditVideo>();
                    cfg.CreateMap<SxVMEditVideo, SxVideo>();

                });
            }
        }
    }
}