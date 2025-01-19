using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatApp.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace BoatApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly BoatAppDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(BoatAppDbContext context)
        {
            _context = context;
        }
        public async Task BeginTranscation()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTranscation()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task RollBackTranscation()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
