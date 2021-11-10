using LearnEngine.Core.Entities.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Commands.Material.Helper
{
    public interface IMaterialHelper
    {
        void ManageAnswerHash(MaterialEntity material);
    }
}
