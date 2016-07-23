using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Presentation.MVC.ViewModels
{
    public class CultureOptionVM
    {
        public string Culture { get; set; }
        public bool Current { get; internal set; }
    }
}