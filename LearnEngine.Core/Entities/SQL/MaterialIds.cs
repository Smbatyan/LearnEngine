using LearnEngine.Core.Enums;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Entities.SQL
{
    public class CompactMaterial
    {
        public string Id { get; set; }

        public MaterialTypes TypeId { get; set; }

        public MaterialStuctureTypes StructureTypeId { get; set; }
    }
}
