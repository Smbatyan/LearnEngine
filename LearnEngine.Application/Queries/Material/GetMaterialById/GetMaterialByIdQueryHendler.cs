using AutoMapper;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Entities;
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
    public sealed class GetMaterialByIdQueryHendler : IRequestHandler<GetMaterialByIdQuery, MaterialResponse>
    {
        private readonly IMaterialRespository _materialMetaRespository;
        private readonly IMapper _mapper;

        public GetMaterialByIdQueryHendler(IMaterialRespository materialMetaRespository, IMapper mapper)
        {
            _mapper = mapper;
            _materialMetaRespository = materialMetaRespository;
        }

        public async Task<MaterialResponse> Handle(GetMaterialByIdQuery query, CancellationToken cancellationToken)
        {
            MaterialEntity material = await _materialMetaRespository.FindByIdAsync(query.Id);

            return _mapper.Map<MaterialResponse>(material);
        }
    }
}
