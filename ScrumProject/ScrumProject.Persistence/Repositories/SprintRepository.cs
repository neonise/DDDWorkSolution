using Microsoft.EntityFrameworkCore;
using ScrumProject.Domain.Sprints;

namespace ScrumProject.Persistence.Repositories;

public class SprintRepository : ISprintRepository
{
    private readonly ScrumDbContext _context;
    private readonly DbSet<Sprint> _sprints;
    public SprintRepository(ScrumDbContext context)
    {
        _context = context;
        _sprints = context.Sprints;
    }

    public Task<bool> ExistByReleaseIdAsync(Guid releaseId, CancellationToken cancellationToken)
    {
        return _sprints.AnyAsync(x => x.ReleaseId == releaseId, cancellationToken);
    }

    public Task<Sprint> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return _sprints.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public void Insert(Sprint sprint)
    {
        _sprints.Add(sprint);
        _context.SaveChanges();
    }
}
