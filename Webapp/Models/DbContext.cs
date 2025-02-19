using Microsoft.EntityFrameworkCore;

namespace homework_7_oscardavila09.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductOrder>().HasKey(s => new {s.OrderID, s.ProductID});
    }

    public DbSet<Product> Products {get; set;}
    public DbSet<Order> Orders {get; set;}
    public DbSet<ProductOrder> ProductOrders {get; set;}
}