using Microsoft.Practices.ServiceLocation;
using ProvaSiteware.Domain.Interfaces.Repositories;
using ProvaSiteware.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProvaSiteware.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public void BeginTransaction()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager>();
            _context = contextManager.Context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
