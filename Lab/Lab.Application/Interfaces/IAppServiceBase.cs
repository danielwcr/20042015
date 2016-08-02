using Lab.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application.Interfaces
{
    public interface IAppServiceBase<TEntity, TId> where TEntity : EntityBase<TId> where TId : IEquatable<TId>
    {
        TEntity Get(TId id);

        IEnumerable<TEntity> GetAll();

        void Save(TEntity entity);

        void Delete(TEntity entity);

    }
}
