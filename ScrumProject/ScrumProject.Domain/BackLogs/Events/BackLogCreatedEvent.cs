using Library.Domain;
using MediatR;
using ScrumProject.Domain.Sprints;

namespace ScrumProject.Domain.BackLogs.Events;
public class BackLogCreatedEvent : IDomainEvent, INotification
{
    public Sprint Sprint { get; init; }
    public BackLog BackLog { get; init; }
    public BackLogCreatedEvent(Sprint sprint, BackLog backLog)
    {
        Sprint = sprint;
        BackLog = backLog;
    }
}