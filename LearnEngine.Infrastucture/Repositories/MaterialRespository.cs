using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Repositories;
using LearnEngine.Infrastucture.Repositories.Base;
using LearnEngine.Infrastucture.Settings.MongoSettings;

namespace LearnEngine.Infrastucture.Repositories
{
    public class MaterialRespository<T> : BaseMongoRepository<T>, IMaterialRespository<T> where T : BaseMaterialEntity
    {
        public MaterialRespository(IMongoDbSettings settings) : base(settings)
        {
        }
    }
}
