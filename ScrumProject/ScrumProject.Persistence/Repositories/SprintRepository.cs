using ScrumProject.Domain.Sprints;

namespace ScrumProject.Persistence.Repositories;

public class SprintRepository : ISprintRepository
{
    private static readonly List<Sprint> Sprints = new();

    public bool ExistByReleaseId(Guid releaseId)
    {
        return Sprints.Any(x => x.ReleaseId == releaseId);
    }

    public Sprint Get(Guid id)
    {
        return Sprints.SingleOrDefault(x => x.Id == id);
    }

    public void Insert(Sprint sprint)
    {
        Sprints.Add(sprint);
    }
}
