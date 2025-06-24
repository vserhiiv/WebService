using Domain.Aggregates.Purchase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Purchase;

public class PurchaseItemConfiguration : IEntityTypeConfiguration<PurchaseItemAggregate>
{
    public void Configure(EntityTypeBuilder<PurchaseItemAggregate> builder)
    {
        builder.ToTable("PurchaseItems");

        builder.HasKey(pi => pi.Id);

        builder.Property(pi => pi.Id)
            .HasColumnName("id");

        builder.Property(pi => pi.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder.Property(pi => pi.UnitPrice)
            .HasColumnName("unit_price")
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(pi => pi.ProductId)
            .HasColumnName("product_id");

        builder.Property(pi => pi.PurchaseId)
            .HasColumnName("purchase_id");

        builder.HasOne(pi => pi.Purchase)
            .WithMany(p => p.Items)
            .HasForeignKey(pi => pi.PurchaseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pi => pi.Product)
            .WithMany(p => p.PurchaseItems)
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
