using System;
using System.Data.Entity;
using Domain.Core;

namespace   DataPersistance.EntityFramework
{
    public class EntityFrameworkTransaction : IUnitOfWork
    {
        private readonly DbContextTransaction _efTransaction;
        private bool _isCommited;
        private bool _isDisposed;

        public EntityFrameworkTransaction(DbContextTransaction efTransaction)
        {
            _efTransaction = efTransaction;
        }

        public void Dispose()
        {
            if (_isDisposed) return;
            if(!_isCommited) RollbackChanges();
            _efTransaction.Dispose();
            _isDisposed = true;
        }

        public void Commit()
        {
            try
            {
                _efTransaction.Commit();
                _isCommited = true;
            }
            catch (Exception)
            {
                RollbackChanges();
            }
        }

        public void RollbackChanges()
        {
            _efTransaction.Rollback();
        }
    }
}