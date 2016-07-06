using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace Lab.Domain.Test
{
    [TestClass]
    public class CarrinhoTest
    {
        [TestMethod]
        public void AdicionarProdutoDeveCriarUmNovoItemQuandoNaoExistirOProduto()
        {
            //Arrange
            var produto = new Produto() { Codigo = 1 };
            var carrinho = new Carrinho();

            //Act
            var itemDoCarrinho = carrinho.AdicionarProduto(produto);

            //Assert
            itemDoCarrinho.Should().NotBeNull();
            itemDoCarrinho.Quantidade.Should().Be(1);
            carrinho.ItensCarrinho.Count.Should().Be(1);
        }

        [TestMethod]
        public void AdicionarProdutoDeveAcrescentarUmaUnidadeQuandoJaExistirOProdutoInserido()
        {
            //Arrange
            var produto = new Produto() { Codigo = 1 };
            var carrinho = new Carrinho()
            {
                ItensCarrinho = new List<ItemCarrinho>()
                {
                    new ItemCarrinho(produto)
                }
            };

            //Act
            var itemDoCarrinho = carrinho.AdicionarProduto(produto);

            //Assert
            itemDoCarrinho.Should().NotBeNull();
            itemDoCarrinho.Quantidade.Should().Be(2);
            carrinho.ItensCarrinho.Count.Should().Be(1);
        }

        [TestMethod]
        public void AdicionarProdutoDeveRetornarNullQuandoProdutoInseridoForNull()
        {
            //Arrange
            var carrinho = new Carrinho();

            //Act
            var itemDoCarrinho = carrinho.AdicionarProduto(null);

            //Assert
            itemDoCarrinho.Should().BeNull();
            carrinho.ItensCarrinho.Count.Should().Be(0);
        }

        [TestMethod]
        public void RemoverProdutoDeveRemoverItemDoCarrinhoQuandoProdutoForEncontrado()
        {
            //Arrange
            var produto = new Produto() { Codigo = 1 };
            var carrinho = new Carrinho()
            {
                ItensCarrinho = new List<ItemCarrinho>()
                {
                    new ItemCarrinho(produto)
                }
            };

            //Act
            carrinho.RemoverProduto(1);

            //Assert
            var itemDoCarrinho = carrinho.ItensCarrinho.FirstOrDefault(p => p.CodigoProduto == produto.Codigo);

            itemDoCarrinho.Should().BeNull();
            carrinho.ItensCarrinho.Count.Should().Be(0);
        }

        [TestMethod]
        public void RemoverProdutoNaoDeveRemoverItemDoCarrinhoQuandoProdutoNaoForEncontrado()
        {
            //Arrange
            var produto = new Produto() { Codigo = 1 };
            var carrinho = new Carrinho()
            {
                ItensCarrinho = new List<ItemCarrinho>()
                {
                    new ItemCarrinho(produto)
                }
            };

            //Act
            carrinho.RemoverProduto(2);

            //Assert
            var itemDoCarrinho = carrinho.ItensCarrinho.FirstOrDefault(p => p.CodigoProduto == produto.Codigo);

            itemDoCarrinho.Should().NotBeNull();
            carrinho.ItensCarrinho.Count.Should().Be(1);
        }

        [TestMethod]
        public void AtualizarItensCarrinhoDeveRemoverItensDoCarrinhoQuandoProdutoForNull()
        {
            //Arrange
            var produto1 = new Produto() { Codigo = 1 };
            var produto2 = new Produto() { Codigo = 2 };
            var itemCarrinho2 = new ItemCarrinho(produto2);
            var carrinho = new Carrinho()
            {
                ItensCarrinho = new List<ItemCarrinho>()
                {
                    new ItemCarrinho(produto1),
                   itemCarrinho2
                }
            };
            itemCarrinho2.Produto = null;

            //Act
            carrinho.AtualizarItensCarrinho();

            //Assert
            carrinho.ItensCarrinho.Count.Should().Be(1);
            carrinho.ItensCarrinho.All(p => p.Produto != null).Should().BeTrue();
        }
    }
}
