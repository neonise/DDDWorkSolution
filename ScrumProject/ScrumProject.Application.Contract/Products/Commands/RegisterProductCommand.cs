using MediatR;

namespace ScrumProject.Application.Contract.Products.Commands;

public class RegisterProductCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime DeadlineDate { get; set; }
}
