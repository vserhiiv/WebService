using Domain.Aggregates.Purchase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Purchase;

public class PurchaseConfiguration : IEntityTypeConfiguration<PurchaseAggregate>
{
    public void Configure(EntityTypeBuilder<PurchaseAggregate> builder)
    {
        builder.ToTable("Purchases");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).
            HasColumnName("id");

        builder.Property(p => p.Number)
            .HasColumnName("number")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Date)
            .HasColumnName("date")
            .IsRequired();

        builder.Property(p => p.TotalAmount)
            .HasColumnName("total_amount")
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.HasOne(p => p.Client)
            .WithMany(c => c.Purchases)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
