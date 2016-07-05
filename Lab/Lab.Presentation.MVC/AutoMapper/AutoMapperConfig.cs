using AutoMapper;

namespace Lab.Presentation.MVC.AutoMapper
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