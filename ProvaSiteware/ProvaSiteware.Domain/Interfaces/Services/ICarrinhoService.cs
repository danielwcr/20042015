using ProvaSiteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Domain.Interfaces.Services
{
    public interface ICarrinhoService
    {
        Carrinho AtualizarItensCarrinho(Carrinho carrinho);

        Carrinho AdicionarItemCarrinho(Carrinho carrinho, int codigoProduto);

        Carrinho RemoverItemCarrinho(Carrinho carrinho, int codigoProduto);
    }
}
