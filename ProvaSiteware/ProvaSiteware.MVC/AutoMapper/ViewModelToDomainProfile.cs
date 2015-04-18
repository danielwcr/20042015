using AutoMapper;
using ProvaSiteware.Domain.Entities;
using ProvaSiteware.MVC.ViewModels;

namespace ProvaSiteware.MVC.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ProdutoViewModel, Produto>();
        }
    }
}