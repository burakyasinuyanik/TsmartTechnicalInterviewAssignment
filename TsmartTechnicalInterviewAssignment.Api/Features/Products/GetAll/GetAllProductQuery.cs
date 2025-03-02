
using TsmartTechnicalInterviewAssignment.Entities.Dtos;
using TsmartTechnicalInterviewAssignment.Entities.Models;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.GetAll
{
    public  class GetAllProductQuery : RequestParameters, IRequestByServiceResult<PagedList<Product>>
    {
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; } 
        public string? SearchTerm { get; set; }
    }
}
