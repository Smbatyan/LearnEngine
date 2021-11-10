using AutoMapper;
using LearnEngine.Application.Exceptions;
using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Repositories;
using MediatR;

namespace LearnEngine.Application.Commands.Material.CreateMaterialGroup
{
    public sealed class CreateMaterialGroupCommandHandler : IRequestHandler<CreateMaterialGroupCommand, Unit>
    {
        private readonly IMaterialRespository<BaseMaterialEntity> _materialRespository;
        private readonly IMapper _mapper;

        public CreateMaterialGroupCommandHandler(IMaterialRespository<BaseMaterialEntity> materialRespository, IMapper mapper)
        {
            _mapper = mapper;
            _materialRespository = materialRespository;
        }

        public async Task<Unit> Handle(CreateMaterialGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MaterialGroupEntity>(command);

            bool allChildrenExists = _materialRespository.FilterByAsync(x => entity.Children.Contains(x.Id)).Result.Count() == entity.Children.Count;
            if (!allChildrenExists)
            {
                throw new BadRequestException("children_id(s)_doesnt_exists");
            }

            await _materialRespository.InsertOneAsync(entity);

            return Unit.Value;
        }
    }
}
