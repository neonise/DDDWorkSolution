using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScrumProject.Domain.BackLogs;
using ScrumProject.Domain.Releases.ValueObjects;
namespace ScrumProject.Persistence.Configurations;

public class BacklogConfiguration : IEntityTypeConfiguration<BackLog>
{
    public void Configure(EntityTypeBuilder<BackLog> builder)
    {
        builder.Property(bc => bc.Title)
          .HasColumnType("nvarchar(512)")
          .IsRequired()
          .HasConversion(title => title.Value, value => new BackLogTitle(value));

        builder.Property(bc => bc.Description)
             .HasColumnType("nvarchar(1024)")
             .IsRequired();
    }
}
