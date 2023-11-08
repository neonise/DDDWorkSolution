using Library.Domain;
using ScrumProject.Domain.BackLogs.Events;
using ScrumProject.Domain.Releases.ValueObjects;
using ScrumProject.Domain.Sprints;
namespace ScrumProject.Domain.BackLogs;

public class BackLog : AggregateRoot<Guid>
{
    public BackLogTitle Title { get; init; }
    public string Description { get; init; }
    public int MemberId { get; private set; }
    private BackLog(Sprint sprint, BackLogTitle backLogTitle, string description)
    {
        Title = backLogTitle;
        Description = description;
        Id = Guid.NewGuid();
        AddEvent(new BackLogCreatedEvent(sprint, this));
    }

    public static BackLog CreateNew(Sprint sprint, BackLogTitle backLogTitle, string description)
    {
        return new BackLog(sprint, backLogTitle, description);
    }

    public void AssignTo(int memberId)
    {
        MemberId = memberId;
    }
}
