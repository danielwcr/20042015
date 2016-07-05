using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class 
    {
        void Insert(T obj);

        T Get(int id);

        IEnumerable<T> GetAll();

        void Update(T obj);

        void Delete(T obj);
    }
}
