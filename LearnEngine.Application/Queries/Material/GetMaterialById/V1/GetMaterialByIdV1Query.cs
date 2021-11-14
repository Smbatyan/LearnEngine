using LearnEngine.Application.ResponseModels;
using MediatR;

namespace LearnEngine.Application.Queries.Material.V1
{
    public sealed record GetMaterialByIdV1Query : IRequest<MaterialResponse>
    {
        public string Id { get; set; }
    }
}
