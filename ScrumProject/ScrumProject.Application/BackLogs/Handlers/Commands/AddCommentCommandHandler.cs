using MediatR;
using ScrumProject.Application.Contract.BackLogs.Commands;
using ScrumProject.Domain.BackLogs;

namespace ScrumProject.Application.BackLogs.Handlers.Commands;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, Guid>
{
    private readonly IBackLogRepository _backLogRepository;

    public AddCommentCommandHandler(IBackLogRepository backLogRepository)
    {
        _backLogRepository = backLogRepository;
    }

    public async Task<Guid> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var backLog = await _backLogRepository.GetAsync(request.BackLogId, cancellationToken);
        backLog.AddComment(request.CommentText);
        await _backLogRepository.CommitAsync(cancellationToken);
        return backLog.Id;
    }
}
