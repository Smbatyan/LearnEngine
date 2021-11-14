using LearnEngine.Application.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Queries.Material.V1
{
    public sealed record GetAllMaterialsV1Query : IRequest<List<MaterialResponse>>
    {

    }
}
