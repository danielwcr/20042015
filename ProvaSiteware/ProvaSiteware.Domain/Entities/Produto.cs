using ProvaSiteware.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Domain.Entities
{
    public class Produto
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public TipoPromocao TipoPromocao { get; set; }

        private Promocao promocao;
        public Promocao Promocao
        {
            get
            {
                if (promocao == null)
                    promocao = Entities.Promocao.Obter(TipoPromocao);

                return promocao;
            }
        }
    }
}
