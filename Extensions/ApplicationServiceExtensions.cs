using ASP.NETCoreWebApplication.Data;
using ASP.NETCoreWebApplication.Interfaces;
using ASP.NETCoreWebApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NETCoreWebApplication.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}