using Lab.Domain.Interfaces.Repositories;
using Lab.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            this.repository = repository;
        }

        public virtual void Insert(T obj)
        {
            repository.Insert(obj);
        }

        public virtual T Get(int id)
        {
            return repository.Get(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return repository.GetAll();
        }

        public virtual void Update(T obj)
        {
            repository.Update(obj);
        }

        public virtual void Delete(T obj)
        {
            repository.Delete(obj);
        }
    }
}
