using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.AspNetCore.Identity;
using CustomerAPI.CustomerAPI.Commons.Extensions;
using CustomerAPI.CustomerAPI.Services.Interfaces;
using CustomerAPI.CustomerAPI.Models;
using CustomerAPI.CustomerAPI.Services.Implementations;
using CustomerAPI.CustomerAPI.Data;
using MassTransit.MultiBus;
using MassTransit;

namespace CustomerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMassTransit(x => {
                x.UsingRabbitMq((ctx, config) =>
                {
                    config.Host("amqp://guest:guest@localhost:5672");
                });
            });
            //services.AddMassTransitHostedService();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IHttpGenericFactory, HttpGenericFactory>();
            services.AddTransient<IBankService, BankService>();
            services.AddHttpClient();


            services.AddDbContextExtension(Configuration, _env);
            services.AddControllers();
            services.AddIdentity<Customer, IdentityRole>().AddEntityFrameworkStores<CustomerAPIDbContext>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Onboarding_MicroserviceAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Onboarding_MicroserviceAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
