using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using ContosoUniversity.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Infrastructure.Repository
{
    public class OfficeAssignmentRepository : GeneralRepository<OfficeAssignment>, IOfficeAssignmentRepository
    {
        public OfficeAssignmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
