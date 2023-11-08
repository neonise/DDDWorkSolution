namespace ScrumProject.Domain.Sprints;

public interface ISprintRepository
{
    void Insert(Sprint sprint);
    Sprint Get(Guid id);
}
