using Microsoft.EntityFrameworkCore;
using ScrumProject.Domain.Sprints;

namespace ScrumProject.Persistence.Repositories;

public class SprintRepository : ISprintRepository
{
    private readonly DbSet<Sprint> _sprints;
    public SprintRepository(ScrumDbContext context)
    {
        _sprints = context.Sprints;
    }

    public async Task AddAsync(Sprint sprint, CancellationToken cancellationToken)
    {
        await _sprints.AddAsync(sprint,cancellationToken);
    }

    public Task<bool> ExistByReleaseIdAsync(Guid releaseId, CancellationToken cancellationToken)
    {
        return _sprints.AnyAsync(x => x.ReleaseId == releaseId, cancellationToken);
    }

    public Task<Sprint> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return _sprints.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}