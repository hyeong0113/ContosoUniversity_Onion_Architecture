using ContosoUniversity.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Interface.Repository
{
    public interface IEnrollmentRepository : IGeneralRepository<Enrollment>
    {
        Task<IEnumerable<Enrollment>> GetAllEnrollments();
        Task<Enrollment> GetEnrollmentById(int id);
    }
}
