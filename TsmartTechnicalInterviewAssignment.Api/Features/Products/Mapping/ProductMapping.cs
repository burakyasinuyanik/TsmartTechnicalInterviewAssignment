using AutoMapper;
using TsmartTechnicalInterviewAssignment.Api.Features.Products.Create;
using TsmartTechnicalInterviewAssignment.Api.Features.Products.GetAll;
using TsmartTechnicalInterviewAssignment.Entities.Models;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping() {

            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, GetAllProductResponse>();
        }
    }
}
