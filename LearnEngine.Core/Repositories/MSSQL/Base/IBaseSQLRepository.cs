using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Infrastucture.Repositories.MSSQL.Base
{
    public interface IBaseSQLRepository
    {
        public int SaveChanges();

        Task<int> SaveChangesAsync();

        Task BeginEFTransactionAsync();

        void CommitEFTrasnaction();

        Task RollBackEFTrasnactionAsync();
    }
}
