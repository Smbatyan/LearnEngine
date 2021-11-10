using LearnEngine.Core.Attributes;
using LearnEngine.Core.Enums;
using MongoDB.Bson;

namespace LearnEngine.Core.Entities.Material
{
    public sealed class MaterialGroupEntity : BaseMaterialEntity
    {
        public MaterialGroupEntity()
        {
            StructureTypeId = (short)MaterialStuctureTypes.MaterialGroup;
        }

        public List<ObjectId> Children { get; set; }
    }
}
