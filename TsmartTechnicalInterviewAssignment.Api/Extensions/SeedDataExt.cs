using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TsmartTechnicalInterviewAssignment.Entities.Models;
using TsmartTechnicalInterviewAssignment.Repositories;

namespace TsmartTechnicalInterviewAssignment.Api.Extensions
{
    public static class SeedDataExt
    {

        public static async Task AddSeedDataExt(this WebApplication application)
        {

            using var scope = application.Services.CreateAsyncScope();

            var context = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            await context.Database.MigrateAsync();
            await context.SaveChangesAsync();

            var userAdmin = new AppUser
            {
                Id = "164d2ede-b0b6-4fe2-a377-ae76641405fb",
                Email = "admin@admin.com",
                NormalizedEmail ="ADMIN@ADMIN.COM",
                EmailConfirmed =false,
                UserName = "Admin",
                NormalizedUserName="ADMIN",
                SecurityStamp = "CALJBGFJ3O6LTP4LQAWFIOK2LF25BG7O",
                ConcurrencyStamp = "d64d2ede-b0b6-4fe2-a377-ae76641405fc",
                RefreshTokenExpiryToken = DateTime.Now.AddHours(1),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            var userMusteri = new AppUser
            {
                Id = "264d2ede-b0b6-4fe2-a377-ae76641405fb",
                Email = "musteri@musteri.com",
                NormalizedEmail = "MUSTERİ",
                EmailConfirmed = false,
                UserName = "Musteri",
                NormalizedUserName = "Musteri",
                SecurityStamp = "DALJBGFJ3O6LTP4LQAWFIOK2LF25BG7O",
                ConcurrencyStamp = "264d2ede-b0b6-4fe2-a377-ae76641405fc",
                RefreshTokenExpiryToken = DateTime.Now.AddHours(1),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0

            };
            var userYetkisiz = new AppUser
            {
                Id = "364d2ede-b0b6-4fe2-a377-ae76641405fb",
                Email = "yetkisiz@yetkisiz.com",
                NormalizedEmail = "YETKISIZ@YETKISIZ.COM",
                EmailConfirmed = false,
                UserName = "Yetkisiz",
                NormalizedUserName = "YETKISIZ",
                SecurityStamp = "FCALJBGFJ3O6LTP4LQAWFIOK2LF25BG7O",
                ConcurrencyStamp = "z64d2ede-b0b6-4fe2-a377-ae76641405fc",
                RefreshTokenExpiryToken = DateTime.Now.AddHours(1),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0

            };
            string password = "Password12**";
            if (!context.Users.Any())
            {
                await userManager.CreateAsync(userAdmin, password);
                await userManager.CreateAsync(userMusteri, password);
                await userManager.CreateAsync(userYetkisiz, password);

               

            }


            if (!context.UserRoles.Any())
            {
                await userManager.AddToRoleAsync(userAdmin, "Admin");
                await userManager.AddToRoleAsync(userMusteri, "Musteri");
                await userManager.AddToRoleAsync(userYetkisiz, "Yetkisiz");


            }
            await context.SaveChangesAsync();

        }
    }
}
