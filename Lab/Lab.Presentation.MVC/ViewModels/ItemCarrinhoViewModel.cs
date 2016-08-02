using Lab.Domain.Entities;
using Lab.Resources;
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

        [Display(Name = nameof(Quantidade), ResourceType = typeof(Resource))]
        [Range(1, 9999999)]
        public int Quantidade { get; set; }

        [Display(Name = nameof(Preco), ResourceType = typeof(Resource))]
        public decimal Preco { get; set; }

        public PromocaoViewModel PromocaoAplicavel { get; set; }

        public Produto Produto { get; set; }
    }
}