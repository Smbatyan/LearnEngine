using LearnEngine.Core.Attributes;
using LearnEngine.Core.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearnEngine.Core.Entities.Material
{
    [BsonCollection("materials")]
    [BsonIgnoreExtraElements]
    public sealed class MaterialGroupEntity : BaseMaterialEntity
    {
        public MaterialGroupEntity()
        {
            StructureTypeId = (short)MaterialStuctureTypes.MaterialGroup;
        }

        public List<ObjectId> Children { get; set; }
    }
}
