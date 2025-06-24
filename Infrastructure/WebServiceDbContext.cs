using Domain.Aggregates.Client;
using Domain.Aggregates.Product;
using Domain.Aggregates.Purchase;
using Infrastructure.Configurations.Client;
using Infrastructure.Configurations.Product;
using Infrastructure.Configurations.Purchase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class WebServiceDbContext : DbContext
{
    WebServiceDbContext(
        DbContextOptions<WebServiceDbContext> options
        ) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<ClientAggregate> Clients { get; set; } = null!;
    public DbSet<ProductAggregate> Products { get; set; } = null!;
    public DbSet<PurchaseAggregate> Purchases { get; set; } = null!;
    public DbSet<PurchaseItemAggregate> PurchaseItems { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseItemConfiguration());
    }
}
