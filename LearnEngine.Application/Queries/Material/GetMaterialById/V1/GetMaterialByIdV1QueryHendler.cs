using AutoMapper;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Repositories;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LearnEngine.Application.Queries.Material
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
