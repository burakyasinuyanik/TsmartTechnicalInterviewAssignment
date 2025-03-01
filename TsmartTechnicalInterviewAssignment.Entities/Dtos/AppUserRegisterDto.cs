using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsmartTechnicalInterviewAssignment.Entities.Dtos
{
    public record class AppUserRegisterDto(string Email, string Password,string UserName,ICollection<string> Roles);
    
}
