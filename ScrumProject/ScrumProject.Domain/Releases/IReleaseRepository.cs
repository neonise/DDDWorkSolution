namespace ScrumProject.Domain.Releases;
public interface IReleaseRepository
{
    void Insert(Release release);
    Task<Release> GetAsync(Guid id,CancellationToken cancellationToken);
    void Delete(Release release);
}
