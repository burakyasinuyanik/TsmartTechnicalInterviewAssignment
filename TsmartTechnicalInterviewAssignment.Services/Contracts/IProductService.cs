using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TsmartTechnicalInterviewAssignment.Entities.Models;

namespace TsmartTechnicalInterviewAssignment.Services.Contracts
{
    public interface IProductService
    {
        Task Create(Product entity, CancellationToken cancellation);
        Task Update(Product entity, CancellationToken cancellation);
        Task Delete(Product entity, CancellationToken cancellation);
        Task<List<Product>> GetAllAsync(CancellationToken cancellation);
        ValueTask<Product> GetByIdAsync(Guid id);
        IQueryable<Product> FindByCondition(Expression<Func<Product, bool>> expression);
        Task<Product> FindByConditionOne(Expression<Func<Product, bool>> expression, CancellationToken cancellation);
        
    }
}
