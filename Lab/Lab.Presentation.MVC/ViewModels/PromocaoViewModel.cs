using Lab.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.Presentation.MVC.ViewModels
{
    public class PromocaoViewModel
    {
        public TipoPromocao TipoPromocao { get; set; }

        [Display(Name = "Promoção")]
        public string Nome { get; set; }
    }
}