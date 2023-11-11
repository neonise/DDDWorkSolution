using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScrumProject.Domain.BackLogs.Entities;

namespace ScrumProject.Persistence.Configurations;

public class BackLogCommentConfiguration : IEntityTypeConfiguration<BackLogComment>
{
    public void Configure(EntityTypeBuilder<BackLogComment> builder)
    {
        builder.Property(bc => bc.CommentText)
             .HasColumnType("nvarchar(1024)")
             .IsRequired();

        builder.Property(bc => bc.CommentDate)
           .IsRequired();
    }
}
