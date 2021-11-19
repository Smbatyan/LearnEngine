using MongoDB.Bson;

namespace LearnEngine.Core.Entities.Learn
{
    public class CourseStuctureEntity
    {
        public string MaterialId { get; set; }

        public BaseMaterialEntity Material { get; set; }

        public List<CourseStuctureEntity> Children { get; set; }

        public BsonDocument RelationConfiguration { get; set; }
    }
}