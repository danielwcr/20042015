using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Domain.Common
{
    public enum TipoPromocao
    {
        [Description("Sem promoção")]
        SemPromocao = 0,
        [Description("Pague 1 e leve 2")]
        PagueUmLeveDois = 1,
        [Description("3 por 10 reais")]
        TresPorDezReais = 2
    }
}
