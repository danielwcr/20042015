using ProvaSiteware.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaSiteware.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o Nome do produto")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o Preço do produto")]
        [DataType(DataType.Currency)]
        [Range(0, 9999999999999999.99, ErrorMessage = "Preço inválido")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Promoção")]
        public TipoPromocao TipoPromocao { get; set; }

        public PromocaoViewModel Promocao { get; set; }
    }
}