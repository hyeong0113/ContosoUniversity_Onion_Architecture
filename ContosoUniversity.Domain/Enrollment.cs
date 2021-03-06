using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Domain
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment : BaseEntity
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Grade Grade { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
