using Lab.Domain.Entities;
using Lab.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity, TId> where TEntity : EntityBase<TId> where TId : IEquatable<TId>
    {
        TEntity Get(TId id);

        IEnumerable<TEntity> GetAll();

        void Save(TEntity entity);

        void Delete(TEntity entity);
    }
}
