using LearnEngine.Application.ResponseModels;
using MediatR;

namespace LearnEngine.Application.Queries.Material
{
    public sealed record GetMaterialByIdQuery : IRequest<MaterialResponse>
    {
        public string Id { get; set; }
    }
}
