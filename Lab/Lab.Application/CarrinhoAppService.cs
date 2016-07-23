using Lab.Application.Aspect;
using Lab.Application.Interfaces;
using Lab.Domain.Entities;
using Lab.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application
{
    public class CarrinhoAppService : ICarrinhoAppService
    {
        private readonly ICarrinhoService service;

        public CarrinhoAppService(ICarrinhoService service)
        {
            this.service = service;
        }

        [UnitOfWorkAspect]
        public Carrinho AtualizarItensCarrinho(Carrinho carrinho)
        {
            return service.AtualizarItensCarrinho(carrinho);
        }

        [UnitOfWorkAspect]
        public Carrinho AdicionarItemCarrinho(Carrinho carrinho, int codigoProduto)
        {
            return service.AdicionarItemCarrinho(carrinho, codigoProduto);
        }

        [UnitOfWorkAspect]
        public Carrinho RemoverItemCarrinho(Carrinho carrinho, int codigoProduto)
        {
            return service.RemoverItemCarrinho(carrinho, codigoProduto);
        }
    }
}
