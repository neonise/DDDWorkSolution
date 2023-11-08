using MediatR;

namespace ScrumProject.Application.Contract.Releases.Commands;

public class RegisterReleaseCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public Guid ProductId { get; set; }
}
