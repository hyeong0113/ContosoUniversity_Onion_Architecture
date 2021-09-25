using ContosoUniversity.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Application.Interface.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        Task<int> SaveChangeAsync();
    }
}
