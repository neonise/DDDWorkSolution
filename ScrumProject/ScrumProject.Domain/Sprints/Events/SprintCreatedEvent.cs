using Library.Domain;
using MediatR;
using ScrumProject.Domain.Releases;
namespace ScrumProject.Domain.Sprints.Events;

public class SprintCreatedEvent : IDomainEvent, INotification
{
    public Sprint Sprint { get; init; }
    public Release Release { get; init; }
    public SprintCreatedEvent(Sprint sprint, Release release)
    {
        Sprint = sprint;
        Release = release;
    }
}
