using AutoMapper;

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
                //aphorism
                //cfg.CreateMap<Aphorism, VMAphorism>();
            });
            }
        }
    }
}