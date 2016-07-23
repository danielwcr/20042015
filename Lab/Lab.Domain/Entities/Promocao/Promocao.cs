using Lab.Domain.Common;
using Lab.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Domain.Entities
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
                    var attibutes = (PromocaoAttribute[])this.GetType().GetCustomAttributes(typeof(PromocaoAttribute), true);
                    if (attibutes.Length == 1)
                        tipoPromocao = attibutes[0].TipoPromocao;
                    else
                        throw new Exception(string.Format("Atributo 'PromocaoAttribute' não foi configurado corretamente para a classe {0}", this.GetType()));
                }

                return tipoPromocao.Value;
            }
        }

        public string Nome
        {
            get { return Resource.ResourceManager.GetString(TipoPromocao.ToString()); }
        }

        public static Promocao Obter(TipoPromocao? tipoPromocao)
        {
            if (!tipoPromocao.HasValue || tipoPromocao.Value == TipoPromocao.SemPromocao) return null;

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
