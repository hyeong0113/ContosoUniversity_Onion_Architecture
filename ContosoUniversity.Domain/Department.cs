using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Domain
{
    public class Department : BaseEntity
    {
        public int? InstructorId { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime StartDate { get; set; }
        
        public Instructor Instructor { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
