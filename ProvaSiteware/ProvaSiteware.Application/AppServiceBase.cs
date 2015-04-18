using ProvaSiteware.Application.Interfaces;
using ProvaSiteware.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Application
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : class
    {
        private readonly IServiceBase<T> service;

        public AppServiceBase(IServiceBase<T> service)
        {
            this.service = service;
        }

        public void Insert(T obj)
        {
            service.Insert(obj);
        }

        public T Get(int id)
        {
            return service.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return service.GetAll();
        }

        public void Update(T obj)
        {
            service.Update(obj);
        }

        public void Delete(T obj)
        {
            service.Delete(obj);
        }
    }
}
