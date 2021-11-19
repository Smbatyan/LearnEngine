using LearnEngine.Core.Attributes;
using LearnEngine.Core.Entities.BaseMongoEntities;
using LearnEngine.Core.Entities.Mongo.Learn;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Entities.Learn
{
    [BsonIgnoreExtraElements]
    [BsonCollection("user-courses")]
    public sealed class UserCourseEntity : Document
    {
        public UserCourseEntity()
        {
            Courses = new();
        }

        public int UserId { get; set; }

        public List<CourseEntity> Courses { get; set; }
    }
}
