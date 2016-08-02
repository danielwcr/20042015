using Microsoft.Practices.ServiceLocation;
using Lab.Domain.Interfaces.Repositories;
using Lab.Infra.Data.EF.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Domain.Entities;
using Lab.Domain.Common;

namespace Lab.Infra.Data.EF.Repositories
{
    public abstract class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId> where TId : IEquatable<TId>
    {
        protected DbContext Context { get; private set; }

        public RepositoryBase()
        {
            var contextManager = ServiceLocator.Current.GetInstance<UnitOfWorkManager>();
            Context = contextManager.Context;
        }

        public virtual TEntity Get(TId id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public virtual void Save(TEntity entity)
        {
            if (!entity.IsValid())
                throw new BusinessException(entity.BrokenRules);

            if (entity.Codigo.Equals(default(TId)))
                Context.Set<TEntity>().Add(entity);
            else
                Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity obj)
        {
            Context.Set<TEntity>().Remove(obj);
        }
    }
}
