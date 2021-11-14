using LearnEngine.Core.Entities.BaseMongoEntities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Entities.Learn
{
    public sealed class UserMaterialEntity : Document
    {
        public int UserId { get; set; }

        public List<UserCourseEntity> Courses { get; set; }
    }
}
