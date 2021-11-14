using LearnEngine.Core.Entities.BaseMongoEntities;
using LearnEngine.Core.Repositories;
using LearnEngine.Infrastucture.Repositories.Base;
using LearnEngine.Infrastucture.Settings.MongoSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Infrastucture.Repositories
{
    public class UserCourseRepository<T> : BaseMongoRepository<T>, IUserCourseRepository<T> where T : IDocument
    {
        public UserCourseRepository(IMongoDbSettings settings) : base(settings)
        {
        }
    }
}
