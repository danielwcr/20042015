using Microsoft.Practices.ServiceLocation;
using NHibernate;
using ProvaSiteware.Domain.Interfaces.Repositories;
using ProvaSiteware.Infra.Data.NHibernate.Session;
using System.Collections.Generic;
using System.Linq;

namespace ProvaSiteware.Infra.Data.NHibernate.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ISession Session { get; private set; }

        public RepositoryBase()
        {
            var sessionManager = ServiceLocator.Current.GetInstance<SessionManager>();
            Session = sessionManager.Session;
        }

        public void Insert(T obj)
        {
            Session.Save(obj);
        }

        public T Get(int id)
        {
            return Session.Get<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Session.QueryOver<T>().List();
        }

        public void Update(T obj)
        {
            Session.Update(obj);
        }

        public void Delete(T obj)
        {
            Session.Delete(obj);
        }
    }
}
