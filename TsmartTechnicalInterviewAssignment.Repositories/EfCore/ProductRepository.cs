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

       

        

    }
}
