using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
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

        public async Task Create(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync(cancellationToken);
        }
        public Task<List<T>> GetAllAsync(CancellationToken cancellationToken) => _dbSet.ToListAsync(cancellationToken);

        public async Task Update(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Update(entity);
            await SaveAsync(cancellationToken);

        }
        public ValueTask<T> GetByIdAsync(Guid id) => _dbSet.FindAsync(id)!;

        public async Task Delete(T entity, CancellationToken cancellationToken)
        {

            await Update(entity,cancellationToken);
            await SaveAsync(cancellationToken);

        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<T> FindByConditionOne(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(expression).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
