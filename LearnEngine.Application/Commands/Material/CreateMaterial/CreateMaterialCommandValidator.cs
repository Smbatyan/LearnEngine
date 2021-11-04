using FluentValidation;
using LearnEngine.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Commands.Material
{
    public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
    {
        public CreateMaterialCommandValidator()
        {
            RuleFor(x => x.MetaTypeId).IsInEnum();
            RuleFor(x => x.MaterialTypeId).IsInEnum();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Body).NotEmpty().When(x => x.MetaTypeId == MaterialStuctureTypes.Material);
            RuleFor(x => x.Answer).NotEmpty().When(x => x.MaterialTypeId == MaterialTypes.Question && x.MetaTypeId == MaterialStuctureTypes.Material);
        }
    }
}
