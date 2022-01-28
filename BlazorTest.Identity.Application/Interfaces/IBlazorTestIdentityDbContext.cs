using BlazorTest.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorTest.Identity.Application.Interfaces
{
    public interface IBlazorTestIdentityDbContext
    {
        DbSet<ApplicationUser> Users
        {
            get; set;
        }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
