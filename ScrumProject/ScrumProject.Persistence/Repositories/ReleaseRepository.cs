using Microsoft.EntityFrameworkCore;
using ScrumProject.Domain.Releases;

namespace ScrumProject.Persistence.Repositories;

public class ReleaseRepository : IReleaseRepository
{
    private readonly ScrumDbContext _context;
    private readonly DbSet<Release> _releases;
    public ReleaseRepository(ScrumDbContext context)
    {
        _context = context;
        _releases = context.Releases;
    }

    public void Delete(Release release)
    {
        _releases.Remove(release);
        _context.SaveChanges();
    }

    public Task<Release> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return _releases.SingleOrDefaultAsync(release => release.Id == id, cancellationToken);
    }

    public void Insert(Release release)
    {
        _releases.Add(release);
        _context.SaveChanges();
    }
}
