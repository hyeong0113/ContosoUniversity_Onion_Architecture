using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using ContosoUniversity.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Infrastructure.Repository
{
    public class InstructorRepository : GeneralRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
