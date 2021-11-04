using LearnEngine.Core.Entities.BaseMongoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Entities
{
    public sealed class AnswerEntity
    {
        public List<AnswerOptionEntity> Options { get; set; }

        public short AnswerTypeId { get; set; }

        public string RightAnswerHash { get; set; }
    }
}
