using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Repositories.Base;

namespace LearnEngine.Core.Repositories
{
    public interface IMaterialRespository<T> : IBaseMongoRepository<T> where T : BaseMaterialEntity
    {

    }
}
