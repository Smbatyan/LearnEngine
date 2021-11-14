using FluentValidation;
using LearnEngine.Application.Commands.Material.V1;

namespace LearnEngine.Application.Commands.Material.CreateMaterialGroup
{
    public sealed class CreateMaterialGroupV1CommandValidator : AbstractValidator<CreateMaterialGroupV1Command>
    {
        public CreateMaterialGroupV1CommandValidator()
        {
            
        }
        
    }
}
