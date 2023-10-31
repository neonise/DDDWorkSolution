using Library.Domain;
using ScrumProject.Domain.Products.Exceptions;

namespace ScrumProject.Domain.Products;

public class Release : Entity<int>
{
    private List<Sprint> _sprints = new();
    public string Title { get; init; }
    public DateTime ReleaseDate { get; init; }
    public IReadOnlyCollection<Sprint> Sprints => _sprints;

    public Release(string title, DateTime releaseDate)
    {
        Title = title;
        ReleaseDate = releaseDate;
    }

    public void AddNewSprint(string sprintTitle, DateTime fromDate, DateTime toDate)
    {
        CheckRule(sprintTitle, fromDate, toDate);
        _sprints.Add(new Sprint(sprintTitle, fromDate, toDate));
    }

    private void CheckRule(string sprintTitle, DateTime fromDate, DateTime toDate)
    {
        if (_sprints.Any(x => x.Title.Equals(sprintTitle)))
            throw new ReleaseDuplicateTitleException();

        if (_sprints.Any(x => x.FromDate == fromDate && x.ToDate == toDate))
            throw new SprintInvalidDateException();
    }
}
