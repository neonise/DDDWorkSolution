using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScrumProject.Domain.Releases.ValueObjects;
using ScrumProject.Domain.Sprints;
namespace ScrumProject.Persistence.Configurations;

public class SprintConfiguration : IEntityTypeConfiguration<Sprint>
{
    public void Configure(EntityTypeBuilder<Sprint> builder)
    {
        builder.Property(s => s.Title)
       .HasColumnType("nvarchar(512)")
       .IsRequired()
       .HasConversion(title => title.Value, value => new SprintTitle(value));

        builder.Property(s => s.FromDate)
            .IsRequired();

        builder.Property(s => s.ToDate)
            .IsRequired();
    }
}
