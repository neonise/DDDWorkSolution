namespace ScrumProject.Domain.Releases;
public interface IReleaseRepository
{
    void Insert(Release release);
    Release Get(Guid id);
}
