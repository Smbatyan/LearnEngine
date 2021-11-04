using LearnEngine.Application.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Queries.Material
{
    public sealed record GetAllMaterialsQuery : IRequest<List<MaterialResponse>>
    {

    }
}
