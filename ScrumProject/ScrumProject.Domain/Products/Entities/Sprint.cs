using Library.Domain;
using ScrumProject.Domain.Products.Exceptions;

namespace ScrumProject.Domain.Products.Entities;

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
        Id = _backLogs.Any() ? _backLogs.Max(x => x.Id) + 1 : 1;
    }

    public void AddNewBackLog(string backLogTitle, string backLogDescription, int? memberId = null)
    {
        CheckRule(backLogTitle);
        _backLogs.Add(new BackLog(backLogTitle,
                                  backLogDescription,
                                  memberId));
    }

    private void CheckRule(string backLogTitle)
    {
        if (_backLogs.Any(x => x.Title.Equals(backLogTitle)))
            throw new BackLogDuplicateException();
    }
}
