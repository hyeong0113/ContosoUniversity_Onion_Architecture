using ContosoUniversity.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Interface.Repository
{
    public interface IGeneralRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> AddAsync(T input);
        Task UpdateAsync(T input);
        Task DeleteAsync(int id);
    }
}
