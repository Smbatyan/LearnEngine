using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.SQL;
using LearnEngine.Core.Enums;
using LearnEngine.Core.Repositories.MSSQL;
using LearnEngine.Infrastucture.Context;
using LearnEngine.Infrastucture.Repositories.MSSQL.Base;
using Microsoft.EntityFrameworkCore;

namespace LearnEngine.Infrastucture.Repositories.MSSQL
{
    public class MaterilRelationRepository : BaseSQLRepository, IMaterilRelationRepository
    {
        private readonly LearnEngineDbContext _context;

        public MaterilRelationRepository(LearnEngineDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddMaterialAsync(BaseMaterialEntity entity) 
        {
            await _context.Materials.AddAsync(
                new CompactMaterial  // TODO
                { 
                    Id = entity.Id.ToString(),
                    TypeId = (MaterialTypes)entity.MaterialTypeId, 
                    StructureTypeId = (MaterialStuctureTypes)entity.StructureTypeId 
                });
        }

        public async Task AddRelationAsync(Relation relation)
        {
            await _context.Relations.AddAsync(relation);
        }

        public async Task AddRelationRangeAsync(List<Relation> relationsList)
        {
            await _context.Relations.AddRangeAsync(relationsList);
        }

        public async Task<List<Relation>> GetCourseRelationsAsync(string courseId)
        {
            List<Relation> relations = await _context.Relations.FromSqlRaw($"sp_generate_course '{courseId}'").ToListAsync();

            return relations;
        }
    }
}
