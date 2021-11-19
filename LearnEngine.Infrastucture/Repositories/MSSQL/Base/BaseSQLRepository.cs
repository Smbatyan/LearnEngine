using LearnEngine.Infrastucture.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Infrastucture.Repositories.MSSQL.Base
{
    public class BaseSQLRepository : IBaseSQLRepository
    {
        private LearnEngineDbContext _dbContext;
        private IDbContextTransaction _efTransaction;

        public BaseSQLRepository(LearnEngineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _dbContext.Dispose();
                _dbContext = null;
                disposedValue = true;

                if (_efTransaction != null)
                {
                    _efTransaction.DisposeAsync();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task BeginEFTransactionAsync()
        {
            if (_efTransaction == null)
            {
                _efTransaction = await _dbContext.Database.BeginTransactionAsync();
            }
            else
            {
                throw new Exception("Before opening a new transaction, you need to commit the previous one");
            }
        }

        public void CommitEFTrasnaction()
        {
            if (_efTransaction == null)
            {
                throw new Exception("Cannot find transaction to commit");
            }

            _efTransaction.Commit();
        }

        public async Task RollBackEFTrasnactionAsync()
        {
            if (_efTransaction == null)
            {
                throw new Exception("Cannot find transaction to rollback, or transaction alredy closed");
            }

            await _efTransaction.RollbackAsync();
        }
    }
}
