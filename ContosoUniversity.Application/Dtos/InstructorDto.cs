using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Application.Dtos
{
    public class InstructorDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }

        public IEnumerable<DepartmentDto> Departments { get; set; }
        public IEnumerable<CourseDto> Courses { get; set; }
        public IEnumerable<OfficeAssignmentDto> OfficeAssignments { get; set; }
    }
}
