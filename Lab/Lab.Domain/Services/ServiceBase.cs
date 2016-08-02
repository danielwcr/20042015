using Lab.Domain.Entities;
using Lab.Domain.Interfaces.Repositories;
using Lab.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public abstract class ServiceBase<TEntity, TId> : IServiceBase<TEntity, TId> where TEntity : EntityBase<TId> where TId : IEquatable<TId>
    {
        private readonly IRepositoryBase<TEntity, TId> repository;

        public ServiceBase(IRepositoryBase<TEntity, TId> repository)
        {
            this.repository = repository;
        }

        public virtual TEntity Get(TId id)
        {
            return repository.Get(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public virtual void Save(TEntity entity)
        {
            repository.Save(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }
    }
}
