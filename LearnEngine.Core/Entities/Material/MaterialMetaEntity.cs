using LearnEngine.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Entities.Material
{
    public sealed class MaterialMetaEntity : BaseMaterialEntity
    {
        public MaterialMetaEntity()
        {
            StructureTypeId = (short)MaterialStuctureTypes.MetaMaterial;
        }

        public List<string> ChildrenKeys { get; set; }
    }
}
