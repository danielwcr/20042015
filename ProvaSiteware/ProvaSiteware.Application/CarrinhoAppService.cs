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
    public class CarrinhoAppService : AppServiceBase, ICarrinhoAppService
    {
        private readonly ICarrinhoService service;

        public CarrinhoAppService(ICarrinhoService service)
        {
            this.service = service;
        }

        public Carrinho AtualizarItensCarrinho(Carrinho carrinho)
        {
            Carrinho retorno = null;

            using (var scope = BeginTransaction())
            {
                retorno = service.AtualizarItensCarrinho(carrinho);
                scope.Commit();
            }

            return retorno;
        }

        public Carrinho AdicionarItemCarrinho(Carrinho carrinho, int codigoProduto)
        {
            Carrinho retorno = null;

            using (var scope = BeginTransaction())
            {
                retorno = service.AdicionarItemCarrinho(carrinho, codigoProduto);
                scope.Commit();
            }

            return retorno;
        }

        public Carrinho RemoverItemCarrinho(Carrinho carrinho, int codigoProduto)
        {
            Carrinho retorno = null;

            using (var scope = BeginTransaction())
            {
                retorno = service.RemoverItemCarrinho(carrinho, codigoProduto);
                scope.Commit();
            }

            return retorno;
        }
    }
}
