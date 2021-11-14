using LearnEngine.Core.Entities.BaseMongoEntities;
using LearnEngine.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Repositories
{
    public interface IUserCourseRepository<T> : IBaseMongoRepository<T> where T : IDocument
    {
        
    }
}
