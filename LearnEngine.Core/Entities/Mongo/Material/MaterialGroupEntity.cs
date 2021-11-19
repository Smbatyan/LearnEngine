using LearnEngine.Core.Attributes;
using LearnEngine.Core.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearnEngine.Core.Entities.Material
{
    [BsonIgnoreExtraElements]
    [BsonCollection("material-groups")]
    public sealed class MaterialGroupEntity : BaseMaterialEntity
    {
        public MaterialGroupEntity()
        {
            StructureTypeId = (short)MaterialStuctureTypes.MaterialGroup;
        }
    }
}
