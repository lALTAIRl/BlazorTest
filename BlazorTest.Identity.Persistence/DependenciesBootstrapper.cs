using BlazorTest.Identity.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorTest.Identity.Persistence
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlazorTestIdentityDbContext>(options =>
            {

                options.UseSqlServer(
                        configuration["IdentityConnection"],
                        b => b.MigrationsAssembly(typeof(BlazorTestIdentityDbContext).Assembly.FullName));

                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });


            services.AddScoped<IBlazorTestIdentityDbContext>(provider => provider.GetService<BlazorTestIdentityDbContext>());

            return services;
        }
    }
}
