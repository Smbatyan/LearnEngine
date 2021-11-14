using AutoMapper;
using LearnEngine.Application.Commands.Learn.V1;
using LearnEngine.Core.Entities;
using LearnEngine.Core.Entities.SQL;
using LearnEngine.Core.Repositories;
using LearnEngine.Core.Repositories.MSSQL;
using MediatR;
using System.Collections.Generic;

namespace LearnEngine.Application.Commands.Learn.EnrollCourse.V1
{
    public class EnrollCourseV1CommandHandler : IRequestHandler<EnrollCourseV1Command, Unit>
    {
        private readonly IMaterialRespository<BaseMaterialEntity> _materialRespository;
        // private readonly IUserCourseRepository<UserMaterialEntity> _userCourseRespository;
        private readonly IMaterilRelationRepository _materilRelationRepository;
        private readonly IMapper _mapper;

        public EnrollCourseV1CommandHandler(
            IMaterialRespository<BaseMaterialEntity> materialRespository
          , IMapper mapper
          //, IUserCourseRepository<UserMaterialEntity> userCourseRespository
          , IMaterilRelationRepository materilRelationRepository)
        {
            _mapper = mapper;
            _materialRespository = materialRespository;
            // _userCourseRespository = userCourseRespository;
            _materilRelationRepository = materilRelationRepository;
        }

        public async Task<Unit> Handle(EnrollCourseV1Command request, CancellationToken cancellationToken)
        {
            List<Core.Entities.SQL.Material> relations = await _materilRelationRepository.GetSimpleRelation();



            return Unit.Value;
        }
    }
}
