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
        private DbContextTransaction _transaction;

        public UnitOfWork()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager>();
            _context = contextManager.Context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
