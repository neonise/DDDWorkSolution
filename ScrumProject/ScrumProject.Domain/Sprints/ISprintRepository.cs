namespace ScrumProject.Domain.Sprints;

public interface ISprintRepository
{
    Task AddAsync(Sprint sprint,CancellationToken cancellationToken);
    Task<Sprint> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistByReleaseIdAsync(Guid releaseId,CancellationToken cancellationToken);
}
