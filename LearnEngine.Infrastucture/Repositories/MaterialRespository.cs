using LearnEngine.Core.Entities;
using LearnEngine.Core.Repositories;
using LearnEngine.Infrastucture.Repositories.Base;
using LearnEngine.Infrastucture.Settings.MongoSettings;

namespace LearnEngine.Infrastucture.Repositories
{
    public class MaterialRespository : BaseMongoRepository<MaterialEntity>, IMaterialRespository
    {
        public MaterialRespository(IMongoDbSettings settings) : base(settings)
        {
        }
    }
}
