using Microsoft.Practices.ServiceLocation;
using Lab.Domain.Interfaces.Repositories;
using Lab.Infra.Data.EF.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Infra.Data.EF.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DbContext Context { get; private set; }

        public RepositoryBase()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager>();
            Context = contextManager.Context;
        }

        public void Insert(T obj)
        {
            Context.Set<T>().Add(obj);
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Update(T obj)
        {
            Context.Entry<T>(obj).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(T obj)
        {
            Context.Set<T>().Remove(obj);
        }
    }
}
