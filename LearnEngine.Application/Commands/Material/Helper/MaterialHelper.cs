using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Commands.Material.Helper
{
    public class MaterialHelper : IMaterialHelper
    {
        public void ManageAnswerHash(MaterialEntity material)
        {
            byte index = 1;
            material.Answer.Options.ForEach(option => option.HashOrder = index++);
        }
    }
}
