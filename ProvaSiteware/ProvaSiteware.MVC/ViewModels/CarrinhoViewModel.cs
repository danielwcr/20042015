using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaSiteware.MVC.ViewModels
{
    public class CarrinhoViewModel
    {
        public IEnumerable<ItemCarrinhoViewModel> ItensCarrinho { get; set; }
    }
}