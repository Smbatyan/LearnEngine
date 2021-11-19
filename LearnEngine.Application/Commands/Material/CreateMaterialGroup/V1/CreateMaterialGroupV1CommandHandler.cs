using AutoMapper;
using LearnEngine.Application.Commands.Learn.Helper;
using LearnEngine.Application.Commands.Material.V1;
using LearnEngine.Application.Exceptions;
using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Entities.SQL;
using LearnEngine.Core.Enums;
using LearnEngine.Core.Repositories;
using LearnEngine.Core.Repositories.MSSQL;
using MediatR;
using MongoDB.Bson;

namespace LearnEngine.Application.Commands.Material.CreateMaterialGroup.V1
{
    public sealed class CreateMaterialGroupV1CommandHandler : IRequestHandler<CreateMaterialGroupV1Command, Unit>
    {
        private readonly IMaterialRespository<MaterialGroupEntity> _materialGroupRespository;
        private readonly IMaterialRespository<MaterialEntity> _materialRespository;
        private readonly IMaterilRelationRepository _materialRelationRespository;
        private readonly ILearnHelper _helper;
        private readonly IMapper _mapper;

        public CreateMaterialGroupV1CommandHandler(
            IMapper mapper,
            ILearnHelper helper,
            IMaterialRespository<MaterialEntity> materialRespository,
            IMaterialRespository<MaterialGroupEntity> materialGroupRespository,
            IMaterilRelationRepository materialRelationRespository)
        {
            _mapper = mapper;
            _helper = helper;
            _materialRespository = materialRespository;
            _materialGroupRespository = materialGroupRespository;
            _materialRelationRespository = materialRelationRespository;
        }

        public async Task<Unit> Handle(CreateMaterialGroupV1Command command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MaterialGroupEntity>(command);
            List<string> relations = new();

            if (command.ParentId is not null)
            {
                MaterialGroupEntity materialGroup = await _materialGroupRespository.FindByIdAsync(command.ParentId);
                if (materialGroup == null)
                {
                    throw new ResourceNotFoundException("parent_material_doesn't_exists");
                }
            }

            List<string> materialsCollection = default;
            List<string> materialGroupsCollection = default;

            if (command.ChildrenIds is not null)
            {
                var materialGroups = await _materialGroupRespository.FilterByIdsAsync(command.ChildrenIds);

                materialGroupsCollection = materialGroups.Select(x=> x.Id.ToString()).ToList();
                int materialGroupsCount = materialGroupsCollection.Count;

                if (materialGroupsCount != command.ChildrenIds.Count)
                {
                    var materials = await _materialRespository.FilterByIdsAsync(command.ChildrenIds);
                    materialsCollection = materials.Select(x => x.Id.ToString()).ToList();

                    int materialsCount = materialsCollection.Count;

                    int totalMaterialCount = materialsCount + materialGroupsCount;

                    if (totalMaterialCount != command.ChildrenIds.Count)
                    {
                        throw new ResourceNotFoundException("children(s)_doesn't_exists TODO"); //TODO
                    }
                }

                command.ChildrenIds.ForEach(x => relations.Add(x));
            }

            await _materialGroupRespository.InsertOneAsync(entity);

            await _materialRelationRespository.AddMaterialAsync(entity);

            if (relations.Any())
            {
                List<Relation> relationsList = new();
                relations.ForEach(x => 
                    relationsList.Add(new Relation()
                    {
                        MaterialId = x,
                        ParentId = entity.Id.ToString()
                    }));

                await _materialRelationRespository.AddRelationRangeAsync(relationsList);
            };

            if (command.ParentId is not null)
            {
                Relation relation = new() 
                { 
                    MaterialId = entity.MaterialTypeId.ToString(),
                    ParentId = command.ParentId 
                };

                await _materialRelationRespository.AddRelationAsync(relation);
            }

            await _materialRelationRespository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
