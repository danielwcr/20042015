using ProvaSiteware.Domain.Entities;
using ProvaSiteware.Domain.Interfaces.Repositories;
using ProvaSiteware.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaSiteware.Domain.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly IProdutoRepository repository;

        public CarrinhoService(IProdutoRepository repository)
        {
            this.repository = repository;
        }

        public Carrinho AtualizarItensCarrinho(Carrinho carrinho)
        {
            // Atualiza todos os produtos do carrinho
            foreach (var item in carrinho.ItensCarrinho)
                item.Produto = repository.Get(item.CodigoProduto);

            carrinho.AtualizarItensCarrinho();

            return carrinho;
        }

        public Carrinho AdicionarItemCarrinho(Carrinho carrinho, int codigoProduto)
        {
            // Atualiza todos os produtos do carrinho
            foreach (var item in carrinho.ItensCarrinho)
                item.Produto = repository.Get(item.CodigoProduto);

            carrinho.AdicionarProduto(repository.Get(codigoProduto));

            return carrinho;
        }

        public Carrinho RemoverItemCarrinho(Carrinho carrinho, int codigoProduto)
        {
            // Atualiza todos os produtos do carrinho
            foreach (var item in carrinho.ItensCarrinho)
                item.Produto = repository.Get(item.CodigoProduto);

            carrinho.RemoverProduto(codigoProduto);

            return carrinho;
        }
    }
}
