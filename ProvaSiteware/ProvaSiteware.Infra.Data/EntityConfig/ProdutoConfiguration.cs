using ProvaSiteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace ProvaSiteware.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.Codigo);
            Property(p => p.Nome).IsRequired().HasMaxLength(200);
            Property(p => p.Preco).IsRequired();
            Property(p => p.TipoPromocao);
            Ignore(p => p.Promocao);
        }
    }
}
