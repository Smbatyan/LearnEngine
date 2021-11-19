using FluentValidation;
using LearnEngine.Application.Commands.Material.V1;
using LearnEngine.Core.Enums;

namespace LearnEngine.Application.Commands.Material.CreateMaterial
{
    public class CreateMaterialV1CommandValidator : AbstractValidator<CreateMaterialV1Command>
    {
        public CreateMaterialV1CommandValidator()
        {
            RuleFor(x => x.MaterialTypeId).IsInEnum();
            RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.Key).NotEmpty();
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
