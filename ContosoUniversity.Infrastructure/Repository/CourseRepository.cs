using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using ContosoUniversity.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Infrastructure.Repository
{
    public class CourseRepository : GeneralRepository<Course>, ICourseRepository
    {

        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
