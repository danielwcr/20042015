using ProvaSiteware.Domain.Interfaces.Repositories;
using ProvaSiteware.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            this.repository = repository;
        }

        public void Insert(T obj)
        {
            repository.Insert(obj);
        }

        public T Get(int id)
        {
            return repository.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(T obj)
        {
            repository.Update(obj);
        }

        public void Delete(T obj)
        {
            repository.Delete(obj);
        }
    }
}
