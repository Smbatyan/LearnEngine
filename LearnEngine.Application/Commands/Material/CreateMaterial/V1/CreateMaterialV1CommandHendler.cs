using AutoMapper;
using LearnEngine.Application.Commands.Material.Helper;
using LearnEngine.Application.Commands.Material.V1;
using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Enums;
using LearnEngine.Core.Repositories;
using MediatR;

namespace LearnEngine.Application.Commands.Material.CreateMaterial.V1
{
    public sealed class CreateMaterialV1CommandHendler : IRequestHandler<CreateMaterialV1Command, Unit>
    {
        private readonly IMaterialRespository<BaseMaterialEntity> _materialRespository;
        private readonly IMaterialHelper _materialHelper;
        private readonly IMapper _mapper;

        public CreateMaterialV1CommandHendler(IMaterialRespository<BaseMaterialEntity> materialRespository, IMapper mapper, IMaterialHelper materialHelper)
        {
            _mapper = mapper;
            _materialRespository = materialRespository;
            _materialHelper = materialHelper;
        }

        public async Task<Unit> Handle(CreateMaterialV1Command command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MaterialEntity>(command);

            if (entity.MaterialTypeId == (short)MaterialTypes.Question)
            {
                _materialHelper.ManageAnswerHash(entity);
            }

            await _materialRespository.InsertOneAsync(entity);

            return Unit.Value;
        }
    }
}
