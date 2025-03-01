using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsmartTechnicalInterviewAssignment.Entities.Models;

namespace TsmartTechnicalInterviewAssignment.Services.Contracts
{
    public interface IProductService
    {
        public Task CreateProduct(Product product);    
        public Task UpdateProduct(Product product);
        public Task DeleteProduct(int id);
        public ValueTask<Product> GetProductByIdAsync(int id);
        public Task<List<Product>> GetAllProductsAsync();
    }
}
