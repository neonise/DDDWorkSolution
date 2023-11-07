using Library.Domain;

namespace ScrumProject.Domain.BackLogs;

public class BackLog : AggregateRoot<int>
{
    public string Title { get; init; }
    public string Description { get; init; }
    public int? MemberId { get; private set; }

    public BackLog(string title, string description, int? memberId = null)
    {
        Title = title;
        Description = description;
        if (memberId.HasValue)
            AssignTo(memberId.Value);
    }

    public void AssignTo(int memberId)
    {
        MemberId = memberId;
    }
}
