using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.BaseMongoEntities;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Repositories.Base;
using MongoDB.Bson;

namespace LearnEngine.Core.Repositories
{
    public interface IMaterialRespository<T> : IBaseMongoRepository<T> where T : IDocument
    {
        Task<IEnumerable<T>> FilterByIdsAsync(List<string> materialIds);
    }
}
