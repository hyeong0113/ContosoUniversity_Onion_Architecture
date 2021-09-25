using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using ContosoUniversity.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Infrastructure.Repository
{
    public class EnrollmentRepository : GeneralRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
