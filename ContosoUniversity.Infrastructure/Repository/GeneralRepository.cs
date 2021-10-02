using ContosoUniversity.Application.Interface.Data;
using ContosoUniversity.Application.Interface.Repository;
using ContosoUniversity.Domain;
using ContosoUniversity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Infrastructure.Repository
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public GeneralRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AddAsync(T input)
        {
            var created = await _context.Set<T>().AddAsync(input);
            await _context.SaveChangesAsync();
            return created.Entity.Id;
        }

        public async Task UpdateAsync(T input)
        {
            _context.Entry(input).State = EntityState.Modified;
            await _context.SaveChangeAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var found = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (found == null)
            {
                return;
            }
            _context.Set<T>().Remove(found);
            await _context.SaveChangeAsync();
        }
    }
}
