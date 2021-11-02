using AutoMapper;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Entities;
using LearnEngine.Core.Repositories;
using MediatR;

namespace LearnEngine.Application.Queries.Material.GetAllCousesesQuery
{
    public class GetAllMaterialMetadatasQueryHendler : IRequestHandler<GetAllMaterialMetadatasQuery, List<MaterialResponse>>
    {
        private readonly IMaterialMetaRespository _materialMetaRespository;
        private readonly IMapper _mapper;

        public GetAllMaterialMetadatasQueryHendler(IMaterialMetaRespository materialMetaRespository, IMapper mapper)
        {
            _mapper = mapper;
            _materialMetaRespository = materialMetaRespository;
        }
        public async Task<List<MaterialResponse>> Handle(GetAllMaterialMetadatasQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<MaterialMetadataEntity> materialMetadatas = await _materialMetaRespository.FilterByAsync(x => true);

            return _mapper.Map<List<MaterialResponse>>(materialMetadatas.ToList());
        }
    }
}
