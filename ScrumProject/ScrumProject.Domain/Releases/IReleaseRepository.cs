namespace ScrumProject.Domain.Releases;
public interface IReleaseRepository
{
    Task AddAsync(Release release,CancellationToken cancellationToken);
    Task<Release> GetAsync(Guid id,CancellationToken cancellationToken);
    void Delete(Release release);
}
