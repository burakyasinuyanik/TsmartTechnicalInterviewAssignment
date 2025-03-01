using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsmartTechnicalInterviewAssignment.Entities.Models;
using TsmartTechnicalInterviewAssignment.Repositories.Contracts;
using TsmartTechnicalInterviewAssignment.Services.Contracts;

namespace TsmartTechnicalInterviewAssignment.Services
{
    public class ProductManager(IProductRepository _productRepository) : IProductService
    {
        public async Task CreateProduct(Product product)
        {
           await _productRepository.Create(product);
            
        }

        public async Task DeleteProduct(int id)
        {
           var product= await _productRepository.GetByIdAsync(id);
            _productRepository.Delete(product);
        }

        public ValueTask<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
