using LearnEngine.Application.Models.Answer;
using LearnEngine.Core.Enums;
using MediatR;

namespace LearnEngine.Application.Commands.Material.V1
{
    public sealed class CreateMaterialV1Command : IRequest<Unit>
    {
        public string Name { get; set; }

        public string Key { get; set; }

        public MaterialTypes MaterialTypeId { get; set; }

        public string Body { get; set; }

        public object Configurations { get; set; }

        public AnswerModel Answer { get; set; }
    }
}