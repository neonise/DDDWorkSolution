namespace ScrumProject.Domain.BackLogs;

public interface IBackLogRepository
{
    void Insert(BackLog backLog);
    Task<BackLog> GetAsync(Guid id, CancellationToken cancellationToken);
}
