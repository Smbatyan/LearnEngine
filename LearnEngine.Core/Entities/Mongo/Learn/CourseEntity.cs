using LearnEngine.Core.Entities.Learn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Core.Entities.Mongo.Learn
{
    public class CourseEntity
    {
        public DateTime EnrollmentDate { get; set; }

        public CourseStuctureEntity Course { get; set; }
    }
}
