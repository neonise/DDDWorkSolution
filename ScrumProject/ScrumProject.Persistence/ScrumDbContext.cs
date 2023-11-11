using Microsoft.EntityFrameworkCore;
using ScrumProject.Domain.BackLogs;
using ScrumProject.Domain.Products;
using ScrumProject.Domain.Releases;
using ScrumProject.Domain.Sprints;
using System.Reflection;

namespace ScrumProject.Persistence;
public class ScrumDbContext : DbContext
{
    public ScrumDbContext(DbContextOptions<ScrumDbContext> options)
      : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Release> Releases { get; set; }
    public DbSet<Sprint> Sprints { get; set; }
    public DbSet<BackLog> BackLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
