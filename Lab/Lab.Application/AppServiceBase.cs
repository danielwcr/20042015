using Microsoft.Practices.ServiceLocation;
using Lab.Application.Interfaces;
using Lab.Domain.Interfaces.Repositories;
using Lab.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Application.Aspect;

namespace Lab.Application
{
    public class AppServiceBase<T> where T : class 
    {
        private readonly IServiceBase<T> service;

        public AppServiceBase(IServiceBase<T> service)
        {
            this.service = service;
        }

        [UnitOfWorkAspect]
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

        [UnitOfWorkAspect]
        public void Update(T obj)
        {
            service.Update(obj);
        }

        [UnitOfWorkAspect]
        public void Delete(T obj)
        {
            service.Delete(obj);
        }
    }
}
