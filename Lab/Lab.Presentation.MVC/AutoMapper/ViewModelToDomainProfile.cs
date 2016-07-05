using AutoMapper;
using Lab.Domain.Entities;
using Lab.Presentation.MVC.ViewModels;
using System.Linq;

namespace Lab.Presentation.MVC.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ProdutoViewModel, Produto>()
                .ForMember(p => p.Promocao, opt => opt.Ignore());

            Mapper.CreateMap<CarrinhoViewModel, Carrinho>();

            Mapper.CreateMap<ItemCarrinhoViewModel, ItemCarrinho>()
                .ForMember(p => p.Produto, opt => opt.Ignore())
                .ForMember(p => p.PromocaoAplicavel, opt => opt.Ignore());

        }
    }
}