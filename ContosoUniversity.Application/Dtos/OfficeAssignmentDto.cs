using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Application.Dtos
{
    public class OfficeAssignmentDto
    {
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public string Location { get; set; }

        public InstructorDto Instructor { get; set; }
    }
}
