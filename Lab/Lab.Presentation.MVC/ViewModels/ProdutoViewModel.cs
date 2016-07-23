using Lab.Domain.Common;
using Lab.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.Presentation.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = nameof(Nome), ResourceType = typeof(Resource))]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Currency)]
        [Range(0, 9999999.99)]
        [Display(Name = nameof(Preco), ResourceType = typeof(Resource))]
        public decimal Preco { get; set; }

        [Display(Name = "Promocao", ResourceType = typeof(Resource))]
        public TipoPromocao TipoPromocao { get; set; }

        public PromocaoViewModel Promocao { get; set; }
    }
}