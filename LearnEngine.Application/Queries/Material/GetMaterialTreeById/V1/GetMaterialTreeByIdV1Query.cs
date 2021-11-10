using LearnEngine.Application.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Queries.Material
{
    public sealed class GetMaterialTreeByIdV1Query : IRequest<List<MaterialResponse>>
    {
        public string MaterialId { get; set; }
    }
}
