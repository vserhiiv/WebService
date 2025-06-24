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
    public WebServiceDbContext(
        DbContextOptions<WebServiceDbContext> options
        ) : base(options)
    {
        Database.Migrate();
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

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ClientAggregate>().HasData(
            new ClientAggregate { Id = 1, FirstName = "Гаррі", SecondName = "Джеймсевіч", LastName = "Потеренко", BirthDate = new DateOnly(1980, 7, 31), RegistrationDate = new DateTime(2024, 1, 1).ToUniversalTime() },
            new ClientAggregate { Id = 2, FirstName = "Драко", SecondName = "Луціюсевіч", LastName = "Малфоєнко", BirthDate = new DateOnly(1980, 6, 5), RegistrationDate = new DateTime(2024, 2, 2).ToUniversalTime() }
        );

        modelBuilder.Entity<ProductAggregate>().HasData(
            new ProductAggregate { Id = 1, Name = "Laptop Lenovo", Category = Domain.Enums.CategoryEnum.Laptops, SKU = "SKU123", Price = 2500m },
            new ProductAggregate { Id = 2, Name = "CellPhone Samsung", Category = Domain.Enums.CategoryEnum.CellPhones, SKU = "SKU456", Price = 1800m },
            new ProductAggregate { Id = 3, Name = "Ipad", Category = Domain.Enums.CategoryEnum.Tablets, SKU = "M4", Price = 2000m }
        );

        modelBuilder.Entity<PurchaseAggregate>().HasData(
            new PurchaseAggregate { Id = 1, Number = "0503002010", Date = new DateTime(2025, 6, 10).ToUniversalTime(), TotalAmount = 3500m, ClientId = 1 },
            new PurchaseAggregate { Id = 2, Number = "0503002011", Date = new DateTime(2025, 6, 20).ToUniversalTime(), TotalAmount = 2000m, ClientId = 2 }
        );

        modelBuilder.Entity<PurchaseItemAggregate>().HasData(
            new PurchaseItemAggregate { Id = 1, PurchaseId = 1, ProductId = 1, Quantity = 1, UnitPrice = 2500m },
            new PurchaseItemAggregate { Id = 2, PurchaseId = 1, ProductId = 2, Quantity = 1, UnitPrice = 1000m },
            new PurchaseItemAggregate { Id = 3, PurchaseId = 2, ProductId = 3, Quantity = 1, UnitPrice = 2000m }
        );
    }
}
