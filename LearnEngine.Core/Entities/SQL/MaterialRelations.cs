using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Entities.SQL
{
    public class MaterialRelations
    {
        public int Id { get; set; }
        public string ParentId { get; set; }
        public string ChildId { get; set; }
        //public string Name { get; set; }
        public ICollection<MaterialRelations> Children { get; set; }
        //public DateTime CreatedDate { get; set; }

        //public string MaterialId { get; set; }

        //public string ChildId { get; set; }

        //public List<MaterialRelations> Children { get; set; }
    }
}