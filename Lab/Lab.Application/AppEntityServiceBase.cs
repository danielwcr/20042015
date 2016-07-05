using Microsoft.Practices.ServiceLocation;
using Lab.Application.Interfaces;
using Lab.Domain.Interfaces.Repositories;
using Lab.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application
{
    public class AppEntityServiceBase<T> : AppServiceBase where T : class
    {
        private readonly IServiceBase<T> service;

        public AppEntityServiceBase(IServiceBase<T> service)
        {
            this.service = service;
        }

        public void Insert(T obj)
        {
            using (var scope = BeginTransaction())
            {
                service.Insert(obj);
                scope.Commit();
            }
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
            using (var scope = BeginTransaction())
            {
                service.Update(obj);
                scope.Commit();
            }
        }

        public void Delete(T obj)
        {
            using (var scope = BeginTransaction())
            {
                service.Delete(obj);
                scope.Commit();
            }
        }
    }
}
