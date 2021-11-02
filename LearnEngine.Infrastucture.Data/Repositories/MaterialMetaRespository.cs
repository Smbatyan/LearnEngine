using LearnEngine.Core.Entities;
using LearnEngine.Core.Repositories;
using LearnEngine.Infrastucture.Repositories.Base;
using LearnEngine.Infrastucture.Settings.MongoSettings;

namespace LearnEngine.Infrastucture.Repositories
{
    public class MaterialMetaRespository : BaseMongoRepository<MaterialMetadataEntity>, IMaterialMetaRespository
    {
        public MaterialMetaRespository(IMongoDbSettings settings) : base(settings)
        {
        }
    }
}
