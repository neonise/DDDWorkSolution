using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScrumProject.Domain.Products;
using ScrumProject.Domain.Products.ValueObjects;

namespace ScrumProject.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Title)
             .HasColumnType("nvarchar(512)")
             .IsRequired()
             .HasConversion(title => title.Value, value => new ProductTitle(value));

        builder.Property(p => p.CreateDate)
            .IsRequired();

        builder.Property(p => p.DeadlineDate)
            .IsRequired();
    }
}
