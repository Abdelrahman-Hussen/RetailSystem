using RetailSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace RetailSystem.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var x = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            return services;
        }
    }


}
