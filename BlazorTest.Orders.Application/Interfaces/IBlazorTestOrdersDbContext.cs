namespace BlazorTest.Orders.Application.Interfaces
{
    using System.Threading.Tasks;
    using BlazorTest.Orders.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IBlazorTestOrdersDbContext
    {
        DbSet<Order> Orders
        {
            get; set;
        }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
