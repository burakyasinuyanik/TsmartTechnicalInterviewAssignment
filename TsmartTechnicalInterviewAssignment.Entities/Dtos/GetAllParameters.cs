using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsmartTechnicalInterviewAssignment.Entities.Dtos
{
    public class GetAllParameters:RequestParameters
    {
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public string? SearchTerm { get; set; }
    }
}
