using LearnEngine.Application.Commands.Learn.Helper;
using LearnEngine.Application.Commands.Learn.V1;
using LearnEngine.Core.Repositories.MSSQL;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Entities.Learn;
using LearnEngine.Core.Entities.SQL;
using LearnEngine.Core.Repositories;
using LearnEngine.Core.Enums;
using AutoMapper;
using MediatR;
using LearnEngine.Core.Entities.Mongo.Learn;
using MongoDB.Bson;
using LearnEngine.Application.Exceptions;

namespace LearnEngine.Application.Commands.Learn.EnrollCourse.V1
{
    public class EnrollCourseV1CommandHandler : IRequestHandler<EnrollCourseV1Command, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILearnHelper _helper;
        private readonly IMaterilRelationRepository _materilRelationRepository;
        private readonly IMaterialRespository<MaterialEntity> _materialRespository;
        private readonly IMaterialRespository<MaterialGroupEntity> _materialGroupRespository;
        private readonly IMaterialRespository<UserCourseEntity> _materialUserCourseRespository;

        public EnrollCourseV1CommandHandler(
            IMapper mapper,
            ILearnHelper helper,
            IMaterilRelationRepository materilRelationRepository,
            IMaterialRespository<MaterialEntity> materialRespository,
            IMaterialRespository<MaterialGroupEntity> materialGroupRespository,
            IMaterialRespository<UserCourseEntity> materialUserCourseRespository
            )
        {
            _mapper = mapper;
            _helper = helper;
            _materialRespository = materialRespository;
            _materialGroupRespository = materialGroupRespository;
            _materilRelationRepository = materilRelationRepository;
            _materialUserCourseRespository = materialUserCourseRespository;
        }

        public async Task<Unit> Handle(EnrollCourseV1Command command, CancellationToken cancellationToken)
        {
            UserCourseEntity userCourse = await _materialUserCourseRespository.FindOneAsync(x => x.UserId == command.UserId);

            if (userCourse is not null)
            {
                if(userCourse.Courses.Any(x=> x.Course.MaterialId == command.CourseId))
                {
                    throw new ConflictException("course_is_already_enrolled");
                }
            }

            List<Relation> relations = await _materilRelationRepository.GetCourseRelationsAsync(command.CourseId);

            if (relations.Any())
            {
                throw new BadRequestException("course_is_incomplete");
            }

            Node node = _helper.GenerateNodeStructure(relations);

            List<CompactMaterial> materialIdsAndTypes = _helper.GetNodeIdsAndTypes(node);

            List<string> materialIds = materialIdsAndTypes
                .Where(x => x.StructureTypeId == MaterialStuctureTypes.Material)
                .Select(x=> x.Id).ToList();
            
            List<string> materialGroupIds = materialIdsAndTypes
                .Where(x => x.StructureTypeId == MaterialStuctureTypes.MaterialGroup)
                .Select(x=> x.Id).ToList();

            IEnumerable<MaterialEntity> materialsEnumerable = await _materialRespository.FilterByIdsAsync(materialIds);

            IEnumerable<MaterialGroupEntity> materialGroupsEnumerable = await _materialGroupRespository.FilterByIdsAsync(materialGroupIds);

            Dictionary<string, MaterialEntity> materials = materialsEnumerable.ToDictionary(x => x.Id.ToString());

            Dictionary<string, MaterialGroupEntity> materialGroups = materialGroupsEnumerable.ToDictionary(x => x.Id.ToString());

            CourseStuctureEntity courseData = _helper.MergeData(node, materials, materialGroups);

            CourseEntity course = new() { Course = courseData, EnrollmentDate = DateTime.UtcNow };

            if (userCourse is null)
            {
                userCourse = new() { UserId = command.UserId };

                userCourse.Courses.Add(course);

                await _materialUserCourseRespository.InsertOneAsync(userCourse);
            }
            else
            {
                userCourse.Courses.Add(course);
            }

            return Unit.Value;
        }
    }
}