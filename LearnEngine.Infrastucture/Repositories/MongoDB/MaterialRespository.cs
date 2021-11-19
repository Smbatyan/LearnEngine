using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.BaseMongoEntities;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Repositories;
using LearnEngine.Infrastucture.Repositories.Base;
using LearnEngine.Infrastucture.Settings.MongoSettings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LearnEngine.Infrastucture.Repositories
{
    public class MaterialRespository<T> : BaseMongoRepository<T>, IMaterialRespository<T> where T : Document
    {
        public MaterialRespository(IMongoDbSettings settings) : base(settings)
        {

        }

        public async Task<IEnumerable<T>> FilterByIdsAsync(List<string> materialIds)
        {
            string ids = string.Empty;
            foreach (var item in materialIds)
            {
                ids += $"'{item}',";
            }

            ids = ids.Remove(ids.Length - 1);
            string query = "{ _id : { $in : [query] } }";
            string finalQuery = query.Replace("query", ids);

            var filter = BsonDocument.Parse(finalQuery);
            var result = await _collection.Find(filter).ToListAsync();

            return result;
            //var filterDef = new FilterDefinitionBuilder<MaterialEntity>();
            //var filter = filterDef.In(_ => _.Id, materialIds.Select(x=> ObjectId.Parse(x)));
            //List<MaterialEntity> attachments = await _collection.Find(filter).ToListAsync();
            //return attachments;

            //return new LinkedList<MaterialEntity>();
        }
    }
}
