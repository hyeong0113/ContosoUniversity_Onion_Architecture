using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Application.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public IEnumerable<EnrollmentDto> Enrollments { get; set; }
    }
}
