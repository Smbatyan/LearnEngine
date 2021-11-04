using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Queries.Material
{
    public sealed class GetAllMaterialQueryValidator : AbstractValidator<GetAllMaterialsQuery>
    {
        public GetAllMaterialQueryValidator()
        {

        }
    }
}
