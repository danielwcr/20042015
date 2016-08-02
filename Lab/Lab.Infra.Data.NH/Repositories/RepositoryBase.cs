using Microsoft.Practices.ServiceLocation;
using NHibernate;
using Lab.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using Lab.Domain.Entities;
using System;
using Lab.Domain.Common;

namespace Lab.Infra.Data.NH.Repositories
{
    public abstract class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId> where TId : IEquatable<TId>
    {
        protected ISession Session { get; private set; }

        public RepositoryBase()
        {
            var sessionManager = ServiceLocator.Current.GetInstance<UnitOfWorkManager>();
            Session = sessionManager.Session;
        }

        public TEntity Get(TId id)
        {
            return Session.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Session.QueryOver<TEntity>().List();
        }

        public void Save(TEntity entity)
        {
            if (!entity.IsValid())
                throw new BusinessException(entity.BrokenRules);

            if (entity.Codigo.Equals(default(TId)))
                Session.Save(entity);
            else
                Session.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            Session.Delete(entity);
        }
    }
}
