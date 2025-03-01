using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsmartTechnicalInterviewAssignment.Repositories.Contracts;

namespace TsmartTechnicalInterviewAssignment.Repositories.EfCore
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppIdentityDbContext _context;
        private readonly Microsoft.EntityFrameworkCore.DbSet<T> _dbSet;

        public GenericRepository(AppIdentityDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Create(T entity)=>await _dbSet.AddAsync(entity);

        public Task<List<T>> GetAllAsync() => _dbSet.ToListAsync();

        public  void Update(T entity) => _dbSet.Update(entity);
        public ValueTask<T> GetByIdAsync(int id)=>_dbSet.FindAsync(id)!;

        public void Delete(T entity)=>_dbSet.Remove(entity);
    }
}
