using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Domain
{
    public class Student : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
