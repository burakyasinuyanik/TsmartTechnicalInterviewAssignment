using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsmartTechnicalInterviewAssignment.Entities.Models;

namespace TsmartTechnicalInterviewAssignment.Repositories.Configurations
{
    internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.DateCraeted).IsRequired();
            builder.Property(x => x.DateModified).IsRequired();           
            builder.Property(x => x.Price).IsRequired();    
            builder.Property(x => x.Barcode).IsRequired();  
            builder.Property(x => x.ProductNo).IsRequired();  
            builder.Property(x => x.Stock).IsRequired();

            builder.HasData(
                new Product
                {
                    Id = Guid.Parse("5577bf0d-8bfb-46df-a48c-45be2be375e6"),
                    Name = "Örnek Ürün 2",
                    Description = "Başka bir örnek ürün.",
                    IsDeleted = false,
                    IsActive = true,
                    DateCraeted = DateTime.Parse("01.01.2025"),
                    DateModified = DateTime.Parse("01.01.2025"),
                    Price = 150.75,
                    Barcode = "9876543210987", 
                    ProductNo = "7654321", 
                    Stock = 100
                },
                new Product
                {
                    Id = Guid.Parse("5577bf0d-8bfb-46df-a48c-45be2be375e1"),
                    Name = "Örnek Ürün 1",
                    Description = "Başka bir örnek ürün.2",
                    IsDeleted = false,
                    IsActive = true,
                    DateCraeted = DateTime.Parse("01.01.2025"),
                    DateModified = DateTime.Parse("01.01.2025"),
                    Price = 15,
                    Barcode = "9876543210987",
                    ProductNo = "7654321",
                    Stock = 10
                }
                );
        }
    }
}
