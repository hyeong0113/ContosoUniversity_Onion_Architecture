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
    public class EnrollmentRepository : GeneralRepository<Enrollment>, IEnrollmentRepository
    {
        protected readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Enrollment>> GetAllEnrollments()
        {
            return await _context.Enrollments.Include(e => e.Student)
                                             .Include(e => e.Course).AsNoTracking()
                                             .ToListAsync();
        }

        public async Task<Enrollment> GetEnrollmentById(int id)
        {
            return await _context.Enrollments.Include(e => e.Student)
                                             .Include(e => e.Course).AsNoTracking()
                                             .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
