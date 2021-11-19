using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Entities.SQL
{
    public class Node
    {
        public Node()
        {
            SubNodes = new List<Node>();
        }

        public string Id { get; set; }

        public string? ParentId { get; set; }

        public short MaterialTypeId { get; set; }

        public short StructureTypeId { get; set; }

        public virtual Node Parent { get; set; }

        public virtual List<Node> SubNodes { get; set; }
    }
}
