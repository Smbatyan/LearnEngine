using AutoMapper;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Entities;
using LearnEngine.Core.Repositories;
using MediatR;

namespace LearnEngine.Application.Queries.Material
{
    public sealed class GetMaterialTreeByIdV1QueryHandler : IRequestHandler<GetMaterialTreeByIdV1Query, List<MaterialResponse>>
    {
        private readonly IMaterialRespository<BaseMaterialEntity> _materialRespository;
        private readonly IMapper _mapper;

        public GetMaterialTreeByIdV1QueryHandler(IMaterialRespository<BaseMaterialEntity> materialRespository, IMapper mapper)
        {
            _mapper = mapper;
            _materialRespository = materialRespository;
        }

        public Task<List<MaterialResponse>> Handle(GetMaterialTreeByIdV1Query request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}