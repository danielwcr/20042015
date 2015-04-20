using Ninject;
using ProvaSiteware.Application;
using ProvaSiteware.Application.Interfaces;
using ProvaSiteware.Domain.Interfaces.Repositories;
using ProvaSiteware.Domain.Interfaces.Services;
using ProvaSiteware.Domain.Services;
using ProvaSiteware.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Infra.CrossCutting.IoC
{
    public static class Resolver
    {
        public static void RegisterServices()
        {
            var kernel = new StandardKernel();
            kernel.Load(System.Reflection.Assembly.GetExecutingAssembly());

            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();
            kernel.Bind<ICarrinhoAppService>().To<CarrinhoAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IProdutoService>().To<ProdutoService>();
            kernel.Bind<ICarrinhoService>().To<CarrinhoService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
        }
    }
}
