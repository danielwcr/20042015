using Microsoft.Practices.ServiceLocation;
using NHibernate;
using ProvaSiteware.Domain.Interfaces.Repositories;
using ProvaSiteware.Infra.Data.NHibernate.Session;
using System;

namespace ProvaSiteware.Infra.Data.NHibernate.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISession _session;
        private ITransaction _transaction;

        public UnitOfWork()
        {
            var sessionManager = ServiceLocator.Current.GetInstance<SessionManager>();
            _session = sessionManager.Session;
        }

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                _session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                _session.Dispose();
            }
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}
