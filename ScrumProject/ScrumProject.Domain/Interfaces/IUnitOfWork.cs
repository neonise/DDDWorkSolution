namespace ScrumProject.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<bool> CommitAsync(CancellationToken cancellationToken);
    Task RollbackAsync(CancellationToken cancellationToken);
}
