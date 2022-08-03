using CustomerAPI.CustomerAPI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerAPI.CustomerAPI.Commons.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDbContextExtension(this IServiceCollection services, IConfiguration config, IWebHostEnvironment _env)
        {
            services.AddDbContextPool<CustomerAPIDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("Default")));
        }
    }
}
