using MarketingBtrl.DAL.Repositories;
using MarketingBtrl.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MarketingBtrl.Services;
using MarketingBtrl.Services.Interfaces;

namespace MarketingBtrl.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<RepositoryContext>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IRemunerationService, RemunerationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRetailerService, RetailerService>();

        }

        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("_allowSpecificOrigins",
                builder =>
                {
                    //builder.AllowAnyOrigin();
                    builder.WithOrigins(configuration["CorsOrigins"])
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyHeader();
                });
            });
        }
    }
}
