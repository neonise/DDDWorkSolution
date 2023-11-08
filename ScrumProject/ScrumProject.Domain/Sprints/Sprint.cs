using Library.Domain;
using ScrumProject.Domain.Products.Exceptions;
using ScrumProject.Domain.Releases;
using ScrumProject.Domain.Releases.ValueObjects;
using ScrumProject.Domain.Sprints.Events;

namespace ScrumProject.Domain.Sprints;
public class Sprint : AggregateRoot<Guid>
{
    public SprintTitle Title { get; init; }
    public DateTime ToDate { get; init; }
    public DateTime FromDate { get; init; }
    private Sprint(Release release, SprintTitle sprintTitle, DateTime fromDate, DateTime toDate)
    {
        CheckRule(fromDate, toDate);
        Title = sprintTitle;
        FromDate = fromDate;
        ToDate = toDate;
        Id = Guid.NewGuid();
        AddEvent(new SprintCreatedEvent(this, release));
    }

    public static Sprint CreateNew(Release release, SprintTitle sprintTitle, DateTime fromDate, DateTime toDate)
    {
        return new Sprint(release, sprintTitle, fromDate, toDate);
    }

    private static void CheckRule(DateTime fromDate, DateTime toDate)
    {
        if (fromDate.Equals(toDate))
            throw new InvalidIntervalDateException();
    }
}
