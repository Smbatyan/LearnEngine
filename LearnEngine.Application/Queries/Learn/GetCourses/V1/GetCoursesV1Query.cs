using LearnEngine.Application.ResponseModels;
using MediatR;

namespace LearnEngine.Application.Queries.Learn.V1
{
    public class GetCoursesV1Query : IRequest<List<CourseRespons>>
    {
        
    }
}
