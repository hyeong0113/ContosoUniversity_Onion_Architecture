using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Domain
{
    public class Instructor : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }

        public virtual IEnumerable<Department> Departments { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }
        public virtual IEnumerable<OfficeAssignment> OfficeAssignments { get; set; }

    }
}
