using ContosoUniversity.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Application.Dtos
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Grade Grade { get; set; }

        public StudentDto Student { get; set; }
        public CourseDto Course { get; set; }
    }
}
