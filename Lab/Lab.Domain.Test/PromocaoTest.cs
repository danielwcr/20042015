using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.Domain.Entities;
using FluentAssertions;

namespace Lab.Domain.Test
{
    [TestClass]
    public class PromocaoTest
    {
        #region PagueUmLeveDois
        [TestMethod]
        public void PagueUmLeveDoisDeveSerAplicavelQuandoQuantidadeForMaiorOuIgualA2()
        {
            //Arrange
            var quantidade = 3;
            var promocao = new PagueUmLeveDois();

            //Act
            var aplicavel = promocao.Aplicavel(quantidade);

            //Assert
            aplicavel.Should().BeTrue();
        }

        [TestMethod]
        public void PagueUmLeveDoisNaoDeveSerAplicavelQuandoQuantidadeForMenorQue2()
        {
            //Arrange
            var quantidade = 1;
            var promocao = new PagueUmLeveDois();

            //Act
            var aplicavel = promocao.Aplicavel(quantidade);

            //Assert
            aplicavel.Should().BeFalse();
        }

        [TestMethod]
        public void PagueUmLeveDoisDeveCalcularPrecoIgualA20QuandoProdutoCustar10EQuantidadeFor3()
        {
            //Arrange
            var quantidade = 3;
            var produto = new Produto() { Preco = 10 };
            var promocao = new PagueUmLeveDois();

            //Act
            var preco = promocao.CalcularPreco(produto, quantidade);

            //Assert
            preco.Should().Be(20);
        }

        [TestMethod]
        public void PagueUmLeveDoisDeveCalcularPrecoIgual10QuandoProdutoCustar10EQuantidadeFor1()
        {
            //Arrange
            var quantidade = 1;
            var produto = new Produto() { Preco = 10 };
            var promocao = new PagueUmLeveDois();

            //Act
            var preco = promocao.CalcularPreco(produto, quantidade);

            //Assert
            preco.Should().Be(10);
        }

        [TestMethod]
        public void PagueUmLeveDoisDeveCalcularPrecoIgual10QuandoProdutoCustar10EQuantidadeFor2()
        {
            //Arrange
            var quantidade = 1;
            var produto = new Produto() { Preco = 10 };
            var promocao = new PagueUmLeveDois();

            //Act
            var preco = promocao.CalcularPreco(produto, quantidade);

            //Assert
            preco.Should().Be(10);
        }

        #endregion

        #region TresPorDezReais
        [TestMethod]
        public void TresPorDezReaisDeveSerAplicavelQuandoQuantidadeForMaiorOuIgualA3()
        {
            //Arrange
            var quantidade = 3;
            var promocao = new TresPorDezReais();

            //Act
            var aplicavel = promocao.Aplicavel(quantidade);

            //Assert
            aplicavel.Should().BeTrue();
        }

        [TestMethod]
        public void TresPorDezReaisNaoDeveSerAplicavelQuandoQuantidadeForMenorQue3()
        {
            //Arrange
            var quantidade = 1;
            var promocao = new TresPorDezReais();

            //Act
            var aplicavel = promocao.Aplicavel(quantidade);

            //Assert
            aplicavel.Should().BeFalse();
        }

        [TestMethod]
        public void TresPorDezReaisDeveCalcularPrecoIgualA14QuandoProdutoCustar4EQuantidadeFor4()
        {
            //Arrange
            var quantidade = 4;
            var produto = new Produto() { Preco = 4 };
            var promocao = new TresPorDezReais();

            //Act
            var preco = promocao.CalcularPreco(produto, quantidade);

            //Assert
            preco.Should().Be(14);
        }

        [TestMethod]
        public void TresPorDezReaisDeveCalcularPrecoIgual10QuandoProdutoCustar4EQuantidadeFor3()
        {
            //Arrange
            var quantidade = 1;
            var produto = new Produto() { Preco = 10 };
            var promocao = new TresPorDezReais();

            //Act
            var preco = promocao.CalcularPreco(produto, quantidade);

            //Assert
            preco.Should().Be(10);
        }

        [TestMethod]
        public void TresPorDezReaisDeveCalcularPrecoIgual8QuandoProdutoCustar4EQuantidadeFor2()
        {
            //Arrange
            var quantidade = 2;
            var produto = new Produto() { Preco = 4 };
            var promocao = new TresPorDezReais();

            //Act
            var preco = promocao.CalcularPreco(produto, quantidade);

            //Assert
            preco.Should().Be(8);
        }

        #endregion
    }
}
