using AutoMapper;
using Lab.Domain.Entities;
using Lab.Presentation.MVC.ViewModels;

namespace Lab.Presentation.MVC.AutoMapper
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

            Mapper.CreateMap<Carrinho, CarrinhoViewModel>();
            Mapper.CreateMap<ItemCarrinho, ItemCarrinhoViewModel>();

            Mapper.CreateMap<Promocao, PromocaoViewModel>()
                .Include<TresPorDezReais, PromocaoViewModel>()
                .Include<PagueUmLeveDois, PromocaoViewModel>();

            Mapper.CreateMap<TresPorDezReais, PromocaoViewModel>();
            Mapper.CreateMap<PagueUmLeveDois, PromocaoViewModel>();
        }
    }
}