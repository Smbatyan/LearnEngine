using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Entities.SQL
{
    public class Material
    {
        [StringLength(50)]
        public string Id { get; set; }
        
        //public virtual ICollection<Relation> Parents { get; set; }
        public virtual ICollection<Relation> Children { get; set; }
    }

    public class Relation
    {
        [StringLength(50)]
        public string ParentId { get; set; }
        [StringLength(50)]
        public string MaterialId { get; set; }

        public virtual Material Parent { get; set; }
        public virtual Material Material { get; set; }
    }
}
