using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Entities
{
    public class Carrinho
    {
        public IList<ItemCarrinho> ItensCarrinho { get; set; }

        public Carrinho()
        {
            ItensCarrinho = new List<ItemCarrinho>();
        }

        public void AtualizarItensCarrinho()
        {
            foreach (var itemSemProduto in this.ItensCarrinho.Where(p => p.Produto == null).ToList())
                this.ItensCarrinho.Remove(itemSemProduto);

            foreach (var item in this.ItensCarrinho)
                item.Atualizar();
        }

        public ItemCarrinho AdicionarProduto(Produto produto)
        {
            ItemCarrinho itemCarrinho = null;

            if (produto == null) return null;

            itemCarrinho = this.ItensCarrinho.FirstOrDefault(p => p.CodigoProduto == produto.Codigo);
            if (itemCarrinho != null)
            {
                itemCarrinho.Quantidade++;
            }
            else
            {
                itemCarrinho = new ItemCarrinho(produto);
                this.ItensCarrinho.Add(itemCarrinho);
            }

            AtualizarItensCarrinho();

            return itemCarrinho;
        }

        public void RemoverProduto(int codigoProduto)
        {
            var item = this.ItensCarrinho.FirstOrDefault(p => p.CodigoProduto == codigoProduto);

            this.ItensCarrinho.Remove(item);

            AtualizarItensCarrinho();
        }
    }
}
