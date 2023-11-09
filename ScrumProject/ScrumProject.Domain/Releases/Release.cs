using Library.Domain;
using ScrumProject.Domain.Releases.ValueObjects;

namespace ScrumProject.Domain.Releases;
public class Release : AggregateRoot<Guid>
{
    public Guid ProductId { get; private set; }
    public ReleaseTitle Title { get; private set; }
    public DateTime ReleaseDate { get; private set; }

    private Release(Guid productId, ReleaseTitle releaseTitle, DateTime releaseDate)
    {
        Title = releaseTitle;
        ProductId = productId;
        ReleaseDate = releaseDate;
        Id = Guid.NewGuid();
        //AddEvent(new ReleaseCreatedEvent(product, this));
    }

    public static Release CreateNew(Guid productId, ReleaseTitle releaseTitle, DateTime releaseDate)
    {
        var release = new Release(productId, releaseTitle, releaseDate);
        //seccond approach for raising event
        //release.AddEvent(new ReleaseCreatedEvent(product, release));
        return release;
    }
}
