using ContosoUniversity.UI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.UI.Services.Student
{
    public class StudentService
    {
        private readonly IBaseClient _baseClient;

        public StudentService(IBaseClient baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<ICollection<StudentDto>> GetAllStudents()
        {
            return await _baseClient.StudentAllAsync();
        }

    }
}
