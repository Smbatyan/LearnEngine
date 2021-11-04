using LearnEngine.Core.Entities.BaseMongoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Entities
{
    public sealed class AnswerOptionEntity
    {
        public string Text { get; set; }

        public short HashOrder { get; set; }
    }
}
