using Library.Domain;
using ScrumProject.Domain.Products.Exceptions;

namespace ScrumProject.Domain.Products;

public class Sprint : Entity<int>
{
    private List<BackLog> _backLogs = new();
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

    public void AddNewBackLog(string backLogTitle, string backLogDescription)
    {
        CheckRule(backLogTitle);
        _backLogs.Add(new BackLog(backLogTitle, backLogDescription));
    }

    private void CheckRule(string backLogTitle)
    {
        if (_backLogs.Any(x => x.Title.Equals(backLogTitle)))
            throw new BackLogDuplicateException();
    }
}
