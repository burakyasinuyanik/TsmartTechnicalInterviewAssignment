using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TsmartTechnicalInterviewAssignment.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity,CancellationToken cancellationToken);
        Task Update(T entity, CancellationToken cancellationToken);
        Task Delete(T entity, CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        ValueTask<T> GetByIdAsync(Guid id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> FindByConditionOne(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task SaveAsync( CancellationToken cancellationToken);


    }
}
