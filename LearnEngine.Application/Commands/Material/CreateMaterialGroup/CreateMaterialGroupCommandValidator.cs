using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Commands.Material.CreateMaterialGroup
{
    public sealed class CreateMaterialGroupCommandValidator : AbstractValidator<CreateMaterialGroupCommand>
    {
        public CreateMaterialGroupCommandValidator()
        {
            
        }
        
    }
}
