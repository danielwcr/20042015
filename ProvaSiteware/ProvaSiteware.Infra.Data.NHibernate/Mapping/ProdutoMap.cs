using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ProvaSiteware.Domain.Entities;
using ProvaSiteware.Domain.Common;

namespace ProvaSiteware.Infra.Data.NHibernate.Mapping
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Id(p => p.Codigo);
            Map(p => p.Nome).Not.Nullable().Length(200);
            Map(p => p.Preco).Not.Nullable();
            Map(p => p.TipoPromocao).CustomType<TipoPromocao>();
        }
    }
}
