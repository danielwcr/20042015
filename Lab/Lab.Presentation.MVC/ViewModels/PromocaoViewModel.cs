using Lab.Domain.Common;
using Lab.Resources;
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

        [Display(Name = "Promocao", ResourceType = typeof(Resource))]
        public string Nome { get; set; }
    }
}