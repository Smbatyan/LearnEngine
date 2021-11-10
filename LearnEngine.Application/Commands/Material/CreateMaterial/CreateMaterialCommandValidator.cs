using FluentValidation;
using LearnEngine.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Commands.Material.CreateMaterial
{
    public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
    {
        public CreateMaterialCommandValidator()
        {
            RuleFor(x => x.MaterialTypeId).IsInEnum();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Key).NotEmpty();
            RuleFor(x => x.Body).NotEmpty();

            RuleFor(x => x.Answer).NotEmpty()
              .When(x => x.MaterialTypeId == MaterialTypes.Question);

            RuleFor(x => x.Answer.Options).Must(x=> x.Count > 0)
              .When(x => x.MaterialTypeId == MaterialTypes.Question);

            RuleFor(x => x.Answer.Options).Must(x => x.Count > 1)
              .When(x => x.MaterialTypeId == MaterialTypes.Question && 
                         x.Answer.AnswerTypeId == AnswerTypes.MultiChoice);
        }
    }
}
