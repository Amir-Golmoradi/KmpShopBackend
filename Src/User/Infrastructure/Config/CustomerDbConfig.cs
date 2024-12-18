using KmpShopBackend.Customer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KmpShopBackend.Customer.Infrastructure.persistance;

public class CustomerDbConfig : IEntityTypeConfiguration<Domain.Customer>
{
    public void Configure(EntityTypeBuilder<Domain.Customer> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(70);

        builder.Property(b => b.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(b => b.Password)
            .IsRequired();

        builder.Property(b => b.CreatedAt)
            .HasDefaultValueSql("NOW()");

        builder.Property(b => b.UpdatedAt)
            .HasDefaultValueSql("NOW()");

        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}