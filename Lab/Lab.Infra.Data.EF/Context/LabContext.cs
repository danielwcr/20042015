using Lab.Domain.Entities;
using Lab.Infra.Data.EF.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Infra.Data.EF.Context
{
    public class LabContext : DbContext
    {
        
        public LabContext()
            : base("LabDBConnection")
        {

        }

        DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(p => p.Name == "Codigo").Configure(p => p.IsKey());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(500));
            modelBuilder.Properties<decimal>().Configure(p => p.HasPrecision(18, 2));

            modelBuilder.Configurations.Add(new ProdutoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
