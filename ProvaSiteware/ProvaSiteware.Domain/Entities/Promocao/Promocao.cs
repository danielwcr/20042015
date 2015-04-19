using ProvaSiteware.Domain.Common;
using ProvaSiteware.Domain.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Domain.Entities
{
    public abstract class Promocao
    {
        private TipoPromocao? tipoPromocao;

        public TipoPromocao TipoPromocao
        {
            get
            {
                if (!tipoPromocao.HasValue)
                {
                    var att = (PromocaoAttribute[])this.GetType().GetCustomAttributes(typeof(PromocaoAttribute), true);
                    if (att.Length == 1)
                        tipoPromocao = att[0].TipoPromocao;
                    else
                        tipoPromocao = TipoPromocao.Indefinido;
                }

                return tipoPromocao.Value;
            }
        }

        public string Nome
        {
            get { return EnumHelper.GetEnumDescription(TipoPromocao); }
        }

        public static Promocao Obter(TipoPromocao? tipoPromocao)
        {
            if (!tipoPromocao.HasValue) return null;

            return ListarPromocoes().FirstOrDefault(p => p.TipoPromocao == tipoPromocao.Value);
        }

        public static IEnumerable<Promocao> ListarPromocoes()
        {
            var types = typeof(Promocao).Assembly.GetTypes().Where(type => type.GetCustomAttributes(typeof(PromocaoAttribute), true).Length > 0);

            foreach (var type in types)
                yield return (Promocao)Activator.CreateInstance(type);
        }

        public abstract decimal CalcularPreco(Produto produto, int quantidade);
        public abstract bool Aplicavel(int quantidade);
    }
}
