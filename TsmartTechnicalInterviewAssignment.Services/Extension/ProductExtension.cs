using TsmartTechnicalInterviewAssignment.Entities.Models;

namespace TsmartTechnicalInterviewAssignment.Services.Extension
{
    public static class ProductExtension
    {
        public static IQueryable<Product> Filterproducts(this IQueryable<Product> products,
           double minPrice, double maxPrice) => products.Where(b => b.Price >= minPrice && b.Price <= maxPrice);
        public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return products.Where(b => b.Name.ToLower().Contains(lowerCaseTerm));
        }
        
    }
}
