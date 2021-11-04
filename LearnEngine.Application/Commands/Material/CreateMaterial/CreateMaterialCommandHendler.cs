using AutoMapper;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Entities;
using LearnEngine.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Commands.Material
{
    public sealed class CreateMaterialCommandHendler : IRequestHandler<CreateMaterialCommand, MaterialResponse>
    {
        private readonly IMaterialRespository _materialMetaRespository;
        private readonly IMapper _mapper;

        public CreateMaterialCommandHendler(IMaterialRespository materialMetaRespository, IMapper mapper)
        {
            _mapper = mapper;
            _materialMetaRespository = materialMetaRespository;
        }

        public async Task<MaterialResponse> Handle(CreateMaterialCommand command, CancellationToken cancellationToken)
        {
            MaterialEntity entity = _mapper.Map<MaterialEntity>(command);

            await _materialMetaRespository.InsertOneAsync(entity);

            MaterialResponse response = _mapper.Map<MaterialResponse>(entity);

            return response;
        }

    }
}
