using ScrumProject.Domain.BackLogs;

namespace ScrumProject.Persistence.Repositories;

public class BackLogRepository : IBackLogRepository
{
    private static readonly List<BackLog> BackLogs = new();

    public BackLog Get(Guid id)
    {
        return BackLogs.SingleOrDefault(x => x.Id == id);
    }

    public void Insert(BackLog backLog)
    {
        BackLogs.Add(backLog);
    }
}
