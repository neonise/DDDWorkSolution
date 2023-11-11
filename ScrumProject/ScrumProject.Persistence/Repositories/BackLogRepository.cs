using Microsoft.EntityFrameworkCore;
using ScrumProject.Domain.BackLogs;

namespace ScrumProject.Persistence.Repositories;

public class BackLogRepository : IBackLogRepository
{
    private readonly ScrumDbContext _context;
    private readonly DbSet<BackLog> _backLogs;
    public BackLogRepository(ScrumDbContext context)
    {
        _context = context;
        _backLogs = context.BackLogs;
    }

    public Task<BackLog> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return _backLogs
            .Include(x => x.BackLogComments)
            .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public void Insert(BackLog backLog)
    {
        _backLogs.Add(backLog);
        _context.SaveChanges();
    }

    public Task CommitAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
