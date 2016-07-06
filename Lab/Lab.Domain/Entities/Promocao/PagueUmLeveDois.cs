using Lab.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Entities
{
    [Promocao(TipoPromocao = TipoPromocao.PagueUmLeveDois)]
    public class PagueUmLeveDois : Promocao
    {
        private const int QuantidadeItensParaBaseDeCalculo = 2;

        public override decimal CalcularPreco(Produto produto, int quantidade)
        {
            decimal valor = 0;
            var quantidadeNaoProcessada = quantidade;

            while (Aplicavel(quantidadeNaoProcessada))
            {
                valor += produto.Preco;
                quantidadeNaoProcessada -= QuantidadeItensParaBaseDeCalculo;
            }

            valor += quantidadeNaoProcessada * produto.Preco;

            return valor;
        }

        public override bool Aplicavel(int quantidade)
        {
            return quantidade >= QuantidadeItensParaBaseDeCalculo;
        }
    }
}
