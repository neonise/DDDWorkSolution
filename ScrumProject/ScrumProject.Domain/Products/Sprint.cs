using Library.Domain;

namespace ScrumProject.Domain.Products;

public class Sprint : Entity<int>
{
    private readonly HashSet<BackLog> _backLogs = new();
    public string Title { get; init; }
    public DateTime ToDate { get; init; }
    public DateTime FromDate { get; init; }
    public IReadOnlyCollection<BackLog> BackLogs => _backLogs;

    public Sprint(string title, DateTime fromDate, DateTime toDate)
    {
        Title = title;
        FromDate = fromDate;
        ToDate = toDate;
    }

    public void AddNewBackLog(BackLog backLog)
    {
        _backLogs.Add(backLog);
    }
}
