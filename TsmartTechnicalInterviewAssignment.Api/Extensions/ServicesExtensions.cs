using Microsoft.AspNetCore.Identity;
using TsmartTechnicalInterviewAssignment.Entities.Models;
using TsmartTechnicalInterviewAssignment.Repositories;
using TsmartTechnicalInterviewAssignment.Repositories.Contracts;
using TsmartTechnicalInterviewAssignment.Repositories.EfCore;
using TsmartTechnicalInterviewAssignment.Services;
using TsmartTechnicalInterviewAssignment.Services.Contracts;

namespace TsmartTechnicalInterviewAssignment.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();         
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IUserService, UserManager>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

        }
    }
}
