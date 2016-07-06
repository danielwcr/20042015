using Ninject.Modules;
using Lab.Application;
using Lab.Application.Interfaces;
using Lab.Domain.Interfaces.Repositories;
using Lab.Domain.Interfaces.Services;
using Lab.Domain.Services;

using Lab.Infra.Data.NH.Session;
using Lab.Infra.Data.NH.Repositories;
//using Lab.Infra.Data.EF.Context;
//using Lab.Infra.Data.EF.Repositories;

namespace Lab.Infra.CrossCutting.IoC
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
