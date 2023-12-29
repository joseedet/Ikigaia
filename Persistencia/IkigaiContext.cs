using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persistencia.Interface;

namespace Persistencia
{
    public class IkigaiContext:IdentityDbContext<Usuario>,IAplicationContext
    {
       public IkigaiContext(DbContextOptions <IkigaiContext> options):base(options)
            {

            }
        


            public DbSet<Planin> Agendas => Set <Planin>();
            public DbSet<Cliente> Clientes => Set <Cliente>();
            public DbSet<DetalleCliente> DetalleClientes => Set <DetalleCliente>();
            public DbSet<Tipo> Tipos => Set <Tipo>();
            

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
            {
                var result = await base.SaveChangesAsync(cancellationToken);

                return result;
            }

        private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => throw new NotImplementedException();

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
             if (_currentTransaction != null) return null!;

            _currentTransaction = await Database.BeginTransactionAsync();

            return _currentTransaction;
        }

        public async Task CommitAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null!;
                }
            }
        }

        private void RollbackTransaction()
        {
                try
            {
                _currentTransaction.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null!;
                }
            }
        }

    }  
}