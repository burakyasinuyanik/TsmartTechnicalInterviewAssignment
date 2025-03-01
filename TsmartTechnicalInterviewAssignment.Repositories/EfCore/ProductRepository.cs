using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsmartTechnicalInterviewAssignment.Entities.Models;
using TsmartTechnicalInterviewAssignment.Repositories.Contracts;

namespace TsmartTechnicalInterviewAssignment.Repositories.EfCore
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public void CreateProduct(Product product)=>Create(product);

        public async Task DeleteProduct(int id)
        {

            var product=await GetByIdAsync(id);
            Delete(product);
            
        }
       
        public ValueTask<Product> GetProductByIdAsync(int id)=> GetByIdAsync(id);
       

        public Task<List<Product>> GetProductsByIdAsync()=>GetAllAsync();

        public void UpdateProduct(Product product)=>Update(product);

        

    }
}
