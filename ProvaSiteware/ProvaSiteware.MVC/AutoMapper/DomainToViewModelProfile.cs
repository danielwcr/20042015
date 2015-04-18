using AutoMapper;
using ProvaSiteware.Domain.Entities;
using ProvaSiteware.MVC.ViewModels;

namespace ProvaSiteware.MVC.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Produto, ProdutoViewModel>();
        }
    }
}