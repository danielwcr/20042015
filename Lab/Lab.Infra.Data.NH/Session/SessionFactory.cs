using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Lab.Infra.Data.NH.Mapping;


namespace Lab.Infra.Data.NH.Session
{
    public class SessionFactory
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()

                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(p => p.FromConnectionStringWithKey("LabDBConnection"))
                    .ShowSql())

                .Mappings(p => p.FluentMappings.AddFromAssemblyOf<ProdutoMap>()
                    .Conventions.Add<DefaultConventions>())

                .ExposeConfiguration(p => new SchemaUpdate(p).Execute(true, true))

                .BuildSessionFactory();
        }
    }
}
