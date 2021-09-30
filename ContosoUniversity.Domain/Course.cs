using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Domain
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
