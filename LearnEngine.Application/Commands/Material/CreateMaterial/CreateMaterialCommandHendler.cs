using AutoMapper;
using LearnEngine.Application.Commands.Material.Helper;
using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Enums;
using LearnEngine.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LearnEngine.Application.Commands.Material.CreateMaterial
{
    public sealed class CreateMaterialCommandHendler : IRequestHandler<CreateMaterialCommand, Unit>
    {
        private readonly IMaterialRespository<BaseMaterialEntity> _materialRespository;
        private readonly IMaterialHelper _materialHelper;
        private readonly IMapper _mapper;

        public CreateMaterialCommandHendler(IMaterialRespository<BaseMaterialEntity> materialRespository, IMapper mapper, IMaterialHelper materialHelper)
        {
            _mapper = mapper;
            _materialRespository = materialRespository;
            _materialHelper = materialHelper;
        }

        public async Task<Unit> Handle(CreateMaterialCommand command, CancellationToken cancellationToken)
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
