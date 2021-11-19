using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnEngine.Core.Entities.SQL
{
    public class Relation
    {
        public short MaterialTypeId { get; set; }

        public short StructureTypeId { get; set; }

        public string ParentId { get; set; }

        public string MaterialId { get; set; }


    }
}
