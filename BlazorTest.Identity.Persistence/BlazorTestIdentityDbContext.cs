using BlazorTest.Identity.Application.Interfaces;
using BlazorTest.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlazorTest.Identity.Persistence
{
    internal class BlazorTestIdentityDbContext : DbContext, IBlazorTestIdentityDbContext
    {
        public BlazorTestIdentityDbContext(DbContextOptions<BlazorTestIdentityDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> Users 
        { 
            get ; set;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
