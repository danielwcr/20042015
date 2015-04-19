using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Domain.Common
{
    public class PromocaoAttribute : Attribute
    {
        public TipoPromocao TipoPromocao { get; set; }
    }
}
