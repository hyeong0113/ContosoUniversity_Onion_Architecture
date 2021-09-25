using ContosoUniversity.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoUniversity.Application.Interface.Repository
{
    public interface IEnrollmentRepository : IGeneralRepository<Enrollment>
    {
    }
}
