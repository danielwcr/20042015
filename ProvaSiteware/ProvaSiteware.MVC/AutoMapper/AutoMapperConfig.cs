using AutoMapper;

namespace ProvaSiteware.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(p =>
            {
                p.AddProfile<DomainToViewModelProfile>();
                p.AddProfile<ViewModelToDomainProfile>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}