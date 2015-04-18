using ProvaSiteware.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class 
    {
        void Insert(T obj);

        T Get(int id);

        IEnumerable<T> GetAll();

        void Update(T obj);

        void Delete(T obj);
    }
}
