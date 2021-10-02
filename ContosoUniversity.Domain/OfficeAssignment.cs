using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Domain
{
    public class OfficeAssignment : BaseEntity
    {
        public int InstructorId { get; set; }
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}
