namespace ScrumProject.Domain.BackLogs;

public interface IBackLogRepository
{
    void Insert(BackLog backLog);
    BackLog Get(Guid id);
}
