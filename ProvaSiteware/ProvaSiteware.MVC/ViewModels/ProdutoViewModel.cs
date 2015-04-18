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

        [Required(ErrorMessage = "Preencha o Nome do Produto")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o Preço do Produto")]
        [DataType(DataType.Currency)]
        [Range(0, 9999999999999999.99, ErrorMessage = "Valor inválido")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        //[RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$"]
        //[RegularExpression(@"^\d+.\d{0,2}$")]
    }
}