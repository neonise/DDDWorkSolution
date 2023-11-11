using MediatR;

namespace ScrumProject.Application.Contract.BackLogs.Commands;

public class RemoveCommentCommand : IRequest
{
    public Guid BackLogId { get; set; }
    public Guid BackLogCommentId { get; set; }
}
