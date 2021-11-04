using AutoMapper;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Entities;
using LearnEngine.Core.Repositories;
using MediatR;

namespace LearnEngine.Application.Queries.Material
{
    public sealed record GetAllMaterialQueryHendler : IRequestHandler<GetAllMaterialsQuery, List<MaterialResponse>>
    {
        private readonly IMaterialRespository _materialMetaRespository;
        private readonly IMapper _mapper;

        public GetAllMaterialQueryHendler(IMaterialRespository materialMetaRespository, IMapper mapper)
        {
            _mapper = mapper;
            _materialMetaRespository = materialMetaRespository;
        }
        public async Task<List<MaterialResponse>> Handle(GetAllMaterialsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<MaterialEntity> materials = await _materialMetaRespository.FilterByAsync(x => true);

            return _mapper.Map<List<MaterialResponse>>(materials.ToList());
        }
    }
}
