using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.Presentation.MVC.ViewModels
{
    public class ItemCarrinhoViewModel
    {
        [Key]
        public int CodigoProduto { get; set; }

        [Display(Name = "Quantidade")]
        [Range(1, 9999999)]
        public int Quantidade { get; set; }

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        public PromocaoViewModel PromocaoAplicavel { get; set; }

        public ProdutoViewModel Produto { get; set; }
    }
}