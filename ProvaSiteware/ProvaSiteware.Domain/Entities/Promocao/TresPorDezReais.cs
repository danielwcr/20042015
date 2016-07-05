using Lab.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Entities
{
    [PromocaoAttribute(TipoPromocao = TipoPromocao.TresPorDezReais)]
    public class TresPorDezReais : Promocao
    {
        const int QUANTIDADE_ITENS_BASE_CALCULO = 3;

        public override decimal CalcularPreco(Produto produto, int quantidade)
        {
            decimal valor = 0;
            var quantidadeNaoProcessada = quantidade;

            while (Aplicavel(quantidadeNaoProcessada))
            {
                valor += 10;
                quantidadeNaoProcessada -= QUANTIDADE_ITENS_BASE_CALCULO;
            }

            valor += quantidadeNaoProcessada * produto.Preco;

            return valor;
        }

        public override bool Aplicavel(int quantidade)
        {
            return quantidade >= QUANTIDADE_ITENS_BASE_CALCULO;
        }
    }
}
