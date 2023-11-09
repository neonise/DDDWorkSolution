using Library.Domain;
using MediatR;
using ScrumProject.Domain.Products;

namespace ScrumProject.Domain.Releases.Events;
public class ReleaseCreatedEvent : IDomainEvent, INotification
{
    public Product Product { get; set; }
    public Release Release { get; set; }
    public ReleaseCreatedEvent(Product product, Release release)
    {
        Product = product;
        Release = release;
    }
}
