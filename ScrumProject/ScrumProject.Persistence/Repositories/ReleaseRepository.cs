using ScrumProject.Domain.Products;
using ScrumProject.Domain.Products.ValueObjects;
using ScrumProject.Domain.Releases;
using ScrumProject.Domain.Releases.ValueObjects;

namespace ScrumProject.Persistence.Repositories;

public class ReleaseRepository : IReleaseRepository
{
    private static readonly List<Release> Releases = new()
    {
       Release.CreateNew(new Product(new ProductTitle("OMS"),DateTime.Now,DateTime.Now.AddDays(21)),new ReleaseTitle("release1"),DateTime.Now),
       Release.CreateNew(new Product(new ProductTitle("OMS"),DateTime.Now,DateTime.Now.AddDays(21)),new ReleaseTitle("release2"),DateTime.Now)
    };

    public Release Get(Guid id)
    {
        return Releases.SingleOrDefault(x => x.Id == id);
    }

    public void Insert(Release release)
    {
        Releases.Add(release);
    }
}
