using LearnEngine.Core.Attributes;
using LearnEngine.Core.Entities.BaseMongoEntities;

namespace LearnEngine.Core.Entities
{
    [BsonCollection("metadatas")]
    public class MaterialMetadataEntity : Document
    {
        public string Name { get; set; }

        public short MaterialTypeId { get; set; }

        public short MetaTypeId { get; set; }
        
        public string Body { get; set; }

        public object Configurations { get; set; }
    }
}
