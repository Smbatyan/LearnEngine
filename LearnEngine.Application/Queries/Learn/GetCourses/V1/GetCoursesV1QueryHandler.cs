using AutoMapper;
using LearnEngine.Application.Queries.Learn.V1;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Entities.Material;
using LearnEngine.Core.Enums;
using LearnEngine.Core.Repositories;
using MediatR;

namespace LearnEngine.Application.Queries.Learn.GetRoots.V1
{
    public class GetCoursesV1QueryHandler : IRequestHandler<GetCoursesV1Query, List<CourseRespons>>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialRespository<MaterialGroupEntity> _materialRespository;

        public GetCoursesV1QueryHandler(IMaterialRespository<MaterialGroupEntity> materialRespository, IMapper mapper)
        {
            _mapper = mapper;
            _materialRespository = materialRespository;
        }

        public async Task<List<CourseRespons>> Handle(GetCoursesV1Query request, CancellationToken cancellationToken)
        {
            IEnumerable<MaterialGroupEntity> materialEntityGroups = await _materialRespository
                .FilterByAsync(x => x.MaterialTypeId == (short)MaterialTypes.Course &&
                                    x.StructureTypeId == (short)MaterialStuctureTypes.MaterialGroup); // && x.StatusId == (short)MaterialStatuses.Published);

            List<CourseRespons> response = _mapper.Map<List<CourseRespons>>(materialEntityGroups);

            return response;
        }
    }
}
