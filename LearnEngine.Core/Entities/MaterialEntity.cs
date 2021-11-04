using LearnEngine.Core.Attributes;
using LearnEngine.Core.Entities.BaseMongoEntities;
using MongoDB.Bson;
using System.Text.Json;

namespace LearnEngine.Core.Entities
{
    [BsonCollection("materials")]
    public sealed class MaterialEntity : Document
    {
        public string Name { get; set; }

        public short MaterialTypeId { get; set; }

        public short StructureTypeId { get; set; }

        public string Body { get; set; }

        public BsonDocument Configurations { get; set; }

        public AnswerEntity Answer { get; set; }
    }
}
