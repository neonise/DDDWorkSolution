using Library.Domain;
using ScrumProject.Domain.Releases.ValueObjects;
namespace ScrumProject.Domain.BackLogs;

public class BackLog : AggregateRoot<Guid>
{
    public BackLogTitle Title { get; private set; }
    public string Description { get; private set; }
    public Guid SprintId { get; private set; }

    private BackLog()
    {
        //ForEF
    }

    private BackLog(Guid sprintId, BackLogTitle backLogTitle, string description)
    {
        Title = backLogTitle;
        SprintId = sprintId;
        Description = description;
        Id = Guid.NewGuid();
        //AddEvent(new BackLogCreatedEvent(sprint, this));
    }

    public static BackLog CreateNew(Guid sprintId, string title, string description)
    {
        return new BackLog(sprintId, new BackLogTitle(title), description);
    }
}
