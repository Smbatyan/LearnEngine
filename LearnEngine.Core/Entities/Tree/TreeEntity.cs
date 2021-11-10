using LearnEngine.Core.Entities.Material;
using MongoDB.Bson;

namespace LearnEngine.Core.Entities.Tree
{
    public sealed class TreeEntity
    {
        public string MaterialId { get; set; }

        public BaseMaterialEntity Material { get; set; }

        public BsonDocument Configurations { get; set; }

        public List<TreeEntity> Children { get; set; }
    }
}