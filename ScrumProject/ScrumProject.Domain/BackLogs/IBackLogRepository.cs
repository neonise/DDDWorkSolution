namespace ScrumProject.Domain.BackLogs;

public interface IBackLogRepository
{
    Task AddAsync(BackLog backLog,CancellationToken cancellationToken);
    Task<BackLog> GetAsync(Guid id, CancellationToken cancellationToken);
}
