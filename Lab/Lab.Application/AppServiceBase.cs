using Lab.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using Lab.Application.Aspect;
using Lab.Domain.Entities;

namespace Lab.Application
{
    public abstract class AppServiceBase<TEntity, TId> where TEntity : EntityBase<TId> where TId : IEquatable<TId>
    {
        private readonly IServiceBase<TEntity, TId> service;

        public AppServiceBase(IServiceBase<TEntity, TId> service)
        {
            this.service = service;
        }

        public TEntity Get(TId id)
        {
            return service.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return service.GetAll();
        }

        [UnitOfWorkAspect]
        public void Save(TEntity entity)
        {
            service.Save(entity);
        }

        [UnitOfWorkAspect]
        public void Delete(TEntity entity)
        {
            service.Delete(entity);
        }
    }
}
