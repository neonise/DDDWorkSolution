using MediatR;
using ScrumProject.Domain.Products.Events;

namespace ScrumProject.Application.Products.EventHandlers;
public class ReleaseCreatedEventHandler : INotificationHandler<ReleaseCreatedEvent>
{
    public Task Handle(ReleaseCreatedEvent notification, CancellationToken cancellationToken)
    {
        //How can save release
        throw new NotImplementedException();
    }
}
