using Microsoft.EntityFrameworkCore;
using ScrumProject.Domain.Releases;

namespace ScrumProject.Persistence.Repositories;

public class ReleaseRepository : IReleaseRepository
{
    private readonly DbSet<Release> _releases;
    public ReleaseRepository(ScrumDbContext context)
    {
        _releases = context.Releases;
    }

    public async Task AddAsync(Release release, CancellationToken cancellationToken)
    {
        await _releases.AddAsync(release,cancellationToken);
    }

    public void Delete(Release release)
    {
        _releases.Remove(release);
    }

    public Task<Release> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return _releases.SingleOrDefaultAsync(release => release.Id == id, cancellationToken);
    }
}