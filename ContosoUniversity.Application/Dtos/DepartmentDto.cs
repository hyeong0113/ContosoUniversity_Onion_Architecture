using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Application.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime StartDate { get; set; }

        public InstructorDto Instructor { get; set; }
        public IEnumerable<CourseDto> Courses { get; set; }
    }
}
