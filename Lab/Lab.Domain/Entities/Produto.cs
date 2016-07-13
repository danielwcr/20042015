using Lab.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Entities
{
    public class Produto
    {
        public virtual int Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual decimal Preco { get; set; }
        public virtual TipoPromocao TipoPromocao { get; set; }

        private Promocao promocao;
        public virtual Promocao Promocao
        {
            get
            {
                if (promocao == null)
                    promocao = Promocao.Obter(TipoPromocao);

                return promocao;
            }
        }
    }
}
