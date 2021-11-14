using LearnEngine.Core.Attributes;
using LearnEngine.Core.Entities.Answer;
using LearnEngine.Core.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace LearnEngine.Core.Entities.Material
{
    [BsonCollection("materials")]
    [BsonIgnoreExtraElements]
    public sealed class MaterialEntity : BaseMaterialEntity
    {
        public MaterialEntity()
        {
            StructureTypeId = (short)MaterialStuctureTypes.Material;
        }

        public string Body { get; set; }

        [BsonIgnoreIfNull]
        public AnswerEntity Answer { get; set; }
    }
}