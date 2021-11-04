using LearnEngine.Application.Models.Answer;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Enums;
using MediatR;

namespace LearnEngine.Application.Commands.Material
{
    public sealed class CreateMaterialCommand : IRequest<MaterialResponse>
    {
        public string Name { get; set; }

        public MaterialTypes MaterialTypeId { get; set; }

        public MaterialStuctureTypes MetaTypeId { get; set; }

        public string Body { get; set; }

        public object Configurations { get; set; }

        public AnswerModel Answer { get; set; }
    }
}
