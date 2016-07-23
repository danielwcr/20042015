using AutoMapper;
using Lab.Domain.Entities;
using Lab.Presentation.MVC.ViewModels;

namespace Lab.Presentation.MVC.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainProfile"; }
        }

        public ViewModelToDomainProfile()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ForMember(p => p.Promocao, opt => opt.Ignore());

            CreateMap<CarrinhoViewModel, Carrinho>();

            CreateMap<ItemCarrinhoViewModel, ItemCarrinho>()
                .ForMember(p => p.Produto, opt => opt.Ignore())
                .ForMember(p => p.PromocaoAplicavel, opt => opt.Ignore());
        }
    }
}