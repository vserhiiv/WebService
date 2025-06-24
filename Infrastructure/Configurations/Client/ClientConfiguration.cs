using Domain.Aggregates.Client;
using Domain.Aggregates.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Client;

public class ClientConfiguration : IEntityTypeConfiguration<ClientAggregate>
{
    public void Configure(EntityTypeBuilder<ClientAggregate> builder)
    {
        builder.ToTable("Clients");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id");

        builder.Property(p => p.FirstName)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.SecondName)
            .HasColumnName("second_name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.LastName)
            .HasColumnName("last_name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.BirthDate)
            .HasColumnName("birth_date");

        builder.Property(p => p.RegistrationDate)
            .HasColumnName("registration_date");

        builder.HasMany(c => c.Purchases)
            .WithOne(p => p.Client)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
