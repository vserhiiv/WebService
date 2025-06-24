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

        builder.Property(pi => pi.Quantity)
            .IsRequired();

        builder.Property(pi => pi.UnitPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

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
