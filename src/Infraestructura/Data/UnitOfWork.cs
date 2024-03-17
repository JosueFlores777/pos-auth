using System;
using Dominio.Service;

namespace Infraestructura.Data
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AutenticationContext _context;
        private bool _disposed = false;

        public UnitOfWork(AutenticationContext context)
        {
            _context = context;
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception error)
            {
              _context.Database.CurrentTransaction.Rollback();
               throw;
            }
                
           
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

    
    }
}
