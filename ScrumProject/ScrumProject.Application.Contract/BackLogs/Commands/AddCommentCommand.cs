using MediatR;

namespace ScrumProject.Application.Contract.BackLogs.Commands;

public class AddCommentCommand : IRequest<Guid>
{
    public Guid BackLogId { get; set; }
    public string CommentText { get; set; }
}
