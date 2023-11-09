using ScrumProject.Domain.Releases;

namespace ScrumProject.Persistence.Repositories;

public class ReleaseRepository : IReleaseRepository
{
    private static readonly List<Release> Releases = new();

    public void Delete(Release release)
    {
        Releases.Remove(release);
    }

    public Release Get(Guid id)
    {
        return Releases.SingleOrDefault(x => x.Id == id);
    }

    public void Insert(Release release)
    {
        Releases.Add(release);
    }
}
