using ProvaSiteware.Application.Interfaces;
using ProvaSiteware.Domain.Entities;
using ProvaSiteware.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Application
{
    public class CarrinhoAppService : ICarrinhoAppService
    {
        private readonly ICarrinhoService service;

        public CarrinhoAppService(ICarrinhoService service)
        {
            this.service = service;
        }

        public Carrinho AtualizarItensCarrinho(Carrinho carrinho)
        {
            return service.AtualizarItensCarrinho(carrinho);
        }

        public Carrinho AdicionarItemCarrinho(Carrinho carrinho, int codigoProduto)
        {
            return service.AdicionarItemCarrinho(carrinho, codigoProduto);
        }

        public Carrinho RemoverItemCarrinho(Carrinho carrinho, int codigoProduto)
        {
            return service.RemoverItemCarrinho(carrinho, codigoProduto);
        }
    }
}
