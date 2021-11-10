using LearnEngine.Core.Attributes;
using LearnEngine.Core.Entities.BaseMongoEntities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearnEngine.Core.Entities
{
    [BsonCollection("materials")]
    public abstract class BaseMaterialEntity : Document
    {
        public string Name { get; set; }

        public short MaterialTypeId { get; set; }

        public string Key { get; set; }

        public short StructureTypeId { get; set; }

        [BsonIgnoreIfNull]
        public BsonDocument Configurations { get; set; }
    }
}
