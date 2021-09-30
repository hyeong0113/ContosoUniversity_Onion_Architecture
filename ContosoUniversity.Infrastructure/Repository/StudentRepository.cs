using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using ContosoUniversity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Infrastructure.Repository
{
    public class StudentRepository : GeneralRepository<Student>, IStudentRepository
    {
        protected readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsWithEnrollments()
        {
            return await _context.Students.Include(s => s.Enrollments).AsNoTracking().ToListAsync();
        }
        public async Task<Student> GetStudentByIdWithEnrollments(int id)
        {
            return await _context.Students.Include(s => s.Enrollments).AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
