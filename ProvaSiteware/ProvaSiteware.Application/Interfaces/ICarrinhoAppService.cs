using Lab.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application.Interfaces
{
    public interface ICarrinhoAppService
    {
        Carrinho AtualizarItensCarrinho(Carrinho carrinho);
        Carrinho AdicionarItemCarrinho(Carrinho carrinho, int codigoProduto);
        Carrinho RemoverItemCarrinho(Carrinho carrinho, int codigoProduto);
    }
}
