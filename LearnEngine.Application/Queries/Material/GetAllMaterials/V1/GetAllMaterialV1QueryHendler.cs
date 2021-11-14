using AutoMapper;
using LearnEngine.Application.Queries.Material.V1;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Repositories;
using MediatR;

namespace LearnEngine.Application.Queries.Material
{
    public sealed record GetAllMaterialV1QueryHendler : IRequestHandler<GetAllMaterialsV1Query, List<MaterialResponse>>
    {
        private readonly IMaterialRespository<MaterialEntity> _materialRespository;
        private readonly IMapper _mapper;

        public GetAllMaterialV1QueryHendler(IMaterialRespository<MaterialEntity> materialRespository, IMapper mapper)
        {
            _mapper = mapper;
            _materialRespository = materialRespository;
        }
        public async Task<List<MaterialResponse>> Handle(GetAllMaterialsV1Query query, CancellationToken cancellationToken)
        {
            IEnumerable<MaterialEntity> materials = await _materialRespository.FilterByAsync(x => true);

            return _mapper.Map<List<MaterialResponse>>(materials.ToList());
        }
    }
}