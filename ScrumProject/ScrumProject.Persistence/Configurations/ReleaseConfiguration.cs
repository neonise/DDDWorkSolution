using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScrumProject.Domain.Releases;
using ScrumProject.Domain.Releases.ValueObjects;

namespace ScrumProject.Persistence.Configurations;

public class ReleaseConfiguration : IEntityTypeConfiguration<Release>
{
    public void Configure(EntityTypeBuilder<Release> builder)
    {
        builder.Property(r => r.Title)
            .HasColumnType("nvarchar(512)")
            .IsRequired()
            .HasConversion(title => title.Value, value => new ReleaseTitle(value));

        builder.Property(r => r.ReleaseDate)
            .IsRequired();
    }
}