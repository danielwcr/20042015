using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Entities
{
    public class ItemCarrinho
    {
        public int CodigoProduto { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; protected set; }

        public Promocao PromocaoAplicavel { get; protected set; }

        public Produto Produto { get; set; }

        public ItemCarrinho(Produto produto)
        {
            Quantidade = 1;
            CodigoProduto = produto.Codigo;
            Produto = produto;
        }

        public void Atualizar()
        {
            IdentificarPromocao();
            CalcularPreco();
        }

        private void CalcularPreco()
        {
            if (PromocaoAplicavel != null)
                this.Preco = PromocaoAplicavel.CalcularPreco(Produto, Quantidade);
            else
                this.Preco = Produto.Preco * Quantidade;
        }

        private void IdentificarPromocao()
        {
            if (Produto == null)
                throw new InvalidOperationException("Não é possível calcular ItemCarrinho sem o produto configurado");

            // O verifica se a promoção configurada no produto é aplicável
            if (Produto.Promocao != null && Produto.Promocao.Aplicavel(Quantidade))
                this.PromocaoAplicavel = Produto.Promocao;
            else
                this.PromocaoAplicavel = null;
        }
    }
}
