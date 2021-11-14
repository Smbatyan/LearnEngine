using LearnEngine.Core.Entities.SQL;
using LearnEngine.Core.Repositories.MSSQL;
using LearnEngine.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LearnEngine.Infrastucture.Repositories.MSSQL
{
    public class MaterilRelationRepository : IMaterilRelationRepository
    {
        private readonly LearnEngineDbContext _context;

        public MaterilRelationRepository(LearnEngineDbContext context)
        {
            _context = context;
        }

        public async Task<List<Material>> GetSimpleRelation()
        {
            var aresult = _context.Material
                 //.Include(x => x.Parents)
                 .Include(x => x.Children)
                 .AsEnumerable()
                 .Where(x => x.Id == "618d0e397c4ad71025600281")
                 .ToList();

            var result = _context.Relation.Where(x=> x.ParentId == "618d0e397c4ad71025600281").Include(x=> x.Material).AsEnumerable();
            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            string s = JsonConvert.SerializeObject(result.First().Material, settings);   
            string ss = JsonConvert.SerializeObject(aresult.First(), settings);   

            return aresult;
        }

    }


}
