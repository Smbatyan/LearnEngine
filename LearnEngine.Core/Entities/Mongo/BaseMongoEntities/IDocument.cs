using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearnEngine.Core.Entities.BaseMongoEntities
{
    public interface IDocument
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        //public DateTime CreatedAt => Id.CreationTime;
    }
}
