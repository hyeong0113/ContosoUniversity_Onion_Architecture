using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Domain
{
    public class Course : BaseEntity
    {
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}
