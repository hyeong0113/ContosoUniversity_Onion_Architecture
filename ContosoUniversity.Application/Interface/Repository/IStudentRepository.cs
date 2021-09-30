using ContosoUniversity.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Interface.Repository
{
    public interface IStudentRepository : IGeneralRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllStudentsWithEnrollments();
        Task<Student> GetStudentByIdWithEnrollments(int id);
    }
}
