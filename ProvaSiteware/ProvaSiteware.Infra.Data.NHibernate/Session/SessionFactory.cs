using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using ProvaSiteware.Infra.Data.NHibernate.Mapping;


namespace ProvaSiteware.Infra.Data.NHibernate.Session
{
    public class SessionFactory
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()

                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(p => p.FromConnectionStringWithKey("ProvaSitewareDBConnection"))
                    .ShowSql())

                .Mappings(p => p.FluentMappings.AddFromAssemblyOf<ProdutoMap>()
                    .Conventions.Add<DefaultConventions>())

                .ExposeConfiguration(p => new SchemaUpdate(p).Execute(true, true))

                .BuildSessionFactory();
        }
    }
}
