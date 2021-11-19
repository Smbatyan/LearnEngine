using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.SQL;
using LearnEngine.Infrastucture.Repositories.MSSQL.Base;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Repositories.MSSQL
{
    public interface IMaterilRelationRepository : IBaseSQLRepository
    {
        Task AddMaterialAsync(BaseMaterialEntity entity);
        Task<List<Relation>> GetCourseRelationsAsync(string courseId);
        Task AddRelationRangeAsync(List<Relation> relationsList);
        Task AddRelationAsync(Relation relation);
    }
}
