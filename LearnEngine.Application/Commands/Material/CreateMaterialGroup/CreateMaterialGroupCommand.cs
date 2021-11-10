using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Commands.Material
{
    public sealed class CreateMaterialGroupCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public string Key { get; set; }

        public MaterialTypes MaterialTypeId { get; set; }

        public object Configurations { get; set; }

        public List<string> ChildrenIds { get; set; }
    }
}