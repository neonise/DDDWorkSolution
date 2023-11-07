using Library.Domain;
using MediatR;
using ScrumProject.Domain.Releases;

namespace ScrumProject.Domain.Products.Events;
public class ReleaseCreatedEvent : IDomainEvent, INotification
{
    public Product Product { get; init; }
    public Release Release { get; init; }

    public ReleaseCreatedEvent(Product product, Release release)
    {
        Product = product;
        Release = release;
    }
}
