using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Entities.Learn
{
    public class UserCourseEntity
    {
        public BaseMaterialEntity Material { get; set; }

        public byte UserMaterialStatusId { get; set; } = 0;

        public byte ComplationPercenatge { get; set; }

        public List<UserMaterialEntity> Children { get; set; }
    }
}
