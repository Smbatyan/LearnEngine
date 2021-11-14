using AutoMapper;
using LearnEngine.Application.Queries.Material.V1;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Repositories;
using MediatR;

namespace LearnEngine.Application.Queries.Material.GetMaterialById.V1
{
    public sealed class GetMaterialByIdV1QueryHendler : IRequestHandler<GetMaterialByIdV1Query, MaterialResponse>
    {
        private readonly IMaterialRespository<MaterialEntity> _materialRespository;
        private readonly IMapper _mapper;

        public GetMaterialByIdV1QueryHendler(IMaterialRespository<MaterialEntity> materialRespository, IMapper mapper)
        {
            _mapper = mapper;
            _materialRespository = materialRespository;
        }

        public async Task<MaterialResponse> Handle(GetMaterialByIdV1Query query, CancellationToken cancellationToken)
        {
            MaterialEntity material = await _materialRespository.FindByIdAsync(query.Id);

            return _mapper.Map<MaterialResponse>(material);
        }
    }
}
