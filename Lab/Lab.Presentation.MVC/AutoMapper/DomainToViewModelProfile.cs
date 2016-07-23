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

        public DomainToViewModelProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();

            CreateMap<Carrinho, CarrinhoViewModel>();
            CreateMap<ItemCarrinho, ItemCarrinhoViewModel>();

            CreateMap<Promocao, PromocaoViewModel>()
                .Include<TresPorDezReais, PromocaoViewModel>()
                .Include<PagueUmLeveDois, PromocaoViewModel>();

            CreateMap<TresPorDezReais, PromocaoViewModel>();
            CreateMap<PagueUmLeveDois, PromocaoViewModel>();
        }
    }
}