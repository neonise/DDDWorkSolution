using Library.Domain;
using ScrumProject.Domain.Products.Entities;
using ScrumProject.Domain.Products.Events;
using ScrumProject.Domain.Products.Exceptions;
using ScrumProject.Domain.Products.ValueObjects;
using System.Text.Json;

namespace ScrumProject.Domain.Products;

public class Product : AggregateRoot<int>
{
    private List<Release> _releases = new();
    public ProductTitle ProductTitle { get; init; }
    public DateTime CreateDate { get; init; }
    public DateTime DeadlineDate { get; init; }
    public IReadOnlyCollection<Release> Releases => _releases;

    public Product(ProductTitle productTitle, DateTime createDate, DateTime deadlineDate)
    {
        ProductTitle = productTitle;
        CreateDate = createDate;
        DeadlineDate = deadlineDate;
        Id = _releases.Any() ? _releases.Max(x => x.Id) + 1 : 1;
    }

    //Is it Ok To Pass An Release Object Directly???
    public void AddNewRelease(string releaseTitle)
    {
        CheckRule(releaseTitle);

        var release = new Release(releaseTitle, DateTime.Now);
        _releases.Add(release);
        AddEvent(new ReleaseCreatedEvent(this, release));
    }

    private void CheckRule(string releaseTitle)
    {
        if (_releases.Any(x => x.Title.Equals(releaseTitle)))
            throw new ReleaseDuplicateTitleException();
    }

    public override string ToString()
    {
        var option = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        return JsonSerializer.Serialize(this, option);
    }
}