using Library.Domain;
using ScrumProject.Domain.Products.Exceptions;
using ScrumProject.Domain.Releases.ValueObjects;

namespace ScrumProject.Domain.Sprints;
public class Sprint : AggregateRoot<Guid>
{
    public SprintTitle Title { get; private set; }
    public DateTime ToDate { get; private set; }
    public DateTime FromDate { get; private set; }
    public Guid ReleaseId { get; private set; }
    private Sprint()
    {
        //ForEF
    }
    private Sprint(Guid releaseId, SprintTitle sprintTitle, DateTime fromDate, DateTime toDate)
    {
        ReleaseId = releaseId;
        Title = sprintTitle;
        FromDate = fromDate;
        ToDate = toDate;
        Id = Guid.NewGuid();
        //AddEvent(new SprintCreatedEvent(this, release));
    }

    public static Sprint CreateNew(Guid releaseId, string title, DateTime fromDate, DateTime toDate)
    {
        CheckRule(fromDate, toDate);
        return new Sprint(releaseId, new SprintTitle(title), fromDate, toDate);
    }

    private static void CheckRule(DateTime fromDate, DateTime toDate)
    {
        if (fromDate.Equals(toDate))
            throw new InvalidIntervalDateException();
    }
}
