using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Domain.Entities
{
    public class Carrinho
    {
        public IList<ItemCarrinho> ItensCarrinho { get; set; }

        public void AtualizarItensCarrinho()
        {
            // Remove os itens que não existe mais produto (Caso de exclusão do produto)
            foreach (var itemSemProduto in this.ItensCarrinho.Where(p => p.Produto == null).ToList())
                this.ItensCarrinho.Remove(itemSemProduto);

            // Atualizar todos os itens do carrinho
            foreach (var item in this.ItensCarrinho)
                item.Atualizar();
        }

        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
                return;

            // Procura por um item com o mesmo produto
            var itemRepetido = this.ItensCarrinho.FirstOrDefault(p => p.CodigoProduto == produto.Codigo);

            // Se encontrar, adiciona uma unidade na quantidade
            if (itemRepetido != null)
                itemRepetido.Quantidade++;

            // Se não encontrar, cria um item para o produto
            else
            {
                var novoItem = new ItemCarrinho(produto);
                this.ItensCarrinho.Add(novoItem);
            }

            // Atualiza todos os itens
            AtualizarItensCarrinho();
        }

        internal void RemoverProduto(int codigoProduto)
        {
            // Identifica o item que será removido
            var item = this.ItensCarrinho.FirstOrDefault(p => p.CodigoProduto == codigoProduto);

            // Remove o item com o produto informado
            this.ItensCarrinho.Remove(item);

            // Atualiza todos os itens
            AtualizarItensCarrinho();
        }
    }
}
