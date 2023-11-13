using Microsoft.EntityFrameworkCore;
using ScrumProject.Domain.BackLogs;

namespace ScrumProject.Persistence.Repositories;

public class BackLogRepository : IBackLogRepository
{
    private readonly DbSet<BackLog> _backLogs;
    public BackLogRepository(ScrumDbContext context)
    {
        _backLogs = context.BackLogs;
    }

    public async Task AddAsync(BackLog backLog, CancellationToken cancellationToken)
    {
        await _backLogs.AddAsync(backLog,cancellationToken);
    }

    public Task<BackLog> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return _backLogs
            .Include(x => x.BackLogComments)
            .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}
