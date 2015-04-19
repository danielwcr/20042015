using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaSiteware.MVC.ViewModels
{
    public class ItemCarrinhoViewModel
    {
        [Key]
        public int CodigoProduto { get; set; }

        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        public PromocaoViewModel PromocaoAplicavel { get; set; }

        public ProdutoViewModel Produto { get; set; }
    }
}