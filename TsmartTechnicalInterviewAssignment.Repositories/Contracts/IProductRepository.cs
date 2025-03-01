using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsmartTechnicalInterviewAssignment.Entities.Models;

namespace TsmartTechnicalInterviewAssignment.Repositories.Contracts
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        public void CreateProduct(Product product);
        public void UpdateProduct(Product product);
        public Task DeleteProduct(int id);
        public ValueTask<Product> GetProductByIdAsync(int id);
        public Task<List<Product>> GetProductsByIdAsync();

    }
}
