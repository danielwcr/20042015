using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.Domain.Entities;
using FluentAssertions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public delegate void customHandler(int a);

        public event customHandler customEvent;
        public event EventHandler defaultEvent;



        public interface IPoint
        {
            int A { get; set; }
            int B { get; set; }

            void methodTest();
        }

        public struct Point : IPoint
        {
            public int A { get; set; }
            public int B { get; set; }

            public void methodTest()
            {

            }
        }

        public struct BigPoint : IPoint
        {
            public int A { get; set; }
            public int B { get; set; }

            static BigPoint()
            {

            }

            public BigPoint(int a, int b)
            {
                A = a;
                B = b;
            }

            public void bigMethodTest()
            {

            }

            public void methodTest()
            {
                
            }
        }

        [TestMethod]
        public void GeneralPurposeTest()
        {
            var func = new Func<string>(() => { return string.Empty; });
            var action = new Action<int>((p) => { });

            Expression<Func<Promocao, bool>> expression = p => p.TipoPromocao == Common.TipoPromocao.PagueUmLeveDois;

            var list = new List<Promocao>();

            var point = new Point();
            point.methodTest();


            customEvent += (a) => { };
            customEvent.Invoke(1);

            defaultEvent += PromocaoTest_defaultEvent1;
            defaultEvent += PromocaoTest_defaultEvent2;
            defaultEvent.Invoke(this, EventArgs.Empty);

            var lazyInt = new Lazy<int>(() => { return 3; });
            // c stores up to eight values 
            var tuple = new Tuple<string, int, Tuple<object, int>>("", 9, new Tuple<object, int>("", 7));
            var array = new int[4];
            var dictionary = new Dictionary<int, string>()
            {
                [2] = "uh"
            };

            // Covariance enables you to cast a generic type to its base types
            IEnumerable<string> str1 = new List<string>();
            IEnumerable<object> str2 = str1;

            // Contravariance allows you to assign a variable of Action<base> to a variable of type Action<derived>
            Action<object> act1 = new Action<object>(p => { });
            Action<string> act2 = act1;

            act2.Invoke("");
            act1.Invoke(2);
        }

        private void PromocaoTest_defaultEvent1(object sender, EventArgs e)
        {
            var hh = "my good";
        }

        private void PromocaoTest_defaultEvent2(object sender, EventArgs e)
        {
            var hh = "my good";
        }
    }
}