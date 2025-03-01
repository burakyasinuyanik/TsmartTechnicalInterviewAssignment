using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsmartTechnicalInterviewAssignment.Entities.Models
{
    public class Product
    {     
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsDeleted { get; set; } 
        public bool IsActive { get; set; }
        public DateTime DateCraeted { get; set; } 
        public DateTime DateModified { get; set; } 
        public double Price { get; set; }
        public string Barcode { get; set; }=default!;
        public string ProductNo { get; set; } = default!;
        public int Stock { get; set; } = default!;
    }
}
