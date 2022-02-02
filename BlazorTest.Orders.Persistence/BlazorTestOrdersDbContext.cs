namespace BlazorTest.Orders.Persistence
{
    using System.Reflection;
    using BlazorTest.Orders.Application.Interfaces;
    using BlazorTest.Orders.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    internal class BlazorTestOrdersDbContext : DbContext, IBlazorTestOrdersDbContext
    {
        public BlazorTestOrdersDbContext(DbContextOptions<BlazorTestOrdersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
