using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsmartTechnicalInterviewAssignment.Repositories.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                   new IdentityRole
                   {
                       Id = "f749fed8-fbf0-4dd0-b236-3bf35ec55945",
                       Name = "Admin",
                       NormalizedName = "ADMIN"
                   },
                 new IdentityRole
                 {
                     Id = "570b1702-7b3a-4919-aa54-d24444afbdff",
                     Name = "Musteri",
                     NormalizedName = "MUSTERI"
                 },
                   new IdentityRole
                   {
                       Id = "f5bcc4f0-5b9b-45fb-b587-d86d912db64d",
                       Name = "Yetkisiz",
                       NormalizedName = "YETKISIZ"
                   }

                 );
        }
    }
}
