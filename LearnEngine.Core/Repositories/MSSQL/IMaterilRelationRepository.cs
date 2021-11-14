using LearnEngine.Core.Entities.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Repositories.MSSQL
{
    public interface IMaterilRelationRepository
    {
        Task<List<Material>> GetSimpleRelation();
        //Task CreateSimpleRelation(string Id);
    }
}
