using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OtpAPI.OtpAPI.Data;

namespace OtpApi.Commons.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDbContextExtension(this IServiceCollection services, IConfiguration config, IWebHostEnvironment _env)
        {
            services.AddDbContextPool<OtpApiDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("Default")));
        }
    }
}
