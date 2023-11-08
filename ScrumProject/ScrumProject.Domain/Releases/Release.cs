using Library.Domain;
using ScrumProject.Domain.Products;
using ScrumProject.Domain.Releases.Events;
using ScrumProject.Domain.Releases.ValueObjects;

namespace ScrumProject.Domain.Releases;
public class Release : AggregateRoot<Guid>
{
    public ReleaseTitle Title { get; init; }
    public DateTime ReleaseDate { get; init; }
    private Release(Product product, ReleaseTitle releaseTitle, DateTime releaseDate)
    {
        Title = releaseTitle;
        ReleaseDate = releaseDate;
        Id = Guid.NewGuid();
        AddEvent(new ReleaseCreatedEvent(product, this));
    }

    public static Release CreateNew(Product product, ReleaseTitle releaseTitle, DateTime releaseDate)
    {
        return new Release(product, releaseTitle, releaseDate);
    }
}
