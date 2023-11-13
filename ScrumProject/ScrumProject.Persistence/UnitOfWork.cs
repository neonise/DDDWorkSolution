using ScrumProject.Domain.Interfaces;

namespace ScrumProject.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ScrumDbContext _context;
    public UnitOfWork(ScrumDbContext context) =>
        _context = context;

    public async Task<bool> CommitAsync(CancellationToken cancellationToken)
    {
        return (await _context.SaveChangesAsync(cancellationToken)) > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task RollbackAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
