using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TsmartTechnicalInterviewAssignment.Entities.Models;
using TsmartTechnicalInterviewAssignment.Repositories.Contracts;
using TsmartTechnicalInterviewAssignment.Services.Contracts;

namespace TsmartTechnicalInterviewAssignment.Services
{
    public class ProductManager(IProductRepository _productRepository) : IProductService
    {
        public async Task Create(Product entity, CancellationToken cancellation)
        {
            await _productRepository.Create(entity, cancellation);
        }

        public async Task Delete(Product entity, CancellationToken cancellation)
        {
            entity.IsDeleted = true;
            await _productRepository.Delete(entity, cancellation);
        }

        public IQueryable<Product> FindByCondition(Expression<Func<Product, bool>> expression)
        {
            return _productRepository.FindByCondition(expression);
        }

        public async Task<Product> FindByConditionOne(Expression<Func<Product, bool>> expression, CancellationToken cancellation)
        {
            return await _productRepository.FindByConditionOne(expression, cancellation);
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellation)
        {
            var productList = await _productRepository.GetAllAsync(cancellation);

            return productList.Where(x=>x.IsDeleted==false).ToList();
        }

        public async ValueTask<Product> GetByIdAsync(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task Update(Product entity, CancellationToken cancellationToken)
        {
            entity.DateModified = DateTime.Now;
            await _productRepository.Update(entity, cancellationToken);
        }
    }
}
