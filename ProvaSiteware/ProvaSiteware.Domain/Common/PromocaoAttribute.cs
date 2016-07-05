using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Common
{
    public class PromocaoAttribute : Attribute
    {
        public TipoPromocao TipoPromocao { get; set; }
    }
}
