using Ninject.Modules;
using ProvaSiteware.Application;
using ProvaSiteware.Application.Interfaces;
using ProvaSiteware.Domain.Interfaces.Repositories;
using ProvaSiteware.Domain.Interfaces.Services;
using ProvaSiteware.Domain.Services;

using ProvaSiteware.Infra.Data.NHibernate.Session;
using ProvaSiteware.Infra.Data.NHibernate.Repositories;

//using ProvaSiteware.Infra.Data.Context;
//using ProvaSiteware.Infra.Data.Repositories;

namespace ProvaSiteware.Infra.IoC
{
    public class IoCModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<ContextManager>().ToSelf();
            Bind<SessionManager>().ToSelf();

            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IProdutoAppService>().To<ProdutoAppService>();
            Bind<ICarrinhoAppService>().To<CarrinhoAppService>();

            Bind<IProdutoService>().To<ProdutoService>();
            Bind<ICarrinhoService>().To<CarrinhoService>();

            Bind<IProdutoRepository>().To<ProdutoRepository>();
        }
    }
}
