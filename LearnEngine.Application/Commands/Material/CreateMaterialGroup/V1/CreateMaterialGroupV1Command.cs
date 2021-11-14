using MediatR;
using LearnEngine.Core.Enums;

namespace LearnEngine.Application.Commands.Material.V1
{
    public sealed class CreateMaterialGroupV1Command : IRequest<Unit>
    {
        public string Name { get; set; }

        public string  Description { get; set; }

        public string Key { get; set; }

        public MaterialTypes MaterialTypeId { get; set; }

        public object Configurations { get; set; }

        public List<string> ChildrenIds { get; set; }
    }
}