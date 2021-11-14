using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Commands.Learn.V1
{
    public class EnrollCourseV1Command : IRequest<Unit>
    {
        public int UserId { get; set; }

        public string CourseId { get; set; }
    }
}
