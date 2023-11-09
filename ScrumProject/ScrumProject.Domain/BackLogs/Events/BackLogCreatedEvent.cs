using Library.Domain;
using MediatR;
using ScrumProject.Domain.Sprints;

namespace ScrumProject.Domain.BackLogs.Events;
public class BackLogCreatedEvent : IDomainEvent, INotification
{
    public Sprint Sprint { get; set; }
    public BackLog BackLog { get; set; }
    public BackLogCreatedEvent(Sprint sprint, BackLog backLog)
    {
        Sprint = sprint;
        BackLog = backLog;
    }
}