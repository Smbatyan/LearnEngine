using LearnEngine.Application.Commands.Learn.V1;
using LearnEngine.Application.Queries.Learn.V1;
using LearnEngine.Application.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnEngine.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Authorize(Roles = "User")]
    public class LearnController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LearnController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Course")]
        public async Task<IActionResult> GetCourses()
        {
            List<CourseRespons> courses = await _mediator.Send(new GetCoursesV1Query());

            return Ok(courses);
        }

        [HttpPost("Enroll")]
        public async Task<IActionResult> EnrollCourse(string materialGroupId)
        {
            int userId = 15023813; // TODO

            EnrollCourseV1Command command = new()
            {
                UserId = userId,
                CourseId = materialGroupId
            };

            await _mediator.Send(command);

            return Ok();
        }
    }
}
