namespace ScrumProject.Domain.Sprints;

public interface ISprintRepository
{
    void Insert(Sprint sprint);
    Task<Sprint> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistByReleaseIdAsync(Guid releaseId,CancellationToken cancellationToken);
}
