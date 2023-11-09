using MediatR;

namespace ScrumProject.Application.Contract.Releases.Commands;

public class RemoveReleaseCommand : IRequest<Guid>
{
    public Guid ReleaseId { get; set; }
}
