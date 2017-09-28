using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MasterChefeContext _masterChefeContext;
        private bool _disposed = false;

        public UnitOfWork(MasterChefeContext databaseContext)
        {
            _masterChefeContext = databaseContext;
        }

        public int Commit()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            return _masterChefeContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && _masterChefeContext != null)
            {
                _masterChefeContext.Dispose();
            }

            _disposed = true;
        }
    }
}
