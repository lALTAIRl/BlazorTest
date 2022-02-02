namespace BlazorTest.Orders.Persistence
{
    using BlazorTest.Orders.Application.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlazorTestOrdersDbContext>(options =>
            {

                options.UseSqlServer(
                        configuration["OrdersConnection"],
                        b => b.MigrationsAssembly(typeof(BlazorTestOrdersDbContext).Assembly.FullName));

                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });


            services.AddScoped<IBlazorTestOrdersDbContext>(provider => provider.GetService<BlazorTestOrdersDbContext>());

            return services;
        }
    }
}
